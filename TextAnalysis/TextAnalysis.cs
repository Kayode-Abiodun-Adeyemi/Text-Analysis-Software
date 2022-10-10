using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP
{
    // Assumptions; 
    //  Numeric and special characters are treated like space.
    //      "20th" is treated as the word "th".
    //      'I co-wrote' is treated as 3 words: 'I', 'co' and 'wrote'
    //  Words are to be treated as the uppercase version.
    //      'AMBIENT', 'Ambient' and 'ambient' are treated as "AMBIENT".
    //  Lower and upper case characters are not differentiated.
    //      'A' and 'a' are both 'A'.
    //      Special characters are ignored. Not interested in frequency of '-'.
    
   
    public class TextAnalysis
    {
        #region (Property)
        public string SelectedSubMenuOption;
        #endregion

        #region (Constructor)
        public TextAnalysis(string Text)        
        {
            string TemporaryHolder = Text;
            
        }
        #endregion

        #region (Method)
        public void TextAnalysisProcedure()   //This is the method that holds/calls all the other methods
                                              //that analalyse the selected text holistically
        {
            try
            {
                ApplicationProcessingEngine Process = new ApplicationProcessingEngine(); // Class ApplicationProcessingEngine is instantiated

                bool Confirm = true;  // variable declaration/initialisation
                while (Confirm) //  This is the loop that controls the Main Menu
                {

                    
                    Menu MainMenu = new Menu();  // This instantiate the class Menu
                    MainMenu.MainMenu();
                    string SelectedOption = Console.ReadLine();
                                        
                    int value1 = 0;  // variable declaration/initialisation
                    if (int.TryParse(SelectedOption, out value1) && !string.IsNullOrWhiteSpace(SelectedOption))
                    {
                        if (Int16.Parse(SelectedOption) == 5)
                        {
                            Environment.Exit(0);
                            Confirm = false;
                        }

                    }

                    // The validation of the option selected by the user is done here
                    ValidationErrorMessage ValidationResult = Process.MainMenuValidation(SelectedOption);

                    if (!ValidationResult.ErrorResponse) Process.MainMenuErrorMessageDisplay(ValidationResult.ErrorMessage);

                    //This code verifies if the option selected by the user is outside of the allowable option
                    ValidationErrorMessage ReturnedResult = Process.CheckRangeofOptionSelectedforMainMenu(SelectedOption);

                    //If there is error in the option selected by the user, this code displays the error message
                    if (!ReturnedResult.ErrorResponse) Process.MainMenuErrorMessageDisplay(ReturnedResult.ErrorMessage);

                    bool Condition = true;

                    while (Condition) ///This loop controls the Sub Menu and validates the option selected
                    {

                        //SubMenu Method of the Menu Class is being called
                        MainMenu.SubMenu();
                        
                        SelectedSubMenuOption = Console.ReadLine();
                        
                        //This code validates the option selected by the user in the Sub Menu
                        ValidationErrorMessage SubMenuValidationResult = Process.CheckingSubMenuValidation(SelectedSubMenuOption);

                        //if the option selected by the user has error, this code displays the error
                        if (!SubMenuValidationResult.ErrorResponse)
                        {
                            Process.SubMenuErrorMessageDisplay(SubMenuValidationResult.ErrorMessage);
                        }


                        int value;
                        //if the user selects 7, this code ensures the control return to the Main Menu
                        if (int.TryParse(SelectedSubMenuOption, out value) && !string.IsNullOrWhiteSpace(SelectedSubMenuOption))
                        {
                            if (Int16.Parse(SelectedSubMenuOption) == 7)
                            {
                                
                                Condition = false;
                                break;
                            }

                            //this code opens the selected file and read the content
                            string EquivalentText = string.Empty;
                            if (SelectedOption.Equals("1")) EquivalentText = "Text1.txt";
                            if (SelectedOption.Equals("2")) EquivalentText = "Text2.txt";
                            if (SelectedOption.Equals("3")) EquivalentText = "Text3.txt";
                            if (SelectedOption.Equals("4")) EquivalentText = "Text4.txt";

                            string[] TheReturnedWordsInsideTheFiles = Process.OpenSelectedFilesforReading(EquivalentText);
                          
                            Process.ProcessingofSubMenuSelection(TheReturnedWordsInsideTheFiles, SelectedSubMenuOption);

                        }
                    }

                }

            }

            catch (Exception ex)
            {
               
                throw ex;
            }
        }
        #endregion
    }

    public class ApplicationProcessingEngine
    {
        #region PropertiesOfTheClass
       // public string SelectedSubMenuOption;
        public string path;
        public string Userresponse = string.Empty;
        public static string UserCharresponse;
        #endregion

      #region (Methods)
       
        public ValidationErrorMessage MainMenuValidation(string option)   //This method handles validation for the Main Menu
        {
            try
            {
                ValidationErrorMessage response = new ValidationErrorMessage();

                if (string.IsNullOrEmpty(option) || (string.IsNullOrWhiteSpace(option)))
                {
                    response.ErrorResponse = false;
                    response.ErrorMessage = "You did NOT enter any value";
                    return response;
                }
                int value;

                if (int.TryParse(option, out value))
                {
                    response.ErrorResponse = true;
                    response.ErrorMessage = "Valid Input";
                    return response;
                }

                response.ErrorResponse = false;
                response.ErrorMessage = "This is an invalid entry";
                return response;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
         
                
        public ValidationErrorMessage CheckingSubMenuValidation(string option)  //This method handles validation for the Sub Menu
        {
            try
            {
                ValidationErrorMessage response = new ValidationErrorMessage();

                if (string.IsNullOrEmpty(option) || (string.IsNullOrWhiteSpace(option)))
                {
                    response.ErrorResponse = false;
                    response.ErrorMessage = "You did NOT enter any value";
                    return response;
                }
                int value;

                if (!int.TryParse(option, out value))
                {
                    response.ErrorResponse = false;
                    response.ErrorMessage = "This is an invalid entry";
                    return response;
                }

                if (Int16.Parse(option) > 0 && Int16.Parse(option) < 8)
                {
                    response.ErrorMessage = "Valid Input";
                    response.ErrorResponse = true;
                    
                }
                else
                {
                    response.ErrorResponse = false;
                    response.ErrorMessage = "The number inputted was out of range";
                }
                return response;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
                         
       public void ProcessingofSubMenuSelection(string[] WordsInsideTheFiles, string SelectedSubMenuOption)   //This method directs the processing
                                                                                                              //of the text analysis to appropriate segment
                                                                                                              //of the code depending on which option is
                                                                                                              //selected by the user
        {

            if (Int16.Parse(SelectedSubMenuOption) == 1)
            {
                //if the user selects 1, this method counts the number of words in the selected
                //text file
                int result = FrequencyofWords(WordsInsideTheFiles);
                Console.WriteLine($"The number of {Userresponse} in the selected txt file is {result}");
                Console.WriteLine("Press Any Key To Continue.............");
                Console.ReadKey();

            }
            else if (Int16.Parse(SelectedSubMenuOption) == 2)
            {
                //if the user selects 2, this method counts the number of specific character
                //in the selected text file
                int result = FrequencyofCharacter(WordsInsideTheFiles);
                Console.WriteLine($"The number of {UserCharresponse} in the selected txt file is {result}");
                Console.WriteLine("Press Any Key To Continue.............");
                Console.ReadKey();
            }
            else if (Int16.Parse(SelectedSubMenuOption) == 3)
            {
                //if the user selects 3, this method counts the number of lines in the
                //selected text file
                int result = NumberofLinesCounter(WordsInsideTheFiles);
                Console.WriteLine($"The number of lines in the selected txt file is {result}");
                Console.WriteLine("Press Any Key To Continue.............");
                Console.ReadKey();

            }
            else if (Int16.Parse(SelectedSubMenuOption) == 4)
            {
                //if the user selects 4, this method counts the number of words in the entire
                //selected text file
                int result = NumberofEntireWordsCounter(WordsInsideTheFiles);
                Console.WriteLine($"The number of words in the entire selected txt file is {result}");
                Console.WriteLine("Press Any Key To Continue.............");
                Console.ReadKey();

            }
            else if (Int16.Parse(SelectedSubMenuOption) == 5)
            {
                //if the user selects 5, this method counts the number of characters in
                //the entire selected text file
                int result = NumberofEntireCharactersCounter(WordsInsideTheFiles);
                Console.WriteLine($"The number of characters in the entire selected txt file is {result}");
                Console.WriteLine("Press Any Key To Continue.............");
                Console.ReadKey();
            }
            
            else if (Int16.Parse(SelectedSubMenuOption) == 6)
            {
                // if the user selects 6, this method will find the longest word in the
                //selected text file

                string ReturnedWordsList = LongestWordInTheContentOfFile(WordsInsideTheFiles);

                Console.WriteLine($"The longest word in the text file is =====> {ReturnedWordsList}");

                Console.WriteLine("Press Any Key To Continue.............");
                Console.ReadKey();

            }

        }
                
        public void SubMenuErrorMessageDisplay(string errorMessage)  // This menu displays the appropriate
                                                                     // error message for the Sub Menu
        {
            Console.WriteLine();
            Console.WriteLine("***********************SUB MENU ERROR MESSAGE DISPLAY**********************************************");
            Console.WriteLine($"Error Message: {errorMessage} ");
            Console.WriteLine("Press Any Key to continue.............");
            Console.WriteLine("**********************************************************************");
            Console.ReadKey();
            Console.WriteLine("========================================================");
            Console.WriteLine("========================================================");

        }
               
        public void MainMenuErrorMessageDisplay(string errorMessage)// This displays the appropriate error
                                                                    // message for the Main Menu
        {
            TextAnalysis analysis = new TextAnalysis("Text4.txt");
            Console.WriteLine();
            Console.WriteLine("***********************MAIN MENU ERROR MESSAGE DISPLAY***********************************************");
            Console.WriteLine($"Error Message: {errorMessage} ");
            Console.WriteLine("Press Any Key to continue.............");
            Console.WriteLine("**********************************************************************");
            Console.ReadKey();
            Console.WriteLine("========================================================");
            Console.WriteLine("========================================================");

            analysis.TextAnalysisProcedure();

        }        
                
        public string[] OpenSelectedFilesforReading(string InputValue)    //This method opens the
                                                                          //selected text file for reading
        {
            try
            {
                StreamHelper FilePath = new StreamHelper();
                string Path = FilePath.GetFilePath(InputValue);
               
                string[] FileContents = File.ReadAllLines(Path);
               
                Console.WriteLine("This is the content of the file selected:");
                Console.WriteLine("...........................................................................");
                foreach (string content in FileContents)
                {
                    Console.WriteLine(content);
                }
                Console.WriteLine("...........................................................................");
                return FileContents;


            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                throw e;
            }
        }       
                
        public ValidationErrorMessage CheckRangeofOptionSelectedforMainMenu(string SelectedOption)  //This method validates if the
                                                                                                    //user selects an entry outside the allowable range in the Main Menu
        {
            try
            {
                ValidationErrorMessage response = new ValidationErrorMessage();
                if (Int16.Parse(SelectedOption) > 0 && Int16.Parse(SelectedOption) < 5)
                {
                    response.ErrorMessage = "Valid Input";
                    response.ErrorResponse = true;
                    return response;
                }

                response.ErrorMessage = "Your selection was out of range";
                response.ErrorResponse = false;
                return response;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }             
        
        public ValidationErrorMessage CheckRangeofOptionSelectedforSubMenu(string SelectedOption)  //This method validates if the
                                                                                                   //user selects an entry outside the allowable range in the Sub Menu
        {
            try
            {
                ValidationErrorMessage response = new ValidationErrorMessage();

                int value;

                if (!int.TryParse(SelectedOption, out value))
                {
                    response.ErrorResponse = false;
                    response.ErrorMessage = "InValid Input";
                    return response;
                }

                if (Int16.Parse(SelectedOption) > 0 && Int16.Parse(SelectedOption) < 6)
                {
                    response.ErrorMessage = "Valid Input";
                    response.ErrorResponse = true;
                    return response;
                }

                response.ErrorMessage = "Your selection was out of range";
                response.ErrorResponse = false;
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }   
        
        public int FrequencyofWords(string[] ContentInsideTheFiles)  //This method determines the number of
                                                                     //times a specific word appeared in the selected text files

        {
            Console.Write("Please, enter the word==========>");
            Userresponse = Console.ReadLine();

            bool condition = true;

            while (condition)
            {
                if (Userresponse.Contains(" ")) //Checking to see if a word is actually entered
                {
                    Console.WriteLine("You did not enter a SINGLE word, rather you entered a statement containing multiple words. Please enter a proper SINGLE word for the search");

                    FrequencyofWords(ContentInsideTheFiles);
                }
                else if (!(Userresponse.Length > 1))
                {
                    Console.WriteLine("You entered a character instead of a word. A word contains two or more characters. Please re-enter the valid words you intend to search");
                    FrequencyofWords(ContentInsideTheFiles);
                }
                else
                {
                    condition = false;
                }
            }

            Dictionary<int, string[]> wordDictionary = new Dictionary<int, string[]>();
            wordDictionary.Add(1, ContentInsideTheFiles);

            int count = 0;

            foreach (KeyValuePair<int, string[]> kvp in wordDictionary)
            {

                foreach (var a in kvp.Value)
                {
                    
                    string[] WordsList = a.Split(new Char[] { '\'','@', '-', ' ', '?', ',', '.',
                    '+','-',')','(','%','$','#','!','*','~','<','>','?','/','|',':','&','^'},
                               StringSplitOptions.RemoveEmptyEntries);
                  
                    foreach (var b in WordsList)
                    {
                        
                        if (b.ToLower().Equals(Userresponse.ToLower()) || b.ToLower().Contains(Userresponse.ToLower()))
                        {
                            count++;
                        }

                    }
                    
                }

            }
            return count;

        }
                
        public int FrequencyofCharacter(string[] ContentInsideTheFiles)  //This method counts the number of
                                                                         //times a specific character appears in the selected text file

        {
            Console.Write("Please, enter the character============>");
            
            UserCharresponse = Console.ReadLine();
            

            bool condition = true;
            int value;
            while (condition)
            {
                
                if ((UserCharresponse.Length != 1) || (string.IsNullOrWhiteSpace(UserCharresponse)) || (int.TryParse(UserCharresponse, out value))) //Checking to see if a word is actually entered
                {
                    Console.WriteLine("You did not enter a character. Please enter a proper character for the search. A character is a single alphabet ");
                    FrequencyofCharacter(ContentInsideTheFiles);
                }
                else
                {
                    condition = false;
                }
            }

            Dictionary<int, string[]> wordDictionary = new Dictionary<int, string[]>();
            wordDictionary.Add(1, ContentInsideTheFiles);

            int count = 0;
            foreach (KeyValuePair<int, string[]> kvp in wordDictionary)
            {

                foreach (var a in kvp.Value)
                {
                    

                    foreach (var t in a)
                    {
                        string holder = t.ToString();
                        if (holder.ToLower() == UserCharresponse.ToLower()) count++;
                        
                    }
                }

            }

            return count;
        }
               
        public int NumberofLinesCounter(string[] ContentInsideTheFiles)  //This method counts the number of
                                                                         //entire lines in the selected text files

        {

            Dictionary<int, string[]> wordDictionary = new Dictionary<int, string[]>();
            wordDictionary.Add(1, ContentInsideTheFiles);

            int count = 0;
            foreach (KeyValuePair<int, string[]> kvp in wordDictionary)
            {

                foreach (var a in kvp.Value)
                {
                   
                    count++;
                }

            }

            return count;
        }       
                
        public static int NumberofEntireCharactersCounter(string[] ContentInsideTheFiles)   //This method counts the number of entire
                                                                                            //characters in the selected text files  

        {

            Dictionary<int, string[]> wordDictionary = new Dictionary<int, string[]>();
            wordDictionary.Add(1, ContentInsideTheFiles);

            int count = 0;
            foreach (KeyValuePair<int, string[]> kvp in wordDictionary)
            {

                foreach (var a in kvp.Value)
                {


                    foreach (char t in a)
                    {
                        if (!Char.IsWhiteSpace(t)) count++;

                    }
                }

            }

            return count;

        }
                
        public static int NumberofEntireWordsCounter(string[] ContentInsideTheFiles)  //This method counts the number of the
                                                                                      //entire words in the selected text file

        {

            Dictionary<int, string[]> wordDictionary = new Dictionary<int, string[]>();
            wordDictionary.Add(1, ContentInsideTheFiles);

            int count = 0;

            foreach (KeyValuePair<int, string[]> kvp in wordDictionary)
            {
                foreach (var a in kvp.Value)
                {                   
                    string[] WordsList = a.Split(new Char[] { '\'','@', '-', ' ', '?', ',', '.',
                    '+','-',')','(','%','$','#','!','*','~','<','>','?','/','|',':','&','^'}, StringSplitOptions.RemoveEmptyEntries);
                                        
                    foreach (var b in WordsList)
                    {
                        if (!string.IsNullOrWhiteSpace(b))
                            count++;
                    }

                }

            }
            return count;

        }       
                
        public static string LongestWordInTheContentOfFile(string[] ContentInsideTheFiles)   // This method finds the
                                                                                             // longest word in the selected text file

        {
            //char[] myArr;
            Dictionary<int, string[]> wordDictionary = new Dictionary<int, string[]>();
            wordDictionary.Add(1, ContentInsideTheFiles);
            // string res;
            //string[] ArrayRes;
            string word = string.Empty;
            int ctr = 0;
            List<string> list = new List<string>();

            //int count = 0;
            foreach (KeyValuePair<int, string[]> kvp in wordDictionary)
            {
                foreach (var a in kvp.Value)
                {
                    string[] WordsList = a.Split(new Char[] { '@', '-', ' ', '?', ',', '.' },
                                  StringSplitOptions.RemoveEmptyEntries);

                    foreach (String _word in WordsList)
                    {
                        if (_word.Length >= ctr)
                        {
                            word = _word;
                            ctr = _word.Length;
                        }
                    }


                }

            }

            return word;
        }
        


        //public 
        //public string ErrorMessage { get; set; }
        //public bool ErrorResponse { get; set; }

    }
    #endregion

    public class ValidationErrorMessage //This is the class that handles all error messages in the application
    {
        #region (Property)
        public string ErrorMessage { get; set; }
        public bool ErrorResponse { get; set; }
        #endregion
    }
   
}
