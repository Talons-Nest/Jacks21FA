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
    
    public void FireWall()
    {
        FireAnimation.FireWallAnim();
       /*while(currentGameState == GameState.COMBAT)
        {
            if( player loses health)
            {
                deal fire damage to bad guy;
            }
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
