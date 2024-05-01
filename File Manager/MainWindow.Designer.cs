namespace File_Manager
{
    partial class MainWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.copyButton = new System.Windows.Forms.Button();
            this.renameButton = new System.Windows.Forms.Button();
            this.catalogButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.lFiles = new System.Windows.Forms.ListBox();
            this.rDriversBox = new System.Windows.Forms.ComboBox();
            this.lDriversBox = new System.Windows.Forms.ComboBox();
            this.rFiles = new System.Windows.Forms.ListBox();
            this.lPanel = new System.Windows.Forms.Panel();
            this.rPanel = new System.Windows.Forms.Panel();
            this.rightTBox = new System.Windows.Forms.TextBox();
            this.leftTBox = new System.Windows.Forms.TextBox();
            this.archiveButton = new System.Windows.Forms.Button();
            this.settingsButton = new System.Windows.Forms.Button();
            this.lPanel.SuspendLayout();
            this.rPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // copyButton
            // 
            this.copyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.copyButton.Location = new System.Drawing.Point(12, 638);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(200, 29);
            this.copyButton.TabIndex = 15;
            this.copyButton.Text = "F5 Copy";
            this.copyButton.UseVisualStyleBackColor = true;
            // 
            // renameButton
            // 
            this.renameButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.renameButton.Location = new System.Drawing.Point(218, 638);
            this.renameButton.Name = "renameButton";
            this.renameButton.Size = new System.Drawing.Size(200, 29);
            this.renameButton.TabIndex = 16;
            this.renameButton.Text = "F6 Rename";
            this.renameButton.UseVisualStyleBackColor = true;
            // 
            // catalogButton
            // 
            this.catalogButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.catalogButton.Location = new System.Drawing.Point(424, 638);
            this.catalogButton.Name = "catalogButton";
            this.catalogButton.Size = new System.Drawing.Size(200, 29);
            this.catalogButton.TabIndex = 17;
            this.catalogButton.Text = "F7 Move";
            this.catalogButton.UseVisualStyleBackColor = true;
            // 
            // deleteButton
            // 
            this.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteButton.Location = new System.Drawing.Point(633, 638);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(200, 29);
            this.deleteButton.TabIndex = 18;
            this.deleteButton.Text = "F8 Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // lFiles
            // 
            this.lFiles.FormattingEnabled = true;
            this.lFiles.ItemHeight = 16;
            this.lFiles.Location = new System.Drawing.Point(3, 3);
            this.lFiles.Name = "lFiles";
            this.lFiles.Size = new System.Drawing.Size(120, 84);
            this.lFiles.TabIndex = 19;
            this.lFiles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnClickFile);
            // 
            // rDriversBox
            // 
            this.rDriversBox.FormattingEnabled = true;
            this.rDriversBox.Location = new System.Drawing.Point(914, 12);
            this.rDriversBox.Name = "rDriversBox";
            this.rDriversBox.Size = new System.Drawing.Size(121, 24);
            this.rDriversBox.TabIndex = 20;
            this.rDriversBox.SelectedIndexChanged += new System.EventHandler(this.rDriversBox_SelectedIndexChanged);
            // 
            // lDriversBox
            // 
            this.lDriversBox.FormattingEnabled = true;
            this.lDriversBox.Location = new System.Drawing.Point(12, 12);
            this.lDriversBox.Name = "lDriversBox";
            this.lDriversBox.Size = new System.Drawing.Size(121, 24);
            this.lDriversBox.TabIndex = 21;
            this.lDriversBox.SelectedIndexChanged += new System.EventHandler(this.lDriversBox_SelectedIndexChanged);
            // 
            // rFiles
            // 
            this.rFiles.FormattingEnabled = true;
            this.rFiles.ItemHeight = 16;
            this.rFiles.Location = new System.Drawing.Point(3, 3);
            this.rFiles.Name = "rFiles";
            this.rFiles.Size = new System.Drawing.Size(120, 84);
            this.rFiles.TabIndex = 22;
            this.rFiles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnClickFile);
            // 
            // lPanel
            // 
            this.lPanel.Controls.Add(this.lFiles);
            this.lPanel.Location = new System.Drawing.Point(12, 77);
            this.lPanel.Name = "lPanel";
            this.lPanel.Size = new System.Drawing.Size(506, 555);
            this.lPanel.TabIndex = 23;
            // 
            // rPanel
            // 
            this.rPanel.Controls.Add(this.rFiles);
            this.rPanel.Location = new System.Drawing.Point(529, 77);
            this.rPanel.Name = "rPanel";
            this.rPanel.Size = new System.Drawing.Size(506, 555);
            this.rPanel.TabIndex = 24;
            // 
            // rightTBox
            // 
            this.rightTBox.Location = new System.Drawing.Point(529, 52);
            this.rightTBox.Name = "rightTBox";
            this.rightTBox.ReadOnly = true;
            this.rightTBox.Size = new System.Drawing.Size(506, 22);
            this.rightTBox.TabIndex = 25;
            // 
            // leftTBox
            // 
            this.leftTBox.Location = new System.Drawing.Point(12, 49);
            this.leftTBox.Name = "leftTBox";
            this.leftTBox.ReadOnly = true;
            this.leftTBox.Size = new System.Drawing.Size(506, 22);
            this.leftTBox.TabIndex = 26;
            // 
            // archiveButton
            // 
            this.archiveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.archiveButton.Location = new System.Drawing.Point(835, 638);
            this.archiveButton.Name = "archiveButton";
            this.archiveButton.Size = new System.Drawing.Size(200, 29);
            this.archiveButton.TabIndex = 27;
            this.archiveButton.Text = "F9 Archive";
            this.archiveButton.UseVisualStyleBackColor = true;
            // 
            // settingsButton
            // 
            this.settingsButton.Location = new System.Drawing.Point(532, 23);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(25, 25);
            this.settingsButton.TabIndex = 28;
            this.settingsButton.Text = "⚙️";
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 669);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.archiveButton);
            this.Controls.Add(this.leftTBox);
            this.Controls.Add(this.rightTBox);
            this.Controls.Add(this.rPanel);
            this.Controls.Add(this.rDriversBox);
            this.Controls.Add(this.lPanel);
            this.Controls.Add(this.lDriversBox);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.catalogButton);
            this.Controls.Add(this.renameButton);
            this.Controls.Add(this.copyButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "MainWindow";
            this.Text = "Form1";
            this.lPanel.ResumeLayout(false);
            this.rPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button copyButton;
        private System.Windows.Forms.Button renameButton;
        private System.Windows.Forms.Button catalogButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.ListBox lFiles;
        private System.Windows.Forms.ComboBox rDriversBox;
        private System.Windows.Forms.ComboBox lDriversBox;
        private System.Windows.Forms.ListBox rFiles;
        private System.Windows.Forms.Panel lPanel;
        private System.Windows.Forms.Panel rPanel;
        private System.Windows.Forms.TextBox rightTBox;
        private System.Windows.Forms.TextBox leftTBox;
        private System.Windows.Forms.Button archiveButton;
        private System.Windows.Forms.Button settingsButton;
    }
}

