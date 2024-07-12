using Program; //We're using this to inherit GameState.

namespace CombatSystem
{
    public class Combat
    {        
        //Delegate for the information in these classes.
        private Player player;
        private PlayerData playerData;
        private GameState currentGameState; //Make sure we're in the right gamestate please!
        protected MonsterData currentMonster; //Delegate for the information in these classes.
        private Random random;
        private IConsoleEffects consoleEffects = new ConsoleEffects();
        //Create an instance of Scripts here so that it can make the object references for the Script methods down below in the Combat System.
        private Scripts scripts = new Scripts();
        protected bool FireEffectOn = false;
        protected bool IceEffectOn = false;
        protected bool BoltEffectOn = false;
        protected bool EarthEffectOn = false;

        private static ItemData itemData = new ItemData();

        




        public Combat(Player player, PlayerData playerData, GameState currentGameState)
        {
            this.player = player;
            this.playerData = playerData;
            this.currentGameState = currentGameState; // Assign the passed GameState.
            this.random = new Random();
            LoadCurrentMonster(); // Load the appropriate monster based on currentGameState
        }

        private void LoadCurrentMonster()
        {
            //DEBUG: Console.WriteLine($"Loading monster for GameState: {currentGameState}");
            switch (currentGameState)
            {
                case GameState.CUBEFARM:
                    currentMonster = new OfficeZombie();
                    //DEBUG: TypeWriterEffect("Loaded OfficeZombie");
                    break;
                case GameState.KITCHEN:
                    currentMonster = new CoffeeMachine();
                    //DEBUG: TypeWriterEffect("Loaded CoffeeMachine");
                    break;
                case GameState.WELLNESSROOM:
                    currentMonster = new ImpromptuMeeting();
                    //DEBUG: TypeWriterEffect("Loaded ImpromptuMeeting");
                    break;
                case GameState.MEETINGROOM:
                    currentMonster = new AzureBlob();
                    //DEBUG: TypeWriterEffect("Azure Blob");
                    break;
                case GameState.QUIETROOM:
                    currentMonster = new Toaster();
                    //DEBUG: TypeWriterEffect("Loaded Toaster");
                    break;
                case GameState.NETWORKCLOSET:
                    // Implement NACBoss class when ready. Really its fine.
                    // currentMonster = new NACBoss();
                    break;
                default:
                    // Do the default thing I guess?
                    consoleEffects.TypeWriterEffect("Unknown GameState. No monster loaded.");
                    break;
            }
        }
        protected void FireDamage()
    {
                
        if (currentMonster.HasDealtDamage() && FireEffectOn)
        {
            int damage = 1;
            currentMonster.EnemyHP -= damage;
           consoleEffects.TypeWriterEffect($"Your protective flames lap at the {currentMonster} for {damage} damage!");
        }
    }

        protected static void IceDamage(MonsterData currentMonster, bool IceEffectOn)
        {

        }

        protected static void EarthDamage(MonsterData currentMonster, bool IceEffectOn)
        {

        }

        protected static void BoltDamage(MonsterData currentMonster, bool BoltEffectOn)
        {

        }
        //This method currently doesn't do anything beyond do the rolls. It needs to also adjust turn order at the start.
        private bool RollForInitiative()
        {
            int playerRoll = random.Next(1, 11);
            int monsterRoll = random.Next(1, 11);
            Console.WriteLine($"You rolled a {playerRoll}. The {currentMonster?.EnemyName ?? "Unknown Enemy"} rolled a {monsterRoll}.");

            return playerRoll >= monsterRoll;
        }

        private void CombatLoop()
        {
            
        }

        //We need to break this out and make a update loop that strictly handles the turn orders and call that the CombatLoop() Method. 
        private void PlayerTurn()
        {
            if (currentMonster == null)
            {
                Console.WriteLine("No monster to fight. Combat cannot proceed.");
                return;
            }

            consoleEffects.PrintDelayEffect($"You encounter a {currentMonster.EnemyName}!");

            bool playerTurn = RollForInitiative();

            while (playerData.currentPlayerHP > 0 && currentMonster.EnemyHP > 0)
            {
                if (playerTurn)
                {
                    consoleEffects.PrintDelayEffect("Your turn to attack!");
                    player.Attack(currentMonster);
                    consoleEffects.PrintDelayEffect($"{currentMonster.EnemyName} has {currentMonster.EnemyHP} HP left."); 
                }
                else
                {
                    MonsterTurn();
                }
                playerTurn = !playerTurn;
            }
        }

        private void MonsterTurn()
        {
            if (currentMonster == null)
            {
                Console.WriteLine("No monster to attack. Skipping monster's turn.");
                return;
            }
            
            currentMonster.MonsterAttack(playerData);
            consoleEffects.PrintDelayEffect($"You have {playerData.currentPlayerHP} HP left.");
            Console.WriteLine($"[DEBUG] FireEffectOn: {FireEffectOn}");
            FireDamage();
        }

