using System.Dynamic;
using System.Xml.Serialization;

public class OfficeZombie : MonsterData
{
    // Zombie HP should be 8. I changed to 2 for testing purposes for items.
    public OfficeZombie() : base(2, 2, 2, 5, "Office Zombie") {}

    public override void MonsterAttack(PlayerData player)
    {        
        if (EnemyHP >= 8)
        {
            Console.WriteLine("The zombie shuffles. You could swear you hear groaning about phishing.");
            return;            
        }
        else
             DamagePlayer(player);
             Console.WriteLine("The Office Zombie takes a bite out of you! Yikes!");
    }

   
}