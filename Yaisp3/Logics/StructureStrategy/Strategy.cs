using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yaisp3
{

    public abstract class Strategy
    {
        public enum StrategyType
        {
            Normal,
            Conservative,
            Aggressive
        }
        protected StrategyType strategy;

        public StrategyType ReturnStrategyType()
        {
            return strategy;
        }

        public abstract void Action();
    }

    class StrategyNormal : Strategy
    {
        public StrategyNormal()
        {
            strategy = StrategyType.Normal;
        }
        public override void Action()
        {

        }
    }
    class StrategyConservative : Strategy
    {
        public StrategyConservative()
        {
            strategy = StrategyType.Conservative;
        }
        public override void Action()
        {

        }
    }
    class StrategyAggressive : Strategy
    {
        public StrategyAggressive()
        {
            strategy = StrategyType.Aggressive;
        }
        public override void Action()
        {

        }
    }
}
