namespace Program
{
    public class GameManager
    {
            //We need to define an Enumerator to handle what state of the game we are in.
            public enum GameState
            {
                MAINMENU,
                COMBAT,
                ROOM1,
                ROOM2,
                ROOM3,
                ROOM4,
                ROOM5,
                ROOM6
            }

           
           
           public void KeepAlive()

           {
                while (true)
            {
                if (Console.In.Peek() > -1)
                {
                    ConsoleKeyInfo key = Console.ReadKey(intercept: true);
                    if (key.KeyChar == 'q')
                    break;
                }
            }
            Console.WriteLine("You're fleeing to the nearest networking closet. Coward.");
        }

    }
}



