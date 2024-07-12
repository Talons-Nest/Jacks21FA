using System.Diagnostics;
using CombatSystem;
using Program;


//This is where special magic attacks go.
 public class Scripts

{
   
    GameState currentGameState;  
    
    List<string> scripts = new List<string>()
    {
        "FireWall",
        "TerraForm",
        "SnowFlake",
        "GucciBolt"

    };

    
    
    public void FireWall()
    {
        //Set a status within Combat System that now happens whenever player is damaged and then stops after the fact.
        Console.WriteLine("You draw on the protections of the Firewall!");
        FireAnimation.FireWallAnim();
    }

    

    public void TerraForm()
    {
        Console.WriteLine("You lay out the perfect plan of attack with Terraform!");
        TerraformAnimation.TerraformAnim();  
    }

    public void Snowflake()
    {
        Console.WriteLine("You throw your enemy into the storage warehouse of ice!");
        SnowflakeAnimation.SnowflakeAnim();
    }

    public void GucciBolt()
    {
        Console.WriteLine("You solve the problem and now we're gucci! The enemy is struck by your brilliance!");
        GucciboltAnimation.GucciboltAnim();
    }
}
