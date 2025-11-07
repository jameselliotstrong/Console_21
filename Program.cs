// See https://aka.ms/new-console-template for more information
// James Strong
using System.IO.Pipes;
using System.Security.AccessControl;
using static System.Console;
using System.Collections;
internal class Program
{
    public static int RandomCard(int total, string[,] SetOfCards)
    {
        bool NotAlreadyEmpty = false;
        string Card = "";
        int Randomnumber = 0;
        while (NotAlreadyEmpty == false)
        {
            Random rnd = new Random();
            Randomnumber = rnd.Next(0, SetOfCards.GetLength(0));
            if (SetOfCards[Randomnumber, 0] != "XX")
            {
                NotAlreadyEmpty = true;
            }
        }
        Card = SetOfCards[Randomnumber, 0];
        WriteLine(Card);
        total = total + int.Parse(SetOfCards[Randomnumber, 1]);
        SetOfCards[Randomnumber, 0] = "XX";
        return total;
    }
    public static void Hit(ref int total, string[,] SetOfCards)
    {
        string args = "";
        bool end = false;
        total = RandomCard(total, SetOfCards);
        WriteLine($"Your total is {total}");
        if (total > 21)
        {
            end = true;
            return;
        }
        if (total == 21)
        {
            WriteLine($"YOU GOT 21");
            return;
        }
        if (end == false)
        {
            WriteLine("For hit press 1 ");
            WriteLine("For stand press 2 ");
            string HitOrStand = ReadLine();
            if (HitOrStand == "1")
            {
                Hit(ref total, SetOfCards);
            }
            if (HitOrStand == "2")
            {
                return;
            }
        }
    }
    public static bool Menu(bool ValidInput)
    {
        bool InitiateProgram;
        while (ValidInput == false)
        {
            string input = " ";
            bool valid = false;
            while (valid == false)
            {
                WriteLine("Enter 1 if you wish to play");
                WriteLine("Enter 2 if you wish to terminate the program");
                input = ReadLine();
                valid = ValidationChecker1_2(input);
                if (valid == false)
                {
                    WriteLine("Invalid input please try again");
                }

            }
            if (input == "1")
            {
                ValidInput = true;
                InitiateProgram = true;
                return InitiateProgram;
            }

            if (input == "2")
            {
                WriteLine("Thanks for playing!");
                WriteLine("Terminating program...");
                return false;
            }
            else
            {
                WriteLine("Invalid input");
            }
        }

        return false;
    }
    public static void WhoWon(int total, int ComputerTotal, ArrayList ComputersCards)
    {
        WriteLine("The computer cards are ...");
        for (int i = 0; i < ComputersCards.Count; i++)
        {
            WriteLine(ComputersCards[i]);
        }

        if (total == 21 && ComputerTotal != 21)
        {
            WriteLine("YOU WON WITH 21!");
        }
        else if (ComputerTotal == 21 && total != 21)
        {
            WriteLine("You lost the computer got 21");
        }
        else if (total > ComputerTotal && ComputerTotal < 21 && total < 21 )
        {
            WriteLine($"You won! the computer got {ComputerTotal} and you got {total}.");
        }
        else if (total < ComputerTotal && ComputerTotal < 21 && total < 21)
        {
            WriteLine($"You Lost:( the computer got {ComputerTotal} and you got {total}.");
        }
        else if (total > 21 && ComputerTotal < 21)
        {
            WriteLine($"You Lost:( the computer got {ComputerTotal} and you went bust.");
        }
        else if (ComputerTotal > 21 && total < 21 )
        {
            WriteLine($"You won:) the computer got {ComputerTotal} and went bust.");
        }
        else if (ComputerTotal > 21 && total > 21)
        {
            WriteLine($"It was a draw you both went bust");
        }
        else if (ComputerTotal == total)
        {
            WriteLine("It was a draw");
        }
    }

    public static bool ValidationChecker1_2(string input)
    {
        if (input == "1" || input == "2")
            {
            return true;
            }
        else return false;
        
    }

    public static bool ValidationCheckerY_N(string input)
    {
        if (input == "Y" || input == "N")
        {
            return true;
        }
        else return false;
    }
        
