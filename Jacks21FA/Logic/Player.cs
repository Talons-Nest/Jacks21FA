
public class Player : IPlayerDataProvider
{
    private PlayerData playerData;

    public Player(PlayerData playerData)
    {
        this.playerData = playerData;
    }

    // Explicitly implement the Player property from IPlayerDataProvider
    Player IPlayerDataProvider.Player => this;

    public PlayerData PlayerData => playerData;

    public void Attack(MonsterData enemy)
    {
        Console.WriteLine("You attack the enemy!");
        // Check if enemy is not null before accessing its properties
        //TODO Refactor this into calling a TakeDamage method with a playerData or currentMonster parameter and use it as an overload. 
        DamageEnemy(enemy);
    }

    private void DamageEnemy(MonsterData enemy)
    {
        if (enemy != null)
        {
            enemy.EnemyHP -= playerData.playerAttackPower;
        }
        else
        {
            Console.WriteLine("No enemy to attack!");
        }
    }

    public void ScriptIt()
    {
        
    }
    public void Item()
    {

    }

    public void RunAway()

    {
        
    }
    
}