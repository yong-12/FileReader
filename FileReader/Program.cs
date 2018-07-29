﻿using LibraryFileReader;
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace FileReader
{
    class Program
    {
        /// <summary>
        /// Main function of program 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        { 
            string Exit;
            do
            {
                Console.WriteLine("*******************************************");
                TypeFile:
                Console.WriteLine("Type of File (TXT) : ");
                String FileType = Console.ReadLine().ToUpper();

                if (!ValidationTypeFlie(FileType))
                {
                    Console.WriteLine("File Type invalid !");
                    goto TypeFile;
                }

                PathFile:
                Console.WriteLine("File path : ");
                String Path = Console.ReadLine();
                
                if (IsValidFilename(Path, FileType))
                {
                    Console.WriteLine("File Path  invalid !");
                    goto PathFile;
                } 

                var readFile = new ReaderFile(FileType, Path);
                readFile.ReadContentFile();

                Console.WriteLine("********************Do you want to exit the program (y/n)***********************");
                Exit = Console.ReadLine().ToUpper();

            } while (Exit.ToUpper() != "Y");

        }

        /// <summary>
        /// Function for extension File validation 
        /// </summary>
        /// <param name="FileType"></param>
        /// <returns></returns>
        public static bool ValidationTypeFlie(String FileType)
        {
            if (FileType.ToUpper().Equals("TXT"))
            {
                return true;
            }else
                return false;
        }

        /// <summary>
        /// Path & file extension function validation 
        /// File existence validation
        /// </summary>
        /// <param name="strFilePath"></param>
        /// <param name="Extension"></param>
        /// <returns></returns>
        public static bool IsValidFilename(string strFilePath, string Extension)
        {
            Regex regex = new Regex("^([a-zA-Z]:)?(\\\\[^<>:\"/\\\\|?*]+)+\\\\?$");
            if (regex.IsMatch(strFilePath) && 
                System.IO.Path.GetExtension(strFilePath).ToUpper().Equals("."+ Extension) &&
                File.Exists(strFilePath))
            { return false; }

            return true; 
        }

    }
}