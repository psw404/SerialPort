namespace 串口通信
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txData = new System.Windows.Forms.TextBox();
            this.txGet = new System.Windows.Forms.TextBox();
            this.labelGetCount = new System.Windows.Forms.Label();
            this.checkBoxNewlineGet = new System.Windows.Forms.CheckBox();
            this.checkBoxHexView = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboxPortName = new System.Windows.Forms.ComboBox();
            this.labelBaudrate = new System.Windows.Forms.Label();
            this.comboxBaudrate = new System.Windows.Forms.ComboBox();
            this.btnOpenClose = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txSend = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.labelSendCount = new System.Windows.Forms.Label();
            this.checkBoxNewLineSend = new System.Windows.Forms.CheckBox();
            this.checkBoxHexSend = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txData);
            this.groupBox1.Controls.Add(this.txGet);
            this.groupBox1.Controls.Add(this.labelGetCount);
            this.groupBox1.Controls.Add(this.checkBoxNewlineGet);
            this.groupBox1.Controls.Add(this.checkBoxHexView);
            this.groupBox1.Location = new System.Drawing.Point(46, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(726, 412);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data receive";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(6, 360);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "Data";
            // 
            // txData
            // 
            this.txData.Location = new System.Drawing.Point(56, 360);
            this.txData.Multiline = true;
            this.txData.Name = "txData";
            this.txData.Size = new System.Drawing.Size(659, 36);
            this.txData.TabIndex = 4;
            // 
            // txGet
            // 
            this.txGet.Location = new System.Drawing.Point(7, 16);
            this.txGet.Multiline = true;
            this.txGet.Name = "txGet";
            this.txGet.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txGet.Size = new System.Drawing.Size(708, 341);
            this.txGet.TabIndex = 3;
            // 
            // labelGetCount
            // 
            this.labelGetCount.AutoSize = true;
            this.labelGetCount.Location = new System.Drawing.Point(603, 1);
            this.labelGetCount.Name = "labelGetCount";
            this.labelGetCount.Size = new System.Drawing.Size(35, 12);
            this.labelGetCount.TabIndex = 2;
            this.labelGetCount.Text = "Get:0";
            // 
            // checkBoxNewlineGet
            // 
            this.checkBoxNewlineGet.AutoSize = true;
            this.checkBoxNewlineGet.Location = new System.Drawing.Point(210, 0);
            this.checkBoxNewlineGet.Name = "checkBoxNewlineGet";
            this.checkBoxNewlineGet.Size = new System.Drawing.Size(96, 16);
            this.checkBoxNewlineGet.TabIndex = 1;
            this.checkBoxNewlineGet.Text = "Auto newline";
            this.checkBoxNewlineGet.UseVisualStyleBackColor = true;
            this.checkBoxNewlineGet.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBoxHexView
            // 
            this.checkBoxHexView.AutoSize = true;
            this.checkBoxHexView.Checked = true;
            this.checkBoxHexView.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxHexView.Location = new System.Drawing.Point(104, 0);
            this.checkBoxHexView.Name = "checkBoxHexView";
            this.checkBoxHexView.Size = new System.Drawing.Size(72, 16);
            this.checkBoxHexView.TabIndex = 0;
            this.checkBoxHexView.Text = "Hex view";
            this.checkBoxHexView.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "Port name";
            // 
            // comboxPortName
            // 
            this.comboxPortName.FormattingEnabled = true;
            this.comboxPortName.Location = new System.Drawing.Point(120, 17);
            this.comboxPortName.Name = "comboxPortName";
            this.comboxPortName.Size = new System.Drawing.Size(121, 20);
            this.comboxPortName.TabIndex = 2;
            // 
            // labelBaudrate
            // 
            this.labelBaudrate.AutoSize = true;
            this.labelBaudrate.Location = new System.Drawing.Point(310, 21);
            this.labelBaudrate.Name = "labelBaudrate";
            this.labelBaudrate.Size = new System.Drawing.Size(53, 12);
            this.labelBaudrate.TabIndex = 3;
            this.labelBaudrate.Text = "Baudrate";
            // 
            // comboxBaudrate
            // 
            this.comboxBaudrate.FormattingEnabled = true;
            this.comboxBaudrate.Items.AddRange(new object[] {
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.comboxBaudrate.Location = new System.Drawing.Point(394, 17);
            this.comboxBaudrate.Name = "comboxBaudrate";
            this.comboxBaudrate.Size = new System.Drawing.Size(121, 20);
            this.comboxBaudrate.TabIndex = 4;
            // 
            // btnOpenClose
            // 
            this.btnOpenClose.Location = new System.Drawing.Point(570, 14);
            this.btnOpenClose.Name = "btnOpenClose";
            this.btnOpenClose.Size = new System.Drawing.Size(83, 23);
            this.btnOpenClose.TabIndex = 5;
            this.btnOpenClose.Text = "OpenOrClose";
            this.btnOpenClose.UseVisualStyleBackColor = true;
            this.btnOpenClose.Click += new System.EventHandler(this.btnOpenClose_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(675, 14);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(86, 23);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txSend);
            this.groupBox2.Controls.Add(this.btnSend);
            this.groupBox2.Controls.Add(this.labelSendCount);
            this.groupBox2.Controls.Add(this.checkBoxNewLineSend);
            this.groupBox2.Controls.Add(this.checkBoxHexSend);
            this.groupBox2.Location = new System.Drawing.Point(46, 461);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(726, 62);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data send ";
            // 
            // txSend
            // 
            this.txSend.Location = new System.Drawing.Point(7, 21);
            this.txSend.Name = "txSend";
            this.txSend.Size = new System.Drawing.Size(592, 21);
            this.txSend.TabIndex = 3;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(629, 21);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(86, 23);
            this.btnSend.TabIndex = 5;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // labelSendCount
            // 
            this.labelSendCount.AutoSize = true;
            this.labelSendCount.Location = new System.Drawing.Point(603, 1);
            this.labelSendCount.Name = "labelSendCount";
            this.labelSendCount.Size = new System.Drawing.Size(41, 12);
            this.labelSendCount.TabIndex = 2;
            this.labelSendCount.Text = "Send:0";
            // 
            // checkBoxNewLineSend
            // 
            this.checkBoxNewLineSend.AutoSize = true;
            this.checkBoxNewLineSend.Location = new System.Drawing.Point(163, 0);
            this.checkBoxNewLineSend.Name = "checkBoxNewLineSend";
            this.checkBoxNewLineSend.Size = new System.Drawing.Size(72, 16);
            this.checkBoxNewLineSend.TabIndex = 1;
            this.checkBoxNewLineSend.Text = "New line";
            this.checkBoxNewLineSend.UseVisualStyleBackColor = true;
            // 
            // checkBoxHexSend
            // 
            this.checkBoxHexSend.AutoSize = true;
            this.checkBoxHexSend.Location = new System.Drawing.Point(89, 0);
            this.checkBoxHexSend.Name = "checkBoxHexSend";
            this.checkBoxHexSend.Size = new System.Drawing.Size(42, 16);
            this.checkBoxHexSend.TabIndex = 0;
            this.checkBoxHexSend.Text = "Hex";
            this.checkBoxHexSend.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 525);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnOpenClose);
            this.Controls.Add(this.comboxBaudrate);
            this.Controls.Add(this.labelBaudrate);
            this.Controls.Add(this.comboxPortName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txGet;
        private System.Windows.Forms.Label labelGetCount;
        private System.Windows.Forms.CheckBox checkBoxNewlineGet;
        private System.Windows.Forms.CheckBox checkBoxHexView;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboxPortName;
        private System.Windows.Forms.Label labelBaudrate;
        private System.Windows.Forms.ComboBox comboxBaudrate;
        private System.Windows.Forms.Button btnOpenClose;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txSend;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label labelSendCount;
        private System.Windows.Forms.CheckBox checkBoxNewLineSend;
        private System.Windows.Forms.CheckBox checkBoxHexSend;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txData;
    }
}

