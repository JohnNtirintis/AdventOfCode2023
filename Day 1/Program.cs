using System.Text;
using System.Text.RegularExpressions;

internal class Program
{
    static void Main(string[] args)
    {
        /*int part_one_solution_sum = SolvePartOne();

        System.Console.WriteLine(part_one_solution_sum);*/

        SolvePartTwo();
    }

    static int SolvePartOne()
    {
        // sum to return
        int sum = 0;
        // line to read from file
        String line = "";

        // regex to keep only numbers
        Regex digitsOnly = new Regex(@"\D+");

        StringBuilder sb = new StringBuilder();


        using (StreamReader sr = new StreamReader("input.txt"))
        {
            while ((line = sr.ReadLine()) != null)
            {
                // Keep only numbers and assign them to the variable digits
                String digits = digitsOnly.Replace(line, "");

                // if there was only 1 number in the line, add it 2 times in the str
                if (digits.Length == 1)
                {
                    sb.Append(digits[0], 2);
                }
                // if there were more than 1 numbers, add the first and the last numbers
                else if (digits.Length >= 2)
                {
                    sb.Append(digits[0]);
                    sb.Append(digits[digits.Length - 1]);
                }

                // convert to sb to string
                String pairs = sb.ToString();
                // to convert to int and assign to total 
                sum += int.Parse(pairs);

                // reset value of sb
                sb.Length = 0;
            }
        }
        return sum;
    }

    static void SolvePartTwo()
    {
        string? line;
        int sum = 0;
        int Parser(string input)
        {
            return input switch
            {
                "one" => 1,
                "two" => 2,
                "three" => 3,
                "four" => 4,
                "five" => 5,
                "six" => 6,
                "seven" => 7,
                "eight" => 8,
                "nine" => 9,
                _ => int.Parse(input)
            };
        }


        using(StreamReader sr = new StreamReader("input.txt"))
        {
            var localResults = new List<int>();
            while((line = sr.ReadLine()) != null)
            {
                localResults.Clear();
                string pattern = @"(?=(one|two|three|four|five|six|seven|eight|nine|\d))";
                var values = Regex.Matches(line, pattern);
                foreach (Match match in values)
                {
                    localResults.Add(Parser(match.Groups[1].Value));
                }
                sum += Convert.ToInt32($"{localResults.First()}{localResults.Last()}");
            }
        }

        Console.WriteLine(sum);
    }
}