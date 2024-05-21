using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Manager
{
    [Serializable]
    public class Settings
    {
        public string Username { get; set; }
        public Font WindowFont  { get; set; }
        public Color FontColor { get; set; }
        public Color BGColor { get; set; }

        public Settings() { }

        public Settings(string username, Font font, Color fontColor, Color bgColor) 
        {
            Username = username;
            WindowFont = font;
            FontColor = fontColor;
            BGColor = bgColor;
        }
    }
}
