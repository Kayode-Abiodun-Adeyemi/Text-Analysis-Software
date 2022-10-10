using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP
{
    class Program
    {
        static void Main(string[] args)
        {
            //This code was written in full alignment with OOP Principles
            //All objects were identified and broken into different classes with their attendant methods
            //The objects are now being called at the point of use.

            //analysis object is created
            TextAnalysis analysis = new TextAnalysis("Text4.txt");

            //TextAnalysisProcedure method of object analysis is called
            analysis.TextAnalysisProcedure();

            Console.Read();
        }
    }
}
