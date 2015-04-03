namespace WinFormsApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnCallStackDemo = new System.Windows.Forms.Button();
            this.TxtMessage = new System.Windows.Forms.TextBox();
            this.BtnShowLogFile = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.btnLogInfo = new System.Windows.Forms.Button();
            this.btnLogTrace = new System.Windows.Forms.Button();
            this.btnLogPass = new System.Windows.Forms.Button();
            this.btnLogFail = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnCallStackDemo
            // 
            this.BtnCallStackDemo.Location = new System.Drawing.Point(50, 141);
            this.BtnCallStackDemo.Name = "BtnCallStackDemo";
            this.BtnCallStackDemo.Size = new System.Drawing.Size(91, 23);
            this.BtnCallStackDemo.TabIndex = 0;
            this.BtnCallStackDemo.Text = "CallStackDemo";
            this.BtnCallStackDemo.UseVisualStyleBackColor = true;
            this.BtnCallStackDemo.Click += new System.EventHandler(this.BtnCallStackDemo_Click);
            // 
            // TxtMessage
            // 
            this.TxtMessage.Location = new System.Drawing.Point(148, 25);
            this.TxtMessage.Multiline = true;
            this.TxtMessage.Name = "TxtMessage";
            this.TxtMessage.Size = new System.Drawing.Size(209, 21);
            this.TxtMessage.TabIndex = 1;
            this.TxtMessage.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // BtnShowLogFile
            // 
            this.BtnShowLogFile.Location = new System.Drawing.Point(238, 68);
            this.BtnShowLogFile.Name = "BtnShowLogFile";
            this.BtnShowLogFile.Size = new System.Drawing.Size(119, 52);
            this.BtnShowLogFile.TabIndex = 2;
            this.BtnShowLogFile.Text = "Show LogFile";
            this.BtnShowLogFile.UseVisualStyleBackColor = true;
            this.BtnShowLogFile.Click += new System.EventHandler(this.BtnShowLogFile_Click);
            // 
            // BtnExit
            // 
            this.BtnExit.Location = new System.Drawing.Point(282, 141);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(75, 23);
            this.BtnExit.TabIndex = 3;
            this.BtnExit.Text = "Exit";
            this.BtnExit.UseVisualStyleBackColor = true;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // btnLogInfo
            // 
            this.btnLogInfo.Location = new System.Drawing.Point(50, 25);
            this.btnLogInfo.Name = "btnLogInfo";
            this.btnLogInfo.Size = new System.Drawing.Size(75, 23);
            this.btnLogInfo.TabIndex = 4;
            this.btnLogInfo.Text = "LogInfo";
            this.btnLogInfo.UseVisualStyleBackColor = true;
            this.btnLogInfo.Click += new System.EventHandler(this.btnLogInfo_Click);
            // 
            // btnLogTrace
            // 
            this.btnLogTrace.Location = new System.Drawing.Point(50, 54);
            this.btnLogTrace.Name = "btnLogTrace";
            this.btnLogTrace.Size = new System.Drawing.Size(75, 23);
            this.btnLogTrace.TabIndex = 5;
            this.btnLogTrace.Text = "LogTrace";
            this.btnLogTrace.UseVisualStyleBackColor = true;
            this.btnLogTrace.Click += new System.EventHandler(this.btnLogTrace_Click);
            // 
            // btnLogPass
            // 
            this.btnLogPass.Location = new System.Drawing.Point(50, 83);
            this.btnLogPass.Name = "btnLogPass";
            this.btnLogPass.Size = new System.Drawing.Size(75, 23);
            this.btnLogPass.TabIndex = 6;
            this.btnLogPass.Text = "LogPass";
            this.btnLogPass.UseVisualStyleBackColor = true;
            this.btnLogPass.Click += new System.EventHandler(this.btnLogPass_Click);
            // 
            // btnLogFail
            // 
            this.btnLogFail.Location = new System.Drawing.Point(50, 112);
            this.btnLogFail.Name = "btnLogFail";
            this.btnLogFail.Size = new System.Drawing.Size(75, 23);
            this.btnLogFail.TabIndex = 7;
            this.btnLogFail.Text = "LogFail";
            this.btnLogFail.UseVisualStyleBackColor = true;
            this.btnLogFail.Click += new System.EventHandler(this.btnLogFail_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 176);
            this.Controls.Add(this.btnLogFail);
            this.Controls.Add(this.btnLogPass);
            this.Controls.Add(this.btnLogTrace);
            this.Controls.Add(this.btnLogInfo);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.BtnShowLogFile);
            this.Controls.Add(this.TxtMessage);
            this.Controls.Add(this.BtnCallStackDemo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnCallStackDemo;
        private System.Windows.Forms.TextBox TxtMessage;
        private System.Windows.Forms.Button BtnShowLogFile;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.Button btnLogInfo;
        private System.Windows.Forms.Button btnLogTrace;
        private System.Windows.Forms.Button btnLogPass;
        private System.Windows.Forms.Button btnLogFail;
    }
}

