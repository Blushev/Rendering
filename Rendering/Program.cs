using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Rendering
{
    class Program
    {
        static List<string> rangeX = new List<string>();
        static List<Coordinates> CoordList = new List<Coordinates>();
        static void Main(string[] args)
        {
            int limitX = 100; 
            for(int x = 0; x < limitX; x++)
            {
                string example = "-5 + 5 * x";
                string numX = x.ToString();
                example = example.Replace("x", numX);
                rangeX.Add(numX);
                string[] exampleArray = example.Split(' ');
                GetOPS deductionOfExample = new GetOPS();
                string reversePolishNotation = deductionOfExample.SignAfter(exampleArray);
                string[] divide_example = reversePolishNotation.Split(' ');
                CountSumm gg = new CountSumm();
                Coordinates newCoord = new Coordinates(x, (int)gg.GetSummRangeX(divide_example));
                CoordList.Add(newCoord);
            }
            Console.ReadKey();
        }

       
    }
}
                
                  