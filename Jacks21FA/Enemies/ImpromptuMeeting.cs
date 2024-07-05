using System.Dynamic;
using System.Xml.Serialization;

public class ImpromptuMeeting : MonsterData

{
    public ImpromptuMeeting() : base(9, 4, 4, 5, "Impromptu Meeting") {}

    public override void MonsterAttack(PlayerData player)
    {
        Console.WriteLine("The Impromtu Meeting begins off topic discussion!");
        if (EnemyHP < 6)
        {
            Console.WriteLine("You are bored to exhaustion!");
            player.currentPlayerHP -= EnemyAttackPower * 2;
        }
        else
        {
            Console.WriteLine("The Impromptu Meeting fires information that could have just been said in an email!");
            {
                player.currentPlayerHP -= EnemyAttackPower;
            }
        }
    }
}