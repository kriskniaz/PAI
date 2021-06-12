namespace NET.Kniaz.PAI.AgentClient
{
    partial class AgentForm
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
            this.sendBtn = new System.Windows.Forms.Button();
            this.wordBox = new System.Windows.Forms.TextBox();
            this.messageList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // sendBtn
            // 
            this.sendBtn.Location = new System.Drawing.Point(47, 43);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(104, 31);
            this.sendBtn.TabIndex = 0;
            this.sendBtn.Text = "Send";
            this.sendBtn.UseVisualStyleBackColor = true;
            this.sendBtn.Click += new System.EventHandler(this.sendBtn_Click);
            // 
            // wordBox
            // 
            this.wordBox.Location = new System.Drawing.Point(224, 43);
            this.wordBox.Name = "wordBox";
            this.wordBox.Size = new System.Drawing.Size(536, 31);
            this.wordBox.TabIndex = 1;
            this.wordBox.TextChanged += new System.EventHandler(this.wordBox_TextChanged);
            // 
            // messageList
            // 
            this.messageList.FormattingEnabled = true;
            this.messageList.ItemHeight = 25;
            this.messageList.Location = new System.Drawing.Point(224, 117);
            this.messageList.Name = "messageList";
            this.messageList.Size = new System.Drawing.Size(536, 304);
            this.messageList.TabIndex = 2;
            // 
            // AgentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.messageList);
            this.Controls.Add(this.wordBox);
            this.Controls.Add(this.sendBtn);
            this.Name = "AgentForm";
            this.Text = "AgentForm";
            this.Load += new System.EventHandler(this.AgentForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button sendBtn;
        private System.Windows.Forms.TextBox wordBox;
        private System.Windows.Forms.ListBox messageList;
    }
}

