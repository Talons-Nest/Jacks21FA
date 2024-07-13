//Implement specific constructor details and custom logic for NACBoss.
using System.Dynamic;
using System.Xml.Serialization;

public class NACBoss : MonsterData
{
    public NACBoss() : base(100, 8, 8, 30, "NAC Boss") {}

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

   
}