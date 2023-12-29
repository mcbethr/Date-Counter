using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length != 2)
        {
            Console.WriteLine("Usage: DateCounter <inputFilePath> <outputFilePath>");
            return;
        }

        string inputFilePath = args[0];
        string outputFilePath = args[1];

        try
        {
            // Read all lines from the input file
            string[] lines = File.ReadAllLines(inputFilePath);

            // Count occurrences of each date
            Dictionary<string, int> dateCounts = CountDates(lines);

            // Write results to the output file
            WriteResults(dateCounts, outputFilePath);

            Console.WriteLine("Process completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    static Dictionary<string, int> CountDates(string[] lines)
    {
        Dictionary<string, int> dateCounts = new Dictionary<string, int>();

        foreach (string line in lines)
        {
            // Assuming each line contains a date
            string date = line.Trim();

            if (dateCounts.ContainsKey(date))
            {
                dateCounts[date]++;
            }
            else
            {
                dateCounts[date] = 1;
            }
        }

        return dateCounts;
    }

    static void WriteResults(Dictionary<string, int> dateCounts, string outputFilePath)
    {
        using (StreamWriter writer = new StreamWriter(outputFilePath))
        {
            // Write header
            writer.WriteLine("Date,Count");

            // Write date and count to the output file
            foreach (var kvp in dateCounts)
            {
                writer.WriteLine($"{kvp.Key},{kvp.Value}");
            }
        }
    }
}
