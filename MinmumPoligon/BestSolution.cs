namespace LeetCode.MinmumPoligon
{
    internal class BestSolution
    {
        public int MinScoreTriangulation(int[] values)
        {
            int len = values.Length;
            int[][] dp = new int[len][];

            for (int i = 0; i < len; i++)
            {
                dp[i] = new int[len];
            }

            for (int j = 2; j < len; j++)
            {
                for (int i = j - 2; i >= 0; i--)
                {
                    dp[i][j] = int.MaxValue;
                    int prod_ij = values[i] * values[j];
                    for (int k = i + 1; k < j; k++)
                    {
                        dp[i][j] = Math.Min(dp[i][j], dp[i][k] + dp[k][j] + prod_ij * values[k]);
                    }
                }
            }

            return dp[0][len - 1];
        }
    }
}
