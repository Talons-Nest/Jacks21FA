

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
            ItemData itemData = new ItemData();

             public void DisplayMainMenu()
             {
                Console.WriteLine(@"
                
                Welcome to Jack's 21st Floor Adventure!
                
                
                It's time to hack your way to freedom. Hit a number key.

                1.) Start Game
                2.) Exit Game
                ");
                string userInput = Console.ReadLine();

                if (userInput == "1")
                {
                    CurrentGameState = GameState.CUBEFARM;
                }
                else if (userInput == "2")
                {
                    Console.WriteLine("You're fleeing to the nearest networking closet. Coward.");
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("You've made an invalid selection.");
                }
                               

             }
            
            public void DisplayCombatScene()
            {
                KeepAlive();//This one might be removed to return to a previous scene. Not sure how i'm gonna keep track of that yet. Probably going to need some kind of quest procedure code.
            }
                   
            public void DisplayCubeFarmScene()
            {
                Console.WriteLine("You've entered the Cube Farm. Many bright lights and colors give his room a sterile feel and you sense someone is watching you.");
                KeepAlive();
            }
                   
            public void DisplayKitchenScene()
            {
                Console.WriteLine("The lights are slightly dimmer here. You breathe with a sigh of relief. The various tables and chairs and industrial refrigerator's are inviting enough. Your breath echoes in the silence.");
                KeepAlive();
            }
                   
            public void DisplayQuietroommScene()
            {
                KeepAlive();
            }
            public void DisplayWelnessRoomScene()
            {
                KeepAlive();
            }  
            public void DisplayMeetingRoomScene()
            {
                KeepAlive();
            }       
            public void DisplayBossOfficeScene()
            {
                KeepAlive();
            }
       
           
           //Hey yo, don't close the game until you hit this key.
           public void KeepAlive()
           {
                while (true)
            {
                Thread.Sleep(1000); // Let the main thread sleep before checking again.
            }
            
        }

    }
}



