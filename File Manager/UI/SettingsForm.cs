using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace File_Manager
{
    public partial class SettingsForm : Form
    {
        private FileSettingsManager fileSettingsManager = new FileSettingsManager();
        public static Color BGColor { get; private set; }
        public static Font FormFont { get; private set; } 
        public static Color FontColor { get; private set; }

        public SettingsForm()
        {
            InitializeComponent();
        }

        private void FontButton_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.ShowColor = true;
            
            if (fontDialog.ShowDialog() == DialogResult.OK )
            {
                FormFont = fontDialog.Font;
                FontColor = fontDialog.Color;
                ApplyFontToAllForms();
            }
        }

        private void ColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                BGColor = colorDialog.Color;
                ApplyColorToAllForms();
            }
        }

        private void SaveSettingsButton_Click(object sender, EventArgs e)
        {
            fileSettingsManager.SaveSettings(new Settings(AuthForm.Username, FormFont, FontColor, BGColor));
        }

        private void LoadSettingsButton_Click(object sender, EventArgs e)
        {
            var settings = fileSettingsManager.LoadSettings().Where(s => s.Username.Equals(AuthForm.Username));

            foreach (var item in settings)
            {
                BGColor = item.BGColor;
                FormFont = item.WindowFont;
                FontColor = item.FontColor;
            }

            ApplyFontToAllForms();
            ApplyColorToAllForms();
        }


        private void ApplyColorToAllForms()
        {
            foreach (Form form in Application.OpenForms)
            {
                form.BackColor = BGColor;
            }
        }

        private void ApplyFontToAllForms()
        {
            foreach (Form form in Application.OpenForms)
            {
                form.Font = FormFont;
                form.ForeColor = FontColor;
                ApplyFontToAllControls(form.Controls);
            }
        }

        private void ApplyFontToAllControls(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                control.Font = FormFont;
                control.ForeColor = FontColor;
                if (control.HasChildren)
                {
                    ApplyFontToAllControls(control.Controls);
                }
            }
        }
    }
}
