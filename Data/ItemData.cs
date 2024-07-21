//This is where all the item data is stored.
using System.Linq.Expressions;

public delegate void Items(); //We have to invoke a delegate that can be inhereted outside of ItemData class.

public class ItemData
{
    
    PlayerData player = new PlayerData();

    Random random= new Random();

    bool itemLoot = false;

    public void CandyBar(PlayerData playerData)
    
    {
        //Heals 2HP.
        if (playerData.Inventory.ContainsKey("Candy Bar"))
        {
        int candyCount = playerData.Inventory["Candy Bar"];
        if(playerData.currentPlayerHP < playerData.playerMaxHP && candyCount > 0)                             
        {
            Console.WriteLine("You take a bite of the delicious treat. You gain 2 HP.");
            playerData.currentPlayerHP += 2;
            playerData.Inventory["Candy Bar"]--;
        }
        else if (playerData.Inventory["Candy Bar"] == 0)
        {
            Console.WriteLine("You are out of candy bars.");
        }
        else 
        {
            Console.WriteLine("HP is full.");}
        }
    }               
    
     public void Cappuccino(PlayerData playerData)
    
    {
        //Heals 2HP.
        if (playerData.Inventory.ContainsKey("Cappaccino"))
        {
        int cappuccinoCount = playerData.Inventory["Candy Bar"];
        if(playerData.currentPlayerSP < playerData.playerMaxSP && cappuccinoCount > 0)                             
        {
            Console.WriteLine("You take a long relaxing sip of hot bean potion. You gain 2 SP.");
            playerData.currentPlayerSP += 3;
            playerData.Inventory["Cappaccino"]--;
        }
        else if (playerData.Inventory["Cappaccino"] == 0)
        {
            Console.WriteLine("You are out of delicious bean potion.");
        }
        else 
        {
            Console.WriteLine("SP is full.");}
        }
    }    

    public void FreeLunch(PlayerData playerData)

    {
        if(playerData.Inventory.ContainsKey("Free Lunch"))
        {
            int freeLunchCount = playerData.Inventory["Free Lunch"];
             //Restores all HP and SP.
        if(playerData.currentPlayerSP < playerData.playerMaxSP && freeLunchCount >= 1)
        {
            Console.WriteLine("There's nothing better than a free lunch. You feel completely restored. You have full HP and SP.");
          playerData.currentPlayerHP = playerData.playerMaxHP;
          playerData.currentPlayerSP = playerData.playerMaxSP;
          playerData.Inventory["Free Lunch"]--;
        }
        else if (playerData.Inventory["Free Lunch"] == 0)
        {
            Console.WriteLine("There is no free lunch. It must be Wednesday my dude.");

        }
        else{Console.WriteLine("Your HP and SP are full. Mentally I'm not sure whats going on. Maybe try something else.");}
        }  
    }

    public void OfficeBadge()
    {
        //Allows you to enter the Bosses Office.
        /*Console.WriteLine("You fiddle around for the thing around your neck. This is it, you have finally nailed down the environment's problem's. You feel it lurking behind the door in front of you.");
        GameManager.GameState = BOSSOFFICE*/
    }

    public bool ItemLoot(PlayerData playerData)
    {
        int itemRoll = random.Next(1, 11);
        //Console.WriteLine($"Debug:{itemRoll} BEFORE LOOT Item tracking you have this many candy bards:{candy}");
        if(itemRoll <= 5)
        {
            playerData.Inventory["Candy Bar"]++;
            //Console.WriteLine($"Debug: AFTER LOOT Item tracking you have this many candy bars: {candy}");   
        }
        else if(itemRoll >= 6 && itemRoll <= 10)
        {
            playerData.Inventory["Cappuccino"]++;
            //Console.WriteLine($"Debug: AFTER LOOT Item tracking you have this many ccappuccinos: {cappuccino}"); 
        }
        else if (itemRoll == 11)
        {
            playerData.Inventory["FreeLunch"]++;
            //Console.WriteLine($"Debug: AFTER LOOT Item tracking you have this many free lunches: {freelunch}");
        }
        else
        {
            Console.WriteLine("try again.");
        }
        return itemLoot; // Add a return statement at the end of the method.
    }



}