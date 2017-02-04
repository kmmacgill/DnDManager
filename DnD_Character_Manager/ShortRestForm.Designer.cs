namespace DnD_Character_Manager
{
    partial class ShortRestForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShortRestForm));
            this.remainingHitDice = new System.Windows.Forms.Label();
            this.HitPointLabel = new System.Windows.Forms.Label();
            this.hitPointsMeter = new System.Windows.Forms.ProgressBar();
            this.hitDiceScore = new System.Windows.Forms.Label();
            this.spendHitDiceButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.hitDieType = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // remainingHitDice
            // 
            this.remainingHitDice.AutoSize = true;
            this.remainingHitDice.BackColor = System.Drawing.Color.Transparent;
            this.remainingHitDice.Font = new System.Drawing.Font("High Tower Text", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remainingHitDice.Location = new System.Drawing.Point(274, 6);
            this.remainingHitDice.Name = "remainingHitDice";
            this.remainingHitDice.Size = new System.Drawing.Size(207, 28);
            this.remainingHitDice.TabIndex = 50;
            this.remainingHitDice.Text = "Remaining Hit Dice:";
            // 
            // HitPointLabel
            // 
            this.HitPointLabel.AutoSize = true;
            this.HitPointLabel.BackColor = System.Drawing.SystemColors.Info;
            this.HitPointLabel.Font = new System.Drawing.Font("High Tower Text", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HitPointLabel.Location = new System.Drawing.Point(14, 58);
            this.HitPointLabel.Name = "HitPointLabel";
            this.HitPointLabel.Size = new System.Drawing.Size(79, 48);
            this.HitPointLabel.TabIndex = 51;
            this.HitPointLabel.Text = "HP";
            // 
            // hitPointsMeter
            // 
            this.hitPointsMeter.BackColor = System.Drawing.Color.Firebrick;
            this.hitPointsMeter.ForeColor = System.Drawing.Color.Firebrick;
            this.hitPointsMeter.Location = new System.Drawing.Point(99, 58);
            this.hitPointsMeter.Name = "hitPointsMeter";
            this.hitPointsMeter.Size = new System.Drawing.Size(367, 48);
            this.hitPointsMeter.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.hitPointsMeter.TabIndex = 52;
            this.hitPointsMeter.Value = 100;
            // 
            // hitDiceScore
            // 
            this.hitDiceScore.BackColor = System.Drawing.SystemColors.Info;
            this.hitDiceScore.Font = new System.Drawing.Font("High Tower Text", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hitDiceScore.Location = new System.Drawing.Point(520, 6);
            this.hitDiceScore.MaximumSize = new System.Drawing.Size(62, 35);
            this.hitDiceScore.MinimumSize = new System.Drawing.Size(62, 35);
            this.hitDiceScore.Name = "hitDiceScore";
            this.hitDiceScore.Size = new System.Drawing.Size(62, 35);
            this.hitDiceScore.TabIndex = 53;
            this.hitDiceScore.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // spendHitDiceButton
            // 
            this.spendHitDiceButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.spendHitDiceButton.Font = new System.Drawing.Font("High Tower Text", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spendHitDiceButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.spendHitDiceButton.Location = new System.Drawing.Point(14, 9);
            this.spendHitDiceButton.Name = "spendHitDiceButton";
            this.spendHitDiceButton.Size = new System.Drawing.Size(153, 43);
            this.spendHitDiceButton.TabIndex = 54;
            this.spendHitDiceButton.Text = "Roll Die";
            this.spendHitDiceButton.UseVisualStyleBackColor = false;
            this.spendHitDiceButton.Click += new System.EventHandler(this.spendHitDiceButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.closeButton.Font = new System.Drawing.Font("High Tower Text", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.closeButton.Location = new System.Drawing.Point(472, 58);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(153, 55);
            this.closeButton.TabIndex = 56;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = false;
            // 
            // hitDieType
            // 
            this.hitDieType.AutoSize = true;
            this.hitDieType.Location = new System.Drawing.Point(185, 18);
            this.hitDieType.Name = "hitDieType";
            this.hitDieType.Size = new System.Drawing.Size(0, 17);
            this.hitDieType.TabIndex = 57;
            this.hitDieType.Visible = false;
            // 
            // ShortRestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(636, 143);
            this.Controls.Add(this.hitDieType);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.spendHitDiceButton);
            this.Controls.Add(this.hitDiceScore);
            this.Controls.Add(this.hitPointsMeter);
            this.Controls.Add(this.HitPointLabel);
            this.Controls.Add(this.remainingHitDice);
            this.DoubleBuffered = true;
            this.MaximumSize = new System.Drawing.Size(654, 190);
            this.MinimumSize = new System.Drawing.Size(654, 190);
            this.Name = "ShortRestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShortRestForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label remainingHitDice;
        private System.Windows.Forms.Label HitPointLabel;
        private System.Windows.Forms.ProgressBar hitPointsMeter;
        private System.Windows.Forms.Label hitDiceScore;
        private System.Windows.Forms.Button spendHitDiceButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label hitDieType;
    }
}