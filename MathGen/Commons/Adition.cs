using System;
using System.Collections.Generic;
using System.Linq;

namespace MathGen.Commons
{
    /// <summary>
    /// 加法
    /// </summary>
    public class AditionBuilder
    {
        private readonly static Random _random = new Random();

        private const int ROW_NUMBER_UPPER = 100000;

        private readonly int _sum;

        private int _addendCount = 2;

        public AditionBuilder(int sum)
        {
            _sum = sum;
        }

        public AditionBuilder SetAddendCount(int count)
        {
            _addendCount = count;

            Check();
            return this;
        }

        private void Check()
        {
            if (_addendCount < 2)
            {
                _addendCount = 2;
            }
        }

        public List<NumberCollectionLine> Build()
        {
            var list = new List<NumberCollectionLine>();
            list.AddRange(AddtionAlgorithm.Resolve(_sum, _addendCount).Select(x => new NumberCollectionLine
            {
                RowNumber = _random.Next(0, ROW_NUMBER_UPPER),
                Numbers = x
            }));
            return list;
        }

        private class AddtionAlgorithm
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="number">待分解的数</param>
            /// <param name="times">分解成几个数字</param>
            public static List<List<int>> Resolve(int number, int times)
            {
                var baseNumber = number;
                var maxValue = number + 1 - times;

                var container = new AdditionItemContainer();

                for (var i = 1; i <= maxValue; i++)
                {
                    var addends = new List<int> { i };
                    ResolveCore(container, addends, baseNumber, number - i, times);
                }

                return container.Items;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="container"></param>
            /// <param name="addends"></param>
            /// <param name="baseNumber"></param>
            /// <param name="number"></param>
            /// <param name="times"></param>
            private static void ResolveCore(AdditionItemContainer container, List<int> addends, int baseNumber, int number, int times)
            {
                if (addends.Count == times - 1)
                {
                    if (addends.Sum() < baseNumber)
                    {
                        addends.Add(baseNumber - addends.Sum());
                        container.Add(addends);
                    }
                    return;
                }

                for (var i = 1; i < number; i++)
                {
                    var dd = new List<int>(addends) { i };

                    ResolveCore(container, dd, baseNumber, number - 1, times);
                }
            }

            private class AdditionItemContainer
            {
                private readonly IDictionary<int, List<int>> _dictionary = new Dictionary<int, List<int>>();

                public List<List<int>> Items => _dictionary.Values.ToList();

                public void Add(List<int> value)
                {
                    if (value == null || value.Count == 0)
                    {
                        return;
                    }

                    value.Sort();

                    var hashCode = string.Join(",", value).GetHashCode();

                    if (!_dictionary.ContainsKey(hashCode))
                    {
                        _dictionary.Add(hashCode, value);
                    }
                }
            }
        }
    }


}
