using System;
using System.Collections.Generic;
using System.Text;

namespace SZBvizsgamunkaChat.Cipher
{
    public class Vigenere
    {
        #region Constructor
        public Vigenere(string message)
        {
            this.message = message;
            this.Coding = new CodingMessages(this.message, this.key);
            this.Decoding = new DecodingMessages(this.message, this.key);
        }
        #endregion

        #region Fields
        private string message;
        private string key = "Vigenere";
        #endregion

        #region Properties
        public CodingMessages Coding = null;
        public DecodingMessages Decoding = null;
        #endregion

        public class CodingMessages
        {
            #region Constructor
            public CodingMessages(string message, string key)
            {
                this.message = message;
                this.key = key;
            }
            #endregion

            #region Fields
            private string message;
            private string key;
            #endregion

            #region Propertie
            public string Value
            {
                get { return coding(message); }
            }
            #endregion

            #region Method
            private string coding(string value)
            {
                string longKey = String.Empty;
                for (int i = 0; longKey.Length != value.Length; i = (i < this.key.Length - 1) ? ++i : 0)
                {
                    longKey += this.key[i];
                }

                string secretString = String.Empty;
                for (int i = 0; i < value.Length; i++)
                {
                    secretString += toltTablazat(longKey[i], value[i]);
                }

                return secretString;
            }

            private char toltTablazat(int keyChar, int textChar)
            {
                int eltolas = --keyChar;
                int[] tomb = new int[143859]; //unicode!

                for (int i = 0; i < tomb.Length; i++)
                {
                    if ((i + eltolas) < tomb.Length) tomb[i + eltolas] = i;
                    else tomb[i + eltolas - tomb.Length] = i;
                }

                return (char)tomb[textChar];
            }
            #endregion
        }

        public class DecodingMessages
        {
            #region Constructor
            public DecodingMessages(string message, string key)
            {
                this.message = message;
                this.key = key;
            }
            #endregion

            #region Fields
            private string message;
            private string key;
            #endregion

            #region Propertie
            public string Value
            {
                get { return decoding(message); }
            }
            #endregion

            #region Method
            private string decoding(string value)
            {
                string longKey = String.Empty;
                for (int i = 0; longKey.Length != message.Length; i = (i < this.key.Length - 1) ? ++i : 0)
                {
                    longKey += this.key[i];
                }

                string origString = String.Empty;
                for (int i = 0; i < value.Length; i++)
                {
                    origString += toltTablazat(longKey[i], value[i]);
                }

                return origString;
            }

            private char toltTablazat(int keyChar, int textChar)
            {
                int eltolas = --keyChar;
                int[] tomb = new int[143859]; //unicode!

                for (int i = 0; i < tomb.Length; i++)
                {
                    if ((i + eltolas) < tomb.Length) tomb[i + eltolas] = i;
                    else tomb[i + eltolas - tomb.Length] = i;
                }

                for (int i = 0; i < tomb.Length; i++)
                {
                    if (((char)tomb[i]).ToString() == ((char)textChar).ToString())
                    {
                        return (char)i;
                    }
                }
                return (char)0;
            }
            #endregion
        }
    }
}
