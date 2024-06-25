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
    }

      public Dictionary<string, Items> itemsList; //Declaring the dictionary before initializing it.
      public ItemData() //Enclose inside of the ItemData initializing method.

     {
         itemsList = new Dictionary<string, Items>
    
     {
             { "Candy Bar", CandyBar },
             { "Cappuccino", Cappuccino },
             { "Free Lunch", FreeLunch }
     };
    }

}