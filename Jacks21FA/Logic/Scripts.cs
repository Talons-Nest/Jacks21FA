using Program;


//This is where special magic attacks go.
class Scripts

{
    GameState currentGameState;  
    
    List<string> scripts = new List<string>()
    {
        "FireWall",
        "TerraForm",
        "SnowFlake",
        "GucciBolt"

    };

    
    
    public void FireWall(MonsterData currentMonster, PlayerData playerData)
    {
        FireAnimation.FireWallAnim();
       /*while(currentGameState == GameState.COMBAT)
       {
            
       }
        */
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
