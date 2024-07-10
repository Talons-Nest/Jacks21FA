//This is where all the item data is stored.
public delegate void Items(); //We have to invoke a delegate that can be inhereted outside of ItemData class.

public class ItemData
{
    
    PlayerData player = new PlayerData();

    public void CandyBar(PlayerData playerData)
    {


        //Heals 2HP.
                        if (playerData.currentPlayerHP < playerData.playerMaxHP)
                        {
                            Console.WriteLine("You take a bite of the delicious treat. You feel slightly better than before.");
                            playerData.currentPlayerHP += 2;
                        }
                        else 
                        {Console.WriteLine("HP is full.");}


    }

    public void Cappuccino(PlayerData playerData)
    {
                         if(playerData.currentPlayerSP < playerData.playerMaxSP)
                        {
                            Console.WriteLine("You drink the completely normal cappuccino you got from the completely normal coffee machine.");
                            playerData.currentPlayerSP += 2;
                        }
                        else 
                        {Console.WriteLine("SP is full.");}
    }

    public void FreeLunch(PlayerData playerData)

    {
        //Restores all HP and SP.
        Console.WriteLine("There's nothing better than a free lunch. You feel completely restored.");
          playerData.currentPlayerHP = playerData.playerMaxHP;
          playerData.currentPlayerSP = playerData.playerMaxSP;
    }

    public void OfficeBadge()
    {
        //Allows you to enter the Bosses Office.
        /*Console.WriteLine("You fiddle around for the thing around your neck. This is it, you have finally nailed down the environment's problem's. You feel it lurking behind the door in front of you.");
        GameManager.GameState = BOSSOFFICE*/
    }

      public Dictionary<string, Items> itemsList; //Declaring the dictionary before initializing it.
      /*
      public ItemData() //Enclose inside of the ItemData initializing method.

     {
         itemsList = new Dictionary<string, Items>
    
     {
             { "Candy Bar", CandyBar },
             { "Cappuccino", Cappuccino },
             { "Free Lunch", FreeLunch },
             {"Your Badge", OfficeBadge}
     }; */
    }

