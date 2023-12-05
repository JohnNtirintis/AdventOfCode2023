internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(ProblemA());
    }

    static int ProblemA()
    {
        string line;
        int sum = 0;
        char[] delimiters = { ':', '|' };

        using (StreamReader sr = new StreamReader("input.txt"))
        {
            while ((line = sr.ReadLine()) != null)
            {
                int count = 0;
                string[] splitLine = line.Split(delimiters);

                var winningNumsStr = splitLine[1].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var pickedNumsStr = splitLine[2].Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var winningNums = Array.ConvertAll(winningNumsStr, s => int.Parse(s));
                var pickedNums = Array.ConvertAll(pickedNumsStr, s => int.Parse(s));

                for (int i = 0; i < winningNums.Length; i++)
                {
                    for (int j = 0; j < pickedNums.Length; j++)
                    {
                        if (winningNums[i] == pickedNums[j])
                        {
                            switch (count)
                            {
                                case 0:
                                    count++;
                                    break;
                                default:
                                    count *= 2;
                                    break;
                            }
                        }
                    }
                    
                }
                sum += count;
            }
        }
            return sum;
    }
}