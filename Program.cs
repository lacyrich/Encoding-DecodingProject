using System;

using System.IO;

namespace file_lab_lacyrich
{
    class Program
    {
        static void Main(string[] args)
        {
            string userChoice = "";
            while(userChoice != "4")
            {
                DisplayMenu(); 
                userChoice = Console.ReadLine();
                RouteEm(userChoice);
            }
        }
        
        static void DisplayMenu()
        {
            System.Console.WriteLine("1) Encode\n2) Decode\n3) Word Count\n4) Exit"); //tells user their choices
        }
        static void RouteEm(string userChoice)
        {
            switch(userChoice)
            {
                case "1":
                    GoForward(); //encodes file
                    break;

                case "2":
                    GoBackwards(); //decodes file
                    break;
                
                case "3":
                    WordCount(); //counts total words in file
                    break;

                case "4":
                    System.Console.WriteLine("Bye bye"); //exits program
                    break;

                default:
                    System.Console.WriteLine("Invalid Choice");
                    break;
            }
        }

        static void Encode()
        {
            System.Console.WriteLine("Please enter an input file");
            string inputFile = Console.ReadLine();
            System.Console.WriteLine("Please enter file to save to");
            string outputFile = Console.ReadLine();

            EncodeIt(ref inputFile, ref outputFile);
        }

        static void GoForward()
        {
            Console.WriteLine("Welcome to our encode method");
            Encode();
        }

        static void GoBackwards()
        {
            Console.WriteLine("Welcome to our decode method");
            Encode();
        }

        static void EncodeIt(ref string inputFile, ref string outputFile)
        {
            StreamReader inFile = new StreamReader(inputFile);
            StreamWriter outFile = new StreamWriter(outputFile);

            string line = inFile.ReadLine(); //prime

            while(line != null)
            {
                outFile.WriteLine(TransformIt(line));
                line = inFile.ReadLine();
            }

            inFile.Close();
            outFile.Close();
        }

        static string TransformIt(string line)
        {
            string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            string newLine = " ";

            line = line.ToUpper();

            for(int i = 0; i < line.Length; i++)
            {
                int found = -1;
                for(int j = 0; j < letters.Length; j++)
                {
                    if(line[i] == letters[j])
                    {
                        found = j;
                    }
                }
                if(found == -1)
                {
                    newLine += line[i];
                }
                else
                {
                    newLine += letters[((found + 13)%26)];
                }
            }

            return newLine;
        }

        static void WordCount()
        {
            System.Console.WriteLine("Name of the input file");
            string fileName = Console.ReadLine();

            StreamReader inFile = new StreamReader(fileName); //read

            string line = inFile.ReadLine(); //prime
            int count = 0;
            while(line != null) //condition
            {
                string[] temp = line.Split(" ");
                count+= temp.Length;

                line = inFile.ReadLine(); //update
            }

            inFile.Close(); //close
            System.Console.WriteLine($"File contains {count} words");
        }

    }
}
