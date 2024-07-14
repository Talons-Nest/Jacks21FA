using System.Security.Cryptography.X509Certificates;

public abstract class MonsterData
{    
    //Create a Constructor for a general monster.

    public int EnemyHP { get; set; }
    public int EnemySP { get; set; }
    public int EnemyAttackPower { get; set; }
    public int EnemyLevel {get; set;}
    public int EnemyMagPower {get; set;}
    public int EnemyMagDefense {get; set;}
    public int ExperienceToGive { get; set; }
    public string EnemyName { get; set; }
    protected bool dealtDamage;
    
    //Set HP, SP, AttackPower, Level, Magic Power, Magic Defense, Experience Given, and Enemy Name.

    public MonsterData(int enemyHP, int enemySP, int enemyAttackPower, int enemyLevel, int enemyMagPower, int enemyMagDefense, int experienceToGive, string enemyName )
    {
        EnemyHP = enemyHP;
        EnemySP = enemySP;
        EnemyAttackPower = enemyAttackPower;
        EnemyLevel = enemyLevel;
        EnemyMagPower = enemyMagPower;
        EnemyMagDefense = enemyMagDefense;
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
