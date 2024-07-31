using System.Dynamic;
using System.Xml.Serialization;

public class ImpromptuMeeting : MonsterData

{
    //Set HP, SP, AttackPower, Level, Magic Power, Magic Defense, Experience Given, Defense, and Enemy Name.
    public ImpromptuMeeting() : base(7, 2, 3, 1, 5, 5, 3, 3, "Impromptu Meeting") {}

    public override void MonsterAttack(PlayerData player)
    {
        DrawImpromptuSprite();
        Console.WriteLine("The Impromtu Meeting begins off topic discussion!");    
        if (EnemyHP < 6)
        {
            Console.WriteLine("You are bored to exhaustion!");
            player.currentPlayerHP -= EnemyAttackPower * 2;
        }
        else if(EnemyHP == 7)
        {
            Console.WriteLine("The Impromptu meeting drain's your willpower! Ack!");
            player.currentPlayerSP -= EnemyMagPower;
        }
        else
        {
            Console.WriteLine("The Impromptu Meeting fires information that could have just been said in an email!");
            DamagePlayer(player);
        }
    }
    public void DrawImpromptuSprite()
    {
        Console.WriteLine(@"

   ______________________________
  |   n                          |
  |  / \  MEETING___NIOWWWWW     |
  | /_ _\       |   |            |
  |   U          \_/             |
  |               O              |
  |   ________________________   |
  |  |   |\              /|   |  |
  |  |   | \            / |   |  |
  |  |   | O\          /O |   |  |
  |  |   |___\        /___|   |  |
  |  |________________________|  |
  |        '''''''''''''''       |
  |           _________          |
  |          /_________\         |
  |             '''''            |
  |______________________________|
		 | |	|    |    | |
		 | |___/  __  \___| |
	      \____  /  \  ____/
	     	   \_\__/_/   ");

    }
    
}