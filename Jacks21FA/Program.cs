using System;
using System.Threading;

namespace Program 

{
    public class Program
    {
        public static void Main(string[] args)

        {
        
           //Load bootstrap to keep game alive and handle other tasks.
            Bootstrap bootstrap = new Bootstrap();
            Thread bootstrapThread = new Thread(new ThreadStart(bootstrap.KeepAlive));
            bootstrapThread.Start();

            //Let's do some game stuff! Put in the logic of progressing through the game here. This would include any method calls or display graphics.
            
            


            //After key is mashed let's do the join thread and close out.
            bootstrapThread.Join();

         

        }
    }
}