using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ScoringAlgorithm algorithm;

            Console.WriteLine("Mans");
            algorithm = new MenScoringAlgorithm();
            Console.WriteLine(algorithm.GeneretaScore(10,new TimeSpan(0,2,30)));

            Console.WriteLine("Women");
            algorithm = new WomanScoringAlgorithm();
            Console.WriteLine(algorithm.GeneretaScore(10, new TimeSpan(0, 2, 30)));

            Console.WriteLine("Childeren");
            algorithm = new ChilderenScoringAlgorithm();
            Console.WriteLine(algorithm.GeneretaScore(10, new TimeSpan(0, 2, 30)));

            Console.ReadKey();
        }
    }
    abstract class  ScoringAlgorithm
    {
        public int GeneretaScore(int hits,TimeSpan time)
        {
            int score = CalculateBaseScore(hits);
            int reduction = CalculateReduction(time);
            return CalculateOverallScore(score, reduction);
        }
        public abstract int CalculateBaseScore(int hits);
        public abstract int CalculateReduction(TimeSpan time);
        public abstract int CalculateOverallScore(int score, int reduction);
    }
    class MenScoringAlgorithm : ScoringAlgorithm
    {
        public override int CalculateBaseScore(int hits)
        {
            return hits * 100;
        }

        public override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;
        }

        public override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 5;
        }
    }
    class WomanScoringAlgorithm : ScoringAlgorithm
    {
        public override int CalculateBaseScore(int hits)
        {
            return hits * 100;
        }

        public override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;
        }

        public override int CalculateReduction(TimeSpan time)
        {
           return (int)time.TotalSeconds / 3;
        }
    }

    class ChilderenScoringAlgorithm : ScoringAlgorithm
    {
        public override int CalculateBaseScore(int hits)
        {
            return hits * 60;
        }

        public override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;
        }

        public override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 3;
        }
    }

}
