using Program;
//We could use these methods to handle printing to the console and then call the description methods in the different scenes to print INSIDE this constructed string graphic. 
namespace MenuSystem

{
        public class Menu
    {

              

        public void CombatMenu()
        {
            
        }
        public void OptionsMenu()
        {
            //We need to get current instance or GameManager enum state so that when we exit the menu we know what the last menu was loaded so that we can reload the scene and menu options.
        }
        public void CubeFarmMenu()
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
            GameManager.Instance.DisplayCombatScene();
            break;
        case "4":
            Console.WriteLine("Accessing Options Menu...");
            OptionsMenu();
            break;
        default:
            Console.WriteLine("You've made an invalid selection.");
            break;
    }          
        }                       
        public void KitchenMenu()
        {
            
        }
        public void WellnessRoomMenu()
        {
            
        }
        public void MeetingRoomMenu()
        {
            
        }
        public void QuietRoomMenu()
        {
            
        }
        public void BossOfficeMenu()
        {
            
        }


    }

}
