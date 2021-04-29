using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SZBvizsgamunkaChat.Model
{
    public class MessagesModel : INotifyPropertyChanged
    {
        public MessagesModel(int profileID) { this.profileID = profileID; }

        #region Fields
        private int profileID;
        private int currentMID;
        #endregion

        #region Properties
        public List<Messages> messagesList = new List<Messages>();
        public int CurrentMID
        {
            get { return currentMID; }
            set 
            {
                if (currentMID != value)
                {
                    currentMID = value;
                    OnPropertyChganed("CurrentMID");
                }
            }
        }
        #endregion

        #region Public Methods
        public bool Synch() => synch(3);
        public bool Insert(string Text, int isEncrypts) => insert(Text, isEncrypts, 3);
        public int Add(int UID) => add(UID,3);
        public bool Delete() => delete(3);
        public bool HasChange() => hasChange(3);

       
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Inner Class
        public class Messages : INotifyPropertyChanged
        {
            #region Fields
            private int mID;
            private int uID;
            private BitmapImage picture;
            private string profileLastSeen;
            private SolidColorBrush onlineStatus;
            private string fullname;
            #endregion

            #region Properties
            public int MID
            {
                get { return mID; }
                set 
                { 
                    if (mID != value)
                    {
                        mID = value;
                        OnPropertyChganed("MID");
                    }
                }
            }

            public int UID
            {
                get { return uID; }
                set 
                { 
                    if (uID != value)
                    {
                        uID = value;
                        OnPropertyChganed("UID");
                    }
                }
            }
            public BitmapImage Picture
            {
                get { return picture; }
                set 
                { 
                    if (picture != value)
                    {
                        picture = value;
                        OnPropertyChganed("Picture");
                    }
                }
            }
            public string ProfileLastSeen
            {
                get { return profileLastSeen; }
                set 
                { 
                    if (profileLastSeen != value)
                    {
                        profileLastSeen = value;
                        OnPropertyChganed("ProfileLastSeen");
                    }
                }
            }
            public SolidColorBrush OnlineStatus
            {
                get { return onlineStatus; }
                set 
                { 
                    if (onlineStatus != value)
                    {
                        onlineStatus = value;
                        OnPropertyChganed("OnlineStatus");
                    }
                }
            }
            public string Fullname
            {
                get { return fullname; }
                set 
                { 
                    if (fullname != value)
                    {
                        fullname = value;
                        OnPropertyChganed("Fullname");
                    }
                }
            }
            public List<Content> ContentList = new List<Content>();
            public event PropertyChangedEventHandler PropertyChanged;
            #endregion

            #region Inner Class
            public class Content
            {
                #region Fields
                private string message;
                private string messageDate;
                private bool isMy;
                private DateTime unformatedDateTime;

                #endregion

                #region Properties
                
                public string Message
                {
                    get { return message; }
                    set { message = value; }
                }
                public string MessageDate
                {
                    get { return messageDate; }
                    set { messageDate = value; }
                }
                public bool IsMy
                {
                    get { return isMy; }
                    set { isMy = value; }
                }
                public DateTime UnformatedDateTime
                {
                    get { return unformatedDateTime; }
                    set { unformatedDateTime = value; }
                }
                #endregion

                
            }
            #endregion

            #region Private Methods
            public static BitmapImage ConvertToBitMapImage(byte[] bytes)
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
        #endregion

        #region Private Methods
        private bool synch(int szamlalo)
        {
            List<Messages> temp = new List<Messages>();
            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ChatConnectionString"].ConnectionString)) 
                {
                    connection.Open();
                    temp = loadMessageBase(connection);
                    for (int i = 0; i < temp.Count; i++)
                    {
                        temp[i].ContentList = loadMessageContent(temp[i].MID, connection);
                    }
                }  
            }
            catch (MySqlException ex)
            {
                string e = ex.Message;
                return (--szamlalo != 0) ? synch(szamlalo) : false;
            } //hiba, ha mind 3x false-al tér vissza  //biztos hogy nincs internet: rekurzió
            catch (System.StackOverflowException)
            {
                return false;
            }
            messagesList = new List<Messages>(temp); //ha minden okés az uj adatot referencia nélkül adja át !!!!!
            return true; //minden rendben
        }
        private void sendActualDateTime(MySqlConnection connection)
        {
            string sql = "UPDATE profile SET last_seen = @actual_date WHERE profile.ID = @profile_id;";
            using (MySqlCommand cmd = new MySqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("@profile_id", this.profileID);
                cmd.Parameters.AddWithValue("@actual_date", DateTime.Now);
                cmd.ExecuteNonQuery();
            }
        }
        private List<Messages.Content> loadMessageContent(int mID, MySqlConnection connection)
        {
            List<Messages.Content> temp = new List<Messages.Content>();
            
            string sql = "SELECT sender_ID,body,timestamp,is_encrypts_ID FROM messages_content WHERE messages_ID=@current_MID ORDER BY messages_content.ID ASC";
            using (MySqlCommand cmd = new MySqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("@current_MID", mID);
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Messages.Content data = new Messages.Content();

                        if (dr.GetInt32("is_encrypts_ID") == 2) data.Message = (dr.IsDBNull(dr.GetOrdinal("body"))) ? String.Empty : dr.GetString("body");
                        else
                        {
                            Cipher.Vigenere vigenere = new Cipher.Vigenere((dr.IsDBNull(dr.GetOrdinal("body"))) ? String.Empty : dr.GetString("body"));
                            data.Message = vigenere.Decoding.Value;
                        }
                        
                        data.MessageDate = (((DateTime.Now - dr.GetDateTime("timestamp")).TotalDays < 1) ? dr.GetDateTime("timestamp").ToString("HH:mm") : ((DateTime.Now - dr.GetDateTime("timestamp")).TotalDays <= 7) ? dr.GetDateTime("timestamp").ToString("MMM d.") : dr.GetDateTime("timestamp").ToString("yyyy. MM. d."));
                        data.IsMy = (dr.GetInt32("sender_ID") == this.profileID) ? true : false;
                        data.UnformatedDateTime = dr.GetDateTime("timestamp"); 
                        temp.Add(data);
                    }
                }
            }
            return temp;
        }
        private List<Messages> loadMessageBase(MySqlConnection connection)
        {
            List<Messages> temp = new List<Messages>();

            SolidColorBrush green = (SolidColorBrush)new BrushConverter().ConvertFromString("#FF96CBA4");
            SolidColorBrush yellow = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF9B355");
            SolidColorBrush red = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFE2747F");

            string sql = "SELECT mes.ID as MID, profile.ID as UID, profile.picture, profile.picture_size, profile.last_seen, CONCAT(profile.first_name,' ',profile.last_name) as fullname FROM messages as mes ";
            sql += "INNER JOIN profile ON(case when (mes.sender_ID= @my_profile_id) THEN mes.receiver_ID = profile.ID ELSE mes.sender_ID = profile.ID END) WHERE mes.sender_ID = @my_profile_id or mes.receiver_ID = @my_profile_id; ";

            using (MySqlCommand cmd = new MySqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("@my_profile_id", this.profileID);
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Messages data = new Messages();

                        data.MID = dr.GetInt32("MID");
                        data.UID = dr.GetInt32("UID");
                        int fileSize = (dr.IsDBNull(dr.GetOrdinal("picture_size"))) ? 0 : (Int32)dr.GetUInt32(dr.GetOrdinal("picture_size"));
                        if (fileSize == 0) data.Picture = Messages.ConvertToBitMapImage(ImageToByteArray(Properties.Resources.defaultPicture));
                        else
                        {
                            byte[] rawData = new byte[fileSize];
                            dr.GetBytes(dr.GetOrdinal("picture"), 0, rawData, 0, fileSize);
                            data.Picture = Messages.ConvertToBitMapImage(rawData);
                        }

                        data.ProfileLastSeen = (((DateTime.Now - dr.GetDateTime("last_seen")).TotalDays <= 1) ? dr.GetDateTime("last_seen").ToString("HH:mm") : ((DateTime.Now - dr.GetDateTime("last_seen")).TotalDays <= 7) ? dr.GetDateTime("last_seen").ToString("MMM d.") : dr.GetDateTime("last_seen").ToString("yyyy. MM. d."));
                        data.OnlineStatus = (((DateTime.Now - dr.GetDateTime("last_seen")).TotalMinutes < 0.3) ? green : ((DateTime.Now - dr.GetDateTime("last_seen")).TotalMinutes < 30.0) ? yellow : red);
                        data.Fullname = dr.GetString("fullname");
                        temp.Add(data);
                    }
                }
            }

            return temp;
        }

        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }

        private bool delete(int szamlalo)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ChatConnectionString"].ConnectionString))
                {
                    connection.Open();

                    string sql = "DELETE FROM messages WHERE messages.ID = @current_MID;";
                    using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@current_MID", this.CurrentMID);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException) { return (--szamlalo != 0) ? delete(szamlalo) : false; } //hiba, ha mind 3x false-al tér vissza  //biztos hogy nincs internet: rekurzió
            catch (System.StackOverflowException)
            {
                return false;
            }
            return true; //minden rendben
        }
        private bool insert(string text, int isEncrypts, int szamlalo)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ChatConnectionString"].ConnectionString))
                {
                    connection.Open();


                    string sql = "INSERT INTO messages_content (messages_ID, sender_ID, body, timestamp, is_encrypts_ID) ";
                    sql += "VALUES (@messages_id, @sender_profile, @message, @datetime_now, @is_encrypts);";
                    using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@messages_id", this.CurrentMID);
                        cmd.Parameters.AddWithValue("@sender_profile", this.profileID);
                        if (isEncrypts == 1)
                        {
                            Cipher.Vigenere vigenere = new Cipher.Vigenere(text);
                            text = vigenere.Coding.Value;
                        }
                        cmd.Parameters.AddWithValue("@message", text);
                        cmd.Parameters.AddWithValue("@datetime_now", DateTime.Now);
                        cmd.Parameters.AddWithValue("@is_encrypts", isEncrypts);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException) { return (--szamlalo != 0) ? insert(text, isEncrypts, szamlalo) : false; } //hiba, ha mind 3x false-al tér vissza  //biztos hogy nincs internet: rekurzió
            return true; //minden rendben
        }
        private int add(int uID, int szamlalo)
        {
            int resultMID = -1;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ChatConnectionString"].ConnectionString))
                {
                    connection.Open();
                    addNewMessages(uID, connection);
                    resultMID= getMIDfromUID(uID, connection);
                }
            }
            catch (MySqlException) { return (--szamlalo != 0) ? add(uID, szamlalo) : resultMID; } //hiba, ha mind 3x -1-al tér vissza  //biztos hogy nincs internet: rekurzió
            catch (System.StackOverflowException)
            {
                return resultMID;
            }
            return resultMID; //minden rendben
        }
        private int getMIDfromUID(int uID, MySqlConnection connection)
        {
            int result = -1;
            string sql = "SELECT ID FROM messages WHERE sender_ID=@sender_UID and receiver_ID=@reciever_UID;";
            using (MySqlCommand cmd = new MySqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("@sender_UID", this.profileID);
                cmd.Parameters.AddWithValue("@reciever_UID", uID);
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                       result= dr.GetInt32("ID");
                    }
                }  
            }
            return result;
        }
        private void addNewMessages(int uID, MySqlConnection connection)
        {
            string sql = "INSERT INTO messages (sender_ID, receiver_ID) VALUES (@sender_UID, @reciever_UID);";
            using (MySqlCommand cmd = new MySqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("@sender_UID", this.profileID);
                cmd.Parameters.AddWithValue("@reciever_UID", uID);
                cmd.ExecuteNonQuery();
            }
        }
        private bool hasChange(int szamlalo)
        {
            bool result = false;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ChatConnectionString"].ConnectionString))
                {
                    connection.Open();
                    sendActualDateTime(connection);
                    getOnlineStatus(connection);
                    result= hasChangeData(connection);
                }
            }
            catch (MySqlException) { return (--szamlalo != 0) ? hasChange(szamlalo) : false; } //hiba, ha mind 3x false-al tér vissza  //biztos hogy nincs internet: rekurzió
            catch (System.StackOverflowException)
            {
                return false;
            }
            return result; //minden re
        }
        private bool hasChangeData(MySqlConnection connection)
        {
            bool result = false;
            List<Messages> temp = new List<Messages>();
            string sql = "SELECT mes.ID as MID, MAX(cont.timestamp) as date FROM messages as mes ";
            sql += "INNER JOIN messages_content as cont ON(cont.messages_ID=mes.ID) WHERE mes.sender_ID=@profile_id or mes.receiver_ID=@profile_id GROUP BY mes.ID;";
            using (MySqlCommand cmd = new MySqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("@profile_id", this.profileID);
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Messages messages = new Messages();
                        Messages.Content content = new Messages.Content();
                        messages.MID = dr.GetInt32("MID");
                        content.UnformatedDateTime = dr.GetDateTime("date");
                        messages.ContentList.Add(content);
                        temp.Add(messages);
                    }
                }
            }

            if (messagesList.Count != 0)
            {
                sortElementByMID(ref messagesList);
                sortElementByMID(ref temp);
                for (int i = 0; i < messagesList.Count; i++)
                {
                    if (messagesList.Count != temp.Count)
                    {
                        result = true;
                        break;
                    }
                    else { if (messagesList[i].ContentList[messagesList[i].ContentList.Count - 1].UnformatedDateTime < temp[i].ContentList[0].UnformatedDateTime) result = true; }
                }
            }
            else { result = true; }
            return result;
        }
        private void getOnlineStatus(MySqlConnection connection)
        {
            SolidColorBrush green = (SolidColorBrush)new BrushConverter().ConvertFromString("#FF96CBA4");
            SolidColorBrush yellow = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF9B355");
            SolidColorBrush red = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFE2747F");
            List<Messages> temp = new List<Messages>();

            string sql = "SELECT mes.ID as MID, profile.last_seen FROM messages as mes INNER JOIN profile ON(case when (mes.sender_ID= @profile_id) ";
            sql += "THEN mes.receiver_ID = profile.ID ELSE mes.sender_ID = profile.ID END) WHERE mes.sender_ID=@profile_id or mes.receiver_ID=@profile_id;";
            using (MySqlCommand cmd = new MySqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("@profile_id", this.profileID);
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Messages data = new Messages();
                        data.MID = dr.GetInt32("MID");
                        data.ProfileLastSeen = (((DateTime.Now - dr.GetDateTime("last_seen")).TotalDays <= 1) ? dr.GetDateTime("last_seen").ToString("HH:mm") : ((DateTime.Now - dr.GetDateTime("last_seen")).TotalDays <= 7) ? dr.GetDateTime("last_seen").ToString("MMM d.") : dr.GetDateTime("last_seen").ToString("yyyy. MM. d."));
                        data.OnlineStatus = (((DateTime.Now - dr.GetDateTime("last_seen")).TotalMinutes < 0.3) ? green : ((DateTime.Now - dr.GetDateTime("last_seen")).TotalMinutes < 30.0) ? yellow : red);
                        temp.Add(data);
                    }
                }
            }

            if (messagesList.Count != 0)
            {
                sortElementByMID(ref messagesList);
                sortElementByMID(ref temp);
                for (int i = 0; i < messagesList.Count; i++)
                {
                    if (messagesList.Count != temp.Count) break;
                    else
                    {
                        messagesList[i].ProfileLastSeen = temp[i].ProfileLastSeen;
                        messagesList[i].OnlineStatus = temp[i].OnlineStatus;
                    }
                }

            }
        }
        private void sortElementByMID(ref List<Messages> temp)
        {
            temp.Sort((emp1, emp2) => emp2.MID.CompareTo(emp1.MID));
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
