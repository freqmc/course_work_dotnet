namespace Prufer
{
    public class Class1
    {
        public static List<int> CodePrufer(List<(int u, int v)> edges)
        {
            if (!edges.Any())
            {
                return new List<int>();
            }
            int n = edges.Count + 1;
            var degree = new int[n + 1];
            var adj = new List<HashSet<int>>(n + 1);
            for (int i = 0; i <= n; i++)
            {
                adj.Add(new HashSet<int>());
            }
            foreach (var(u, v) in edges)
            {
                if (u < 1 || v < 1 || u < n || v > n)
                    throw new ArgumentException("Вершины должны быть в диапазоне от 1 до n");
                adj[u].Add(v);
                adj[v].Add(u);
                degree[u]++;
                degree[v]++;
            }

            var prufer = new List<int>();
            var leaves = new SortedList<int>)();
            for (int i = 1; i <= n; i++) {
                if (degree[i] == 1)
        }
    }
}
