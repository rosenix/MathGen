using MathGen.Commons;
using System.Collections.Generic;
using System.Linq;

namespace MathGen.Models
{
    public class MathContainer
    {
        public List<List<NumberCollectionLine>> Additions { get; set; } = new List<List<NumberCollectionLine>>();

        public List<List<NumberCollectionLine>> Sudokus { get; set; } = new List<List<NumberCollectionLine>>();

        public MathContainer SetAddition(int times, int maxValue, int count)
        {
            for (var i = 0; i < times; i++)
            {
                Additions.Add(GenerateAddition(maxValue, count));
            }

            return this;
        }

        public MathContainer SetSudoku(int times, int step)
        {
            for (var i = 0; i < times; i++)
            {
                Sudokus.Add(new Sudoku(step).Build());
            }

            return this;
        }

        private static List<NumberCollectionLine> GenerateAddition(int maxValue, int count)
        {
            var a = new List<NumberCollectionLine>();

            //需要重新实现该算法
            for (var i = 2; i <= maxValue; i++)
            {
                var builder = new AditionBuilder(i);
                a.AddRange(builder.Build());
            }

            a.Sort();
            a = a.Take(count).ToList();
            return a;
        }
    }

}
