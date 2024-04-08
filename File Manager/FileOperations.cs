using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace File_Manager
{
    internal class FileOperations 
    {
        public void Delete(string source, ListBox listBox)        // looks weird... 
        {

            if (source != "...")
            {
                if (Directory.Exists(source))
                    Directory.Delete(source, true);

                else
                    File.Delete(source);

                listBox.Items.Remove(listBox.SelectedItems[0].ToString());

            }
        }

        public bool CopyFolder(string source, string destination, ListBox listBox)  // even weirder...
        {
            if(source == "..." || destination == "...")
            {
                return false;
            }


            if (!Directory.Exists(destination))
            {
                Directory.CreateDirectory(destination);
            }

            string[] files = Directory.GetFiles(source);
            foreach(string file in files)
            {
                string name = Path.GetFileName(file);
                string dest = Path.Combine(destination, name);
                File.Copy(file, dest);
            }

            string[] folders = Directory.GetDirectories(source);
            foreach (string folder in folders)
            {
                string name = Path.GetFileName(folder);
                string dest = Path.Combine(destination, name);
                CopyFolder(folder, dest, listBox);
            }
            return true;
        }

        //public void EditFile() { }
        //public void ViewFile() { }

        public void Move(string source, string destination, ListBox listBox)
        {
            if (File.Exists(source))
            {
                try
                {
                    File.Move(source, destination);
                }

                catch (Exception ex) 
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }

            }

            
            else if (Directory.Exists(source))
            {
                try
                {
                    if (Directory.Exists(destination))
                    {
                        string newDestination = Path.Combine(destination, Path.GetFileName(source));
                        Directory.Move(source, newDestination);
                    }
                }

                catch(Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
        }
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
