namespace NET.Kniaz.PAI.MultiAgentSystems.GUI
{
    partial class Messaging
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
            this.messageList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // messageList
            // 
            this.messageList.FormattingEnabled = true;
            this.messageList.ItemHeight = 25;
            this.messageList.Location = new System.Drawing.Point(28, 19);
            this.messageList.Name = "messageList";
            this.messageList.Size = new System.Drawing.Size(742, 404);
            this.messageList.TabIndex = 0;
            // 
            // Messaging
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.messageList);
            this.Name = "Messaging";
            this.Text = "Messaging";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox messageList;
    }
}