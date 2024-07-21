using MenuSystem;
using CombatSystem;

namespace Program
{
    //We need to define an Enumerator to handle what state of the game we are in.
     public enum GameState
            {
                MAINMENU,
                COMBAT,
                OPTIONS,
                CUBEFARM,
                KITCHEN,
                QUIETROOM,
                WELLNESSROOM,
                MEETINGROOM,
                NETWORKCLOSET,
                WINNING
            }
    public class GameManager 
    {
        private IConsoleEffects consoleEffects = new ConsoleEffects();
            
       
                   
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
           {    // Console.Clear();
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Gray;
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


                ");
                
                consoleEffects.PrintDelayEffect(@"It's time to hack your way to freedom. Hit a number key.");

                Console.WriteLine(@"
                1.) Start Game
                2.) Exit Game
                 ");
                 
                string userInput = Console.ReadLine()?.ToString();

                if (userInput == "1")
                {
                    CurrentGameState = GameState.CUBEFARM;
                }
                else if (userInput == "2")
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
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
            menuSystem = new Menu(CurrentGameState, playerData); // Pass initial game state to Menu constructor.
        }
            
        private Menu menuSystem;
        private Combat combatSystem;
        Player player; // Instantiate Player
        private PlayerData playerData = new PlayerData();

            public void DisplayOptionsScene(GameState gameState)
            {
                player = new Player(playerData);
                menuSystem.SetCurrentGameState(GameState.OPTIONS);
                menuSystem.OptionsMenu();
                KeepAlive();              
            }

            public void DisplayCombatScene(GameState gameState)
            {
                // Ensure player and combatSystem are instantiated with the correct GameState
                player = new Player(playerData);
                combatSystem = new Combat(player, playerData, gameState); // Pass CurrentGameState
                combatSystem.RollForInitiative();
                combatSystem.CombatLoop();
                KeepAlive();
            }
                   
            public void DisplayCubeFarmScene()
            {
                consoleEffects.PrintDelayEffect("You've entered the Cube Farm. Many bright lights and colors give this room a sterile feel and you sense someone is watching you.");
                //DEBUG: Console.WriteLine($"Current GameState updated to: {CurrentGameState}");
                menuSystem.SetCurrentGameState(GameState.CUBEFARM);
                menuSystem.CubeFarmMenu();
                KeepAlive();
            }
                   
            public void DisplayKitchenScene()
            {
                consoleEffects.PrintDelayEffect("The lights are slightly dimmer here. You breathe with a sigh of relief. The various tables and chairs and industrial refrigerator's are inviting enough. Your breath echoes in the silence.");
                menuSystem.SetCurrentGameState(GameState.KITCHEN);
                menuSystem.KitchenMenu();
                KeepAlive();
            }
                   
            public void DisplayQuietroomScene()
            {                
                consoleEffects.PrintDelayEffect("A line of desks with workstations on both sides. The silence is chilling. A great place to think. Though, food smells stronger in here for some reason.");
                menuSystem.SetCurrentGameState(GameState.QUIETROOM);
                menuSystem.QuietRoomMenu();
                KeepAlive();
            }
            public void DisplayWellnessRoomScene()
            {
                consoleEffects.PrintDelayEffect("A dark, rarely inhabited place. A couch sits in the corner. This eery room makes you feel anything but well.");
                menuSystem.SetCurrentGameState(GameState.WELLNESSROOM);
                menuSystem.WellnessRoomMenu();
                KeepAlive();
            }  
            public void DisplayMeetingRoomScene()
            {
                consoleEffects.PrintDelayEffect("A long skinny room littered with empty chairs. A dull whine echoes. You can't tell if its coming from the speakers in the ceiling or the TV. Maybe grab the remote.");
                menuSystem.SetCurrentGameState(GameState.MEETINGROOM);
                menuSystem.MeetingRoomMenu();
                KeepAlive();
            }       
            public void DisplayNetworkClosetScene()
            {
                consoleEffects.PrintDelayEffect("There are small fires in the room, you can smell the haylon. There are strands of CAT6 strewn about and the fiber cables are completely melted. You sense a menacing presence overwhelming your psyche.");
                menuSystem.SetCurrentGameState(GameState.NETWORKCLOSET);
                menuSystem.NetworkClosetMenu();
                KeepAlive();
            }

            public void DisplayWinGameScene()
            {
               consoleEffects.PrintDelayEffect("They won't remember what you've done for them... but you did it all the same. You are a hero in the truest sense. I'm sure you'd like a better ending cut scene, but this is all you're getting. Back to work, Engineer!");
               menuSystem.SetCurrentGameState(GameState.WINNING);
               menuSystem.WinGameMenu();
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

