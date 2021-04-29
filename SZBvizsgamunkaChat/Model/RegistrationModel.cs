using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Reflection.Metadata;
using System.Text;

namespace SZBvizsgamunkaChat.Model
{
    class RegistrationModel
    {
        public UserData userData = new UserData();
        public ProfileData profileData = new ProfileData();

        public RegistrationModel() { return; }

        public byte?[] CanBeRegistered(string email,string username) => canBeRegistered(email,username,3);

        private byte?[] canBeRegistered(string email, string username, int szamlalo)
        {
            byte?[] result = new byte?[2];
            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ChatConnectionString"].ConnectionString))
                {
                    connection.Open();
                    result[0] = checkEmail(email, connection);
                    result[1] = checkUsername(username, connection);
                }
            }
            catch (MySqlException) 
            {
                result[0] = null;
                result[1] = null;
                return (--szamlalo != 0) ? canBeRegistered(email,username,szamlalo) : result; 
            } //hiba, ha mind 3x hiba, akkor null-al tér vissza  //biztos hogy nincs internet: rekurzió-t 3x próbálja meg
            catch (System.StackOverflowException)
            {
                result[0] = null;
                result[1] = null;
                return result;
            }
            return result; //minden rendben
        }

        private byte checkUsername(string username, MySqlConnection connection)
        {
            byte result = (byte)1;//ha egy akk regisztráltak ezzel a usernamel
            string sql = "SELECT Count(*) FROM user WHERE username=@usern";
            using (MySqlCommand cmd = new MySqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("@usern", username);
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    dr.Read();
                    result = (dr.GetInt32(0) == 0) ? (byte)0 : (byte)1;
                }
            }
            return result;
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

        public bool Insert()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ChatConnectionString"].ConnectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO user (username, email, password) ";
                    sql += "VALUES (@username, @email, @password); ";
                    string insert = (this.profileData.Picture != null) ? ", picture_size, picture" : String.Empty;
                    string value = (this.profileData.Picture != null) ? ", @picture_size, @picture" : String.Empty;
                    sql += $"INSERT INTO profile (user_ID, first_name, last_name, last_seen, is_encrypts_messages_id {insert}) ";
                    sql += $"VALUES ((SELECT id FROM user WHERE username=@username), @firstname, @lastname, @lastseen, @encrypt {value});";
                    
                    using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@username", userData.Username);
                        cmd.Parameters.AddWithValue("@email", userData.Email);
                        cmd.Parameters.AddWithValue("@password", userData.Password);

                        cmd.Parameters.AddWithValue("@firstname", profileData.Firstname);
                        cmd.Parameters.AddWithValue("@lastname", profileData.Lastname);
                        cmd.Parameters.AddWithValue("@lastseen", profileData.Last_Seen);
                        cmd.Parameters.AddWithValue("@encrypt", profileData.Is_encrypts_messages);
                        if (this.profileData.Picture != null)
                        {
                            cmd.Parameters.AddWithValue("@picture", profileData.Picture);
                            cmd.Parameters.AddWithValue("@picture_size", profileData.Picture_size);
                        }
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException ex) {
                string hiba = ex.Message;
                return false; } //hiba
            catch (System.StackOverflowException)
            {
                return false;
            }
            return true; //minden rendben
        }

        public class UserData
        {
            #region Fields
            string username;
            string email;
            string password;
            #endregion

            #region Properties
            public string Username
            {
                get { return username; }
                set { this.username = value; }
            }

            public string Email
            {
                get { return email; }
                set { this.email = value; }
            }

            public string Password
            {
                get { return password; }
                set { this.password = value; }
            }
            #endregion
        }

        public class ProfileData
        {
            #region Fields
            string firstname;
            string lastname;
            byte[] picture;
            #endregion

            #region Properties
            public string Firstname
            {
                get { return firstname; }
                set { this.firstname = value; }
            }

            public string Lastname
            {
                get { return lastname; }
                set { this.lastname = value; }
            }

            public byte[] Picture
            {
                get { return picture; }
                set { this.picture = value; }
            }

            public int Is_encrypts_messages
            {
                get { return 2; } //titkosítatlan
            }

            public DateTime Last_Seen
            {
                get { return DateTime.Now; }
            }

            public int Picture_size
            {
                get { return picture.Length; }
            }
            #endregion
        }
    }
}
