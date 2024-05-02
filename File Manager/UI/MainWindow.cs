using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ScrollBar;
using System.Windows;

namespace File_Manager
{
    public partial class MainWindow : Form
    {

        private FileOperations fileOperations = new FileOperations();
        private SettingsForm settingsForm = new SettingsForm();
        private string[] paths = new string[2];
        
        public ListBox leftLB { get; private set; }
        public ListBox rightLB { get; private set; } 

        public MainWindow()

        {
            InitializeComponent();

            leftLB = lFiles;
            rightLB = rFiles;

            DriveInfo[] drives = DriveInfo.GetDrives();
            leftLB.Size = lPanel.Size;
            rightLB.Size = rPanel.Size;

            foreach (DriveInfo drive in drives)
            {
                lDriversBox.Items.Add(drive.Name);
                rDriversBox.Items.Add(drive.Name);
            }
        }


        private void OnClickFile(object sender, KeyEventArgs e)
        {
            ListBox currentBox = sender as ListBox;
            string currentFolder = currentBox == leftLB ? paths[0] : paths[1];
            string selectedObject = default;

            try
            {
                selectedObject = currentBox.SelectedItems[0].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            } // lol)

            /*if (currentBox.SelectedItems.Count == 1)
            {

                if (e.KeyCode == Keys.Enter)
                {
                    DirectoryInfo parentDirectory = Directory.GetParent(currentFolder);
                    string newPath;

                    if (File.Exists(Path.Combine(currentFolder, selectedObject)))
                    {
                        fileOperations.ViewFile(Path.Combine(currentFolder, selectedObject));
                        return;
                    }

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

                    if (currentBox == leftLB)
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

                if(e.KeyCode == Keys.F9)
                {
                    string source = Path.Combine(currentFolder, selectedObject);
                    fileOperations.ArchiveFile(source);
                }

                if (e.KeyCode == Keys.F8)
                {
                    string query = $"Вы действительно хотите удалить этот объект '{selectedObject}' ?";

                    if (MessageBox.Show(query, "Удалить?",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        fileOperations.Delete(Path.Combine(currentFolder, selectedObject));
                        selectedObject = "";
                    }
                    TopMost = true;
                }

                if (e.KeyCode == Keys.F7)
                {
                    string source = Path.Combine(currentFolder, selectedObject);
                    string destination = (currentFolder == paths[1] ? paths[0] : paths[1]) + "\\";

                    string query = $"Переместить {Path.GetFileName(source)} в {destination} ?";

                    if (MessageBox.Show(query, "Переместить?",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        fileOperations.Move(source, destination);
                    }
                }

                if (e.KeyCode == Keys.F6)
                {
                    string result = Microsoft.VisualBasic.Interaction.InputBox("Введите новое имя:");
                    string oldName = Path.Combine(currentFolder, selectedObject);
                    string newName = Path.Combine(currentFolder, result);

                    fileOperations.Rename(oldName, newName);
                }

                if (e.KeyCode == Keys.F5)
                {
                    string source = Path.Combine(currentFolder, selectedObject);
                    string destination = currentFolder == paths[1] ? paths[0] + "\\" + selectedObject : paths[1] + '\\' + selectedObject;
                    string query = $"Копировать {Path.GetFileName(source)} в {Path.GetDirectoryName(destination)} ?";

                    if(MessageBox.Show(query, "Копировать?",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        fileOperations.Copy(source, destination);
                    }
                }

                fileOperations.RefreshList(this, paths[0], paths[1]);

            }*/ // Old realization.


            if (currentBox.SelectedItems.Count == 1)
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        DirectoryInfo parentDirectory = Directory.GetParent(currentFolder);
                        string newPath;

                        if (File.Exists(Path.Combine(currentFolder, selectedObject)))
                        {
                            fileOperations.ViewFile(Path.Combine(currentFolder, selectedObject));
                            return;
                        }

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
                            newPath = (currentFolder == paths[0]) ? Path.Combine(paths[0], selectedObject) : Path.Combine(paths[1], selectedObject);

                        if (currentBox == leftLB)
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
                        break;

                    case Keys.F9:
                        string source = Path.Combine(currentFolder, selectedObject);
                        fileOperations.ArchiveFile(source);
                        break;

                    case Keys.F8:
                        string query = $"Вы действительно хотите удалить этот объект '{selectedObject}' ?";

                        if (MessageBox.Show(query, "Удалить?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            fileOperations.Delete(Path.Combine(currentFolder, selectedObject));
                            selectedObject = "";
                        }

                        TopMost = true;
                        break;

                    case Keys.F7:
                        string sourceMove = Path.Combine(currentFolder, selectedObject);
                        string destinationMove = (currentFolder == paths[1] ? paths[0] : paths[1]) + "\\";

                        string queryMove = $"Переместить {Path.GetFileName(sourceMove)} в {destinationMove} ?";

                        if (MessageBox.Show(queryMove, "Переместить?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            fileOperations.Move(sourceMove, destinationMove);

                        break;

                    case Keys.F6:
                        string result = Microsoft.VisualBasic.Interaction.InputBox("Введите новое имя:");
                        string oldName = Path.Combine(currentFolder, selectedObject);
                        string newName = Path.Combine(currentFolder, result);

                        fileOperations.Rename(oldName, newName);
                        break;

                    case Keys.F5:
                        string sourceCopy = Path.Combine(currentFolder, selectedObject);
                        string destinationCopy = currentFolder == paths[1] ? paths[0] + "\\" + selectedObject : paths[1] + '\\' + selectedObject;
                        string queryCopy = $"Копировать {Path.GetFileName(sourceCopy)} в {Path.GetDirectoryName(destinationCopy)} ?";

                        if (MessageBox.Show(queryCopy, "Копировать?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            fileOperations.Copy(sourceCopy, destinationCopy);

                        break;
                }

                fileOperations.RefreshList(this, paths[0], paths[1]);
            } // Idk if this works


        }


        private void lDriversBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            paths[0] = lDriversBox.Text;
            fileOperations.NavigateToDirectory(paths[0], leftLB);
            leftTBox.Text = paths[0];
        }

        private void rDriversBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            paths[1] = rDriversBox.Text;
            fileOperations.NavigateToDirectory(paths[1], rightLB);
            rightTBox.Text = paths[1];
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            settingsForm.ShowDialog();
        }
    }
}
