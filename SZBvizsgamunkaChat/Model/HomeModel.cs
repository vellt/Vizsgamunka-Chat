using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using System.Windows.Media.Imaging;

namespace SZBvizsgamunkaChat.Model
{
    public class HomeModel
    {
        public List<User> UsersList = new List<User>();

        public bool Synch() => synch(3); 
        private bool synch(int szamlalo)
        {
            List<User> temp = new List<User>();
            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ChatConnectionString"].ConnectionString))
                {
                    connection.Open();
                    string sql = "SELECT ID, CONCAT(first_name,' ',last_name) as name, picture_size, picture, last_seen FROM profile ORDER BY ID DESC";

                    using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                    {
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                User user = new User();
                                user.UID = dr.GetInt32("ID");
                                user.Name = dr.GetString("name");
                                int fileSize = (dr.IsDBNull(dr.GetOrdinal("picture_size"))) ? 0 : (Int32)dr.GetUInt32(dr.GetOrdinal("picture_size"));
                                if (fileSize == 0)
                                {
                                    user.Picture = ConvertToBitMapImage(ImageToByteArray(Properties.Resources.defaultPicture));
                                }
                                else
                                {
                                    byte[] rawData = new byte[fileSize];
                                    dr.GetBytes(dr.GetOrdinal("picture"), 0, rawData, 0, fileSize);
                                    user.Picture = ConvertToBitMapImage(rawData);
                                }
                                user.ProfileLastSeen = (((DateTime.Now - dr.GetDateTime("last_seen")).TotalDays <= 1) ? dr.GetDateTime("last_seen").ToString("HH:mm") : ((DateTime.Now - dr.GetDateTime("last_seen")).TotalDays <= 7) ? dr.GetDateTime("last_seen").ToString("MMM d.") : dr.GetDateTime("last_seen").ToString("yyyy. MM. d."));
                                temp.Add(user);
                            }
                        }
                    }
                }
            }
            catch (MySqlException) { return (--szamlalo != 0) ? synch(szamlalo) : false; } //hiba, ha mind 3x false-al tér vissza  //biztos hogy nincs internet: rekurzió
            catch (System.StackOverflowException)
            {
                return false;
            }
            UsersList = new List<User>(temp); //ha minden okés az uj adatot referencia nélkül adja át !!!!!
            return true; //minden rendben
        }

        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }
        private static BitmapImage ConvertToBitMapImage(byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(bytes))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            return image;
        }
        public class User
        {
            #region Fields
            private int uid;
            private string name;
            private BitmapImage picture;
            private string profileLastSeen;
            #endregion

            #region Properties
            public int UID
            {
                get { return uid; }
                set { uid = value; }
            }
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            public BitmapImage Picture
            {
                get { return picture; }
                set { picture = value; }
            }
            public string ProfileLastSeen
            {
                get { return profileLastSeen; }
                set { profileLastSeen = value; }
            }
            #endregion
        }
    }
}
