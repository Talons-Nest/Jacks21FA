using System;
using System.Threading;
using System.Collections.Generic;

class MountainAnimation
{
    // All the ANSI color codes for the palette we want to use.
    static readonly string[] colors = {
        "\u001b[38;5;94m",  // Dark brown.
        "\u001b[38;5;130m", // Brown.
        "\u001b[38;5;136m", // Light brown.
        "\u001b[38;5;143m", // Lighter brown.
        "\u001b[38;5;179m", // Even lighter brown.
        "\u001b[38;5;223m", // Lightest brown.
        "\u001b[38;5;15m"   // White for peak.
    };

    // Reset to base color.
    static readonly string resetColor = "\u001b[0m";

    static void MountainPeakAnim()
    {
        // Width and height of the console window size.
        const int width = 40;
        const int height = 10;

        // Time to play animation in milliseconds.
        const int duration = 2500;

        // Let's start the animation.
        DateTime startTime = DateTime.Now;

        // Generate mountain frames.
        List<string> frames = GenerateMountainFrames(width, height);

        // Time per frame.
        int frameCount = frames.Count;
        int frameDurationMs = duration / frameCount;

        // Play animation.
        foreach (string frame in frames)
        {
            Console.Clear();
            Console.WriteLine(frame);
            Thread.Sleep(frameDurationMs);
        }

        // Close the animation and create the desired effect state.
        Console.Clear();
        Console.WriteLine("You've cast Terraform on the enemy!");
    }

    static List<string> GenerateMountainFrames(int width, int height)
    {
        List<string> frames = new List<string>();
        int peakHeight = height / 2;

        for (int peak = 0; peak <= peakHeight; peak++)
        {
            frames.Add(GenerateMountainFrame(width, height, peak));
        }

        for (int peak = peakHeight; peak >= 0; peak--)
        {
            frames.Add(GenerateMountainFrame(width, height, peak));
        }

        return frames;
    }

    static string GenerateMountainFrame(int width, int height, int peakHeight)
    {
        string[,] frame = new string[height, width];
        FillFrameWithSpaces(frame, height, width);

        int centerX = width / 2;
        int peakY = height - peakHeight - 1;

        for (int y = peakY; y < height; y++)
        {
            int offset = y - peakY;
            for (int x = centerX - offset; x <= centerX + offset; x++)
            {
                frame[y, x] = GetMountainChar(y, peakY, height);
            }
        }

        return ConvertFrameToString(frame, height, width);
    }

    static void FillFrameWithSpaces(string[,] frame, int height, int width)
    {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                frame[y, x] = " ";
            }
        }
    }

    static string GetMountainChar(int y, int peakY, int height)
    {
        if (y == peakY)
            return "\x1b[38;5;15m#\x1b[0m"; // White for peak.
        else if (y < peakY + 2)
            return "\x1b[38;5;223m#\x1b[0m"; // Lightest brown.
        else if (y < peakY + 4)
            return "\x1b[38;5;179m#\x1b[0m"; // Even lighter brown.
        else if (y < peakY + 6)
            return "\x1b[38;5;143m#\x1b[0m"; // Lighter brown.
        else if (y < peakY + 8)
            return "\x1b[38;5;136m#\x1b[0m"; // Light brown.
        else if (y < peakY + 10)
            return "\x1b[38;5;130m#\x1b[0m"; // Brown.
        else
            return "\x1b[38;5;94m#\x1b[0m"; // Dark brown.
    }

    static string ConvertFrameToString(string[,] frame, int height, int width)
    {
        string result = "";
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                result += frame[y, x];
            }
            result += "\n";
        }
        return result;
    }
}
