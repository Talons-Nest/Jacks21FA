using System;
using Program; // Ensure Program namespace is accessible for GameState

namespace CombatSystem
{
    public class Combat
    {
    private Player player;
    private PlayerData playerData;
    private GameState currentGameState; // Ensure this is using the correct GameState type
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

        private void LoadCurrentMonster()
        {
            Console.WriteLine($"Loading monster for GameState: {currentGameState}");
            switch (currentGameState)
            {
                case GameState.CUBEFARM:
                    currentMonster = new OfficeZombie();
                    Console.WriteLine("Loaded OfficeZombie");
                    break;
                case GameState.KITCHEN:
                    // Implement CoffeeMachine class when ready
                    // currentMonster = new CoffeeMachine();
                    break;
                case GameState.QUIETROOM:
                    currentMonster = new Toaster();
                    Console.WriteLine("Loaded Toaster");
                    break;
                case GameState.MEETINGROOM:
                    // Implement ImpromptuMeeting class when ready
                    // currentMonster = new ImpromptuMeeting();
                    break;
                case GameState.BOSSOFFICE:
                    // Implement NACBoss class when ready
                    // currentMonster = new NACBoss();
                    break;
                default:
                    // Handle default case appropriately, like throwing an exception or choosing a default enemy
                    Console.WriteLine("Unknown GameState. No monster loaded.");
                    break;
            }
        }

        private bool RollForInitiative()
        {
            int playerRoll = random.Next(1, 11);
            int monsterRoll = random.Next(1, 11);
            Console.WriteLine($"You rolled a {playerRoll}. The {currentMonster?.EnemyName ?? "Unknown Enemy"} rolled a {monsterRoll}.");

            return playerRoll >= monsterRoll;
        }

        private void PlayerTurn()
        {
            if (currentMonster == null)
            {
                Console.WriteLine("No monster to fight. Combat cannot proceed.");
                return;
            }

            Console.WriteLine($"You encounter a {currentMonster.EnemyName}!");

            bool playerTurn = RollForInitiative();

            while (playerData.currentPlayerHP > 0 && currentMonster.EnemyHP > 0)
            {
                if (playerTurn)
                {
                    player.Attack(currentMonster);
                }
                else
                {
                    MonsterTurn();
                }
                playerTurn = !playerTurn;
            }

            if (playerData.currentPlayerHP <= 0)
            {
                Console.WriteLine("You have been defeated!");
            }
            else if (currentMonster.EnemyHP <= 0)
            {
                Console.WriteLine($"You have defeated the {currentMonster.EnemyName}!");
                playerData.currentPlayerExp += 10; // Grant some experience points
                playerData.LevelUp(); // Check if the player levels up
            }
        }

        private void MonsterTurn()
        {
            if (currentMonster == null)
            {
                Console.WriteLine("No monster to attack. Skipping monster's turn.");
                return;
            }

            Console.WriteLine($"The {currentMonster.EnemyName} attacks!");
            currentMonster.MonsterAttack(playerData);
        }

        public void CombatMenu()
        {
            while (true)
            {
                Console.WriteLine(@"Your enemy is coming for you Engineer, what will you do? 
                
                                  1.) Attack
                                  2.) ScriptIt!
                                  3.) Item
                                  4.) RunAway        ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        player.Attack(currentMonster);
                        break;
                    case "2":
                        player.ScriptIt();
                        break;
                    case "3":
                        player.Item();
                        break;
                    case "4":
                        player.RunAway();
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please choose again.");
                        break;
                }
            }
        }
    }
}
