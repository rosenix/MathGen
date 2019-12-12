using MathGen.Commons;
using MathGen.Configs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MathGen.Models
{
    public class MathContainer
    {
        public List<List<NumberCollectionLine>> Additions { get; set; } = new List<List<NumberCollectionLine>>();

        public List<List<NumberCollectionLine>> Subtractions { get; set; } = new List<List<NumberCollectionLine>>();

        public List<List<NumberCollectionLine>> Sudokus { get; set; } = new List<List<NumberCollectionLine>>();

        public MathContainer SetSubtraction(SubtractionConfig config)
        {
            if (config == null)
            {
                config = new SubtractionConfig();
                config.SetDefault();
            }

            config.Repaire();

            for (var i = 0; i < config.Times; i++)
            {
                Subtractions.Add(GenerateSubtraction(config));
            }

            return this;
        }

        public MathContainer SetAddition(AdditionConfig config)
        {
            if (config == null)
            {
                config = new AdditionConfig();
                config.SetDefault();
            }

            config.Repaire();

            for (var i = 0; i < config.Times; i++)
            {
                Additions.Add(GenerateAddition(config));
            }

            return this;
        }

        public MathContainer SetSudoku(SukoduConfig config)
        {
            if (config == null)
            {
                config = new SukoduConfig { Times = 1, Step = 3 };
            }

            for (var i = 0; i < config.Times; i++)
            {
                Sudokus.Add(new Sudoku(config.Step).Build());
            }

            return this;
        }

        private static List<NumberCollectionLine> GenerateAddition(AdditionConfig config)
        {
            if (config == null)
            {
                throw new ArgumentNullException(nameof(config));
            }

            var a = new List<NumberCollectionLine>();

            //需要重新实现该算法
            for (var i = config.MinValue; i <= config.MaxValue; i++)
            {
                var builder = new AdditionBuilder(i)
                    .SetItemUpperLimit(config.ItemUpperLimit)
                    .SetAddendCount(config.ItemCount);

                a.AddRange(builder.Build());
            }

            a.Sort();
            a = a.Take(config.Count).ToList();

            //查看是否存在相同的，如果有则加数顺序交换一下

            return a;
        }

        private static List<NumberCollectionLine> GenerateSubtraction(SubtractionConfig config)
        {
            if (config == null)
            {
                throw new ArgumentNullException(nameof(config));
            }

            var a = new List<NumberCollectionLine>();

            //需要重新实现该算法
            for (var i = config.MinValue; i <= config.MaxValue; i++)
            {
                var builder = new SubtractionBuilder(i)
                    .SetSubItemCount(config.ItemCount); ;

                a.AddRange(builder.Build());
            }
            a.Sort();
            a = a.Take(config.Count).ToList();
            return a;
        }
    }

}
