using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
 

namespace LibraryFileReader
{
    public partial class ReaderFile 
    {
        /// <summary>
        /// Text File reader function 
        /// </summary>
        /// <returns></returns>
        public IList<string> ReadFileTxt()
        {
            try
            {
                var list = new List<string>();

                var fileStream = new FileStream(this._path, FileMode.Open, FileAccess.Read);

                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        //if user want to read the encrypted file system
                        list.Add((_useEncryptedSystem == true ? Reverse(line) : line));

                    }
                }

                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.ToString());
                Console.ReadKey();
                throw;
            }
        }


        /// <summary>
        /// Simple text reversion algorithm 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string Reverse(string s)
        {
            if (s != null)
            {
                char[] charArray = s.ToCharArray();
                Array.Reverse(charArray);
                return new string(charArray);
            }
            else
                return s;

        }


    }
}
