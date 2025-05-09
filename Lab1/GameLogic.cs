namespace Lab01
{
    internal class GameLogic
    {
        /// <summary>
        /// # of attempt that is allowed
        /// </summary>
        public int guessesLeft = 5;

        /// <summary>
        /// the word that the rng pick
        /// </summary>
        public string chosenWord;

        /// <summary>
        /// not sure what this is meant to be used for
        /// </summary>
        public int currentIndexOfLetterToBeGuessed = 0;

        public string [] wordsToChoose =
        { "Fortnite", "Overwatch", "Minecraft", "Battlefield", "Rust"};

        /// <summary>
        /// Get a random string from wordsToChoose
        /// </summary>
        /// <returns></returns>
        public string ChooseRandomWord()
        {
            // get a random object
            Random random = new Random();

            // pick a random word within the string length 
            int index = random.Next(0, wordsToChoose.Length);

            // return the integer index in wordToChoose
            chosenWord = wordsToChoose[index];

            return chosenWord;
        }

        /// <summary>
        /// Check the if the user guess right
        /// </summary>
        /// <param name="guessedChar"></param>
        /// <param name="displayCurrentLetterPosition"></param>
        /// <returns></returns>
        public bool CheckUserGuess(char guessedChar, char[] displayCurrentLetterPosition)
        {
            bool matching = false;

            // uppercase the current all the letter so it's not sensitive to the case
            guessedChar = char.ToUpper(guessedChar);

            // Check the whole word to see if any of the guessed letter matched with a loop
            for (int i = 0; i < chosenWord.Length; i++)
            {
                // check if the current position of the guess is right
                if (char.ToUpper(chosenWord[i]) == guessedChar)
                {
                    // display the letter (original case) if the current position of the guess was right
                    displayCurrentLetterPosition[i] = chosenWord[i];

                    // this will prevent the lost of a point if the letter matched
                    matching = true;

                    // making sure that the letter is shown at the current position
                    if (i == currentIndexOfLetterToBeGuessed)
                    {
                        // Keep checking until it reach the end of the word & until all underscore is founded
                        while (currentIndexOfLetterToBeGuessed < chosenWord.Length &&
                              displayCurrentLetterPosition[currentIndexOfLetterToBeGuessed] != '_')
                        {
                            currentIndexOfLetterToBeGuessed++;
                        }
                    }
                }
            }

            // deduct a point (true) if none of the letter matched
            if (!matching)
            {
                guessesLeft--;
            }

            return matching;
        }

        /// <summary>
        /// check if there's any underscore left to determine if the game is won
        /// </summary>
        /// <param name="remainingLetter"></param>
        /// <returns></returns>
        public bool CheckWinCondition(char[] remainingLetter)
        {
            // Check if the word does not contain any more underscores
            return !remainingLetter.Contains('_');
        }
    }
}

