namespace File_Manager
{
    partial class SettingsForm
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
            this.LoadSettingsButton = new System.Windows.Forms.Button();
            this.SaveSettingsButton = new System.Windows.Forms.Button();
            this.FontButton = new System.Windows.Forms.Button();
            this.ColorButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LoadSettingsButton
            // 
            this.LoadSettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoadSettingsButton.Location = new System.Drawing.Point(12, 201);
            this.LoadSettingsButton.Name = "LoadSettingsButton";
            this.LoadSettingsButton.Size = new System.Drawing.Size(178, 35);
            this.LoadSettingsButton.TabIndex = 0;
            this.LoadSettingsButton.Text = "Загрузить настройки";
            this.LoadSettingsButton.UseVisualStyleBackColor = true;
            this.LoadSettingsButton.Click += new System.EventHandler(this.LoadSettingsButton_Click);
            // 
            // SaveSettingsButton
            // 
            this.SaveSettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveSettingsButton.Location = new System.Drawing.Point(272, 201);
            this.SaveSettingsButton.Name = "SaveSettingsButton";
            this.SaveSettingsButton.Size = new System.Drawing.Size(178, 35);
            this.SaveSettingsButton.TabIndex = 2;
            this.SaveSettingsButton.Text = "Сохранить настройки";
            this.SaveSettingsButton.UseVisualStyleBackColor = true;
            this.SaveSettingsButton.Click += new System.EventHandler(this.SaveSettingsButton_Click);
            // 
            // FontButton
            // 
            this.FontButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FontButton.Location = new System.Drawing.Point(12, 32);
            this.FontButton.Name = "FontButton";
            this.FontButton.Size = new System.Drawing.Size(159, 35);
            this.FontButton.TabIndex = 3;
            this.FontButton.Text = "Выбрать шрифт";
            this.FontButton.UseVisualStyleBackColor = true;
            this.FontButton.Click += new System.EventHandler(this.FontButton_Click);
            // 
            // ColorButton
            // 
            this.ColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColorButton.Location = new System.Drawing.Point(291, 32);
            this.ColorButton.Name = "ColorButton";
            this.ColorButton.Size = new System.Drawing.Size(159, 35);
            this.ColorButton.TabIndex = 4;
            this.ColorButton.Text = "Изменить цвет";
            this.ColorButton.UseVisualStyleBackColor = true;
            this.ColorButton.Click += new System.EventHandler(this.ColorButton_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 248);
            this.Controls.Add(this.ColorButton);
            this.Controls.Add(this.FontButton);
            this.Controls.Add(this.SaveSettingsButton);
            this.Controls.Add(this.LoadSettingsButton);
            this.Name = "SettingsForm";
            this.Text = "Настройки";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button LoadSettingsButton;
        private System.Windows.Forms.Button SaveSettingsButton;
        private System.Windows.Forms.Button FontButton;
        private System.Windows.Forms.Button ColorButton;
    }
}