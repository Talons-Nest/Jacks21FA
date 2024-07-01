using Program;
//This is where all the logic for the combat system will go.
namespace CombatSystem
{
    public class Combat
{

        //The horror of object oriented programming is having to create a billion instances of things in different classes so that they can use each others methods. Fuck all. 
        Player player;
        PlayerData playerData;
        GameState currentGameState;
        MonsterData currentMonster;
        Random random;

        public Combat(Player player, PlayerData playerData, GameState currentGameState)
        {
            this.player = player;
            this.playerData = playerData;
            this.currentGameState = currentGameState;
            this.random = new Random();
            LoadCurrentMonster();
        }
       private void LoadCurrentMonster()
        {
            switch (currentGameState)
            {
                case GameState.CUBEFARM:
                    currentMonster = new Toaster();
                    break;
                case GameState.KITCHEN:
                    //currentMonster = new CoffeeMachine(); TODO: Create coffee machine.
                    break;
                case GameState.QUIETROOM:
                    currentMonster = new OfficeZombie();
                    break;
                case GameState.MEETINGROOM:
                    //currentMonster = new ImpromptuMeeting(); TODO: Create Impromptu Meeting.
                    break;
                case GameState.BOSSOFFICE:
                    //currentMonster = new NACBoss(); TODO: Create NACBoss.
                    break;
                default:
                    //currentMonster = new UnknownEnemy(); TODO: Create Default.
                    break;
            }
        }
         private bool RollForInitiative()
        {
            int playerRoll = random.Next(1, 11);
            int monsterRoll = random.Next(1, 11);
            Console.WriteLine($"You rolled a {playerRoll}. The {currentMonster.EnemyName} rolled a {monsterRoll}.");

            return playerRoll >= monsterRoll;
        }

        private void PlayerTurn()
         {
            Console.WriteLine($"You encounter a {currentMonster.EnemyName}!");

            bool playerTurn = RollForInitiative();

            while (playerData.currentPlayerHP > 0 && currentMonster.EnemyHP > 0)
            {
                if (playerTurn)
                {
                    PlayerTurn();
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

            Console.WriteLine($"The {currentMonster.EnemyName} attacks!");
            currentMonster.MonsterAttack(playerData);
        }

    //First import or "Get Set" both the player and the enemy. Get Set their properties, sprites, and the players choices.
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
                    player.Attack();
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
                }
            }
            
        }
    

    //Create a while loop that is running as long as both characters have more than 0 HP the fight continues. Alternate turns. 

    //Call the insantiated enemies AI. Give the player a turn with their action choices. 

    //Dice rolls should be used for both. Should that method be stored here? Called here? 
}
}
