namespace DnD_Character_Manager
{
    partial class HealthForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HealthForm));
            this.HealthPrompt = new System.Windows.Forms.Label();
            this.amountValue = new System.Windows.Forms.NumericUpDown();
            this.addButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.amountValue)).BeginInit();
            this.SuspendLayout();
            // 
            // HealthPrompt
            // 
            this.HealthPrompt.AutoSize = true;
            this.HealthPrompt.BackColor = System.Drawing.Color.Transparent;
            this.HealthPrompt.Font = new System.Drawing.Font("High Tower Text", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HealthPrompt.Location = new System.Drawing.Point(225, 9);
            this.HealthPrompt.Name = "HealthPrompt";
            this.HealthPrompt.Size = new System.Drawing.Size(132, 39);
            this.HealthPrompt.TabIndex = 0;
            this.HealthPrompt.Text = "Amount";
            // 
            // amountValue
            // 
            this.amountValue.BackColor = System.Drawing.SystemColors.Info;
            this.amountValue.Font = new System.Drawing.Font("High Tower Text", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amountValue.Location = new System.Drawing.Point(232, 64);
            this.amountValue.Name = "amountValue";
            this.amountValue.Size = new System.Drawing.Size(131, 46);
            this.amountValue.TabIndex = 1;
            this.amountValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.Color.Green;
            this.addButton.Font = new System.Drawing.Font("High Tower Text", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.addButton.Location = new System.Drawing.Point(47, 164);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(113, 67);
            this.addButton.TabIndex = 2;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = false;
            // 
            // removeButton
            // 
            this.removeButton.BackColor = System.Drawing.Color.Crimson;
            this.removeButton.Font = new System.Drawing.Font("High Tower Text", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.removeButton.Location = new System.Drawing.Point(216, 164);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(162, 67);
            this.removeButton.TabIndex = 3;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = false;
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.cancelButton.Font = new System.Drawing.Font("High Tower Text", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cancelButton.Location = new System.Drawing.Point(430, 164);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(147, 67);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            // 
            // HealthForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(604, 253);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.amountValue);
            this.Controls.Add(this.HealthPrompt);
            this.DoubleBuffered = true;
            this.MaximumSize = new System.Drawing.Size(622, 300);
            this.MinimumSize = new System.Drawing.Size(622, 300);
            this.Name = "HealthForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HealthForm";
            ((System.ComponentModel.ISupportInitialize)(this.amountValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label HealthPrompt;
        private System.Windows.Forms.NumericUpDown amountValue;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button cancelButton;
    }
}