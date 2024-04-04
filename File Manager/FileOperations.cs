using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace File_Manager
{
    internal class FileOperations 
    { 
        /*public void CreateFolder() 
        {

        }*/
        public void Delete(string path, ListBox listBox) 
        {
            if (path != "..." && Directory.Exists(path))
            {
                Directory.Delete(path, true);
                listBox.Items.Remove(listBox.SelectedItems[0].ToString());
            }
            else if (path != "...")
            {
                File.Delete(path);
                Console.Write(listBox.Items);
            }
        }   
        public void CopyFile() { }
        public void EditFile() { }
        public void ViewFile() { }
        public void MoveFile() { }
        public void NavigateToDirectory(string path, ListBox listBox)
        {
            listBox.Items.Clear();

            listBox.Items.Add("...");

            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                foreach (var directory in directoryInfo.EnumerateDirectories("*", SearchOption.TopDirectoryOnly))
                {
                    listBox.Items.Add(directory.Name);
                }

                foreach (var file in directoryInfo.EnumerateFiles("*", SearchOption.TopDirectoryOnly))
                {
                    listBox.Items.Add(file.Name);
                }
            }
            catch (Exception ex) {}
        }

    }
}
