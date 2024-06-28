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
            // Daniel is cool
            //Let's do some game stuff! Put in the logic of progressing through the game here. This would include any method calls or display graphics. Starting with the while loop for the switch and calling the different states from GameManager.
           while (true)
           {
                switch (gameManager.CurrentGameState)
                {
                    case GameState.MAINMENU:
                    gameManager.DisplayMainMenu();
                    break;
                    
                    case GameState.COMBAT:
                    gameManager.DisplayCombatScene();
                    break;
                    
                    case GameState.CUBEFARM:
                    gameManager.DisplayCubeFarmScene();
                    break;
                    
                    case GameState.KITCHEN:
                    gameManager.DisplayKitchenScene();
                    break;
                    
                    case GameState.QUIETROOM:
                    gameManager.DisplayQuietroomScene();
                    break;
                    
                    case GameState.WELLNESSROOM:
                    gameManager.DisplayWellnessRoomScene();
                    break;
                    
                    case GameState.MEETINGROOM:
                    gameManager.DisplayMeetingRoomScene();
                    break;
                    
                    case GameState.BOSSOFFICE:
                    gameManager.DisplayBossOfficeScene();
                    break;
                                 
                }
                
           }
            
            //After key is mashed let's do the join thread and close out the application.
            bootstrapThread.Join();
      

        }
    }
}