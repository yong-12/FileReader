using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;


namespace LibraryFileReader
{
    public partial class  ReaderFile
    {
        /// <summary>
        /// XML File reader function
        /// </summary>
        /// <returns></returns>
        public IList<string> ReadFileXml()
        {
            var list = new List<string>();
            XmlTextReader reader = new XmlTextReader(this._path);
            var nb = reader.AttributeCount; 

            while (reader.Read())
            {

                //if role is admin can read all the file 
                if (this._role && list.Count > this._NblimitRead) break;

                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // The node is an element.
                        list.Add("<" + reader.Name+ ">"); 
                        break;
                    case XmlNodeType.Text: //Display the text in each element.          
                        list.Add(reader.Value);
                        break;
                    case XmlNodeType.EndElement: //Display the end of the element.
                        list.Add("</" + reader.Name + ">"); 
                        break;
                }
            }
            return list;
        }
    }
}
