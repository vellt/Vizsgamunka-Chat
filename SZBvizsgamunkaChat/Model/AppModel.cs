using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace SZBvizsgamunkaChat.Model
{
    class AppModel
    {
        public About about = new About();
        public PrivacyPolicy privacyPolicy = new PrivacyPolicy();
        public Terms terms = new Terms();
        public Help help = new Help();

        public bool Synch()
        {
            if (privacyPolicy.Synch() && terms.Synch() && help.Synch() && about.Synch()) return true;
            return false;
        }
        public class About
        {
            public List<AboutElement> List = new List<AboutElement>();
            public class AboutElement
            {
                private string header;
                private string description;

                public string Header
                {
                    get { return header; }
                    set { header = value; }
                }

                public string Description
                {
                    get { return description; }
                    set { description = value; }
                }
            }

            public bool Synch() => synch(3);
            private bool synch(int szamlalo)
            {
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ChatConnectionString"].ConnectionString))
                    {
                        connection.Open();
                        string sql = "SELECT header, description FROM about";

                        using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                        {
                            using (MySqlDataReader dr = cmd.ExecuteReader())
                            {

                                while (dr.Read())
                                {
                                    AboutElement aboutElement = new AboutElement();
                                    aboutElement.Header = (dr.IsDBNull(dr.GetOrdinal("header"))) ? String.Empty : dr.GetString("header");
                                    aboutElement.Description = (dr.IsDBNull(dr.GetOrdinal("description"))) ? String.Empty : dr.GetString("description");
                                    this.List.Add(aboutElement);
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
                return true; //minden rendben
            }
        }
        public class PrivacyPolicy
        {
            //Adatvédelem
            //header, description, list
            public List<PrivacyPolicyElement> List = new List<PrivacyPolicyElement>();
            public class PrivacyPolicyElement
            {
                private string header;
                private string description;

                public string Header
                {
                    get { return header; }
                    set { header = value; }
                }

                public string Description
                {
                    get { return description; }
                    set { description = value; }
                }
            }
            public bool Synch() => synch(3);
            private bool synch(int szamlalo)
            {
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ChatConnectionString"].ConnectionString))
                    {
                        connection.Open();
                        string sql = "SELECT header, description FROM privacy_policy";
                        
                        using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                        {
                            using (MySqlDataReader dr = cmd.ExecuteReader())
                            {
                                
                                while (dr.Read())
                                {
                                    PrivacyPolicyElement privacyPolicyElement = new PrivacyPolicyElement();
                                    privacyPolicyElement.Header = (dr.IsDBNull(dr.GetOrdinal("header"))) ? String.Empty : dr.GetString("header");
                                    privacyPolicyElement.Description = (dr.IsDBNull(dr.GetOrdinal("description"))) ? String.Empty : dr.GetString("description");
                                    this.List.Add(privacyPolicyElement);
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
        }
        public class Terms
        {
            //szabvályzat
            //header, description, list
            
            public List<TermsElement> List = new List<TermsElement>();
            public class TermsElement
            {
                private string header;
                private string description;

                public string Header
                {
                    get { return header; }
                    set { header = value; }
                }

                public string Description
                {
                    get { return description; }
                    set { description = value; }
                }
            }
            public bool Synch() => synch(3);
            private bool synch(int szamlalo)
            {
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ChatConnectionString"].ConnectionString))
                    {
                        connection.Open();
                        string sql = "SELECT header, description FROM terms";

                        using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                        {
                            using (MySqlDataReader dr = cmd.ExecuteReader())
                            {

                                while (dr.Read())
                                {
                                    TermsElement termsElement = new TermsElement();
                                    termsElement.Header = (dr.IsDBNull(dr.GetOrdinal("header"))) ? String.Empty : dr.GetString("header");
                                    termsElement.Description = (dr.IsDBNull(dr.GetOrdinal("description"))) ? String.Empty : dr.GetString("description");
                                    this.List.Add(termsElement);
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
                return true; //minden rendben
            }
        }
        public class Help
        {
            #region Properties
            public List<HelpElement> List = new List<HelpElement>();
            public bool Synch() => synch(3);
            #endregion

            #region PrivateMethods
            private bool synch(int szamlalo)
            {
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ChatConnectionString"].ConnectionString))
                    {
                        connection.Open();
                        string sql = "SELECT hg.name, h.header, h.description FROM help_group as hg INNER JOIN help as h on (h.help_group_ID=hg.ID) ORDER BY hg.id ASC";

                        using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                        {
                            using (MySqlDataReader dr = cmd.ExecuteReader())
                            {
                                while (dr.Read())
                                {
                                    HelpElement helpElement = new HelpElement();
                                    helpElement.GroupName = (dr.IsDBNull(dr.GetOrdinal("name"))) ? String.Empty : dr.GetString("name");

                                    if (!string.IsNullOrWhiteSpace(helpElement.GroupName))
                                    {
                                        int index = SearchIndexFromList(dr.GetString("name"));
                                        HelpElement.HelpContentElement helpContentElement = new HelpElement.HelpContentElement();
                                        helpContentElement.Header = (dr.IsDBNull(dr.GetOrdinal("header"))) ? String.Empty : dr.GetString("header");
                                        helpContentElement.Description = (dr.IsDBNull(dr.GetOrdinal("description"))) ? String.Empty : dr.GetString("description");
                                        if (index != -1) this.List[index].ContentList.Add(helpContentElement); //szerepel a listába
                                        else
                                        {
                                            helpElement.ContentList.Add(helpContentElement);
                                            this.List.Add(helpElement);
                                        }
                                    }
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
                return true; //minden rendben
            }
            private int SearchIndexFromList(string groupName)
            {
                for (int i = 0; i < this.List.Count; i++)
                {
                    if (this.List[i].GroupName == groupName) return i;
                }
                return -1;
            }
            #endregion

            #region InnerClass
            public class HelpElement
            {
                #region Field
                private string groupName;
                #endregion

                #region Properties
                public string GroupName
                {
                    get { return groupName; }
                    set { groupName = value; }
                }
                public List<HelpContentElement> ContentList = new List<HelpContentElement>();
                #endregion

                #region InnerClass
                public class HelpContentElement
                {
                    #region Fields
                    private string header;
                    private string description;
                    #endregion

                    #region Properties
                    public string Header
                    {
                        get { return header; }
                        set { header = value; }
                    }
                    public string Description
                    {
                        get { return description; }
                        set { description = value; }
                    }
                    #endregion
                }
                #endregion
            }
            #endregion
        }

    }
}
