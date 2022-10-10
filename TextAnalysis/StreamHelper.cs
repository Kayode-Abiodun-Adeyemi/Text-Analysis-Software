using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP
{
    class StreamHelper // Using this class is not compulsary
    {
        public string GetFilePath(string fileName)
        {
            // Returns string that represents the path to a file in
            //  the executable folder of solution
            // Executable folder is at ..\ITS\ITS\bin\Debug\netcoreapp3.1\
            return Directory.GetCurrentDirectory() + $"\\{fileName}";
        }

        public StreamReader GetReader(string fileName)
        {
            // Creates the StreamReader object, sr, using path to file
            StreamReader sr = new StreamReader(GetFilePath(fileName));
            return sr; // Returns sr
        }

        public StreamWriter GetWriter(string fileName, bool replaceFile)
        {
            // To implement ..
            // Create StreanWriter object, sw, using the path to file.
            // Note that replaceFile parameter: 
            //  if true, file not be replaced if it exists
            //  if false, it will be replaced if it exists
            StreamWriter sw = new StreamWriter(GetFilePath(fileName), replaceFile);
            return sw; // Returns sw
        }
    }
}