    public static void Main(string[] args)
    {
        string[,] SetOfCards =
        {
            { "2 of hearts", "2" }, { "3 of hearts", "3" }, { "4 of hearts", "4" }, { "5 of hearts", "5" },
            { "6 of hearts", "6" }, { "7 of hearts", "7" }, { "8 of hearts", "8" }, { "9 of hearts", "9" },
            { "Jack of Hearts", "10" }, { "Queen of Hearts", "10" }, { "King of Hearts", "10" },
            { "Ace of Hearts", "1" }, { "10 of Hearts", "10" },
            { "2 of diamonds", "2" }, { "3 of diamonds", "3" }, { "4 of diamonds", "4" }, { "5 of diamonds", "5" },
            { "6 of diamonds", "6" }, { "7 of diamonds", "7" }, { "8 of diamonds", "8" }, { "9 of diamonds", "9" },
            { "Jack of Diamonds", "10" }, { "Queen of Diamonds", "10" }, { "King of Diamonds", "10" },
            { "Ace of Diamonds", "1" }, { "10 of diamonds", "10" },
            { "2 of spades", "2" }, { "3 of spades", " " }, { "4 of spades", "4" }, { "5 of spades", "5" },
            { "6 of spades", "6" }, { "7 of spades", "7" }, { "8 of spades", "8" }, { "9 of spades", "9" },
            { "Jack of Spades", "10" }, { "Queen of Spades", "10" }, { "King of Spades", "10" },
            { "Ace of Spades", "1" }, { "10 of Spades", "10" },
            { "2 of clubs", "2" }, { "3 of clubs", "3" }, { "4 of clubs", "4" }, { "5 of clubs", "5" },
            { "6 of clubs", "6" }, { "7 of clubs", "7" }, { "8 of clubs", "8" }, { "9 of clubs", "9" },
            { "10 of clubs", "10" }, { "Jack of Clubs", "10" }, { "Queen of Clubs", "10" }, { "King of Clubs", "10" },
            { "Ace of Clubs", "10" } };
        int total = 0;
        int ComputerTotal = 0;
        bool ValidInput = false;
        bool InitiateProgram = false;
        ArrayList ComputersCards = new ArrayList();
        bool Valid;
        string HitOrStand = "";
        string input = "";
                WriteLine(
            "⠀⢀⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⣽⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣇⠀⠀⠀⠀⠀⠀⠀\n⠀⠀⠀⠀⠀⠀⠀⢠⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⣿⣿⢃⣿⢸⣿⣿⣿⣿⣿⡿⣿⢹⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣆⠀⠀⠀⠀⠀⠀\n⠀⠀⠀⠀⠀⠀⣠⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢣⣿⡏⢸⡇⢸⣿⣿⣿⣿⢻⡇⣿⠘⣿⣿⣿⣿⣿⣻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡄⠀⠀⠀⠀⠀\n⠀⠀⠀⠀⠀⣰⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡏⣼⣿⢀⡾⠀⣾⣿⣿⣿⣿⣸⠁⣿⠀⢿⣿⣿⣿⣿⡇⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡄⠀⠀⠀⠀\n⠀⠀⠀⠀⣰⣿⣿⣿⣿⣿⠟⠉⠉⠻⢿⣿⣿⣿⣿⣿⣿⣿⡿⣾⢀⣿⠇⢸⠇⢀⣿⣿⣿⣿⡇⣿⢸⣿⠂⣸⣿⣿⣿⡿⣇⠸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡄⠀⠀⠀\n⠀⠀⠀⣰⣿⠋⠁⠀⠈⠁⠀⠀⠀⠀⠀⢹⣿⣿⢿⣿⣿⣿⢧⡇⢸⡿⢀⡟⠀⢸⣿⣿⣿⡿⢀⡟⣀⣿⠀⠘⣿⣿⣿⡇⢿⠀⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⡀⠀⠀\n⠀⢀⡴⠟⠁⠀⠀⠀⠀⠀⠀⡄⠀⠀⠀⠀⢿⣿⢼⣿⣿⣟⢹⡋⢹⠏⠽⠉⠉⣿⣿⣿⡿⠃⠈⠋⢿⡿⠉⠙⣿⣿⣿⡟⠚⠗⠺⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡀⠀\n⠠⠃⠀⠀⠀⢀⠀⠀⠀⠀⠀⢷⠀⠀⠀⠀⡸⣿⣬⠭⣛⣿⣿⣿⣿⣯⣵⣒⡂⠀⠀⠀⠀⠀⠀⠀⠀⠠⠤⢖⣛⣯⣭⣽⣷⣶⡢⢍⠿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⡀\n⠀⠀⠀⠀⠀⠈⣧⠀⠀⠀⠀⠸⡇⠀⠀⠀⠀⢯⢻⣿⠋⣽⠋⣙⣿⣿⣿⣿⡟⡖⠀⠀⠀⠀⠀⠀⠀⢠⢾⠟⠛⢿⣿⣿⣿⣿⡻⣷⡭⣖⣻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷\n⠀⠀⠀⠀⠀⠀⡘⣇⠀⠀⠀⠀⢻⡄⠀⠀⠀⢸⡤⠷⠒⠋⠉⠁⠀⠈⢿⣿⡿⠀⠀⠀⠀⠀⠀⠀⠀⠸⢸⣦⣤⣼⣿⡿⠿⣿⡇⠸⠛⢃⠟⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿\n⠀⠀⠘⡄⠀⠀⠀⠸⣆⣀⣠⠬⠿⢷⠀⣀⠀⠊⡇⠀⠀⠰⠀⠀⠀⠀⢸⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢿⣽⣿⣿⣷⡀⠈⠁⠀⣀⡾⢀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿\n⠀⠀⠀⢹⡀⡴⠒⠋⠉⠀⢀⠀⣀⣸⣦⢀⠱⠄⢷⣄⡀⠀⠀⢆⡀⠀⠈⢇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠛⠛⠉⠙⠛⠁⠀⠀⡞⣤⣂⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿\n⠁⠀⠀⠀⢿⡇⣐⡆⠀⠀⠸⣿⣿⠿⢷⢰⠾⠶⣼⠛⠛⠷⣄⠈⡇⠀⠀⢸⡄⠀⠀⠀⠀⠀⣦⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣸⣷⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿\n⠀⢧⡀⣀⠐⢿⠙⣷⠀⠀⠀⢻⠀⠀⠺⣼⠀⠀⢸⡦⠂⠀⠈⠃⢿⡄⠀⠠⢧⠀⠀⠀⠀⠀⠀⠀⠀⢀⣀⡀⠀⠀⠀⠀⠀⠀⣰⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿\n⠀⠀⠻⣵⠖⠸⡇⢹⡄⠀⠀⠘⡇⠀⣾⣿⣤⣀⣼⣁⡀⠀⠀⢠⣾⣿⣄⠀⢸⡅⠀⠀⠰⠲⠶⠄⣰⠋⠀⠈⠉⠒⠒⠤⢄⣰⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿\n⠀⠀⠀⠹⣏⡀⢹⠈⣷⡀⠀⠀⢻⡀⣿⢛⣿⢿⣿⣿⣿⣷⡀⠀⢹⣿⣿⠀⠀⢳⠀⠀⠀⠀⠀⢺⡇⢠⣦⠀⠀⠀⠀⠀⠀⠀⠈⠉⠛⠻⠿⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿\n⠀⠀⠦⣄⣈⣻⣾⡇⠙⠓⠂⠀⠘⣇⠹⣿⣽⣿⣿⣿⣿⣿⣿⣄⣿⣿⣿⣷⣤⠘⡆⠀⠀⠀⠀⡼⢀⡚⠽⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠉⠛⠛⢿⣿⣿⣿⣿⣿⣿⣿\n⣤⡀⠀⠀⠉⠉⠋⢻⡀⠀⠀⠀⠀⡽⣶⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣧⠀⢱⣀⠀⠀⣰⡇⠸⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣿⣿⣿⣿⣿⣿⣿\n⣿⣿⣦⡀⠀⠀⠀⠀⣇⠀⠀⠀⢠⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡟⠂⠘⣯⣽⣲⡿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣾⣿⣿⣿⣿⣿⣿⣿\n⣿⣿⣿⣿⣦⣄⠀⣀⣼⡀⠀⠀⣿⣿⣧⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡀⡀⡀⢹⣿⣿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢰⣿⣿⣿⣿⣿⣿⣿⣿\n⣾⣿⣿⣿⣿⣿⣿⣿⣿⣇⠀⠀⠉⠙⣻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣟⠁⠹⣇⠀⣿⡟⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣾⣿⣿⣿⣿⣿⣯⣿⣿\n⣿⣽⡿⣿⣿⣿⣿⣿⣿⣿⡄⠀⠀⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠁⠀⢿⡆⢸⡁⠀⠀⠀⠀⠀⠀⠀⠀⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢰⣿⣿⣿⣿⣿⣿⣿⡿⣿\n⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣇⠀⠀⠀⠸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠇⠀⠀⠐⣿⡀⣇⠀⠀⠀⠀⠀⠀⠀⢺⣿⣿⣿⣷⠄⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿\n⣿⣻⣿⣿⣿⣿⣿⣿⣿⣿⣿⡀⠀⠀⠀⢨⣿⣿⣿⣿⣿⣿⣿⣿⣿⠏⠀⠀⠀⠀⠀⢹⠇⠸⡄⠀⠀⠀⠀⠀⠀⠘⣿⣿⡿⠋⠀⠀⠀⠀⠀⠀⠀⠀⣸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿\n⣭⣷⣿⢿⣿⣿⣿⣿⣿⣿⣿⣧⠀⠀⠀⠀⠛⢿⠟⢻⣿⣿⣿⡟⠁⠀⠀⠀⠀⠀⠀⠈⠁⢀⡇⠀⠀⠀⠀⠀⠀⠀⠙⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⢿⣿\n⣿⣯⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⡄⠀⠀⠀⠀⠸⡇⠘⠻⠿⣿⡀⠀⠀⠀⢀⣀⣠⣤⠖⠒⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿\n⣞⢿⢼⣿⣿⣽⣿⣿⣿⣿⣿⣿⣷⠀⠀⠀⠀⠀⠛⠆⣀⣠⠤⠴⡖⣺⠯⣻⠟⠛⢇⠀⠀⣀⡗⠙⢳⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣏\n⣿⣝⣽⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣦⣤⣤⣴⣶⣿⣿⡿⠁⠀⠀⠠⣿⣴⡇⢀⢀⢸⡆⠀⣿⡇⠀⡁⢹⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣼⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠋\n⣿⣾⣷⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠋⠀⠀⠁⣴⡟⢱⡏⠉⠓⠚⠋⣇⠶⡇⠻⠾⠛⠉⢹⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⠀⢠⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀!");
        WriteLine("Welcome to 21!");

        InitiateProgram = Menu(InitiateProgram);
        if (InitiateProgram == true)
        {
            Clear();
            WriteLine("Welcome to the game!");
            WriteLine("Let's deal your cards");
            for (int i = 0; i <= 1; i++)
            { 
               total = RandomCard(total, SetOfCards);
                
            }
            WriteLine(total.ToString());
            
            for(int i = 0; i <= 1; i++)
            {        
                bool NotAlreadyEmpty = false;
                string Card = "";
                int Randomnumber = 0;
                while (NotAlreadyEmpty == false)
                {
                    Random rnd = new Random();
                    Randomnumber = rnd.Next(0, SetOfCards.GetLength(0));
                    if (SetOfCards[Randomnumber, 0] != "XX")
                    {
                        NotAlreadyEmpty = true;
                    }
                }
                ComputersCards.Add(SetOfCards[Randomnumber, 0]);
                ComputerTotal = ComputerTotal + int.Parse(SetOfCards[Randomnumber, 1]);
                SetOfCards[Randomnumber, 0] = "XX";
            }

            while (ComputerTotal < 17)
            {
                bool NotAlreadyEmpty = false;
                string Card = "";
                int Randomnumber = 0;
                while (NotAlreadyEmpty == false)
                {
                    Random rnd = new Random();
                    Randomnumber = rnd.Next(0, SetOfCards.GetLength(0));
                    if (SetOfCards[Randomnumber, 0] != "XX")
                    {
                        NotAlreadyEmpty = true;
                    }
                }
                ComputersCards.Add(SetOfCards[Randomnumber, 0]);
                ComputerTotal = ComputerTotal + int.Parse(SetOfCards[Randomnumber, 1]);
                SetOfCards[Randomnumber, 0] = "XX";
            }

            Valid = false;
            while (Valid == false)
            {
                WriteLine("For hit press 1 ");
                WriteLine("For stand press 2 ");
                HitOrStand = ReadLine();
                Valid = ValidationChecker1_2(HitOrStand);
                if (Valid == false)
                {
                    WriteLine("InValid Input Please try again ");
                }
            }
            if (HitOrStand == "1")
            {
                Hit(ref total, SetOfCards);
            }
            if (HitOrStand == "2")
            {}
            WhoWon(total,ComputerTotal, ComputersCards);
            Valid = false;
            while (Valid == false)
            {
                WriteLine("Would you like to play again? Y/N");
                input = ReadLine().ToUpper();
                if (ValidationCheckerY_N(input) == true)
                {
                    Valid = true;
                }
                else
                {
                    WriteLine("Invalid Input Please try again .");
                }

            }
            if (input == "Y")
            {
                WriteLine("Returning to Main Menu.....");
                Main(args);
            }
            else
            {
                WriteLine("Thanks for playing!");
            }

        }
    }
}
