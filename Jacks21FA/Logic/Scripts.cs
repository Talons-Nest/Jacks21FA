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
       
        FireAnimation.FireWallAnim();
        
        //Set a status within Combat System that now happens whenever player is damaged and then stops after the fact.
        Console.WriteLine("You draw on the protections of the Firewall!.");
    }

    

    public void TerraForm()
    {
        TerraformAnimation.TerraformAnim();
    }

    public void Snowflake()
    {
        SnowflakeAnimation.SnowflakeAnim();
    }

    public void GucciBolt()
    {
        GucciboltAnimation.GucciboltAnim();
    }
}
