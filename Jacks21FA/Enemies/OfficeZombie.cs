using System.Dynamic;
using System.Xml.Serialization;

public class OfficeZombie : MonsterData
{
    // trying to figure the logic 
    public OfficeZombie() : base(8, 2, 2, 5, "Office Zombie") {}

    public override void MonsterAttack(PlayerData player)
    {
        Console.WriteLine("The Zombie lurches at you");
        if (EnemyHP >= 8)
        {
            Console.WriteLine("The zombie shuffles. You could swear you hear groaning about phishing.");
            
        }
        else
             DamagePlayer(player);
             Console.WriteLine("The Office Zombie takes a bite out of you! Yikes!");
    }

   
}