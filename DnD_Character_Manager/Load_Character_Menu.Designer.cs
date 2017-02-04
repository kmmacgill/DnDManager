namespace DnD_Character_Manager
{
    partial class Load_Character_Menu
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Load_Character_Menu));
            this.button1 = new System.Windows.Forms.Button();
            this.charactersList = new System.Windows.Forms.ListView();
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Level = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DodgerBlue;
            this.button1.Font = new System.Drawing.Font("High Tower Text", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(482, 583);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(294, 78);
            this.button1.TabIndex = 5;
            this.button1.Text = "Load Character";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // charactersList
            // 
            this.charactersList.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.charactersList.BackColor = System.Drawing.Color.PeachPuff;
            this.charactersList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.Level});
            this.charactersList.Font = new System.Drawing.Font("High Tower Text", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.charactersList.FullRowSelect = true;
            this.charactersList.GridLines = true;
            this.charactersList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3});
            this.charactersList.Location = new System.Drawing.Point(378, 42);
            this.charactersList.MaximumSize = new System.Drawing.Size(495, 518);
            this.charactersList.MinimumSize = new System.Drawing.Size(495, 518);
            this.charactersList.MultiSelect = false;
            this.charactersList.Name = "charactersList";
            this.charactersList.Size = new System.Drawing.Size(495, 518);
            this.charactersList.TabIndex = 6;
            this.charactersList.TileSize = new System.Drawing.Size(10, 10);
            this.charactersList.UseCompatibleStateImageBehavior = false;
            this.charactersList.View = System.Windows.Forms.View.Details;
            // 
            // name
            // 
            this.name.Text = "Name";
            this.name.Width = 289;
            // 
            // Level
            // 
            this.Level.Text = "Level";
            this.Level.Width = 79;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DodgerBlue;
            this.button2.Font = new System.Drawing.Font("High Tower Text", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(1002, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(219, 66);
            this.button2.TabIndex = 7;
            this.button2.Text = "Main Menu";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Load_Character_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1233, 673);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.charactersList);
            this.Controls.Add(this.button1);
            this.DoubleBuffered = true;
            this.MaximumSize = new System.Drawing.Size(1251, 720);
            this.MinimumSize = new System.Drawing.Size(1251, 720);
            this.Name = "Load_Character_Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Load_Character_Menu";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView charactersList;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader Level;
        private System.Windows.Forms.Button button2;
    }
}