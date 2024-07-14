using System.Dynamic;
using System.Xml.Serialization;

public class CoffeeMachine : MonsterData

{
    //Set HP, SP, AttackPower, Level, Magic Power, Magic Defense, Experience Given, and Enemy Name.
    public CoffeeMachine() : base(9, 4, 4, 1, 4, 4, 5, "Coffee Machine") {}

    public override void MonsterAttack(PlayerData player)
    {
        Console.WriteLine("The Coffee Machine prepares a fresh pot.");
        if (EnemyHP < 6)
        {
            Console.WriteLine("A scalding stream of bean water shoots toward you!");
            player.currentPlayerHP -= EnemyAttackPower * 2;
        }
        else
        {
            Console.WriteLine("The Coffee Machine ridicules you for your addiction to caffeine!");
            DamagePlayer(player);
        }
    }
}