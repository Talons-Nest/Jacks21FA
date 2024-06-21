namespace Program
{
    public class Bootstrap
    {
           
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



