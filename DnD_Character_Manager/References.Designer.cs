namespace DnD_Character_Manager
{
    partial class References
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(References));
            this.helpfulText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // helpfulText
            // 
            this.helpfulText.Font = new System.Drawing.Font("High Tower Text", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpfulText.Location = new System.Drawing.Point(12, 9);
            this.helpfulText.Name = "helpfulText";
            this.helpfulText.Size = new System.Drawing.Size(532, 492);
            this.helpfulText.TabIndex = 2;
            this.helpfulText.Text = "Helpful Text";
            this.helpfulText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // References
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(556, 510);
            this.Controls.Add(this.helpfulText);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "References";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Deactivate += new System.EventHandler(this.References_Deactivate);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label helpfulText;
    }
}