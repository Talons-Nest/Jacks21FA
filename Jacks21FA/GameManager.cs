using MenuSystem;

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
        //What state are we currently in? Create a singleton so that there is only one instance of this ever running at once.
        private static GameManager instance;
        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameManager();
                }
                return instance;
            }
        }
            //Auto setting the properties.
            public GameState CurrentGameState {get; private set;}
       


            //Change what state we are in. Create the new state.
            public void ChangeGameState(GameState newState)
            {
                CurrentGameState = newState;
            }
            ItemData itemData = new ItemData(); //See if we need this if not delete it.

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

             Menu menuSystem = new Menu();
            
            public void DisplayCombatScene()
            {   
                KeepAlive();//This one might be removed to return to a previous scene. Not sure how i'm gonna keep track of that yet. Probably going to need some kind of quest procedure code.
            }
                   
            public void DisplayCubeFarmScene()
            {
                Console.WriteLine("You've entered the Cube Farm. Many bright lights and colors give this room a sterile feel and you sense someone is watching you.");
                menuSystem.CubeFarmMenu();
                KeepAlive();
            }
                   
            public void DisplayKitchenScene()
            {
                Console.WriteLine("The lights are slightly dimmer here. You breathe with a sigh of relief. The various tables and chairs and industrial refrigerator's are inviting enough. Your breath echoes in the silence.");
                KeepAlive();
            }
                   
            public void DisplayQuietroomScene()
            {
                Console.WriteLine("A line of desks with workstations on both sides. The silence is chilling. A great place to think. It feels like that one movie with Jim from The Office.");
                KeepAlive();
            }
            public void DisplayWellnessRoomScene()
            {
                Console.WriteLine("A dark, rarely inhabited place. A couch sits in the corner. This eery room makes you feel anything but well.");
                KeepAlive();
            }  
            public void DisplayMeetingRoomScene()
            {
                Console.WriteLine("A long skinny room littered with empty chairs. A dull whine echoes. You can't tell if its coming from the speakers in the ceiling or the tv. Maybe grab the remote.");
                KeepAlive();
            }       
            public void DisplayBossOfficeScene()
            {
                Console.WriteLine("A broken light is dangling from the ceiling. Cables strewn all over the floor. You think you might smell a fire.");
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