        public void CombatMenu()//This is handling combat flow.
        {
            consoleEffects.PrintDelayEffect("Entering combat...");
            while (playerData.currentPlayerHP > 0 && currentMonster.EnemyHP > 0)
            
            {
                
                consoleEffects.PrintDelayEffect(@"Your enemy is coming for you Engineer, what will you do?"); 
                Console.WriteLine(@"
                                  1.) Attack
                                  2.) ScriptIt!
                                  3.) Item
                                  4.) RunAway        ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        consoleEffects.PrintDelayEffect("Jack swings his FruityBook Air at the enemy!");
                        player.Attack(currentMonster);
                        consoleEffects.PrintDelayEffect($"Debug: {currentMonster.EnemyName} has {currentMonster.EnemyHP} HP left."); //TODO: Turn this from a Debug to a displayed message for the player.
                        break;
                    case "2":
                        consoleEffects.PrintDelayEffect(@$"Jack says fuck it, let's script this out.");

                         if(playerData.currentScripts.Contains("Firewall"))
                         {
                            Console.WriteLine("1.) Firewall");                                                      
                         }
                         if(playerData.currentScripts.Contains("Terraform"))
                         {
                            Console.WriteLine("2.) Terraform");
                         }
                         if(playerData.currentScripts.Contains("Snowflake"))
                         {
                            Console.WriteLine("3.) Snowflake");
                         }
                         if(playerData.currentScripts.Contains("GucciBolt"))
                         {
                            Console.WriteLine("4.) GucciBolt");
                         }
                                               //player.ScriptIt(); FIX** Inheritance pains. Doing case choice instead for now.
                        string choice = Console.ReadLine();

                        switch (choice)
                        {
                        case "1": if(playerData.currentPlayerSP > 2)scripts.FireWall();
                        Console.WriteLine($"[DEBUG] FireEffectOn set to: {FireEffectOn}");
                        FireEffectOn = true;
                        break;
                        case "2": if(playerData.currentPlayerSP > 4)scripts.TerraForm();
                        EarthEffectOn = true;
                        break;
                        case "3": if(playerData.currentPlayerSP > 6)scripts.Snowflake();
                        IceEffectOn = true;
                        break;
                        case "4": if(playerData.currentPlayerSP > 8)scripts.GucciBolt();
                        BoltEffectOn = true;
                        break;
                        }
                        
                        break;
                    case "3":
                        consoleEffects.PrintDelayEffect("Jack checks his cowboy hat for a useful item!");
                        Console.WriteLine($"1.) Candy Bar");
                        Console.WriteLine("2.) Cappuccino");
                        Console.WriteLine("3.) Free Lunch");
                    
                        //player.ScriptIt(); FIX** Inheritance pains. Doing case choice instead for now.
                        string item = Console.ReadLine();
                        switch (item)
                        {
                        case "1": itemData.CandyBar(playerData);
                        break;
                        case "2": itemData.Cappuccino(playerData);
                        break;
                        case "3": itemData.FreeLunch(playerData);
                        break;
                        }  //TODO Get player currently available items. List items in numbered order for Console.ReadLine *and* how much of them you have. 
                        break;
                    case "4":
                        consoleEffects.PrintDelayEffect("Jack decides to go hide on the 16th floor and check the Wifi until things cool down.");
                        ReturnToPreviousGameState();
                        break;
                    default:
                        consoleEffects.PrintDelayEffect("Invalid option. Please choose again.");
                        break;
                }

                // Monster's turn to attack
                if (currentMonster.EnemyHP > 0)
                {
                    MonsterTurn();
                }
            }

            if (playerData.currentPlayerHP <= 0)
            {
                FireEffectOn = false;
                consoleEffects.PrintDelayEffect("You have been defeated!");
            }
            else if (currentMonster.EnemyHP <= 0)
            {
                //Victory! See if you gain some experience, drink some MaiTais, go on PTO...
                consoleEffects.PrintDelayEffect($"You have defeated the {currentMonster.EnemyName}!");
                FireEffectOn = false;
                playerData.currentPlayerExp += 10; 
                consoleEffects.PrintDelayEffect($"You have gained 10 experience points.");
                int previousLevel = playerData.currentPlayerLevel;
                playerData.LevelUp(); 

                if (playerData.currentPlayerLevel > previousLevel)
                {
                    consoleEffects.PrintDelayEffect($"Congratulations! You have reached level {playerData.currentPlayerLevel}!");
                }

                int nextLevelExp = GetNextLevelExperience(playerData);
                if (nextLevelExp > 0)
                {
                    consoleEffects.PrintDelayEffect($"You need {nextLevelExp - playerData.currentPlayerExp} more experience points to reach the next level.");
                }

                ReturnToPreviousGameState(); //Go back from whence you came young hobbit!
            }
        }

        private int GetNextLevelExperience(PlayerData playerData)
        {
            foreach (var exp in playerData.experienceToLevel.Keys)
            {
                if (exp > playerData.currentPlayerExp)
                {
                    return exp;
                }
            }
            return -1; //If there's no next level, fuck off no leveling for you plebian.
        }

        private void ReturnToPreviousGameState()
        {
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
