using Program;
using CombatSystem;
using OptionsSystem;


//We could use these methods to handle printing to the console and then call the description methods in the different scenes to print INSIDE this constructed string graphic. 
namespace MenuSystem

{
        public class Menu
    {
    
     private IConsoleEffects consoleEffects = new ConsoleEffects();
     private GameState currentGameState;
     private Combat combat;
     private PlayerData playerData; //Need an instance of this data to initialize in the Menu state.
     private Options options; //Same with this.
     private GameState previousGameState; //Same with this.


     public Menu (GameState initialGameState, PlayerData playerData)//In this initalized instance of menu initialize playerData and options.
     {
        currentGameState = initialGameState;
        this.playerData = playerData; 
        options = new Options();
     }
        
     public void OptionsMenu()
        {
            previousGameState = currentGameState;
            //We need to get current instance or GameManager enum state so that when we exit the menu we know what the last menu was loaded so that we can reload the scene and menu options.
             while(true)
        {
            consoleEffects.PrintDelayEffect(@"You figure this is a good time to review your options."); 
            Console.WriteLine(@"
                              1.) Status?
                              2.) Save?   
                              3.) Load?
                              4.) Audio?
                              5.) Video?
                              6.) Back to work!       ");
            string userInput = Console.ReadLine();

                switch (userInput)
            {
                case "1":
                consoleEffects.PrintDelayEffect("This reveals your current HP, SP, and Level.");
                options.PlayerStatus(playerData);
                break;
                case "2":
                consoleEffects.PrintDelayEffect("Let's review your save files.");
                Options.SaveData(playerData);
                break;
                case "3":
                consoleEffects.PrintDelayEffect("Load a previous save?");
                Options.LoadData(playerData);
                break;
                case "4":
                Options.Sound();
                break;
                case "5":
                Options.Video();
                break;
                case "6":
                consoleEffects.PrintDelayEffect("Time to get back to the grind!");//TODO: Need a new trick to return to previous menu.
                ReturnToPreviousGameState();
                break;
                default:
                Console.WriteLine("You've made an invalid selection.");
                break;
            }          
        }
    }
    

        public void CubeFarmMenu()
        {
        while(true)
        {
            consoleEffects.PrintDelayEffect(@"What will you do?"); 
            Console.WriteLine(@"
                              1.) Move to the Kitchen.
                              2.) Explore the room.   
                              3.) Fight!
                              4.) Options Menu         ");
            string userInput = Console.ReadLine();

    switch (userInput)
    {
        case "1":
            GameManager.Instance.DisplayKitchenScene();
            break;
        case "2":
            consoleEffects.PrintDelayEffect("You check the desks for something useful.");
            break;
        case "3":
            consoleEffects.PrintDelayEffect("You notice an Office Zombie wandering between the cubes. Time to fight!");
            //We need to pass in Office Zombie somehow to the DisplayCombatScene() method, that way when we move to that instance it will know what enemy to grab.
            GameManager.Instance.DisplayCombatScene(currentGameState);
            break;
        case "4":
            consoleEffects.PrintDelayEffect("Accessing Options Menu..."); // Call options menu
            OptionsMenu();
            break;
        default:
            Console.WriteLine("You've made an invalid selection.");
            break;
    }          
        }
        }

        public void KitchenMenu()
        {while(true)
        {
        
            consoleEffects.PrintDelayEffect(@"What will you do?"); 
            Console.WriteLine(@"
                              1.) Move to the Wellness Room.
                              2.) Go back to where you came.
                              3.) Explore the room.   
                              4.) Fight!
                              5.) Options Menu         ");
             string userInput = Console.ReadLine();

    switch (userInput)
    {
        case "1":
            GameManager.Instance.DisplayWellnessRoomScene();
            break;
        case "2":
            GameManager.Instance.DisplayCubeFarmScene();
            break;
        case "3":
            consoleEffects.PrintDelayEffect("You look through the cabinets for supplies.");
            break;
        case "4":
            consoleEffects.PrintDelayEffect("The coffee machine has become sentient! Time to fight!");
            //We need to pass in Coffee Machine somehow to the DisplayCombatScene() method, that way when we move to that instance it will know what enemy to grab.
            GameManager.Instance.DisplayCombatScene(currentGameState);
            break;
        case "5":
            consoleEffects.PrintDelayEffect("Accessing Options Menu...");
            OptionsMenu();
            break;
        default:
            Console.WriteLine("You've made an invalid selection.");
            break;
    } 
        }
        }

        public void WellnessRoomMenu()
        {while (true)
        {
               consoleEffects.PrintDelayEffect(@"What will you do?"); 
               Console.WriteLine(@"
                              1.) Move to the Meeting Room.
                              2.) Go back to where you came.
                              3.) Explore the room.   
                              4.) Fight!
                              5.) Options Menu         ");
             string userInput = Console.ReadLine();

    switch (userInput)
    {
        case "1":
            GameManager.Instance.DisplayMeetingRoomScene();
            break;
        case "2":
            GameManager.Instance.DisplayKitchenScene();
            break;
        case "3":
            consoleEffects.PrintDelayEffect("You look through the uncomfortable silence and all you find is your own thoughts. Have fun with those.");
            break;
        case "4":
            consoleEffects.PrintDelayEffect("The Impromtu Meeting forces itself into your calendar! Time to fight!");
            
            GameManager.Instance.DisplayCombatScene(currentGameState);
            break;
        case "5":
            consoleEffects.PrintDelayEffect("Accessing Options Menu...");
            OptionsMenu();
            break;
        default:
            Console.WriteLine("You've made an invalid selection.");
            break;
        }
    }
    }

        public void MeetingRoomMenu()
        {while(true)
        {
                   consoleEffects.PrintDelayEffect(@"What will you do?"); 
                   Console.WriteLine(@"
                              1.) Move to the Quiet Room.
                              2.) Go back to where you came.
                              3.) Explore the room.   
                              4.) Fight!
                              5.) Options Menu         ");
             string userInput = Console.ReadLine();

    switch (userInput)
    {
        case "1":
            GameManager.Instance.DisplayQuietroomScene();
            break;
        case "2":
            GameManager.Instance.DisplayWellnessRoomScene();
            break;
        case "3":
            consoleEffects.PrintDelayEffect("You check the remote. No batteries. Sorry.");
            break;
        case "4":
            consoleEffects.PrintDelayEffect("The Cloud has turned on you! The Azure Blob appears! Time to fight!");
            
            GameManager.Instance.DisplayCombatScene(currentGameState);
            break;
        case "5":
            consoleEffects.PrintDelayEffect("Accessing Options Menu...");
            OptionsMenu();
            break;
        default:
            Console.WriteLine("You've made an invalid selection.");
            break;
        }
    }
        }

        public void QuietRoomMenu()
        {
            while(true)
        {
            
                   consoleEffects.PrintDelayEffect(@"What will you do?"); 
                   Console.WriteLine(@"
                              1.) Move to the Boss's Office.
                              2.) Go back to where you came.
                              3.) Explore the room.   
                              4.) Fight!
                              5.) Options Menu         ");
             string userInput = Console.ReadLine();

    switch (userInput)
    {
        case "1":
            GameManager.Instance.DisplayNetworkClosetScene();
            break;
        case "2":
            GameManager.Instance.DisplayMeetingRoomScene();
            break;
        case "3":
            consoleEffects.PrintDelayEffect("You look through the uncomfortable silence and all you find is your own thoughts. You smell burnt toast. That's usually a bad sign.");
            break;
        case "4":
            consoleEffects.PrintDelayEffect("The toaster shows itself! Time to fight!");          
            GameManager.Instance.DisplayCombatScene(currentGameState);
            break;
        case "5":
            consoleEffects.PrintDelayEffect("Accessing Options Menu...");
            OptionsMenu();
            break;
        default:
            Console.WriteLine("You've made an invalid selection.");
            break;
    }
        }

        }
        public void NetworkClosetMenu()
        {
            /*if (playerData.playerInventory.Contains("Office Badge))
            {
                consoleEffects.PrintDelayEffect("You grab your badge, and badge into the Networking Closet. It is time to do this thing.");
                DisplayNetworkClosetScene();
            }
            while(true)
            {
            
                   consoleEffects.PrintDelayEffect(@"What will you do?"); 
                   Console.WriteLine(@"
                              1.) Retreat to the Meeting Room!
                              2.) Explore the room.   
                              3.) Fight!
                              4.) Options Menu         ");
             string userInput = Console.ReadLine();

            switch (userInput)
            {
            case "1":
            GameManager.Instance.DisplayMeetingRoomScene();
            break;
            case "2":
            consoleEffects.PrintDelayEffect("You look through the uncomfortable silence and all you find is your own thoughts. You smell burnt toast. That's usually a bad sign.");
            break;
            case "3":
            consoleEffects.PrintDelayEffect("The toaster shows itself! Time to fight!");
            GameManager.Instance.DisplayCombatScene(currentGameState);
            break;
            case "4":
            consoleEffects.PrintDelayEffect("Accessing Options Menu...");
            OptionsMenu();
            break;
            default:
            Console.WriteLine("You've made an invalid selection.");
            break;
            }
            
            */
        }

         public void SetCurrentGameState(GameState gameState)//Serialize this value for the save file.
        {
            currentGameState = gameState;
        }
        private void ReturnToPreviousGameState()
        {
            currentGameState = previousGameState;
            consoleEffects.PrintDelayEffect("Returning to previous game state...");
            switch (currentGameState)
            {
                case GameState.CUBEFARM:
                    GameManager.Instance.DisplayCubeFarmScene();
                    break;
                case GameState.KITCHEN:
                    GameManager.Instance.DisplayKitchenScene();
                    break;
                case GameState.QUIETROOM:
                    GameManager.Instance.DisplayQuietroomScene();
                    break;
                case GameState.MEETINGROOM:
                    GameManager.Instance.DisplayMeetingRoomScene();
                    break;
                case GameState.NETWORKCLOSET:
                    GameManager.Instance.DisplayNetworkClosetScene();
                    break;
                default:
                    consoleEffects.PrintDelayEffect("Error: Invalid game state.");
                    break;
            }
        }
        
    }
}