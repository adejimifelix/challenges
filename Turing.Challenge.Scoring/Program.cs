namespace Turing.Challenge.Scoring
{
    public class Program
    {
        public static int GenerateScore(string[] ops)
        {
            int score = 0;
            List<int> scores = new List<int>();
            if (ops == null || ops.Length == 0) return score;
            if (ops.Length == 1) return int.TryParse(ops[0], out score) ? score : 0;

            for(int j = 0; j < ops.Length; j++)
            {
                string element = ops[j].ToUpper();
                switch (element)
                {
                   case "D": //means to double previous score to get additional score
                        if (scores.Count > 0)
                            scores.Add(scores[scores.Count - 1] * 2);
                        else
                            scores.Add(0);
                    break;

                    case "C": //means to remove previous score
                        if (scores.Count > 0)
                            scores.RemoveAt(scores.Count - 1);
                        break;

                    case "+": //means to add up two previous scores to get additional score
                        int last = 0, nextToLast = 0;
                        if(scores.Count > 0)
                        last = scores[scores.Count - 1];

                        if((scores.Count - 2) >=0 )
                            nextToLast = scores[scores.Count - 2];
                        scores.Add(last + nextToLast);
                        break;

                        default:
                        if(int.TryParse(element, out score)) { scores.Add(score); }
                        break;
                }
            }
            if (scores.Count < 1) return 0;
            score = scores.Sum(x => x);
            return score;
        }
        static void Main(string[] args)
        {
            var score = GenerateScore("5 3 D C +".Split(" "));
            Console.WriteLine(score);

        }
    }
}