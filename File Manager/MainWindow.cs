using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ScrollBar;
using System.Windows;

namespace File_Manager
{
    public partial class MainWindow : Form
    {
        private FileOperations fileOperations = new FileOperations();
        private string[] paths = new string[2];

        public MainWindow()
        {
            InitializeComponent();
            DriveInfo[] drives = DriveInfo.GetDrives();
            lFiles.Size = lPanel.Size;
            rFiles.Size = rPanel.Size;

            foreach (DriveInfo drive in drives)
            {
                lDriversBox.Items.Add(drive.Name);
                rDriversBox.Items.Add(drive.Name);
            }
        }


        private void OnClickFile(object sender, KeyEventArgs e)
        {
            ListBox currentBox = sender as ListBox;
            string currentFolder = currentBox == lFiles ? paths[0] : paths[1];
            string selectedObject = currentBox.SelectedItems[0].ToString();

            if (currentBox.SelectedItems.Count == 1)
            {

                if (e.KeyCode == Keys.Enter)
                {
                    DirectoryInfo parentDirectory = Directory.GetParent(currentFolder);
                    string newPath;

                    if (selectedObject.Equals("..."))
                    {
                        if (currentFolder == paths[0])
                        {
                            parentDirectory = Directory.GetParent(paths[0]);
                            newPath = parentDirectory != null ? parentDirectory.FullName : paths[0];
                        }
                        else
                        {
                            parentDirectory = Directory.GetParent(paths[1]);
                            newPath = parentDirectory != null ? parentDirectory.FullName : paths[1];
                        }
                    }

                    else
                    {
                        newPath = (currentFolder == paths[0]) ? Path.Combine(paths[0], selectedObject) : Path.Combine(paths[1], selectedObject);
                    }

                    if (currentBox == lFiles)
                    {
                        paths[0] = newPath;
                        leftTBox.Text = paths[0];
                    }
                    else
                    {
                        paths[1] = newPath;
                        rightTBox.Text = paths[1];
                    }

                    currentFolder = newPath;
                    fileOperations.NavigateToDirectory(currentFolder, currentBox);
                }

                if (e.KeyCode == Keys.F8)
                {
                    string query = $"Вы действительно хотите удалить этот объект '{selectedObject}' ?";

                    if (MessageBox.Show(query, "Удалить?",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        fileOperations.Delete(Path.Combine(currentFolder, selectedObject), currentBox);
                        currentBox.Update();
                        selectedObject = "";
                    }
                    TopMost = true;
                }

                if (e.KeyCode == Keys.F7)
                {
                    string source = Path.Combine(currentFolder, selectedObject);
                    string destination = currentFolder == paths[1] ? paths[0] : paths[1];

                    string query = $"Переместить {Path.GetFileName(source)} в {destination} ?";

                    if (MessageBox.Show(query, "Переместить?",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        fileOperations.Move(source, destination, currentBox);
                    }
                }

                if(e.KeyCode == Keys.F6)
                {

                }

                if (e.KeyCode == Keys.F5)
                {
                    string fromPath = Path.Combine(currentFolder, selectedObject);
                    string toPath = currentFolder == paths[1] ? paths[0] + selectedObject : paths[1] + selectedObject;

                    string query = $"Копировать {Path.GetFileName(fromPath)} в {Path.GetDirectoryName(toPath)} ?";

                    if (MessageBox.Show(query, "Копировать?",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (fileOperations.CopyFolder(fromPath, toPath, currentBox))
                        {
                            MessageBox.Show("Успех!");
                            TopMost = true;
                        }
                        TopMost = true;
                    }
                }
                
            }

        }

        private void lDriversBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            paths[0] = lDriversBox.Text;
            fileOperations.NavigateToDirectory(paths[0], lFiles);
            leftTBox.Text = paths[0];
        }

        private void rDriversBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            paths[1] = rDriversBox.Text;
            fileOperations.NavigateToDirectory(paths[1], rFiles);
            rightTBox.Text = paths[1];
        }
    }
}
