using NUnit.Framework;
using System.Net.WebSockets;
using System.Xml;

namespace AdventCodeTest
{
    public class Tests
    {

        [Test]
        public void DayOne()
        {
            var input = File.ReadAllText(Directory.GetCurrentDirectory() + "\\InputFiles\\DayOne.txt");
            var lines = input.Split(Environment.NewLine);
            int runningTotal = 0;
            int numOne = 0 ;
            int numTwo = 0;
            bool firstNumberEvaluated;
           
            foreach (var line in lines)
            {
                firstNumberEvaluated = false;
                var transformedLine = GetTransformedLine(line);
                foreach (var character in transformedLine)
                {
                    var isNumber = char.IsNumber(character);
                    if(isNumber)
                    {
                        if (!firstNumberEvaluated)
                        {
                            numOne = (int)char.GetNumericValue(character);
                            firstNumberEvaluated = true;
                        }
                        numTwo = (int)char.GetNumericValue(character);
                    }
                }
                var combinedNum = int.Parse(numOne.ToString() + numTwo.ToString());
                runningTotal += combinedNum;
             }
            Assert.That(runningTotal == 55488);
        }

        private string GetTransformedLine(string line)
        {
            var numbers = new Dictionary<string, char>
            {
                { "one",   '1' },
                { "two",   '2' },
                { "three", '3' },
                { "four",  '4' },
                { "five",  '5' },
                { "six",   '6' },
                { "seven", '7' },
                { "eight", '8' },
                { "nine",  '9' }
            };
            var transformedLine = new List<char>();
            var wordNumber = new List<char>();
            foreach (var character in line)
            {
                if (char.IsNumber(character))
                {
                    transformedLine.Add(character);
                    continue;
                }
                wordNumber.Add(character);
                var wordNumberString = new string(wordNumber.ToArray());
                var matchingWord = numbers.ContainsKey(wordNumberString);
                if(matchingWord)
                {
                    numbers.TryGetValue(wordNumberString, out var test);
                    transformedLine.Add(test);
                }
            }
            var newLine = new string(transformedLine.ToArray());
            return newLine;
        }
    }
}