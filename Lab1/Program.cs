// Hoang Le
// hle2@northeaststate.edu

using System.Numerics;

namespace Lab01
{
    /// <summary>
    /// Lab1 Refresher
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Program entry point
        /// </summary>
        static void Main()
        {
            Console.WriteLine("Wordle 2.0\nGuess the Game");

            GameLogic game = new GameLogic();
            UserInput input = new UserInput();

            // get a random word
            string guessTheLetter = game.ChooseRandomWord();

            // Break all the words into individual letters
            char[] displayTheLetter = new char[guessTheLetter.Length];

            // turn all the letter of the chosen word to underscores
            int currentLetter = 0;
            foreach (char letter in guessTheLetter)
            {
                displayTheLetter[currentLetter] = '_';
                currentLetter++;
            }

            Console.WriteLine("\nPlease guess a letter :  " + new string(displayTheLetter));

            // the game will continue until the while loop hit zero or if it doesn't contain any more underscores
            while (game.guessesLeft > 0)
            {
                Console.Write("\nUser Entry: ");

                char guess = input.GetUserChar();
                bool correct = game.CheckUserGuess(guess, displayTheLetter);

                if (correct)
                {
                    Console.WriteLine("\nCorrect! Please guess another letter: " + new string(displayTheLetter));
                }

                else
                {
                    Console.WriteLine("\nWrong! " + game.guessesLeft + " guesses left! Please guess another letter:" + new string(displayTheLetter));
                }

                if (!displayTheLetter.Contains('_'))
                {
                    Console.WriteLine("\nYou guessed what the game was: " + guessTheLetter);
                    break;
                }
            }

            // if the guesses hit zero then it show what the word was
            if (game.guessesLeft == 0)
            {
                Console.WriteLine("\n The video game was: " + guessTheLetter);
            }

            Console.WriteLine("Press any of the key to exit");
            Console.ReadKey();
        }
    }
}
