using System.Security.Cryptography.X509Certificates;

public abstract class MonsterData
{    
    //Create a Constructor for a general monster.

    public int EnemyHP { get; set; }
    public int EnemySP { get; set; }
    public int EnemyAttackPower { get; set; }
    public int ExperienceToGive { get; set; }
    public string EnemyName { get; set; }
    protected bool dealtDamage;

    public MonsterData(int enemyHP, int enemySP, int enemyAttackPower, int experienceToGive, string enemyName )
    {
        EnemyHP = enemyHP;
        EnemySP = enemySP;
        EnemyAttackPower = enemyAttackPower;
        ExperienceToGive = experienceToGive;
        EnemyName = enemyName;
    }

    //Abstract method for monster attack AI. Create new individual cs files for specific beasties!
    public abstract void MonsterAttack(PlayerData player);
    public void DamagePlayer(PlayerData player)
     {
        {
            player.currentPlayerHP -= EnemyAttackPower;
            dealtDamage = true;
            Console.WriteLine($"They have dealt {EnemyAttackPower} damage to you!");
        }
     }

     public bool HasDealtDamage()
     {
        return dealtDamage;
     }

}
