using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace MathGen.Commons
{

    public class Sudoku
    {
        private const int DEFAULT_DIMENSION = 3;

        /// <summary>
        /// 
        /// </summary>
        private readonly int _dimension = DEFAULT_DIMENSION;

        public Sudoku() : this(3)
        {

        }

        public Sudoku(int dimension)
        {
            _dimension = dimension;

            if (_dimension < DEFAULT_DIMENSION)
            {
                _dimension = DEFAULT_DIMENSION;
            }

            _points = InitPoints().ToImmutableList();
        }


        private readonly static Random _random = new Random();

        private readonly ImmutableList<Point> _points;

        private IEnumerable<Point> InitPoints()
        {
            var tempPoints = new List<Point>();
            for (var i = 0; i < _dimension; i++)
            {
                for (var j = 0; j < _dimension; j++)
                {
                    tempPoints.Add(new Point(i, j));
                }
            }

            return tempPoints;
        }


        private void AssignPoints()
        {
            //首页清除已经复制的点
            _points.FindAll(x => x.Value != -1).ForEach(x => x.Value = -1);

            var tempPoints = new List<Point>();
            while (tempPoints.Count < _dimension)
            {
                var x = _random.Next(0, _dimension);
                var y = _random.Next(0, _dimension);
                var value = _random.Next(0, _dimension) + 1;

                //所在的x（横坐标）不能有相同的值，即定位纵坐标
                var xPoints = _points.FindAll(p => p.Y == y);

                //所在的y（纵坐标）不能有相同的值，即定位横坐标
                var yPoints = _points.FindAll(p => p.X == x);

                if (!tempPoints.Any(p => p.X == x && p.Y == y) && !xPoints.Any(p => p.Value == value) && !yPoints.Any(p => p.Value == value))
                {
                    var point = _points.Find(p => p.X == x && p.Y == y);
                    point.Value = value;

                    tempPoints.Add(point);
                }
            }
        }


        public List<NumberCollectionLine> Build()
        {
            while (true)
            {
                AssignPoints();
                //Print();
                if (Validate())
                {
                    //Print();
                    break;
                }
            }

            var list = new List<NumberCollectionLine>();
            for (var i = 0; i < _dimension; i++)
            {
                list.Add(new NumberCollectionLine
                {
                    RowNumber = i,
                    Numbers = _points.FindAll(x => x.Y == i).Select(x => x.Value).ToList()
                });
            }

            return list;
        }

        private void Print()
        {
            for (var i = 0; i < _dimension; i++)
            {
                Console.WriteLine(string.Join(" ", _points.FindAll(p => p.Y == i).Select(p => p.Value)));
            }
        }

        /// <summary>
        /// 验证给定的数独数字是否可以计算完成
        /// </summary>
        /// <returns></returns>
        private bool Validate()
        {
            return true;
        }


        private class Point
        {
            public Point(int x, int y) : this(x, y, -1) { }

            public Point(int x, int y, int value) => (X, Y, Value) = (x, y, value);

            public int Y { get; set; }

            public int X { get; set; }

            public int Value { get; set; }
        }
    }
}
