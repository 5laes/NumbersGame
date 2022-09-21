using System;

namespace NumbersGame
{
    class Program
    {        
        static void Main(string[] args)
        {
            bool menu = true;
            Random random = new Random();
            int hiddenNumber;

            //detta är em while loop som gör att "menyn" inte stängs ner
            while (menu == true)
            {
                Console.Clear();
                Console.WriteLine("LOOOOOOOOOOOOOOOOOL");
                Console.Write("\n\tVälkommen till Gissa Numret spelet!" +
                    "\n\tVälj svårighetsgrad!" +
                    "\n\t[1] Lätt   (Gissa mellan 1-20, 10 försök)" +
                    "\n\t[2] Mellan (Gissa mellan 1-30, 8 försök)" +
                    "\n\t[3] Svår   (Gissa mellan 1-40, 5 försök)" +
                    "\n\t[4] Egna inställningar" +
                    "\n\t[5] Stäng av!" +
                    "\n\t: ");
                int.TryParse(Console.ReadLine(), out int menuChoice);

                switch (menuChoice)
                {
                    case 1:
                        hiddenNumber = random.Next(1, 21);
                        GuessGame(hiddenNumber, 10);
                        break;

                    case 2:
                        hiddenNumber = random.Next(1, 31);
                        GuessGame(hiddenNumber, 8);
                        break;

                    case 3:
                        hiddenNumber = random.Next(1, 41);
                        GuessGame(hiddenNumber, 5);
                        break;

                    case 4:
                        Console.Write("\n\tAnge hur många nummer du vill gissa på" +
                            "\n\t: ");
                        int.TryParse(Console.ReadLine(), out int ammount);
                        Console.Write("\n\tAnge hur många försök du vill ha" +
                            "\n\t: ");
                        int.TryParse(Console.ReadLine(), out int guesses);

                        hiddenNumber = random.Next(1, ammount);
                        GuessGame(hiddenNumber, guesses);
                        break;

                    case 5:
                        menu = false;
                        break;

                    default:
                        Console.Write("\n\tDu angav en ogiltlig karaktär!" +
                            "\n\tFörsök igen!");
                        Console.ReadLine();
                        break;
                }
            }
        }

        public static void GuessGame(int hiddenNumber, int guesses)
        {
            double closeGuessD = Math.Ceiling(hiddenNumber * 0.2);
            int closeGuess = Convert.ToInt32(closeGuessD);
            for (int guessesLeft = guesses; guessesLeft > 0; guessesLeft--)
            {
                Console.Clear();
                Console.Write(hiddenNumber + " " + closeGuess);
                Console.Write("\n\tVad gissar du på?" +
                    "\n\t: ");
                int.TryParse(Console.ReadLine(), out int guess);

                if (CheckGuess(hiddenNumber, guess) == true)
                {
                    Console.Write("\n\tGrattis du gissade rätt!");
                    Console.ReadLine();
                    guessesLeft = 0;
                }
                else
                {
                    Console.Write("\n\t" + GuessAnswer(hiddenNumber, guess) +
                        $"\n\tDu har {guessesLeft - 1} gissningar kvar");
                    if ((hiddenNumber - closeGuess) <= guess && guess <= (hiddenNumber + closeGuess))
                    {
                        Console.Write($"\n\tDet bränns du är inom {closeGuess} nummer ifrån!");
                    }
                    if (guessesLeft == 1)
                    {
                        Console.Write("\n\tSlut på försök du förlorade!");
                    }
                    Console.ReadLine();
                }
            }
        }

        public static bool CheckGuess(int hiddenNumber, int guess)
        {
            if (guess == hiddenNumber)
            {
                return true;
            }
            return false;
        }

        public static string GuessAnswer(int hiddenNumber, int guess)
        {
            Random random = new Random();
            int number = random.Next(1, 4);

            if (guess < hiddenNumber)
            {
                if (number == 1)
                {
                    return "\n\tDu gissade för lågt";
                }
                if (number == 2)
                {
                    return "\n\tInte rätt, för lågt";
                }
                return "\n\tDet var fel, prova något högre";
            }

            if (number == 1)
            {
                return "\n\tDu gissade för högt";
            }
            if (number == 2)
            {
                return "\n\tInte rätt, för högt";
            }
            return "\n\tDet var fel, prova något lägre";
        }
    }
}
