namespace MathGen.Configs
{
    public class Config
    {
        /// <summary>
        /// 运算几次
        /// </summary>
        public int Times { get; set; }
    }

    public class FourOperationsConfig : Config
    {
        /// <summary>
        /// XXX以内的
        /// </summary>
        public int MaxValue { get; set; }

        /// <summary>
        /// XXX以内的最小值
        /// </summary>
        public int MinValue { get; set; }

        /// <summary>
        /// 获取多少个数
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 每一个算子不能超过的数目
        /// </summary>
        public int ItemUpperLimit { get; set; }

        /// <summary>
        /// 几个算子
        /// </summary>
        public int ItemCount { get; set; }

        /// <summary>
        /// 修复初始值
        /// </summary>
        public void Repaire()
        {
            if (Times <= 0)
            {
                Times = 1;
            }

            if (Count <= 0)
            {
                Count = 1;
            }

            if (MaxValue < 2)
            {
                MaxValue = 10;
            }

            if (MinValue < 2)
            {
                MinValue = 2;
            }
        }
        public void SetDefault()
        {
            Times = 1;
            MaxValue = 10;
            MinValue = 2;
            Count = 18;
            ItemCount = 2;
        }
    }

    public class AdditionConfig : FourOperationsConfig
    {
        
    }

    public class SubtractionConfig : FourOperationsConfig
    {
    }

    public class SukoduConfig : Config
    {
        /// <summary>
        /// 多少阶
        /// </summary>
        public int Step { get; set; }
        public void Repaire()
        {
            if (Times <= 0)
            {
                Times = 1;
            }

            if (Step <= 2)
            {
                Step = 3;
            }
        }
    }
}
