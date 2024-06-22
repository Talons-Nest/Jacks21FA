namespace Program
{
    //We need to define an Enumerator to handle what state of the game we are in.
     public enum GameState
            {
                MAINMENU,
                COMBAT,
                CUBEFARM,
                KITCHEN,
                QUIETROOM,
                WELLNESSROOM,
                MEETINGROOM,
                BOSSOFFICE
            }
    public class GameManager
    {           
          
             //What state are we currently in?
            public GameManager()
            {
                CurrentGameState = GameState.MAINMENU;
            }

            //Auto setting the properties.
            public GameState CurrentGameState {get; private set;}

           

            //Change what state we are in. Create the new state.
            public void ChangeGameState(GameState newState)
            {
                CurrentGameState = newState;
            }

           
           //Hey yo, don't close the game until you hit this key.
           public void KeepAlive()

           {
                while (true)
            {
                if (Console.In.Peek() > -1)
                {
                    ConsoleKeyInfo key = Console.ReadKey(intercept: true);
                    if (key.KeyChar == 'q')
                    break;
                }
            }
            Console.WriteLine("You're fleeing to the nearest networking closet. Coward.");
        }

    }
}



