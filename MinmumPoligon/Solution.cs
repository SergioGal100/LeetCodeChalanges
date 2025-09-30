
namespace LeetCode.MinmumPoligon
{
    /*
    You have a convex n-sided polygon where each vertex has an integer value. 
    You are given an integer array values where values[i] is the value of the ith 
    vertex in clockwise order.
    Polygon triangulation is a process where you divide a polygon into a set of 
    triangles and the vertices of each triangle must also be vertices of the original polygon. 
    Note that no other shapes other than triangles are allowed in the division. This process will 
    result in n - 2 triangles.
    You will triangulate the polygon. For each triangle, the weight of that triangle is the product
    of the values at its vertices. The total score of the triangulation is the sum of these weights 
    over all n - 2 triangles.
    Return the minimum possible score that you can achieve with some triangulation of the polygon.
     */
    internal class Solution
    {

        int[] values;
        int[,] memo;

        public int minPoligons(int[] values)
        {
            this.values = values;
            int n = values.Length;
            memo = new int[n,n];
            return dp(0, n - 1);

        }

        private int dp(int i, int j)
        {
            if (j < i + 2)
            {
                return 0;
            }

            if(memo[i,j] != 0)
            {
                return memo[i,j];
            }

            int res = int.MaxValue;

            for(int k = i + 1; k < j; k++)
            {
                res = Math.Min(res, values[i] * values[k] * values[j] + dp(i, k) + dp(k, j) );
            }

            memo[i,j] = res;

            return res;
        }
    }
}
