using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryFileReader
{
    public partial class ReaderFile
    {

        public String _type { get; set; }
        public String _path { get; set; } 
               
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Type"></param>
        /// <param name="Path"></param> 
        public ReaderFile(String Type, String Path)
        {
            _type = Type;
            _path = Path; 
        }

        /// <summary>
        /// 
        /// </summary>
        public void ReadContentFile()
        {
            IList<string> Content = new List<string>();

            switch (this._type)
            {
                case "TXT":
                    Content = ReadFileTxt();
                    break; 
            }

            Console.WriteLine("******************File content*************************");
            Console.WriteLine("File path : {0}", this._path);
            Console.WriteLine("File type : {0}", this._type);
            Console.WriteLine("File content : ");
            foreach (var item in Content)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("******************End Of file*************************");
        }
    }
}
