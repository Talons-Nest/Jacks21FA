using System.Dynamic;
using System.Xml.Serialization;

public class OfficeZombie : MonsterData
{
    //Set HP, SP, AttackPower, Level, Magic Power, Magic Defense, Experience Given, and Enemy Name.
    public OfficeZombie() : base(8, 2, 2, 1, 0, 0, 5, 1, "Office Zombie") {}

    public override void MonsterAttack(PlayerData player)
    {   
        DrawZombieSprite();     
        if (EnemyHP >= 8)
        {
            Console.WriteLine("The zombie shuffles. You could swear you hear groaning about phishing.");
            return;            
        }
        else
             DamagePlayer(player);
             Console.WriteLine("The Office Zombie takes a bite out of you! Yikes!");
    }

    public void DrawZombieSprite()
    {
                    Console.WriteLine(@"

          | | | | | | | | | | | 
         _|_|_|_|_|_|_|_|_|_|_|__
       /                          \
      /                            \
     /        ___        ___        \
    /        / _ \      / _ \        \
    |       | | | |    | | | |       |
    |       | |_| |    | |_| |       |
    |        \___/      \___/        |
    |              |  |              |
    |             (    )             |
    |           ____________         |
    |          /____________\        |
    |         |             |        |
    \         |____________ |       /
     \         \____________/      /
	  |___________________________|
	       |         X         |
		   |        / \        |
		   |        \ /        |
		   |         V         |
		   |___________________|    ");

    }      
}