using System;
using System.Threading;
using System.Collections.Generic;

class SnowflakeAnimation
{
    // All the ANSI color codes for the palette we want to use.
    static readonly string[] colors = {
        "\u001b[38;5;15m", // White
        "\u001b[38;5;39m", // Light blue
        "\u001b[38;5;27m", // Blue
    };

    // Reset to base color.
    static readonly string resetColor = "\u001b[0m";

    // Snowflake shapes.
    static readonly string[] snowflakes = {
        " * ",
        "*o*",
        " * "
    };

    public static void SnowflakeAnim()
    {
        // Width and height of the console window size.
        const int width = 80;
        const int height = 20;

        // Time to play animation in milliseconds.
        const int duration = 2500;

        // Let's start the animation.
        DateTime startTime = DateTime.Now;

        // Initialize snowflakes positions.
        List<(int x, int y, string color, string shape)> activeSnowflakes = new List<(int, int, string, string)>();
        Random rand = new Random();

        // Play animation.
        while ((DateTime.Now - startTime).TotalMilliseconds < duration)
        {
            Console.Clear();

            // Add new snowflakes.
            if (rand.NextDouble() < 0.3)
            {
                int x = rand.Next(width);
                string color = colors[rand.Next(colors.Length)];
                string shape = GenerateSnowflakeShape();
                activeSnowflakes.Add((x, 0, color, shape));
            }

            // Move snowflakes down.
            for (int i = 0; i < activeSnowflakes.Count; i++)
            {
                var (x, y, color, shape) = activeSnowflakes[i];
                if (y < height)
                {
                    PrintSnowflake(x, y, color, shape, width, height);
                    activeSnowflakes[i] = (x, y + 1, color, shape);
                }
            }

            // Remove snowflakes that are out of screen.
            activeSnowflakes.RemoveAll(s => s.y >= height);

            Thread.Sleep(100);
        }

        // Close the animation and create the desired effect state.
        Console.Clear();
        Console.WriteLine("You have deployed Snowflake! The enemy is frozen in storage!");
    }

    static void PrintSnowflake(int x, int y, string color, string shape, int width, int height)
    {
        // Split the shape into lines.
        string[] lines = shape.Split('\n');
        for (int i = 0; i < lines.Length; i++)
        {
            int posY = y + i;
            if (posY < height)
            {
                Console.SetCursorPosition(x, posY);
                Console.Write(color + lines[i] + resetColor);
            }
        }
    }

    static string GenerateSnowflakeShape()
    {
        Random rand = new Random();
        int index = rand.Next(snowflakes.Length);
        return snowflakes[index];
    }

}

