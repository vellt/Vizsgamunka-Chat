using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.ComponentModel;
using System.Text;
using System.Windows.Media.Imaging;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SZBvizsgamunkaChat.Model
{
    public class ProfileModel: INotifyPropertyChanged
    {
        #region Constructor
        public ProfileModel() { }
        public ProfileModel(int profileID) => this.id = profileID; 
        #endregion

        #region Fields
        private int id;
        private BitmapImage picture;
        private string firstName;
        private string lastName;
        private int isEncryptsID;
        private string email;
        private string password;
        #endregion

        #region Properties
        public int ID
        {
            get { return id; }
            set 
            {
                if (id!=value)
                {
                    id = value;
                    OnPropertyChganed("ID");
                }
            }
        }
        public BitmapImage Picture
        {
            get { return picture; }
            set 
            {
                if (picture !=value)
                {
                    picture = value;
                    OnPropertyChganed("Picture");
                }
            }
        }
        public string FirstName
        {
            get { return firstName; }
            set 
            {
                if (firstName!=value)
                {
                    firstName = value;
                    OnPropertyChganed("FirstName");
                }
            }
        }
        public string LastName
        {
            get { return lastName; }
            set 
            {
                if (lastName!=value)
                {
                    lastName = value;
                    OnPropertyChganed("LastName");
                }
            }
        }
        public int IsEncryptsID
        {
            get { return isEncryptsID; }
            set 
            {
                if (isEncryptsID!=value)
                {
                    isEncryptsID = value;
                    OnPropertyChganed("IsEncryptsID");
                }    
            }
        }
        public string Email
        {
            get { return email; }
            set 
            {
                if (email!=value)
                {
                    email = value;
                    OnPropertyChganed("Email");
                }    
            }
        }
        public string Password
        {
            get { return password; }
            set 
            {
                if (password!=value)
                {
                    password = value;
                    OnPropertyChganed("Password");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Public Methods
        public bool Synch() => synch(3);
        #endregion

        #region Private Methods
        private bool synch(int szamlalo)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ChatConnectionString"].ConnectionString))
                {
                    connection.Open();
                    string sql = "SELECT us.email, us.password, prof.first_name, prof.last_name,prof.is_encrypts_messages_ID, prof.picture,  prof.picture_size  ";
                    sql += "FROM profile as prof INNER JOIN user as us ON (us.ID=prof.user_ID) WHERE prof.ID=@profile_id;";

                    using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@profile_id", this.ID);
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            dr.Read();
                            this.Email = dr.GetString("email");
                            this.Password = dr.GetString("password");
                            this.FirstName = dr.GetString("first_name");
                            this.LastName = dr.GetString("last_name");
                            this.IsEncryptsID = dr.GetInt32("is_encrypts_messages_ID");

                            int fileSize = (dr.IsDBNull(dr.GetOrdinal("picture_size"))) ? 0 : (Int32)dr.GetUInt32(dr.GetOrdinal("picture_size"));
                            if (fileSize == 0)
                            {
                                Picture = ConvertToBitMapImage(ImageToByteArray(Properties.Resources.defaultPicture));
                            }
                            else
                            {
                                byte[] rawData = new byte[fileSize];
                                dr.GetBytes(dr.GetOrdinal("picture"), 0, rawData, 0, fileSize);
                                Picture = ConvertToBitMapImage(rawData);
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                string exV = ex.Message;
                return (--szamlalo != 0) ? synch(szamlalo) : false;
            } //hiba, ha mind 3x false-al tér vissza  //biztos hogy nincs internet: rekurzió
            catch (System.StackOverflowException)
            {
                return false;
            }
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
        private void OnPropertyChganed(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        } 
        #endregion
    }
}
