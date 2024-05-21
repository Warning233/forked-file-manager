using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace File_Manager
{
    public partial class AuthForm : Form
    {
        private UserManager userManager = new UserManager();
        public static string Username { get; private set; }

        public AuthForm()
        {
            InitializeComponent();
        }

        private void SignInUp_Click(object sender, EventArgs e)
        {
            Username = login.Text;
            string pass = password.Text;

            if (!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(pass))
            {
                if (userManager.Login(Username, pass))
                {
                    MessageBox.Show("Вход выполнен!");
                    Close();
                }

                else
                { 
                    userManager.SaveUser(new Users(Username, pass));

                    MessageBox.Show("Регистрация успешна!");
                    Close();
                }
            }

            else
                MessageBox.Show("Введите логин/пароль");
        }

        private void AuthForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
