using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP
{
    class Menu // Using this class is not compulsary
    {
        public void MainMenu()
        {
            //This is the Main Menu for the application

            Console.WriteLine("You are welcome to Text Analysis Software developed by Kayode Abiodun Adeyemi");
            Console.WriteLine("=============================================================================");
            Console.WriteLine();
            Console.WriteLine("Please, select the number corresponding to each of the file stated below for analysis:");
            Console.WriteLine("1    -   Text1.txt");
            Console.WriteLine("2    -   Text2.txt");
            Console.WriteLine("3    -   Text3.txt");
            Console.WriteLine("4    -   Text4.txt ");
            Console.WriteLine("5    -   Exit the Application ");
            Console.Write("Please enter your choice================>");


        }

        public void SubMenu()
        {
            //This is the SubMenu for the application

            Console.WriteLine("Welcome to the Sub Menu");
            Console.WriteLine();
            Console.WriteLine(">>>>>>>>>>SUB MENU<<<<<<<<<<");
            Console.WriteLine("============================");
            Console.WriteLine();
            Console.WriteLine("1  - Enter a word and see how many times it occurs in the file");
            Console.WriteLine("2  - Enter a single character and see how many times it occurs in the file");
            Console.WriteLine("3  - Get the number of lines in the entire file");
            Console.WriteLine("4 -  Get the number of words in the entire file.");
            Console.WriteLine("5 -  Get the number of characters in the entire file");
            Console.WriteLine("6 -  Get the longest word in the entire file");
            Console.WriteLine("7 -  Press to go back to main menu");
            Console.WriteLine("");
            Console.Write("Please enter your choice from the SubMenu Options================>");


        }
    }
}
