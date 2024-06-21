using System;
using System.Threading;

namespace Program 

{
    public class Program
    {
        public static void Main(string[] args)

        {
        
           //Load bootstrap to keep game alive and handle other tasks.
            GameManager gameManager = new GameManager();
            Thread bootstrapThread = new Thread(new ThreadStart(gameManager.KeepAlive));
            bootstrapThread.Start();

            //Let's do some game stuff! Put in the logic of progressing through the game here. This would include any method calls or display graphics.
           while (true)
           {
                switch (gameManager.CurrentGameState)
                {
                    
                }
           }
            


            //After key is mashed let's do the join thread and close out the application.
            bootstrapThread.Join();

         

        }
    }
}