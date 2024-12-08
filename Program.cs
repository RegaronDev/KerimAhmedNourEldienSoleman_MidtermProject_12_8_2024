using System;

namespace GameMidterm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // create a game instance and start the game
            Game game = new Game();
            game.Start();
        }
    }

    class Game
    {
        private string playerName; // store the player's name
        private BravePoints bravePoints = new BravePoints(); // manage brave points

        public void Start()
        {
            // here where the user or the player will input their name
            Console.WriteLine("What is your name?");
            playerName = Console.ReadLine();

            // introduce the story to the player
            Console.WriteLine($"\nHi {playerName}! You are lying in your bed at night.");
            Console.WriteLine("You hear a knock on your window.");

            // create a question handler for asking questions
            QuestionHandler questionHandler = new QuestionHandler(playerName, bravePoints);

            // ask the 1st question
            questionHandler.AskQuestion(1, "\nWhat do you do?", "1. Look at the window", "2. Hide under blanket");

            // ask the 2nd question
            questionHandler.AskQuestion(2, "\nYou see a glowing portal outside! What do you do now?",
                "1. Get closer to window", "2. Stay in bed");

            // ask the 3rd question
            questionHandler.AskQuestion(3, "\nThe portal is getting bigger! Do you:",
                "1. Call for help", "2. Watch the portal");

            // ask the 4th question
            questionHandler.AskQuestion(4, "\nA voice comes from the portal. What do you do?",
                "1. Listen to it", "2. Cover your ears");

            // shows the result based on brave points
            Console.WriteLine($"\nWell {playerName}...");
            if (bravePoints.Score >= 3)
            {
                // player is very brave
                Console.WriteLine("You were very brave tonight!");
            }
            else if (bravePoints.Score >= 1)
            {
                // player showed some bravery
                Console.WriteLine("You were a little scared, but thats okay!");
            }
            else
            {
                // player avoided the journey
                Console.WriteLine("Maybe journeys arent your thing!");
            }

            // prompt the player to exit
            Console.WriteLine("\nPress Enter to exit");
            Console.ReadLine();
        }
    }

    class QuestionHandler
    {
        private readonly string playerName; // used readonly and not const since it will recognize the name once!
        private readonly BravePoints bravePoints; 

        public QuestionHandler(string playerName, BravePoints bravePoints)
        {
            // player name and bravepoints
            this.playerName = playerName;
            this.bravePoints = bravePoints;
        }

        public void AskQuestion(int questionNumber, string questionText, string option1, string option2)
        {
            string answer; // name storage

            while (true) // repeater if the player keeps giving invalid/impossible answers
            {
                // display the question and options
                Console.WriteLine($"\n{playerName}, {questionText}");
                Console.WriteLine(option1);
                Console.WriteLine(option2);

                // answer var
                answer = Console.ReadLine();

                // the answer checker, which it checks the answers from 1 to 2.
                if (answer == "1" || answer == "2")
                {
                    break; 
                }

                // if the player types in wrong answer such as greater than 1 & 2 or strings
                Console.WriteLine("Impossible answer, please retry answering the question!");
            }

            // update brave points based on the answer
            if (questionNumber == 1 && answer == "1") bravePoints.Increase();
            if (questionNumber == 2 && answer == "1") bravePoints.Increase();
            if (questionNumber == 3 && answer == "2") bravePoints.Increase();
            if (questionNumber == 4 && answer == "1") bravePoints.Increase();
        }
    }

    class BravePoints
    {
        public int Score { get; private set; } = 0; // store the player's brave points

        public void Increase()
        {
            // increment brave points
            Score++;
        }
    }
}
