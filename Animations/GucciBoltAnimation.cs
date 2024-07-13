using System;
using System.Threading;
using System.Collections.Generic;

class GucciboltAnimation
{
    // All the ANSI color codes for the palette we want to use.
    static readonly string[] colors = {
        "\u001b[38;5;226m", // Yellow
        "\u001b[38;5;220m", // Light yellow
        "\u001b[38;5;214m", // Lighter yellow
    };

    // Reset to base color.
    static readonly string resetColor = "\u001b[0m";

    // Lightning bolt shape.
    static readonly string[] lightningBolt = {
     
        "             d$$$$$$\"",
        "           .d$$$$$$\"",
        "          .$$$$$$P\"",
        "         z$$$$$$P",
        "        d$$$$$$\"",
        "      .d$$$$$$\"",
        "     .$$$$$$$\"",
        "    z$$$$$$$beeeeee",
        "   d$$$$$$$$$$$$$*",
        "  ^\"\"\"\"\"\"\"\"$$$$$\"",
        "          d$$$*",
        "         d$$$\"",
        "        d$$*",
        "       d$P\"",
        "     .$$\"",
        "    .$P\"",
        "   .$\"",
        "  .P\"",
        " .\"",
        "/\""
    };

    public static void GucciboltAnim()
    {
        // Width and height of the console window size.
        const int width = 80;
        const int height = 20;

        // Time to play animation in milliseconds.
        const int duration = 2500;

        // Let's start the animation.
        DateTime startTime = DateTime.Now;

        // Initialize random number generator.
        Random rand = new Random();

        // Play animation.
        while ((DateTime.Now - startTime).TotalMilliseconds < duration)
        {
            Console.Clear();

            // Determine starting position for the lightning bolt.
            int startX = rand.Next(width - 33); // Ensure it fits within the width
            int y = 0;

            // Draw the lightning bolt.
            foreach (string line in lightningBolt)
            {
                if (y >= height) break;

                int x = startX;

                // Choose a random color for the lightning bolt segment.
                string color = colors[rand.Next(colors.Length)];

                // Print the lightning bolt segment.
                if (x + line.Length < width)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(color + line + resetColor);
                }
                y++;
                Thread.Sleep(50);
            }

            // Draw the blast effect at the bottom of the screen.
            string blastColor = colors[rand.Next(colors.Length)];
            for (int i = 0; i < width; i++)
            {
                Console.SetCursorPosition(i, height - 1);
                Console.Write(blastColor + "*" + resetColor);
            }

            Thread.Sleep(100);
        }

        // Close the animation and create the desired effect state.
        Console.Clear();
        Console.WriteLine("You just turned the enemy off and on again! We're gucci!");
    }

}
