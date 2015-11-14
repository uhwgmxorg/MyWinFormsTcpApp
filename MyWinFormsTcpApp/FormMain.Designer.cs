namespace MyWinFormsTcpApp
{
    partial class FormMyWinFormsTcpApp
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMyWinFormsTcpApp));
            this.button_Close = new System.Windows.Forms.Button();
            this.radioButtonServer = new System.Windows.Forms.RadioButton();
            this.radioButtonClient = new System.Windows.Forms.RadioButton();
            this.button_Start = new System.Windows.Forms.Button();
            this.button_Stop = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Exit = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_LoadConfig = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_SaveConfig = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_ChangeLog = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_About = new System.Windows.Forms.ToolStripButton();
            this.labelTCPIPAddress = new System.Windows.Forms.Label();
            this.maskedTextBoxPort = new System.Windows.Forms.MaskedTextBox();
            this.labelPort = new System.Windows.Forms.Label();
            this.labelPackageSizeValue = new System.Windows.Forms.Label();
            this.labelPackageSize = new System.Windows.Forms.Label();
            this.labelPerformanceValue = new System.Windows.Forms.Label();
            this.labelPerformance = new System.Windows.Forms.Label();
            this.trackBarPackageSize = new System.Windows.Forms.TrackBar();
            this.progressBarPerformance = new System.Windows.Forms.ProgressBar();
            this.labelServerClient = new System.Windows.Forms.Label();
            this.labelInfo = new System.Windows.Forms.Label();
            this.textBoxInfo = new System.Windows.Forms.TextBox();
            this.button_Clear = new System.Windows.Forms.Button();
            this.labelSendDelayValue = new System.Windows.Forms.Label();
            this.labelSendDelay = new System.Windows.Forms.Label();
            this.trackBarSendDelay = new System.Windows.Forms.TrackBar();
            this.textBoxTCPIPAddress = new System.Windows.Forms.TextBox();
            this.checkBoxAutoRecover = new System.Windows.Forms.CheckBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPackageSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSendDelay)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Close
            // 
            this.button_Close.Location = new System.Drawing.Point(407, 277);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(75, 23);
            this.button_Close.TabIndex = 0;
            this.button_Close.Text = "Close";
            this.button_Close.UseVisualStyleBackColor = true;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // radioButtonServer
            // 
            this.radioButtonServer.AutoSize = true;
            this.radioButtonServer.Location = new System.Drawing.Point(15, 34);
            this.radioButtonServer.Name = "radioButtonServer";
            this.radioButtonServer.Size = new System.Drawing.Size(56, 17);
            this.radioButtonServer.TabIndex = 1;
            this.radioButtonServer.TabStop = true;
            this.radioButtonServer.Text = "Server";
            this.radioButtonServer.UseVisualStyleBackColor = true;
            this.radioButtonServer.CheckedChanged += new System.EventHandler(this.radioButtonServer_CheckedChanged);
            // 
            // radioButtonClient
            // 
            this.radioButtonClient.AutoSize = true;
            this.radioButtonClient.Location = new System.Drawing.Point(15, 57);
            this.radioButtonClient.Name = "radioButtonClient";
            this.radioButtonClient.Size = new System.Drawing.Size(51, 17);
            this.radioButtonClient.TabIndex = 2;
            this.radioButtonClient.TabStop = true;
            this.radioButtonClient.Text = "Client";
            this.radioButtonClient.UseVisualStyleBackColor = true;
            this.radioButtonClient.CheckedChanged += new System.EventHandler(this.radioButtonClient_CheckedChanged);
            // 
            // button_Start
            // 
            this.button_Start.Location = new System.Drawing.Point(13, 108);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(75, 23);
            this.button_Start.TabIndex = 3;
            this.button_Start.Text = "Start";
            this.button_Start.UseVisualStyleBackColor = true;
            this.button_Start.Click += new System.EventHandler(this.button_Start_Click);
            // 
            // button_Stop
            // 
            this.button_Stop.Location = new System.Drawing.Point(94, 108);
            this.button_Stop.Name = "button_Stop";
            this.button_Stop.Size = new System.Drawing.Size(75, 23);
            this.button_Stop.TabIndex = 4;
            this.button_Stop.Text = "Stop";
            this.button_Stop.UseVisualStyleBackColor = true;
            this.button_Stop.Click += new System.EventHandler(this.button_Stop_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Exit,
            this.toolStripButton_LoadConfig,
            this.toolStripButton_SaveConfig,
            this.toolStripButton_ChangeLog,
            this.toolStripButton_About});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(504, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton_Exit
            // 
            this.toolStripButton_Exit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Exit.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Exit.Image")));
            this.toolStripButton_Exit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Exit.Name = "toolStripButton_Exit";
            this.toolStripButton_Exit.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_Exit.Text = "toolStripButton1";
            this.toolStripButton_Exit.ToolTipText = "Exit";
            this.toolStripButton_Exit.Click += new System.EventHandler(this.toolStripButton_Exit_Click);
            // 
            // toolStripButton_LoadConfig
            // 
            this.toolStripButton_LoadConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_LoadConfig.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_LoadConfig.Image")));
            this.toolStripButton_LoadConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_LoadConfig.Name = "toolStripButton_LoadConfig";
            this.toolStripButton_LoadConfig.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_LoadConfig.Text = "Load";
            this.toolStripButton_LoadConfig.ToolTipText = "Load Configuration";
            this.toolStripButton_LoadConfig.Click += new System.EventHandler(this.toolStripButton_Load_Click);
            // 
            // toolStripButton_SaveConfig
            // 
            this.toolStripButton_SaveConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_SaveConfig.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_SaveConfig.Image")));
            this.toolStripButton_SaveConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_SaveConfig.Name = "toolStripButton_SaveConfig";
            this.toolStripButton_SaveConfig.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_SaveConfig.Text = "Save";
            this.toolStripButton_SaveConfig.ToolTipText = "Save Configuration";
            this.toolStripButton_SaveConfig.Click += new System.EventHandler(this.toolStripButton_Save_Click);
            // 
            // toolStripButton_ChangeLog
            // 
            this.toolStripButton_ChangeLog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_ChangeLog.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_ChangeLog.Image")));
            this.toolStripButton_ChangeLog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_ChangeLog.Name = "toolStripButton_ChangeLog";
            this.toolStripButton_ChangeLog.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_ChangeLog.Text = "toolStripButton1";
            this.toolStripButton_ChangeLog.ToolTipText = "Show Change Log";
            this.toolStripButton_ChangeLog.Click += new System.EventHandler(this.toolStripButton_ChangeLog_Click);
            // 
            // toolStripButton_About
            // 
            this.toolStripButton_About.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_About.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_About.Image")));
            this.toolStripButton_About.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_About.Name = "toolStripButton_About";
            this.toolStripButton_About.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_About.Text = "toolStripButton4";
            this.toolStripButton_About.ToolTipText = "About";
            this.toolStripButton_About.Click += new System.EventHandler(this.toolStripButton_About_Click);
            // 
            // labelTCPIPAddress
            // 
            this.labelTCPIPAddress.AutoSize = true;
            this.labelTCPIPAddress.Location = new System.Drawing.Point(244, 47);
            this.labelTCPIPAddress.Name = "labelTCPIPAddress";
            this.labelTCPIPAddress.Size = new System.Drawing.Size(90, 13);
            this.labelTCPIPAddress.TabIndex = 15;
            this.labelTCPIPAddress.Text = "TCP / IP Address";
            // 
            // maskedTextBoxPort
            // 
            this.maskedTextBoxPort.Location = new System.Drawing.Point(340, 71);
            this.maskedTextBoxPort.Name = "maskedTextBoxPort";
            this.maskedTextBoxPort.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBoxPort.TabIndex = 19;
            // 
            // labelPort
            // 
            this.labelPort.AutoSize = true;
            this.labelPort.Location = new System.Drawing.Point(244, 74);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(26, 13);
            this.labelPort.TabIndex = 18;
            this.labelPort.Text = "Port";
            // 
            // labelPackageSizeValue
            // 
            this.labelPackageSizeValue.AutoSize = true;
            this.labelPackageSizeValue.Location = new System.Drawing.Point(86, 205);
            this.labelPackageSizeValue.Name = "labelPackageSizeValue";
            this.labelPackageSizeValue.Size = new System.Drawing.Size(28, 13);
            this.labelPackageSizeValue.TabIndex = 25;
            this.labelPackageSizeValue.Text = "XXX";
            // 
            // labelPackageSize
            // 
            this.labelPackageSize.AutoSize = true;
            this.labelPackageSize.Location = new System.Drawing.Point(18, 205);
            this.labelPackageSize.Name = "labelPackageSize";
            this.labelPackageSize.Size = new System.Drawing.Size(73, 13);
            this.labelPackageSize.TabIndex = 24;
            this.labelPackageSize.Text = "Package Size";
            // 
            // labelPerformanceValue
            // 
            this.labelPerformanceValue.AutoSize = true;
            this.labelPerformanceValue.Location = new System.Drawing.Point(86, 141);
            this.labelPerformanceValue.Name = "labelPerformanceValue";
            this.labelPerformanceValue.Size = new System.Drawing.Size(28, 13);
            this.labelPerformanceValue.TabIndex = 23;
            this.labelPerformanceValue.Text = "XXX";
            // 
            // labelPerformance
            // 
            this.labelPerformance.AutoSize = true;
            this.labelPerformance.Location = new System.Drawing.Point(18, 141);
            this.labelPerformance.Name = "labelPerformance";
            this.labelPerformance.Size = new System.Drawing.Size(67, 13);
            this.labelPerformance.TabIndex = 22;
            this.labelPerformance.Text = "Performance";
            // 
            // trackBarPackageSize
            // 
            this.trackBarPackageSize.Location = new System.Drawing.Point(12, 221);
            this.trackBarPackageSize.Name = "trackBarPackageSize";
            this.trackBarPackageSize.Size = new System.Drawing.Size(237, 45);
            this.trackBarPackageSize.TabIndex = 21;
            this.trackBarPackageSize.Scroll += new System.EventHandler(this.trackBarPackageSize_Scroll);
            // 
            // progressBarPerformance
            // 
            this.progressBarPerformance.Location = new System.Drawing.Point(12, 160);
            this.progressBarPerformance.Name = "progressBarPerformance";
            this.progressBarPerformance.Size = new System.Drawing.Size(237, 23);
            this.progressBarPerformance.TabIndex = 20;
            // 
            // labelServerClient
            // 
            this.labelServerClient.AutoSize = true;
            this.labelServerClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelServerClient.ForeColor = System.Drawing.Color.DarkRed;
            this.labelServerClient.Location = new System.Drawing.Point(12, 89);
            this.labelServerClient.Name = "labelServerClient";
            this.labelServerClient.Size = new System.Drawing.Size(35, 16);
            this.labelServerClient.TabIndex = 26;
            this.labelServerClient.Text = "XXX";
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInfo.ForeColor = System.Drawing.Color.DarkRed;
            this.labelInfo.Location = new System.Drawing.Point(252, 98);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(31, 15);
            this.labelInfo.TabIndex = 27;
            this.labelInfo.Text = "Info";
            // 
            // textBoxInfo
            // 
            this.textBoxInfo.Location = new System.Drawing.Point(255, 116);
            this.textBoxInfo.Multiline = true;
            this.textBoxInfo.Name = "textBoxInfo";
            this.textBoxInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxInfo.Size = new System.Drawing.Size(227, 150);
            this.textBoxInfo.TabIndex = 28;
            // 
            // button_Clear
            // 
            this.button_Clear.Location = new System.Drawing.Point(255, 277);
            this.button_Clear.Name = "button_Clear";
            this.button_Clear.Size = new System.Drawing.Size(75, 23);
            this.button_Clear.TabIndex = 29;
            this.button_Clear.Text = "Clear";
            this.button_Clear.UseVisualStyleBackColor = true;
            this.button_Clear.Click += new System.EventHandler(this.button_Clear_Click);
            // 
            // labelSendDelayValue
            // 
            this.labelSendDelayValue.AutoSize = true;
            this.labelSendDelayValue.Location = new System.Drawing.Point(87, 256);
            this.labelSendDelayValue.Name = "labelSendDelayValue";
            this.labelSendDelayValue.Size = new System.Drawing.Size(28, 13);
            this.labelSendDelayValue.TabIndex = 32;
            this.labelSendDelayValue.Text = "XXX";
            // 
            // labelSendDelay
            // 
            this.labelSendDelay.AutoSize = true;
            this.labelSendDelay.Location = new System.Drawing.Point(19, 256);
            this.labelSendDelay.Name = "labelSendDelay";
            this.labelSendDelay.Size = new System.Drawing.Size(62, 13);
            this.labelSendDelay.TabIndex = 31;
            this.labelSendDelay.Text = "Send Delay";
            // 
            // trackBarSendDelay
            // 
            this.trackBarSendDelay.Location = new System.Drawing.Point(13, 272);
            this.trackBarSendDelay.Name = "trackBarSendDelay";
            this.trackBarSendDelay.Size = new System.Drawing.Size(237, 45);
            this.trackBarSendDelay.TabIndex = 30;
            this.trackBarSendDelay.Scroll += new System.EventHandler(this.trackBarSendDelay_Scroll);
            // 
            // textBoxTCPIPAddress
            // 
            this.textBoxTCPIPAddress.Location = new System.Drawing.Point(341, 39);
            this.textBoxTCPIPAddress.Name = "textBoxTCPIPAddress";
            this.textBoxTCPIPAddress.Size = new System.Drawing.Size(141, 20);
            this.textBoxTCPIPAddress.TabIndex = 33;
            // 
            // checkBoxAutoRecover
            // 
            this.checkBoxAutoRecover.AutoSize = true;
            this.checkBoxAutoRecover.Location = new System.Drawing.Point(94, 57);
            this.checkBoxAutoRecover.Name = "checkBoxAutoRecover";
            this.checkBoxAutoRecover.Size = new System.Drawing.Size(92, 17);
            this.checkBoxAutoRecover.TabIndex = 34;
            this.checkBoxAutoRecover.Text = "Auto Recover";
            this.checkBoxAutoRecover.UseVisualStyleBackColor = true;
            this.checkBoxAutoRecover.CheckedChanged += new System.EventHandler(this.checkBoxAutoRecover_CheckedChanged);
            // 
            // FormMyWinFormsTcpApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 321);
            this.Controls.Add(this.checkBoxAutoRecover);
            this.Controls.Add(this.textBoxTCPIPAddress);
            this.Controls.Add(this.labelSendDelayValue);
            this.Controls.Add(this.labelSendDelay);
            this.Controls.Add(this.trackBarSendDelay);
            this.Controls.Add(this.button_Clear);
            this.Controls.Add(this.textBoxInfo);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.labelServerClient);
            this.Controls.Add(this.labelPackageSizeValue);
            this.Controls.Add(this.labelPackageSize);
            this.Controls.Add(this.labelPerformanceValue);
            this.Controls.Add(this.labelPerformance);
            this.Controls.Add(this.trackBarPackageSize);
            this.Controls.Add(this.progressBarPerformance);
            this.Controls.Add(this.maskedTextBoxPort);
            this.Controls.Add(this.labelPort);
            this.Controls.Add(this.labelTCPIPAddress);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.button_Stop);
            this.Controls.Add(this.button_Start);
            this.Controls.Add(this.radioButtonClient);
            this.Controls.Add(this.radioButtonServer);
            this.Controls.Add(this.button_Close);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(590, 380);
            this.MinimumSize = new System.Drawing.Size(520, 360);
            this.Name = "FormMyWinFormsTcpApp";
            this.Text = "Form MyWinFormsTcpApp";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMyWinFormsTcpApp_FormClosed);
            this.Load += new System.EventHandler(this.FormMyWinFormsTcpApp_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPackageSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSendDelay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Close;
        private System.Windows.Forms.RadioButton radioButtonServer;
        private System.Windows.Forms.RadioButton radioButtonClient;
        private System.Windows.Forms.Button button_Start;
        private System.Windows.Forms.Button button_Stop;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_Exit;
        private System.Windows.Forms.ToolStripButton toolStripButton_LoadConfig;
        private System.Windows.Forms.ToolStripButton toolStripButton_SaveConfig;
        private System.Windows.Forms.ToolStripButton toolStripButton_About;
        private System.Windows.Forms.Label labelTCPIPAddress;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxPort;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.Label labelPackageSizeValue;
        private System.Windows.Forms.Label labelPackageSize;
        private System.Windows.Forms.Label labelPerformanceValue;
        private System.Windows.Forms.Label labelPerformance;
        private System.Windows.Forms.TrackBar trackBarPackageSize;
        private System.Windows.Forms.ProgressBar progressBarPerformance;
        private System.Windows.Forms.Label labelServerClient;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.TextBox textBoxInfo;
        private System.Windows.Forms.Button button_Clear;
        private System.Windows.Forms.Label labelSendDelayValue;
        private System.Windows.Forms.Label labelSendDelay;
        private System.Windows.Forms.TrackBar trackBarSendDelay;
        private System.Windows.Forms.ToolStripButton toolStripButton_ChangeLog;
        private System.Windows.Forms.TextBox textBoxTCPIPAddress;
        private System.Windows.Forms.CheckBox checkBoxAutoRecover;
    }
}

