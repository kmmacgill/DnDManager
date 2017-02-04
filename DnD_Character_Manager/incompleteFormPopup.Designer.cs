namespace DnD_Character_Manager
{
    partial class incompleteFormPopup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(incompleteFormPopup));
            this.understoodButton = new System.Windows.Forms.Button();
            this.incompleteFormLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // understoodButton
            // 
            this.understoodButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.understoodButton.Font = new System.Drawing.Font("High Tower Text", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.understoodButton.Location = new System.Drawing.Point(325, 273);
            this.understoodButton.Name = "understoodButton";
            this.understoodButton.Size = new System.Drawing.Size(260, 51);
            this.understoodButton.TabIndex = 0;
            this.understoodButton.Text = "Close";
            this.understoodButton.UseVisualStyleBackColor = false;
            this.understoodButton.Click += new System.EventHandler(this.understoodButton_Click);
            // 
            // incompleteFormLabel
            // 
            this.incompleteFormLabel.BackColor = System.Drawing.Color.Transparent;
            this.incompleteFormLabel.Font = new System.Drawing.Font("High Tower Text", 23F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.incompleteFormLabel.ForeColor = System.Drawing.Color.Crimson;
            this.incompleteFormLabel.Location = new System.Drawing.Point(12, 61);
            this.incompleteFormLabel.Name = "incompleteFormLabel";
            this.incompleteFormLabel.Size = new System.Drawing.Size(888, 196);
            this.incompleteFormLabel.TabIndex = 1;
            this.incompleteFormLabel.Text = "Warning, this form is incomplete, please review your decisions and fix any proble" +
    "ms, failure to do so will result in frustration. Proceed at own risk.";
            // 
            // incompleteFormPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(912, 326);
            this.Controls.Add(this.incompleteFormLabel);
            this.Controls.Add(this.understoodButton);
            this.DoubleBuffered = true;
            this.MaximumSize = new System.Drawing.Size(930, 373);
            this.MinimumSize = new System.Drawing.Size(930, 373);
            this.Name = "incompleteFormPopup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button understoodButton;
        private System.Windows.Forms.Label incompleteFormLabel;
    }
}