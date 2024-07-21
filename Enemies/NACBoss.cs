//Implement specific constructor details and custom logic for NACBoss.
using System.Dynamic;
using System.Xml.Serialization;

public class NACBoss : MonsterData
{
    //Set HP, SP, AttackPower, Level, Magic Power, Magic Defense, Experience Given, and Enemy Name.
    public NACBoss() : base(100, 8, 8, 1, 8, 8, 30, "NAC Boss") {}

        public override void MonsterAttack(PlayerData player)
    {        
        if (EnemyHP >= 100)
        {
            Console.WriteLine("The NAC device laughs at you, you can hear it in your mind. You're so tired of this thing...");
            return;            
        }
        else
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
  \/       \/                            \/     \/");

    }      

   
}