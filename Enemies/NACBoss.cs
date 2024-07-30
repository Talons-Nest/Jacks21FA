//Implement specific constructor details and custom logic for NACBoss.

public class NACBoss : MonsterData
{
    //Set HP, SP, AttackPower, Level, Magic Power, Magic Defense, Experience Given, and Enemy Name.
    public NACBoss() : base(100, 8, 8, 1, 8, 8, 30, 8, "NAC Boss") {}

        public override void MonsterAttack(PlayerData player)
    {   
        DrawNACBossSprite();     
        
        if(EnemyHP >= 100)
        {
            Console.WriteLine("The NAC device laughs at you, you can hear it in your mind. You're so tired of this thing...");
            return;            
        }
        else if (EnemyHP >= 99)
        {
            Console.WriteLine("The NAC drains your will to continue! You've lost SP!");
            player.currentPlayerSP -= EnemyMagPower;
            Console.WriteLine("It assaults you with its additional ports! No!!");
            player.currentPlayerHP -= EnemyAttackPower;
        }
        else if (EnemyHP >= 50)
             DamagePlayer(player);
             Console.WriteLine("It whips its LAN cables at you! Ouch!");
    }

    public void DrawNACBossSprite()
    {
        Console.WriteLine(@"

                         /\
                        /  \
                       /    \
                      / /  \ \
                     / /    \ \
            /\      /  |    |  \      /\
      /\   /  \    /    \  /    \    /  \   /\
     /()\_/ () \__/              \__/ () \_/()\
   _/__________________________________________\_
  |   \   |   /                      \   |   /   |
  |    \__|__/                        \__|__/    |
  |                ______________                |
  |               |  |  |  |  |  |               |
  |_______________|__|__|__|__|__|_______________|
    /      /                            \      \
   /      /                              \      \
   \      \                              /       \
   /       \                             \       /
  /\       /\                            /\     /\
  \/       \/                            \/     \/  ");

    }      

   
}