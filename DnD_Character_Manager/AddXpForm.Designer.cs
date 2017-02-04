namespace DnD_Character_Manager
{
    partial class AddXpForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddXpForm));
            this.cancelButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.amountBox = new System.Windows.Forms.NumericUpDown();
            this.xpPrompt = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.amountBox)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.cancelButton.Font = new System.Drawing.Font("High Tower Text", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(352, 127);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(124, 56);
            this.cancelButton.TabIndex = 15;
            this.cancelButton.Text = "cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.Color.Green;
            this.addButton.Font = new System.Drawing.Font("High Tower Text", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addButton.Location = new System.Drawing.Point(56, 127);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(88, 56);
            this.addButton.TabIndex = 14;
            this.addButton.Text = "add";
            this.addButton.UseVisualStyleBackColor = false;
            // 
            // amountBox
            // 
            this.amountBox.BackColor = System.Drawing.SystemColors.Info;
            this.amountBox.Font = new System.Drawing.Font("High Tower Text", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amountBox.Location = new System.Drawing.Point(186, 64);
            this.amountBox.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.amountBox.Name = "amountBox";
            this.amountBox.Size = new System.Drawing.Size(131, 46);
            this.amountBox.TabIndex = 17;
            this.amountBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // xpPrompt
            // 
            this.xpPrompt.AutoSize = true;
            this.xpPrompt.BackColor = System.Drawing.Color.Transparent;
            this.xpPrompt.Font = new System.Drawing.Font("High Tower Text", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xpPrompt.Location = new System.Drawing.Point(185, 9);
            this.xpPrompt.Name = "xpPrompt";
            this.xpPrompt.Size = new System.Drawing.Size(132, 39);
            this.xpPrompt.TabIndex = 16;
            this.xpPrompt.Text = "Amount";
            // 
            // AddXpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(497, 195);
            this.Controls.Add(this.amountBox);
            this.Controls.Add(this.xpPrompt);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.addButton);
            this.DoubleBuffered = true;
            this.MaximumSize = new System.Drawing.Size(515, 242);
            this.MinimumSize = new System.Drawing.Size(515, 242);
            this.Name = "AddXpForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddXpForm";
            ((System.ComponentModel.ISupportInitialize)(this.amountBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.NumericUpDown amountBox;
        private System.Windows.Forms.Label xpPrompt;
    }
}