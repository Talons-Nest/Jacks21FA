using MenuSystem;
using CombatSystem;

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
            public GameState CurrentGameState {get; set;}
       


            //Change what state we are in. Create the new state.
            public void ChangeGameState(GameState newState)
            {
                CurrentGameState = newState;
            }
            ItemData itemData = new ItemData(); //See if we need this if not delete it.

             public void DisplayMainMenu()
             {
                Console.WriteLine(@"
                
                

'##:::::'##:'########:'##::::::::'######:::'#######::'##::::'##:'########::::'########::'#######::   
 ##:'##: ##: ##.....:: ##:::::::'##... ##:'##.... ##: ###::'###: ##.....:::::... ##..::'##.... ##:   
 ##: ##: ##: ##::::::: ##::::::: ##:::..:: ##:::: ##: ####'####: ##::::::::::::: ##:::: ##:::: ##:   
 ##: ##: ##: ######::: ##::::::: ##::::::: ##:::: ##: ## ### ##: ######::::::::: ##:::: ##:::: ##:   
 ##: ##: ##: ##...:::: ##::::::: ##::::::: ##:::: ##: ##. #: ##: ##...:::::::::: ##:::: ##:::: ##:   
 ##: ##: ##: ##::::::: ##::::::: ##::: ##: ##:::: ##: ##:.:: ##: ##::::::::::::: ##:::: ##:::: ##:   
. ###. ###:: ########: ########:. ######::. #######:: ##:::: ##: ########::::::: ##::::. #######::   
:...::...:::........::........:::......::::.......:::..:::::..::........::::::::..::::::.......:::   
::::::'##::::'###:::::'######::'##:::'##:'####::'######::                                            
:::::: ##:::'## ##:::'##... ##: ##::'##:: ####:'##... ##:                                            
:::::: ##::'##:. ##:: ##:::..:: ##:'##:::. ##:: ##:::..::                                            
:::::: ##:'##:::. ##: ##::::::: #####::::'##:::. ######::                                            
'##::: ##: #########: ##::::::: ##. ##:::..:::::..... ##:                                            
 ##::: ##: ##.... ##: ##::: ##: ##:. ##::::::::'##::: ##:                                            
. ######:: ##:::: ##:. ######:: ##::. ##:::::::. ######::                                            
:......:::..:::::..:::......:::..::::..:::::::::......:::                                            
:'#######:::::'##::::'######::'########::::'########:'##::::::::'#######:::'#######::'########::     
'##.... ##::'####:::'##... ##:... ##..::::: ##.....:: ##:::::::'##.... ##:'##.... ##: ##.... ##:     
..::::: ##::.. ##::: ##:::..::::: ##::::::: ##::::::: ##::::::: ##:::: ##: ##:::: ##: ##:::: ##:     
:'#######::::: ##:::. ######::::: ##::::::: ######::: ##::::::: ##:::: ##: ##:::: ##: ########::     
'##::::::::::: ##::::..... ##:::: ##::::::: ##...:::: ##::::::: ##:::: ##: ##:::: ##: ##.. ##:::     
 ##::::::::::: ##:::'##::: ##:::: ##::::::: ##::::::: ##::::::: ##:::: ##: ##:::: ##: ##::. ##::     
 #########::'######:. ######::::: ##::::::: ##::::::: ########:. #######::. #######:: ##:::. ##:     
.........:::......:::......::::::..::::::::..::::::::........:::.......::::.......:::..:::::..::     
:::'###::::'########::'##::::'##:'########:'##::: ##:'########:'##::::'##:'########::'########:'####:
::'## ##::: ##.... ##: ##:::: ##: ##.....:: ###:: ##:... ##..:: ##:::: ##: ##.... ##: ##.....:: ####:
:'##:. ##:: ##:::: ##: ##:::: ##: ##::::::: ####: ##:::: ##:::: ##:::: ##: ##:::: ##: ##::::::: ####:
'##:::. ##: ##:::: ##: ##:::: ##: ######::: ## ## ##:::: ##:::: ##:::: ##: ########:: ######:::: ##::
 #########: ##:::: ##:. ##:: ##:: ##...:::: ##. ####:::: ##:::: ##:::: ##: ##.. ##::: ##...:::::..:::
 ##.... ##: ##:::: ##::. ## ##::: ##::::::: ##:. ###:::: ##:::: ##:::: ##: ##::. ##:: ##:::::::'####:
 ##:::: ##: ########::::. ###:::: ########: ##::. ##:::: ##::::. #######:: ##:::. ##: ########: ####:
..:::::..::........::::::...:::::........::..::::..:::::..::::::.......:::..:::::..::........::....::


                
                
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

        private GameManager()
        {
            // Initialize menuSystem with initial game state
            CurrentGameState = GameState.MAINMENU; // Set initial game state
            menuSystem = new Menu(CurrentGameState); // Pass initial game state to Menu constructor
        }
            
        private Menu menuSystem;
        private Combat combatSystem;
        Player player; // Instantiate Player
        private PlayerData playerData = new PlayerData();

        
            public void DisplayCombatScene(GameState gameState)
            {
                // Ensure player and combatSystem are instantiated with the correct GameState
                player = new Player(playerData);
                combatSystem = new Combat(player, playerData, gameState); // Pass CurrentGameState
                combatSystem.CombatMenu();
                KeepAlive();
            }

                   
            public void DisplayCubeFarmScene()
            {
                Console.WriteLine("You've entered the Cube Farm. Many bright lights and colors give this room a sterile feel and you sense someone is watching you.");
                Console.WriteLine($"Current GameState updated to: {CurrentGameState}");
                menuSystem.SetCurrentGameState(GameState.CUBEFARM);
                menuSystem.CubeFarmMenu();
                KeepAlive();
            }
                   
            public void DisplayKitchenScene()
            {
                Console.WriteLine("The lights are slightly dimmer here. You breathe with a sigh of relief. The various tables and chairs and industrial refrigerator's are inviting enough. Your breath echoes in the silence.");
                menuSystem.SetCurrentGameState(GameState.KITCHEN);
                menuSystem.KitchenMenu();
                KeepAlive();
            }
                   
            public void DisplayQuietroomScene()
            {                
                Console.WriteLine("A line of desks with workstations on both sides. The silence is chilling. A great place to think. It feels like that one movie with Jim from The Office.");
                menuSystem.SetCurrentGameState(GameState.QUIETROOM);
                menuSystem.QuietRoomMenu();
                KeepAlive();
            }
            public void DisplayWellnessRoomScene()
            {
                Console.WriteLine("A dark, rarely inhabited place. A couch sits in the corner. This eery room makes you feel anything but well.");
                menuSystem.SetCurrentGameState(GameState.WELLNESSROOM);
                menuSystem.WellnessRoomMenu();
                KeepAlive();
            }  
            public void DisplayMeetingRoomScene()
            {
                Console.WriteLine("A long skinny room littered with empty chairs. A dull whine echoes. You can't tell if its coming from the speakers in the ceiling or the tv. Maybe grab the remote.");
                menuSystem.SetCurrentGameState(GameState.MEETINGROOM);
                menuSystem.MeetingRoomMenu();
                KeepAlive();
            }       
            public void DisplayBossOfficeScene()
            {
                Console.WriteLine("A broken light is dangling from the ceiling. Cables strewn all over the floor. You think you might smell a fire.");
                menuSystem.SetCurrentGameState(GameState.BOSSOFFICE);
                menuSystem.BossOfficeMenu();
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



