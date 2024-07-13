//Implement specific constructor details and custom logic for Toaster.

public class Toaster : MonsterData

{
    public Toaster() : base(10, 1, 2, 7, "Toaster") {}

    public override void MonsterAttack(PlayerData player)
    {
        Console.WriteLine("The Toaster is heating up!");
        if (EnemyHP < 8)
        {
            Console.WriteLine("The Toaster launches a fiery attack!");
            player.currentPlayerHP -= EnemyAttackPower * 2;
        }
        else
        {
            Console.WriteLine("The Toaster assaults you with a flying piece of toasted bread. Yikes!");
            DamagePlayer(player);
        }
    }



    public void DrawToasterSprite()
    {
        Console.WriteLine(@"  .___________.
                              |           |
       ___________.           |  |    /~\ |
      / __   __  /|           | _ _   |_| |
     / /:/  /:/ / |           !________|__!
    / /:/  /:/ /  |                    |
   / /:/  /:/ /   |____________________!
  / /:/  /:/ /    |
 / /:/  /:/ /     |
/  ~~   ~~ /      |
|~~~~~~~~~~|      |
|    ::    |     /
|    ==    |    /
|    ::    |   /
|    ::    |  /
|    ::  @ | /
!__________!/
");
    }



}

