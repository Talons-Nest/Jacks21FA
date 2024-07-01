using System;
using Program; //We're using this to inherit GameState.

namespace CombatSystem
{
<<<<<<< HEAD
    //First import or "Get Set" both the player and the enemy. Get Set their properties, sprites, and the players choices.
    Enemy officeZombie = new Enemy();
    Player player = new Player();
    //Create a while loop that is running as long as both characters have more than 0 HP the fight continues. Alternate turns. 
=======
    public class Combat
    {
        private Player player;
        private PlayerData playerData;
        private GameState currentGameState; //Make sure we're in the right gamestate please!
        private MonsterData currentMonster;
        private Random random;

        public Combat(Player player, PlayerData playerData, GameState currentGameState)
        {
            this.player = player;
            this.playerData = playerData;
            this.currentGameState = currentGameState; // Assign the passed GameState
            this.random = new Random();
            LoadCurrentMonster(); // Load the appropriate monster based on currentGameState
        }
>>>>>>> f87508d965c8ed3e5d0e3f3d4f68f9bc0649b93a

        private void LoadCurrentMonster()
        {
            TypeWriterEffect($"Loading monster for GameState: {currentGameState}");
            switch (currentGameState)
            {
                case GameState.CUBEFARM:
                    currentMonster = new OfficeZombie();
                    TypeWriterEffect("Loaded OfficeZombie");
                    break;
                case GameState.KITCHEN:
                    // Implement CoffeeMachine class when ready. Really its fine.
                    // currentMonster = new CoffeeMachine();
                    break;
                case GameState.QUIETROOM:
                    currentMonster = new Toaster();
                    TypeWriterEffect("Loaded Toaster");
                    break;
                case GameState.MEETINGROOM:
                    // Implement ImpromptuMeeting class when ready. Really its fine.
                    // currentMonster = new ImpromptuMeeting();
                    break;
                case GameState.BOSSOFFICE:
                    // Implement NACBoss class when ready. Really its fine.
                    // currentMonster = new NACBoss();
                    break;
                default:
                    // Do the default thing I guess?
                    TypeWriterEffect("Unknown GameState. No monster loaded.");
                    break;
            }
        }

        private bool RollForInitiative()
        {
            int playerRoll = random.Next(1, 11);
            int monsterRoll = random.Next(1, 11);
            TypeWriterEffect($"You rolled a {playerRoll}. The {currentMonster?.EnemyName ?? "Unknown Enemy"} rolled a {monsterRoll}.");

            return playerRoll >= monsterRoll;
        }

        private void PlayerTurn()
        {
            if (currentMonster == null)
            {
                TypeWriterEffect("No monster to fight. Combat cannot proceed.");
                return;
            }

            TypeWriterEffect($"You encounter a {currentMonster.EnemyName}!");

            bool playerTurn = RollForInitiative();

            while (playerData.currentPlayerHP > 0 && currentMonster.EnemyHP > 0)
            {
                if (playerTurn)
                {
                    TypeWriterEffect("Player's turn to attack!");
                    player.Attack(currentMonster);
                    TypeWriterEffect($"Debug: {currentMonster.EnemyName} has {currentMonster.EnemyHP} HP left."); //TODO: Turn this from a Debug to a displayed message for the player.
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
                TypeWriterEffect("No monster to attack. Skipping monster's turn.");
                return;
            }

            TypeWriterEffect($"The {currentMonster.EnemyName} attacks!");
            currentMonster.MonsterAttack(playerData);
        }

        public void CombatMenu()
        {
            TypeWriterEffect("Entering combat...");
            while (playerData.currentPlayerHP > 0 && currentMonster.EnemyHP > 0)
            {
                TypeWriterEffect(@"Your enemy is coming for you Engineer, what will you do? 
                
                                  1.) Attack
                                  2.) ScriptIt!
                                  3.) Item
                                  4.) RunAway        ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        TypeWriterEffect("Jack swings his FruityBook Air at the enemy!");
                        player.Attack(currentMonster);
                        TypeWriterEffect($"Debug: {currentMonster.EnemyName} has {currentMonster.EnemyHP} HP left."); //TODO: Turn this from a Debug to a displayed message for the player.
                        break;
                    case "2":
                        TypeWriterEffect("Jack says fuck it, it's time to script this sucker!");
                        player.ScriptIt();
                        break;
                    case "3":
                        TypeWriterEffect("Jack checks his cowboy hat for a useful item!");
                        player.Item();
                        break;
                    case "4":
                        TypeWriterEffect("Jack decides to go hide on the 16th floor and check the Wifi until things cool down.");
                        player.RunAway();
                        break;
                    default:
                        TypeWriterEffect("Invalid option. Please choose again.");
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
                TypeWriterEffect("You have been defeated!");
            }
            else if (currentMonster.EnemyHP <= 0)
            {
                //Victory! See if you gain some experience, drink some MaiTais, go on PTO...
                TypeWriterEffect($"You have defeated the {currentMonster.EnemyName}!");
                playerData.currentPlayerExp += 10; 
                TypeWriterEffect($"You have gained 10 experience points.");
                int previousLevel = playerData.currentPlayerLevel;
                playerData.LevelUp(); 

                if (playerData.currentPlayerLevel > previousLevel)
                {
                    TypeWriterEffect($"Congratulations! You have reached level {playerData.currentPlayerLevel}!");
                }

                int nextLevelExp = GetNextLevelExperience(playerData);
                if (nextLevelExp > 0)
                {
                    TypeWriterEffect($"You need {nextLevelExp - playerData.currentPlayerExp} more experience points to reach the next level.");
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
            TypeWriterEffect("Returning to previous game state...");
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
                case GameState.BOSSOFFICE:
                    GameManager.Instance.DisplayBossOfficeScene();
                    break;
                default:
                    TypeWriterEffect("Error: Invalid game state.");
                    break;
            }
        }

        private void TypeWriterEffect(string text)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(10); //This gives us a more typewriter like effect.
            }
            Console.WriteLine();
        }
    }
}
