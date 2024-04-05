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
        /*public void CreateFolder() 
        {

        }*/
        public void Delete(string path, ListBox listBox)        // looks weird... 
        {

            if (path != "...")
            {
                if (Directory.Exists(path))
                    Directory.Delete(path, true);

                else
                    File.Delete(path);

                listBox.Items.Remove(listBox.SelectedItems[0].ToString());

            }
        }

        public bool CopyFolder(string fromPath, string toPath)  // even weirder...
        {
            if(fromPath == "..." || toPath == "...")
            {
                return false;
            }


            if (!Directory.Exists(toPath))
            {
                Directory.CreateDirectory(toPath);
            }

            string[] files = Directory.GetFiles(fromPath);
            foreach(string file in files)
            {
                string name = Path.GetFileName(file);
                string destination = Path.Combine(toPath, name);
                File.Copy(file, destination);
            }

            string[] folders = Directory.GetDirectories(fromPath);
            foreach (string folder in folders)
            {
                string name = Path.GetFileName(folder);
                string destination = Path.Combine(toPath, name);
                CopyFolder(folder, destination);
            }
            return true;
        }

        //public bool CopyFile(string fromPath, string toPath, ListBox listBox)
        //{

//        }
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
