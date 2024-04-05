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

            if (e.KeyCode == Keys.Enter && currentBox.SelectedItems.Count == 1)
            { 

                if (selectedObject == "...")
                {
                    DirectoryInfo parentDir = Directory.GetParent(currentFolder);
                    if (currentFolder == paths[0])
                    {
                        paths[0] = parentDir.FullName;
                        leftTBox.Text = paths[0];
                        currentFolder = paths[0];                   //  A simpler solution is needed here. This solution is hard to read...
                    }
                    else
                    {
                        paths[1] = parentDir.FullName;
                        rightTBox.Text = paths[1];
                        currentFolder = paths[1];
                    }

                }
                else
                {
                    if (currentFolder == paths[0])
                    { 
                        paths[0] = Path.Combine(paths[0], selectedObject);
                        leftTBox.Text = paths[0];
                        currentFolder = paths[0];                               // The same problem.
                    }
                    else
                    {
                        paths[1] = Path.Combine(paths[1], selectedObject);
                        rightTBox.Text = paths[1];
                        currentFolder = paths[1];
                    }
                }


                fileOperations.NavigateToDirectory(currentFolder, currentBox);
            }


            if(e.KeyCode == Keys.F8 && currentBox.SelectedItems.Count == 1)
            {
                DialogResult result = MessageBox.Show(
                    "Вы действительно хотите удалить этот объект?",
                    "Сообщение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);

                if (result == DialogResult.Yes)
                {
                    fileOperations.Delete(Path.Combine(currentFolder, selectedObject), currentBox);
                    currentBox.Update();
                    selectedObject = "";
                }
                TopMost = true;
            }

            if(e.KeyCode == Keys.F5 && currentBox.SelectedItems.Count == 1)
            {
                string fromPath = Path.Combine(currentFolder, selectedObject);
                string toPath = currentFolder == paths[1] ? paths[0] + selectedObject : paths[1] + selectedObject;
                

                DialogResult result = MessageBox.Show(
                    $"Копировать {Path.GetFileName(fromPath)} в {Path.GetDirectoryName(toPath)} ?",     // Maybe, here I need to define this condition in other method.
                    "Сообщение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);

                if (result == DialogResult.Yes)
                {
                    if (fileOperations.CopyFolder(fromPath, toPath))
                    {
                        MessageBox.Show("Успех!");
                        TopMost = true;
                    }
                    TopMost = true;
             
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
