//This is where all the stored player data goes.

public class PlayerData
{    //Constructor and properties for Player information. Health, Attack Power, ScriptPoints. You know, the fun stuff. //Serialize this values for the safe file.

    public int playerMaxHP = 10;
    public int currentPlayerHP = 10;
    public int playerMaxSP = 3;
    public int currentPlayerSP = 3;
    public int playerAttackPower = 2;
    public int currentPlayerExp = 0;
    public int currentPlayerLevel = 1;
    public int currentMagPower = 2;
    public int currentMagDefense = 2;
    public List <string> currentScripts = new List <string>()//Serialize this value for the safe file.
    {
        "Firewall"
    };

    public Dictionary<string, int> Inventory = new Dictionary<string, int>()//Serialize this values for the safe file.
    {
        {"Candy Bar", 1},
        {"Cappuccino", 1},
        {"Free Lunch", 1},
        {"Office Badge", 0}
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
                        currentMagPower +=2;
                        currentMagDefense += 2;
                        playerAttackPower += 2;
                        break;
                    case 2:
                        playerMaxHP += 5;
                        playerMaxSP += 3;
                        currentMagPower +=2;
                        currentMagDefense += 2;
                        playerAttackPower += 2;
                        currentScripts.Add("Terraform");
                        break;
                    case 3:
                        playerMaxHP += 5;
                        playerMaxSP += 3;
                        currentMagPower +=2;
                        currentMagDefense += 2;
                        playerAttackPower += 2;
                        break;
                    case 4:
                        playerMaxHP += 5;
                        playerMaxSP += 3;
                        currentMagPower +=2;
                        currentMagDefense += 2;
                        playerAttackPower += 2;
                        break;
                    case 5:
                        playerMaxHP += 5;
                        playerMaxSP += 3;
                        currentMagPower +=2;
                        currentMagDefense += 2;
                        playerAttackPower += 2;
                        currentScripts.Add("Snowflake");
                        break;
                    case 6:
                        playerMaxHP += 5;
                        playerMaxSP += 3;
                        currentMagPower +=2;
                        currentMagDefense += 2;
                        playerAttackPower += 2;
                        Inventory["Office Badge"] += 1;
                        break;
                    case 7:
                        playerMaxHP += 5;
                        playerMaxSP += 3;
                        currentMagPower +=2;
                        currentMagDefense += 2;
                        playerAttackPower += 2;
                        break;
                    case 8:
                        playerMaxHP += 5;
                        playerMaxSP += 3;
                        currentMagPower +=2;
                        currentMagDefense += 2;
                        playerAttackPower += 2;
                        break;
                    case 9:
                        playerMaxHP += 5;
                        playerMaxSP += 3;
                        currentMagPower +=2;
                        currentMagDefense += 2;
                        playerAttackPower += 2;
                        break;
                    case 10:
                        playerMaxHP += 5;
                        playerMaxSP += 3;
                        currentMagPower +=2;
                        currentMagDefense += 2;
                        playerAttackPower += 2;
                        currentScripts.Add("Guccibolt");
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

