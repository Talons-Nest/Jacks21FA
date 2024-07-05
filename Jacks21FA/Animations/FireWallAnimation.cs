using System;
using System.Threading;

class FireAnimation
{
    //All the ANSI color codes for the palette we want to use.
    static readonly string[] colors = {
        "\u001b[38;5;160m", // Dark red
        "\u001b[38;5;196m", // Red
        "\u001b[38;5;202m", // Orange
        "\u001b[38;5;208m", // Light orange
        "\u001b[38;5;214m", // Yellow
        "\u001b[38;5;220m"  // Light yellow
    };

    //Reset to base color.
    static readonly string resetColor = "\u001b[0m";

    public static void FireWallAnim()
    {
        // Width and height of the console window size.
        const int width = 80;
        const int height = 20;

        //Let's create some chars to play with in the array.
        char[] fireChars = { ' ', '.', ':', '*', '+', 'o', 'O', '8', '&', '#', '@' };

        //Random number generator for the truth.
        Random rand = new Random();

        //Time to play animation in milliseconds.
        const int duration = 2500;

        //Let's start cooking baby!
        DateTime startTime = DateTime.Now;

        //Cook as long as this loop hasn't exceeded it's defined duration. Because I said so.
        while ((DateTime.Now - startTime).TotalMilliseconds < duration)
        {
            //Clean up for the animation.
            Console.Clear();

            //Go through each position in a for loop. For the lulz.
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    // Calculate a base intensity using a sine wave and randomness - I had to rob this from Trigonometry. Because dumb.
                    double baseIntensity = (Math.Sin(x * 0.1 + DateTime.Now.Millisecond * 0.005) + 1) / 2;

                    //Doing this randomly will add some organic effect.
                    double randomFactor = rand.NextDouble() * 0.5;

                    //Intensity calculation.
                    double intensity = baseIntensity + randomFactor;

                    //Ramp up the intensity to the range of fireChars array.
                    int index = (int)(intensity * (fireChars.Length - 1));
                    if (index >= fireChars.Length) index = fireChars.Length - 1;
                    if (index < 0) index = 0;

                    //Scale intensity to the range of colors in our char array.
                    int colorIndex = (int)(intensity * (colors.Length - 1));
                    if (colorIndex >= colors.Length) colorIndex = colors.Length - 1;
                    if (colorIndex < 0) colorIndex = 0;

                    //Show me the fire chars!
                    Console.Write(colors[colorIndex] + fireChars[index] + resetColor);
                }
                //Move down to the next line!
                Console.WriteLine();
            }

            //Respect the users CPU and take some milliseconds before calling the next frame. Also if its too fast well uh, you can't see it.
            Thread.Sleep(100);
        }

        //Close the animation out, and create desired effect state. May need a public enumerator to say hey loser, you now have protection with fire and it will burn the attacker each time they attack you for however many turns. Need a turn tracker method/function I guess if we want to be try hards.
        Console.Clear();
        Console.WriteLine("You've been protected by a wall of flame!");
    }
}
