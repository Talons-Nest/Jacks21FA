//This is where all the item data is stored.
public delegate void Items(); //We have to invoke a delegate that can be inhereted outside of ItemData class.
 
public class ItemData
{
 
    public void CandyBar()
    {
        //Heals 2HP.
    }

    public void Cappuccino()
    {
        //Restores 2SP
    }

    public void FreeLunch()

    {
        //Restores all HP and SP.
        /*Console.WriteLine("There's nothing better than a free lunch. You feel completely restored.");
          Player.currentPlayerHP = Player.playerMaxHP
          Player.currentPlayerSP = Player.playerMaxSP*/
    }

    public void OfficeBadge()
    {
        //Allows you to enter the Bosses Office.
        /*Console.WriteLine("You fiddle around for the thing around your neck. This is it, you have finally nailed down the environment's problem's. You feel it lurking behind the door in front of you.");
        GameManager.GameState = BOSSOFFICE*/
    }

      public Dictionary<string, Items> itemsList; //Declaring the dictionary before initializing it.
      public ItemData() //Enclose inside of the ItemData initializing method.

     {
         itemsList = new Dictionary<string, Items>
    
     {
             { "Candy Bar", CandyBar },
             { "Cappuccino", Cappuccino },
             { "Free Lunch", FreeLunch },
             {"Your Badge", OfficeBadge}
     };
    }

}