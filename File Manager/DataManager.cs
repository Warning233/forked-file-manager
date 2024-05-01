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

        public UserManager() 
        {
            listOfUsers = LoadUsers();
        }

        public void SaveUsers()
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            using (Stream fStream = new FileStream("users.bin",
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

            if (!File.Exists("users.bin"))
            {
                return loadedUsers;
            }

            BinaryFormatter binFormat = new BinaryFormatter();
            using (Stream fStream = new FileStream("users.bin", FileMode.Open, FileAccess.Read))
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
        public void SaveSettings(Settings settings)
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            using (Stream fStream = new FileStream("settings.bin",
                FileMode.Append, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fStream, settings);
            }
        }

        public List<Settings> LoadSettings()
        {
            List<Settings> loadedSettings;

            if (!File.Exists("settings.bin"))
            {
                return new List<Settings>();
            }

            BinaryFormatter binFormat = new BinaryFormatter();
            using (Stream fStream = new FileStream("settings.bin", FileMode.Open, FileAccess.Read))
            {
                //List<Settings> deserializedPrefs = binFormat.Deserialize(fStream) as List<Settings>;

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
