using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Json;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace LibraryFileReader
{
    public partial class ReaderFile
    {

        /// <summary>
        /// JsonFile File reader function
        /// </summary>
        /// <returns></returns>
        public IList<string> ReadFileJson()
        {
            var list = new List<string>();

            string json = string.Empty;

            JArray jsonResponse = JArray.Parse(File.ReadAllText(this._path));
            
            foreach (var item in jsonResponse)
            {
                //if role is admin, he can read all the file 
                if (this._role && list.Count > this._NblimitRead) break;

                list.Add("{");
                JObject jRaces = (JObject)item;
                foreach (var rItem in jRaces)
                {
                    string rItemKey = rItem.Key;
                    string rItemValueJson = (string)rItem.Value;

                    //if user want to read the encrypted file systeme
                    rItemValueJson = (this._useEncryptedSystem == true ? Reverse(rItemValueJson) : rItemValueJson);

                    list.Add("\"" + rItemKey + "\":\"" + rItemValueJson + "\"");
                    
                }
                list.Add("}");
            } 
            return list;
        } 
    }


}

