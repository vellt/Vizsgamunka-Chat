using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace SZBvizsgamunkaChat.Model
{
    class SettingsModel
    {
        public SettingsModel(int profile_ID)
        {
            profile = new Profile(profile_ID);
            user = new User(profile_ID);
        }

        public Profile profile = null;
        public User user = null;

        public class Profile
        {
            public Profile(int profileID) => this.profileID = profileID;
            
            #region Fields
            private int profileID;
            private byte[] picture;
            private string firstName;
            private string lastName;
            private int? isEncryptsID;
            #endregion

            #region Properties
            public byte[] Picture
            {
                get { return picture; }
                set { picture = value; }
            }
            public string FirstName
            {
                get { return firstName; }
                set { firstName = value; }
            }
            public string LastName
            {
                get { return lastName; }
                set { lastName = value; }
            }
            public int? IsEncryptsID
            {
                get { return isEncryptsID; }
                set { isEncryptsID = value; }
            }
            #endregion

            public bool? Update() => update(3);
            private bool? update(int szamlalo)
            {
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ChatConnectionString"].ConnectionString))
                    {
                        connection.Open();
                        List<string> sqlList = new List<string>();
                        
                        string firstName = setValueWhenItIsNotNull(FirstName, "first_name = @first_name");
                        if (!String.IsNullOrEmpty(firstName)) sqlList.Add(firstName);
                        string lastName = setValueWhenItIsNotNull(LastName, "last_name = @last_name");
                        if (!String.IsNullOrEmpty(lastName)) sqlList.Add(lastName);
                        string isEncrypts = setValueWhenItIsNotNull(IsEncryptsID.ToString(), "is_encrypts_messages_ID=@encrypts_id");
                        if (!String.IsNullOrEmpty(isEncrypts)) sqlList.Add(isEncrypts);
                        string picture = setValueWhenItIsNotNull(Convert.ToString(Picture), "picture=@picture, picture_size =@picture_size");
                        if (!String.IsNullOrEmpty(picture)) sqlList.Add(picture);

                        string query = String.Empty;
                        if (sqlList.Count > 0) query = (sqlList.Count == 1) ? sqlList[0] : String.Join(", ", sqlList);
                        else return null; //lépjen ki nincs frissitendo adat
                        string sql = $"UPDATE profile SET {query} WHERE ID=@profile_id;";

                        using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                        {
                            if (!String.IsNullOrWhiteSpace(FirstName)) cmd.Parameters.AddWithValue("@first_name", this.FirstName);
                            if (!String.IsNullOrWhiteSpace(LastName)) cmd.Parameters.AddWithValue("@last_name", this.LastName);
                            if (IsEncryptsID != null) cmd.Parameters.AddWithValue("@encrypts_id", this.IsEncryptsID);
                            if (Picture != null)
                            {
                                cmd.Parameters.AddWithValue("@picture", this.Picture);
                                cmd.Parameters.AddWithValue("@picture_size", this.Picture.Length);
                            }
                            cmd.Parameters.AddWithValue("@profile_id", this.profileID);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                catch (MySqlException ex ) {
                    string hiba = ex.Message;
                    return (--szamlalo != 0) ? update(szamlalo) : false; } //hiba, ha mind 3x false-al tér vissza  //biztos hogy nincs internet: rekurzió
                catch (System.StackOverflowException)
                {
                    return false;
                }
                return true; //minden rendben
            }
            private string setValueWhenItIsNotNull(string firstName, string value)
            {
                string result = String.Empty;
                if (!String.IsNullOrEmpty(firstName))
                {
                    result = value;
                }
                return result;
            }
        }
        public class User
        {
            public User(int profileID) => this.profileID = profileID;

            #region Fields
            private int profileID;
            private string email;
            private string password;
            #endregion

            #region Properties
            public string Email
            {
                get { return email; }
                set { email = value; }
            }
            public string Password
            {
                get { return password; }
                set { password = value; }
            }
            #endregion

            public bool? Update() => update(3);
            public bool? Delete() => delete(3);

            private bool? update(int szamlalo)
            {
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ChatConnectionString"].ConnectionString))
                    {
                        connection.Open();
                        string email = (!String.IsNullOrEmpty(Email)) ? "us.email = @email_address" : String.Empty;
                        string jelszo = (!String.IsNullOrEmpty(Password)) ? "us.password = @password_text" : String.Empty;
                        byte emailResult = 0;
                        if (!String.IsNullOrEmpty(email))
                        {
                            emailResult = checkEmail(this.Email, connection); //lecsekkoljukh folgalt-e az uj email
                            if (emailResult==1)
                            {
                                email = String.Empty;
                            }
                        }
                        string vesszo = (!String.IsNullOrEmpty(email) && !String.IsNullOrEmpty(jelszo)) ? ", " : String.Empty;
                        string sql = $"UPDATE user as us INNER JOIN profile as prof ON(prof.user_ID=us.ID) SET {email} {vesszo} {jelszo}  WHERE prof.ID=@profile_id;";

                        if (!String.IsNullOrEmpty(email) && !String.IsNullOrEmpty(jelszo)) return false;//nincs adat nem frissitemn az adatbázist
                        using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                        {
                            if (!String.IsNullOrEmpty(Email)) cmd.Parameters.AddWithValue("@email_address", this.Email);
                            if (!String.IsNullOrEmpty(Password)) cmd.Parameters.AddWithValue("@password_text", this.Password);
                            cmd.Parameters.AddWithValue("@profile_id", this.profileID);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                catch (MySqlException ex) {
                    string hiba = ex.Message;
                    return (--szamlalo != 0) ? update(szamlalo) : null; } //hiba, ha mind 3x null-al tér vissza  //biztos hogy nincs internet: rekurzió
                catch (System.StackOverflowException)
                {
                    return false;
                }
                return true; //minden rendben
            }
            private byte checkEmail(string email, MySqlConnection connection)
            {
                byte result = (byte)1;//ha egy akk regisztráltak ezzel a maillal
                string sql = "SELECT Count(*) FROM user WHERE email=@email";
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        dr.Read();
                        result = (dr.GetInt32(0) == 0) ? (byte)0 : (byte)1;
                    }
                }
                return result;
            }
            private bool? delete(int szamlalo)
            {
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ChatConnectionString"].ConnectionString))
                    {
                        connection.Open();
                        string sql = "DELETE FROM user WHERE user.ID = (SELECT user_ID FROM profile WHERE ID=@profile_id);";
                        using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                        {
                            cmd.Parameters.AddWithValue("@profile_id", this.profileID);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                catch (MySqlException ex) {
                    string hiba = ex.Message;
                    return (--szamlalo != 0) ? delete(szamlalo) : false; } //hiba, ha mind 3x false-al tér vissza  //biztos hogy nincs internet: rekurzió
                catch (System.StackOverflowException)
                {
                    return false;
                }
                return true; //minden rendben
            }
        }

    }
}
