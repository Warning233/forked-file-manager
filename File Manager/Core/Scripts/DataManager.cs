using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Security.Cryptography;
using System.Runtime.InteropServices.ComTypes;

namespace File_Manager
{
    public class UserManager
    {
        private List<Users> listOfUsers = new List<Users>();
        private string myDocuments = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

        public UserManager() 
        {
            listOfUsers = LoadUsers();
        }

        public void SaveUsers()
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            using (Stream fStream = new FileStream($@"{myDocuments}\\usersdata.bin",
                 FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fStream, listOfUsers);
            }
        }

        public void SaveUser(Users user) // Need better solution
        {
            listOfUsers.Add(user);
            SaveUsers();
        }

        public List<Users> LoadUsers()
        {
            List<Users> loadedUsers = new List<Users>();

            if (!File.Exists($@"{myDocuments}\\usersdata.bin"))
            {
                return loadedUsers;
            }

            BinaryFormatter binFormat = new BinaryFormatter();
            using (Stream fStream = new FileStream($@"{myDocuments}\\usersdata.bin", FileMode.Open, FileAccess.Read))
            {
                List<Users> deserializedList = binFormat.Deserialize(fStream) as List<Users>;

                foreach (var item in deserializedList)
                {
                    loadedUsers.Add(new Users(item.Name, item.Password));
                }
            }

            return loadedUsers;
        }

        public bool Login(string username, string password)
        {

            foreach (Users user in listOfUsers)
            {
                if (user.Name == username && user.Password == password)
                {
                    return true;
                }
            }
            return false;
        }
    }

    public class FileSettingsManager
    {
        private string myDocuments = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        public void SaveSettings(Settings settings)
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            using (Stream fStream = new FileStream($@"{myDocuments}\\settings.bin",
                FileMode.Append, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fStream, settings);
            }
        }

        public List<Settings> LoadSettings()
        {
            List<Settings> loadedSettings;

            if (!File.Exists($@"{myDocuments}\\settings.bin"))
            {
                return new List<Settings>();
            }

            BinaryFormatter binFormat = new BinaryFormatter();
            using (Stream fStream = new FileStream($@"{myDocuments}\\settings.bin", FileMode.Open, FileAccess.Read))
            {
                loadedSettings = new List<Settings>();

                while (fStream.Position < fStream.Length)
                {
                    Settings settings = binFormat.Deserialize(fStream) as Settings;
                    if (settings != null) 
                    {
                        loadedSettings.Add(settings);
                    }
                }
            }

            return loadedSettings;
        }
    }
}
