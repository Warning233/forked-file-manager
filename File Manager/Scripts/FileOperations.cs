using System;
using System.IO;
using System.Windows.Forms;
using System.IO.Compression;
using System.Diagnostics;

namespace File_Manager
{
    internal class FileOperations 
    {
        public void Delete(string source)
        {
            try
            {
                if (!source.Equals("..."))
                {
                    if (Directory.Exists(source))
                        Directory.Delete(source, true);

                    else
                        File.Delete(source);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }

        }

        public void CopyDirectory(string source, string destination, bool recursive) 
        { 
            if(Path.GetFileName(source).Equals("..."))
                return;

            if (destination[0] == '\\')
            {
                MessageBox.Show("Неверный путь!");
                return;
            }

            var dir = new DirectoryInfo(source);

            if (!dir.Exists)
                throw new DirectoryNotFoundException($"Папка не была найдена: {dir.FullName}");

            DirectoryInfo[] dirs = dir.GetDirectories();
            Directory.CreateDirectory(destination);

            foreach (FileInfo file in dir.GetFiles())
            {
                string targetFilePath = Path.Combine(destination, file.Name);
                CopyFile(file.FullName, targetFilePath);
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
            try
            {
                FileInfo inputFile = new FileInfo(source);

                using (FileStream originalFileStream = inputFile.OpenRead())
                {
                    using (FileStream outputFileStream = File.Create(destination))
                    {
                        originalFileStream.CopyTo(outputFileStream);
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        public void Copy(string source, string destination) // Distributor method
        {
            if (Directory.Exists(source))
                CopyDirectory(source, destination, true);

            else
                CopyFile(source, destination);
        } 

        public void ViewFile(string source)
        {
            Process.Start(source);
        }

        public void Rename(string oldName, string newName)
        {
            try
            {
                Microsoft.VisualBasic.FileSystem.Rename(oldName, newName);
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        public void ArchiveFile(string source)
        {
            string sourceFile = source;
            string destinationFile = Path.Combine(Path.GetDirectoryName(source), Path.GetFileNameWithoutExtension(source) + ".gz");

            if (File.Exists(source) && !Path.GetFileName(source).Equals("..."))
            {

                if (!File.Exists(destinationFile))
                    using (File.Create(destinationFile)) { }

                const int BufferSize = 16384;

                byte[] buffer = new byte[BufferSize];

                using (Stream inFileStream = File.Open(sourceFile, FileMode.Open,
                    FileAccess.Read, FileShare.Read))
                {
                    using (Stream outFileStream = File.Open(destinationFile, FileMode.Create,
                        FileAccess.Write, FileShare.None))
                    {
                        using (GZipStream gzipStream = new GZipStream(
                            outFileStream, CompressionMode.Compress))
                        {
                            Stream inStream = inFileStream;
                            Stream outStream = gzipStream;
                            int bytesRead = 0;
                            do
                            {
                                bytesRead = inStream.Read(buffer, 0, BufferSize);
                                outStream.Write(buffer, 0, bytesRead);
                            } while (bytesRead > 0);
                        }
                    }
                }
            }

            else
                MessageBox.Show("Выберите файл!");


        }

        public void Move(string source, string destination)
        {
            if (File.Exists(source))
            {
                try
                {
                    string newDestination = Path.Combine(destination, Path.GetFileName(source));
                    Copy(source, newDestination);
                    Delete(source);
                }

                catch (Exception ex) 
                {
                    MessageBox.Show($"Ошибка: {ex.Message}");
                }

            }

            
            else if (Directory.Exists(source))
            {
                try
                {
                    if (Directory.Exists(destination))
                    {
                        string newDestination = Path.Combine(destination, Path.GetFileName(source));

                        Copy(source, newDestination);
                        Delete(source);
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}");
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

            catch (Exception ex) 
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        public void RefreshList(MainWindow main, string leftPath, string rightPath)
        {
            if (leftPath != null)
                NavigateToDirectory(leftPath, main.leftLB);

            if (rightPath != null)
                NavigateToDirectory(rightPath, main.rightLB);
        }
    }
}
