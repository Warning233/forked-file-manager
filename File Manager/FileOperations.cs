using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace File_Manager
{
    internal class FileOperations 
    {
        public void Delete(string source, ListBox listBox)        // looks weird... 
        {

            if (!source.Equals("..."))
            {
                if (Directory.Exists(source))
                    Directory.Delete(source, true);

                else
                    File.Delete(source);

                listBox.Items.Remove(listBox.SelectedItems[0].ToString());

            }
        }

        public void CopyDirectory(string source, string destination, bool recursive)  // even weirder...
        { 
            if(Path.GetFileName(source).Equals("..."))
            {
                return;
            }

            var dir = new DirectoryInfo(source);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException($"Папка не была найдена: {dir.FullName}");
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            Directory.CreateDirectory(destination);

            foreach (FileInfo file in dir.GetFiles())
            {
                string targetFilePath = Path.Combine(destination, file.Name);
                file.CopyTo(targetFilePath);
            }

            if (recursive)
            {
                foreach (DirectoryInfo subDir in dirs)
                {
                    string newDestination = Path.Combine(destination, subDir.Name);
                    CopyDirectory(subDir.FullName, newDestination, true);
                }
            }
        }
        public void CopyFile(string source, string destination)
        {
            if (!Path.GetFileName(destination).Equals("..."))
            {
                File.Copy(source, destination);
            }
        }

        public void ViewFile(string source)
        {
            Process.Start(source);
        }
        
        public void Rename(string oldName, string newName)
        {
            if (Path.GetFileName(oldName).Equals("..."))
            {
                throw new Exception("Выбран неверный объект!");
            }
            
            Microsoft.VisualBasic.FileSystem.Rename(oldName, newName);
        }

        public void ArchiveFile(string source)
        {
            if (Path.GetFileName(source).Equals("..."))
            {
                throw new Exception("Выбран неверный объект!");
            }

            if (File.Exists(source))
            {
                
            }

            else
            {

            }
        }

        public void Move(string source, string destination)
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
        public void NavigateToDirectory(string source, ListBox listBox)
        {
            try
            {
                listBox.Items.Clear();
                listBox.Items.Add("...");
                DirectoryInfo directoryInfo = new DirectoryInfo(source);

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
