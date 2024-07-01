public abstract class MonsterData
{    
    //Create a Constructor for a general monster.

    public int EnemyHP { get; set; }
    public int EnemySP { get; set; }
    public int EnemyAttackPower { get; set; }
    public int ExperienceToGive { get; set; }
    public string EnemyName { get; set; }

    public MonsterData(int enemyHP, int enemySP, int enemyAttackPower, int experienceToGive, string enemyName )
    {
        EnemyHP = enemyHP;
        EnemySP = enemySP;
        EnemyAttackPower = enemyAttackPower;
        ExperienceToGive = experienceToGive;
        EnemyName = enemyName;
    }

    //Abstract method for monster attack AI.
    public abstract void MonsterAttack(PlayerData player);

    //Constructor with properties already set for Toaster enemy. 

    //Constructer with properties already set for Coffee Machine enemy.

    //Constructor with properties already set for Office Zombie enemy.

    //Constructor with properties already set for NAC Boss.

    

   

}