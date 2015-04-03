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
            this.BtnAssertStringEquals = new System.Windows.Forms.Button();
            this.BtnAssertStringMatches = new System.Windows.Forms.Button();
            this.BtnAssertStringContains = new System.Windows.Forms.Button();
            this.TxtAssertArg1 = new System.Windows.Forms.TextBox();
            this.TxtAssertArg2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BtnCallStackDemo
            // 
            this.BtnCallStackDemo.Location = new System.Drawing.Point(49, 177);
            this.BtnCallStackDemo.Name = "BtnCallStackDemo";
            this.BtnCallStackDemo.Size = new System.Drawing.Size(89, 23);
            this.BtnCallStackDemo.TabIndex = 0;
            this.BtnCallStackDemo.Text = "CallStackDemo";
            this.BtnCallStackDemo.UseVisualStyleBackColor = true;
            this.BtnCallStackDemo.Click += new System.EventHandler(this.BtnCallStackDemo_Click);
            // 
            // TxtMessage
            // 
            this.TxtMessage.Location = new System.Drawing.Point(49, 25);
            this.TxtMessage.Multiline = true;
            this.TxtMessage.Name = "TxtMessage";
            this.TxtMessage.Size = new System.Drawing.Size(75, 21);
            this.TxtMessage.TabIndex = 1;
            this.TxtMessage.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // BtnShowLogFile
            // 
            this.BtnShowLogFile.Location = new System.Drawing.Point(342, 139);
            this.BtnShowLogFile.Name = "BtnShowLogFile";
            this.BtnShowLogFile.Size = new System.Drawing.Size(75, 35);
            this.BtnShowLogFile.TabIndex = 2;
            this.BtnShowLogFile.Text = "Show LogFile";
            this.BtnShowLogFile.UseVisualStyleBackColor = true;
            this.BtnShowLogFile.Click += new System.EventHandler(this.BtnShowLogFile_Click);
            // 
            // BtnExit
            // 
            this.BtnExit.Location = new System.Drawing.Point(342, 181);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(75, 23);
            this.BtnExit.TabIndex = 3;
            this.BtnExit.Text = "Exit";
            this.BtnExit.UseVisualStyleBackColor = true;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // btnLogInfo
            // 
            this.btnLogInfo.Location = new System.Drawing.Point(49, 52);
            this.btnLogInfo.Name = "btnLogInfo";
            this.btnLogInfo.Size = new System.Drawing.Size(75, 23);
            this.btnLogInfo.TabIndex = 4;
            this.btnLogInfo.Text = "LogInfo";
            this.btnLogInfo.UseVisualStyleBackColor = true;
            this.btnLogInfo.Click += new System.EventHandler(this.btnLogInfo_Click);
            // 
            // btnLogTrace
            // 
            this.btnLogTrace.Location = new System.Drawing.Point(49, 81);
            this.btnLogTrace.Name = "btnLogTrace";
            this.btnLogTrace.Size = new System.Drawing.Size(75, 23);
            this.btnLogTrace.TabIndex = 5;
            this.btnLogTrace.Text = "LogTrace";
            this.btnLogTrace.UseVisualStyleBackColor = true;
            this.btnLogTrace.Click += new System.EventHandler(this.btnLogTrace_Click);
            // 
            // btnLogPass
            // 
            this.btnLogPass.Location = new System.Drawing.Point(49, 110);
            this.btnLogPass.Name = "btnLogPass";
            this.btnLogPass.Size = new System.Drawing.Size(75, 23);
            this.btnLogPass.TabIndex = 6;
            this.btnLogPass.Text = "LogPass";
            this.btnLogPass.UseVisualStyleBackColor = true;
            this.btnLogPass.Click += new System.EventHandler(this.btnLogPass_Click);
            // 
            // btnLogFail
            // 
            this.btnLogFail.Location = new System.Drawing.Point(49, 139);
            this.btnLogFail.Name = "btnLogFail";
            this.btnLogFail.Size = new System.Drawing.Size(75, 23);
            this.btnLogFail.TabIndex = 7;
            this.btnLogFail.Text = "LogFail";
            this.btnLogFail.UseVisualStyleBackColor = true;
            this.btnLogFail.Click += new System.EventHandler(this.btnLogFail_Click);
            // 
            // BtnAssertStringEquals
            // 
            this.BtnAssertStringEquals.Location = new System.Drawing.Point(146, 52);
            this.BtnAssertStringEquals.Name = "BtnAssertStringEquals";
            this.BtnAssertStringEquals.Size = new System.Drawing.Size(156, 23);
            this.BtnAssertStringEquals.TabIndex = 8;
            this.BtnAssertStringEquals.Text = "AssertStringEquals";
            this.BtnAssertStringEquals.UseVisualStyleBackColor = true;
            this.BtnAssertStringEquals.Click += new System.EventHandler(this.BtnAssertStringEquals_Click);
            // 
            // BtnAssertStringMatches
            // 
            this.BtnAssertStringMatches.Location = new System.Drawing.Point(146, 81);
            this.BtnAssertStringMatches.Name = "BtnAssertStringMatches";
            this.BtnAssertStringMatches.Size = new System.Drawing.Size(156, 23);
            this.BtnAssertStringMatches.TabIndex = 9;
            this.BtnAssertStringMatches.Text = "AssertStringMatches";
            this.BtnAssertStringMatches.UseVisualStyleBackColor = true;
            this.BtnAssertStringMatches.Click += new System.EventHandler(this.BtnAssertStringMatches_Click);
            // 
            // BtnAssertStringContains
            // 
            this.BtnAssertStringContains.Location = new System.Drawing.Point(146, 110);
            this.BtnAssertStringContains.Name = "BtnAssertStringContains";
            this.BtnAssertStringContains.Size = new System.Drawing.Size(156, 23);
            this.BtnAssertStringContains.TabIndex = 10;
            this.BtnAssertStringContains.Text = "AssertStringContains";
            this.BtnAssertStringContains.UseVisualStyleBackColor = true;
            this.BtnAssertStringContains.Click += new System.EventHandler(this.BtnAssertStringContains_Click);
            // 
            // TxtAssertArg1
            // 
            this.TxtAssertArg1.Location = new System.Drawing.Point(146, 25);
            this.TxtAssertArg1.Multiline = true;
            this.TxtAssertArg1.Name = "TxtAssertArg1";
            this.TxtAssertArg1.Size = new System.Drawing.Size(75, 21);
            this.TxtAssertArg1.TabIndex = 11;
            // 
            // TxtAssertArg2
            // 
            this.TxtAssertArg2.Location = new System.Drawing.Point(227, 25);
            this.TxtAssertArg2.Multiline = true;
            this.TxtAssertArg2.Name = "TxtAssertArg2";
            this.TxtAssertArg2.Size = new System.Drawing.Size(75, 21);
            this.TxtAssertArg2.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 227);
            this.Controls.Add(this.TxtAssertArg2);
            this.Controls.Add(this.TxtAssertArg1);
            this.Controls.Add(this.BtnAssertStringContains);
            this.Controls.Add(this.BtnAssertStringMatches);
            this.Controls.Add(this.BtnAssertStringEquals);
            this.Controls.Add(this.btnLogFail);
            this.Controls.Add(this.btnLogPass);
            this.Controls.Add(this.btnLogTrace);
            this.Controls.Add(this.btnLogInfo);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.BtnShowLogFile);
            this.Controls.Add(this.TxtMessage);
            this.Controls.Add(this.BtnCallStackDemo);
            this.Name = "Form1";
            this.Text = "Ovid Demo App";
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
        private System.Windows.Forms.Button BtnAssertStringEquals;
        private System.Windows.Forms.Button BtnAssertStringMatches;
        private System.Windows.Forms.Button BtnAssertStringContains;
        private System.Windows.Forms.TextBox TxtAssertArg1;
        private System.Windows.Forms.TextBox TxtAssertArg2;
    }
}

