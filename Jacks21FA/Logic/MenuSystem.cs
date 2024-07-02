using Program;


//We could use these methods to handle printing to the console and then call the description methods in the different scenes to print INSIDE this constructed string graphic. 
namespace MenuSystem

{
        public class Menu
    {
    
     private GameState currentGameState;

     public Menu (GameState initialGameState)
     {
        currentGameState = initialGameState;
     }   
     public void OptionsMenu()
        {
            //We need to get current instance or GameManager enum state so that when we exit the menu we know what the last menu was loaded so that we can reload the scene and menu options.
        }
        public void CubeFarmMenu()
        {
        while(true)
        {
            Console.WriteLine(@"What will you do? 
            
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
            Console.WriteLine("You check the desks for something useful.");
            break;
        case "3":
            Console.WriteLine("You notice an Office Zombie wandering between the cubes. Time to fight!");
            //We need to pass in Office Zombie somehow to the DisplayCombatScene() method, that way when we move to that instance it will know what enemy to grab.
            GameManager.Instance.DisplayCombatScene(currentGameState);
            break;
        case "4":
            Console.WriteLine("Accessing Options Menu..."); // Call options menu
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
        
            Console.WriteLine(@"What will you do? 
            
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
            Console.WriteLine("You look through the cabinets for supplies.");
            break;
        case "4":
            Console.WriteLine("The coffee machine has become sentient! Time to fight!");
            //We need to pass in Coffee Machine somehow to the DisplayCombatScene() method, that way when we move to that instance it will know what enemy to grab.
            GameManager.Instance.DisplayCombatScene(currentGameState);
            break;
        case "5":
            Console.WriteLine("Accessing Options Menu...");
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
               Console.WriteLine(@"What will you do? 
            
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
            Console.WriteLine("You look through the uncomfortable silence and all you find is your own thoughts. Have fun with those.");
            break;
        case "4":
            Console.WriteLine("The toaster has become sentient! Time to fight!");
            //We need to pass in Coffee Machine somehow to the DisplayCombatScene() method, that way when we move to that instance it will know what enemy to grab.
            GameManager.Instance.DisplayCombatScene(currentGameState);
            break;
        case "5":
            Console.WriteLine("Accessing Options Menu...");
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
                   Console.WriteLine(@"What will you do? 
            
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
            Console.WriteLine("You check the remote. No batteries. Sorry.");
            break;
        case "4":
            Console.WriteLine("The Cloud has turned on you! The Azure Blob appears! Time to fight!");
            
            GameManager.Instance.DisplayCombatScene(currentGameState);
            break;
        case "5":
            Console.WriteLine("Accessing Options Menu...");
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
            
                   Console.WriteLine(@"What will you do? 
            
                              1.) Move to the Boss's Office.
                              2.) Go back to where you came.
                              3.) Explore the room.   
                              4.) Fight!
                              5.) Options Menu         ");
             string userInput = Console.ReadLine();

    switch (userInput)
    {
        case "1":
            GameManager.Instance.DisplayBossOfficeScene();
            break;
        case "2":
            GameManager.Instance.DisplayMeetingRoomScene();
            break;
        case "3":
            Console.WriteLine("You look through the uncomfortable silence and all you find is your own thoughts. Have fun with those.");
            break;
        case "4":
            Console.WriteLine("An Impromptu Meeting has appeared on your calendar! Time to fight!");
            
            GameManager.Instance.DisplayCombatScene(currentGameState);
            break;
        case "5":
            Console.WriteLine("Accessing Options Menu...");
            OptionsMenu();
            break;
        default:
            Console.WriteLine("You've made an invalid selection.");
            break;
    }
        }
        }
        public void BossOfficeMenu()
        {
            // assume logic would be different here.
        }

         public void SetCurrentGameState(GameState gameState)
        {
            currentGameState = gameState;
        }


    }

}