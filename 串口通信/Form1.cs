using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO .Ports;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Threading;

namespace 串口通信
{
    public partial class Form1 : Form
    {
        private SerialPort comm = new SerialPort();
        private StringBuilder builder = new StringBuilder();
        private long received_count = 0;//接收计数
        private long send_count = 0;//发送计数
        private List<byte> buffer = new List<byte>(4096);//默认分配一页内存，并始终限制不允许超过 
        private byte[] binary_data_1 = new byte[9];//AA 44 05 01 02 03 04 05 EA     
            
        public Form1()
        {
            InitializeComponent();
        }
        //窗体初始化
        private void Form1_Load(object sender, EventArgs e)
        {
            //初始化下拉串口名称列表框
            string[] ports = SerialPort.GetPortNames();
            Array.Sort(ports);
            comboxPortName.Items.AddRange(ports);
            comboxPortName.SelectedIndex = comboxPortName.Items.Count > 0 ? 0 : -1;
            comboxBaudrate.SelectedIndex = comboxBaudrate.Items.IndexOf("9600");
            //初始化SerialPort对象
            comm.NewLine = "/r/n";
            comm.RtsEnable = true;//根据实际情况
            //添加事件注册
            comm.DataReceived +=comm_DataReceived;
        }

        void comm_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int n = comm.BytesToRead;//先记录下来，避免某种原因，人为的原因，操作几次之间
                                    //时间长，缓存不一致
            byte[] buf = new byte[n];//声明一个临时数组存储当前来的串口数据
            received_count += n;//增加接收计数
            comm.Read(buf, 0, n);//读取缓冲数据
            //////////////////////////////////////////////
            //<协议解析>
            bool data_1_catched = false;//缓存记录数据是否捕获到
            //1.缓存数据
            buffer.AddRange(buf);
            //2.完整性判断
            while (buffer.Count >= 4)//至少要包含（2字节头）+长度（1字节）+校验（1字节）
            {
                //2.1查找数据头
                if (buffer[0] == 0XAA && buffer[1] == 0x44)
                {
                    //2.2探测缓存数据是否有一条数据的字节，如果不够，就不用费劲的做其他验证了
                    //前面已经限定了剩余长度>=4，那我们这里一定能访问到buffer[2]这个长度
                    int len = buffer[2];//数据长度
                    //数据完整判断第一步，长度是否足够
                    //len是数据段长度，4个字节是while行注释的3部分长度
                    if (buffer.Count < len + 4) break;//数据不够的时候什么都不做
                    //这里确保数据长度足够，数据头标志找到，我们开始计算校验
                    //2.3 校验数据，确认数据正确
                    //异或校验，逐个字节异或得到校验码
                    byte checkSum = 0;
                    for (int i = 0; i < len+3; i++)//len+3表示最后一个校验符之前的位置
                    {
                        checkSum ^= buffer[i];
                    }
                    if (checkSum != buffer[len + 3])//如果数据校验失败，丢弃这一包数据
                    {
                        buffer.RemoveRange(0, len + 4);//缓存中删除错误数据
                        continue;//继续下一次循环
                    }
                    //至此，已经被找到了一条完整数据。我们将数据直接分析，或是缓存起来一起分析
                    //我们这里采用的办法是缓存一次，好处就是如果你某种原因，数据堆积在缓存buffer中
                    //已经很对了，那你需要循环的找到最后一组，只分析最新数据，过往数据你已经处理不及了，
                    //就不要浪费时间了。这也是考虑到系统负载能够降低。
                    buffer.CopyTo(0, binary_data_1, 0, len + 4);//复制一条完整数据到具体的数据缓存
                    data_1_catched = true;
                    buffer.RemoveRange(0, len + 4);
                }
                else
                {
                    //这里很重要，如果数据开始不是头，则删除数据
                    buffer.RemoveAt(0);
                }
            }
            //分析数据
            if (data_1_catched)
            {
                //我们的数据是定好格式的，所以当我们找到分析出的数据1，就知道固定位置一定是这些数据，我们只要显示就好了
                string data = binary_data_1[3].ToString("X2") + " " + binary_data_1[4].ToString("X2") + " " + binary_data_1[5].ToString("X2")
                    + " " + binary_data_1[6].ToString("X2") + " " + binary_data_1[7].ToString("X2");

                ////////////////////////////////////////////////////
                /////////////////////////////自己添加的，保存数据到文件
                ///////////////自己添加的，保存数据到数据库

                dataSaveToFile(data);     //保存数据到文件
                
                Thread mythread = new Thread(new ParameterizedThreadStart (dataBaseSave ));
                mythread.Start(data);
                       //保存数据到数据库

                /////////////////////////////////////
                /////////////////////////////////////////////////////
               
                //更新界面
                this.BeginInvoke((EventHandler )(delegate { txData.Text = data; }));
            }


