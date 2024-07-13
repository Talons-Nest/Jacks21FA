
public class AzureBlob : MonsterData

{
    public AzureBlob() : base(5, 2, 2, 1, "Azure Blob") {}

    public override void MonsterAttack(PlayerData player)
    {
        Console.WriteLine("The Azure Blob expands!");
        if (EnemyHP < 6)
        {
            Console.WriteLine("You are hit by the amorphous beast!");
            player.currentPlayerHP -= EnemyAttackPower * 2;
        }
        else
        {
            Console.WriteLine("The Azure Blob shoots goo toward you!");
            DamagePlayer(player);
        }
    }
}