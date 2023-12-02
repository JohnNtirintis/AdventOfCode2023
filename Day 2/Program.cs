internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ProblemA()); 
        }

        static int ProblemA()
        {
            String line;
            int sum = 0;
            char[] delimiters = { ':', ',', ';', ' '};
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    List<string> alphabeticValues = new List<string>();
                    List<int> numericValues = new List<int>();
                    string[] splitLine = line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                    bool check = false;

                    foreach (string value in splitLine)
                    {
                        int parsedValue;
                        if(int.TryParse(value, out parsedValue))
                        {
                            numericValues.Add(parsedValue);
                        } 
                        else
                        {
                            alphabeticValues.Add(value);
                        }
                    }

                    alphabeticValues.Reverse();
                    numericValues.Reverse();

                    var result = alphabeticValues.Select((value, index) => new { alphabeticValue = value, numericValue = numericValues[index]});

                    foreach(var item in result)
                    {
                        if ((item.alphabeticValue == "red" && item.numericValue > 12) ||
                           (item.alphabeticValue == "green" && item.numericValue > 13) ||
                           (item.alphabeticValue == "blue" && item.numericValue > 14))
                        {
                            check = false;
                            break;
                        }
                        check = true;
                    }

                    if (!check)
                    {
                        // Clear lists and go to the next line
                        alphabeticValues.Clear();
                        numericValues.Clear();
                    }
                    else
                    {
                        // all requirements are met, cubes are valid
                        // add last numeric value (Game ID) to sum
                        sum += result.Last().numericValue;
                    }
                }
            }
            return sum;
        }
}