            builder.Clear();//清除字符串构造器的内容
            //因为要访问UI资源，所以需要使用invoke 方式同步UI。
            this.BeginInvoke((EventHandler)(delegate
            {
                //判断是否是显示为16进制
                if (checkBoxHexView.Checked)
                {
                    foreach (byte b in buf)
                    {
                        //依次拼接出16进制字符串
                        builder.Append(b.ToString("X2") + " ");
                    }
                }
                else
                {
                    //直接按ASCII规则转换成字符串
                    builder.Append(Encoding.ASCII.GetString(buf));
                }
                //追加的形式添加到文本框末尾，并滚动到最后
                this.txGet.AppendText(builder.ToString());
                //修改接收计数
                labelGetCount.Text = "Get:" + received_count.ToString();
            }));
            
            //throw new NotImplementedException();
        }

        #region 开启关闭串口通信按钮
        private void btnOpenClose_Click(object sender, EventArgs e)
        {
            //根据当前串口对象，来判断操作
            if (comm.IsOpen)
            {
                //打开时点击，则关闭串口
                comm.Close();
                
            }
            else
            {
                try
                {
                    //关闭时点击，则设置好端口，波特率后打开
                    comm.PortName = comboxPortName.Text;
                    comm.BaudRate = int.Parse(comboxBaudrate.Text);
                    comm.Open();                 
                }
                catch (Exception ex)
                {
                    //捕获到异常信息，创建一个新的comm对象，之前的不能用了
                    comm = new SerialPort();
                    //显示异常信息给客户。
                    MessageBox.Show(ex.Message);
                }
            }
            //设置按钮的状态
            btnOpenClose.Text = comm.IsOpen ? "Close" : "Open";
            btnSend.Enabled = comm.IsOpen;
        }
        #endregion 

        //动态的修改获取文本框是否支持自动换行
          private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

            txGet.WordWrap = checkBoxNewlineGet.Checked;
        }

          #region 发送数据
          private void btnSend_Click(object sender, EventArgs e)
          {
              //定义一个变量，记录发送了几个字节
              int n = 0;
              //16进制发送
              if (checkBoxHexSend.Checked)
              {
                  //我们不管规则了，如果写错了一些，我们允许的，只用正则得到有效的十六进制数
                  MatchCollection mc = Regex.Matches(txSend.Text, @"(?i)[\da-f]{2}");
                  List<byte> buf = new List<byte>();
                  //依次添加到列表中
                  foreach (Match m in mc)
                  {
                      buf.Add(byte.Parse(m.Value ,System .Globalization .NumberStyles.HexNumber ));
                  }
                  //转换列表为数组后发送
                  comm.Write(buf.ToArray(), 0, buf.Count);
                  //记录发送的字节数
                  n = buf.Count;
              }
              else //ascii编码直接发送
              {
                  //包含换行符
                  if (checkBoxNewLineSend.Checked)
                  {
                      comm.WriteLine(txSend.Text);
                      n = txSend.Text.Length + 2;
                  }
                  else //不包含换行符
                  {
                      comm.Write(txSend.Text);
                      n = txSend.Text.Length;
                  }
              }
              send_count += n;//累加发送字节数
              labelSendCount.Text = "Send:" + send_count.ToString();//更新界面
              
          }
          #endregion 

          private void btnReset_Click(object sender, EventArgs e)
          {
              //复位接收和发送的字节数计数器并更新界面
              send_count = received_count = 0;
              labelGetCount.Text = "Get:0";
              labelSendCount.Text = "Send:0";
          }

          public void  dataBaseSave(object  data)
          {
              string mydata = data.ToString ();
              string connstr = @"server=localhost\SQLEXPRESS;database=myData;
                               integrated security=true;";
              SqlConnection conn = new SqlConnection(connstr);
              SqlCommand comm = conn.CreateCommand();
              comm.CommandText = string.Format(@"insert into insertTable (data) values ('{0}')", mydata);
              try
              {
                  conn.Open();
                  comm.ExecuteNonQuery();
                  conn.Close();
                 
              }
              catch(Exception ex)
              {
                  MessageBox.Show (ex .ToString ()); 
              }
              
          }
          public bool dataSaveToFile(string data)
          {
              
              StreamWriter switer = File.AppendText("F:\\1.txt");
              switer.WriteLine(data);
              switer.Flush();
              switer.Close();
              return true;
          }
          

        
                                   
    }
}
