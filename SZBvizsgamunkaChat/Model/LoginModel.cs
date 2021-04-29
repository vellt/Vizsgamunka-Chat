using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace SZBvizsgamunkaChat.Model
{
    class LoginModel
    {
        public int Select()
        {
            int profID=-1;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ChatConnectionString"].ConnectionString))
                {
                    connection.Open();
                    string sql = "SELECT (CASE WHEN (a.count_number=0) THEN 0 ELSE (SELECT prof.ID FROM user as us INNER JOIN profile as prof ON (prof.user_ID=us.ID) WHERE (us.username=@usernameOrEmail OR us.email=@usernameOrEmail) ";
                    sql += "AND us.password=@password) END) as id FROM (SELECT COUNT(*) as count_number FROM user WHERE (username=@usernameOrEmail OR email=@usernameOrEmail) AND password=@password) as a";
                    using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@usernameOrEmail", UsernameOrEmail);
                        cmd.Parameters.AddWithValue("@password", Password);
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            dr.Read();
                            profID = dr.GetInt32("id");
                        }
                    }
                }
            }
            catch (MySqlException ex) {
                string s = ex.Message;
                return profID; } //hiba
            catch (System.StackOverflowException)
            {
                return profID;
            }
            return profID; //minden rendben
        }

        #region Fields
        private string usernameOrEmail;
        private string password;
        #endregion

        public string Password
        {
            get { return password; }
            set { password = value.Trim(); }
        }

        public string UsernameOrEmail
        {
            get { return usernameOrEmail; }
            set { usernameOrEmail = value.Trim(); }
        }

    }
}
