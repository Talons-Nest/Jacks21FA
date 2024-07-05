//This is where all the stored player data goes.

public class PlayerData
{    //Constructor and properties for Player information. Health, Attack Power, ScriptPoints. You know, the fun stuff.

    public int playerMaxHP = 10;
    public int currentPlayerHP = 10;
    public int playerMaxSP = 3;
    public int currentPlayerSP = 3;
    public int playerAttackPower = 2;
    public int currentPlayerExp = 0;

    public int currentPlayerLevel = 1;
    public List <string> currentScripts = new List <string>()
    {
        "Firewall"
    };

    public Dictionary <int, int> experienceToLevel = new Dictionary<int, int>()
    {
        {5 , 1},
        {10, 2},
        {20, 3},
        {40, 4},
        {60, 5},
        {80, 6},
        {100,7},
        {130,8},
        {150,9},
        {200,10}
    };

    public void LevelUp()//We're using the Diciontary above to compare the number of XP needed to level, with what level we are. Increase stats at level up.
    {
        foreach(var keyValuePair in experienceToLevel)
        {
            if (currentPlayerExp >= keyValuePair.Key)
            {
                currentPlayerLevel = keyValuePair.Value;

                switch (currentPlayerLevel)
                {
                    case 1:
                        playerMaxHP += 5;
                        playerMaxSP += 3;
                        playerAttackPower += 2;
                        break;
                    case 2:
                        playerMaxHP += 5;
                        playerMaxSP += 3;
                        playerAttackPower += 2;
                        break;
                    case 3:
                        playerMaxHP += 5;
                        playerMaxSP += 3;
                        playerAttackPower += 2;
                        break;
                    case 4:
                        playerMaxHP += 5;
                        playerMaxSP += 3;
                        playerAttackPower += 2;
                        break;
                    case 5:
                        playerMaxHP += 5;
                        playerMaxSP += 3;
                        playerAttackPower += 2;
                        break;
                    case 6:
                        playerMaxHP += 5;
                        playerMaxSP += 3;
                        playerAttackPower += 2;
                        break;
                    case 7:
                        playerMaxHP += 5;
                        playerMaxSP += 3;
                        playerAttackPower += 2;
                        break;
                    case 8:
                        playerMaxHP += 5;
                        playerMaxSP += 3;
                        playerAttackPower += 2;
                        break;
                    case 9:
                        playerMaxHP += 5;
                        playerMaxSP += 3;
                        playerAttackPower += 2;
                        break;
                    case 10:
                        playerMaxHP += 5;
                        playerMaxSP += 3;
                        playerAttackPower += 2;
                        break;
                }
            }
            else
            {
                //If you can't level up right now, don't do it. 
                break;
            }
        }     
    }


}

