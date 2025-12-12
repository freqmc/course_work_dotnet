using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace course_work_dotnet
{
    public partial class Form1 : Form
    {
        
        private List<(int u, int v)> currentEdges = null;

        public Form1()
        {
            InitializeComponent();
            drawingPanel.Paint += drawingPanel_Paint;
            this.Text = "Кодирование и декодирование с помощью кода Прюфера";
        }

        private void DrawTree(List<(int u, int v)> edges, Panel panel)
        {
            currentEdges = edges;
            panel.Invalidate();
        }

        private void drawingPanel_Paint(object sender, PaintEventArgs e)
        {
            if (currentEdges == null || currentEdges.Count == 0) return;

            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            var vertices = new HashSet<int>();
            foreach (var (u, v) in currentEdges)
            {
                vertices.Add(u);
                vertices.Add(v);
            }
            var vertexList = vertices.OrderBy(x => x).ToList();
            int n = vertexList.Count;

            var adj = new Dictionary<int, List<int>>();
            foreach (var v in vertexList)
                adj[v] = new List<int>();
            foreach (var (u, v) in currentEdges)
            {
                adj[u].Add(v);
                adj[v].Add(u);
            }

            int root = vertexList[0];
            var parent = new Dictionary<int, int>();
            var level = new Dictionary<int, int>();
            var children = new Dictionary<int, List<int>>();
            foreach (var v in vertexList)
                children[v] = new List<int>();

            var queue = new Queue<int>();
            queue.Enqueue(root);
            level[root] = 0;
            parent[root] = -1;

            while (queue.Count > 0)
            {
                int u = queue.Dequeue();
                foreach (int v in adj[u])
                {
                    if (v != parent[u])
                    {
                        parent[v] = u;
                        level[v] = level[u] + 1;
                        children[u].Add(v);
                        queue.Enqueue(v);
                    }
                }
            }

            int maxDepth = level.Values.Max();
            int padding = 30;
            int availableHeight = drawingPanel.Height - 2 * padding;
            int hStep = maxDepth == 0 ? availableHeight : availableHeight / (maxDepth + 1);

            var positions = new Dictionary<int, PointF>();
            for (int depth = 0; depth <= maxDepth; depth++)
            {
                var nodesAtLevel = vertexList.Where(v => level[v] == depth).OrderBy(x => x).ToList();
                int count = nodesAtLevel.Count;
                if (count == 0) continue;


                float y = padding + hStep * (depth + 1);
                for (int i = 0; i < count; i++)
                {
                    float x = padding + (drawingPanel.Width - 2 * padding) * (i + 1) / (float)(count + 1);
                    positions[nodesAtLevel[i]] = new PointF(x, y);
                }
            }

            foreach (var (u, v) in currentEdges)
            {
                if (positions.ContainsKey(u) && positions.ContainsKey(v))
                {
                    g.DrawLine(Pens.Gray, positions[u], positions[v]);
                }
            }

            foreach (var v in vertexList)
            {
                if (positions.TryGetValue(v, out PointF pt))
                {
                    g.FillEllipse(Brushes.LightBlue, pt.X - 12, pt.Y - 12, 24, 24);
                    g.DrawEllipse(Pens.DarkBlue, pt.X - 12, pt.Y - 12, 24, 24);
                    var text = v.ToString();
                    var size = g.MeasureString(text, Font);
                    g.DrawString(text, Font, Brushes.Black,
                        pt.X - size.Width / 2,
                        pt.Y - size.Height / 2);
                }
            }
        }

        private void SaveTextToFile(string content, string description, string defaultFileName)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                MessageBox.Show($"Нет данных для сохранения ({description.ToLower()}).", "Пусто",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
                saveFileDialog.FileName = defaultFileName;
                saveFileDialog.Title = $"Сохранить {description.ToLower()}";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        System.IO.File.WriteAllText(saveFileDialog.FileName, content, System.Text.Encoding.UTF8);
                        MessageBox.Show($"Файл успешно сохранён:\n{saveFileDialog.FileName}", "Сохранено",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при сохранении файла:\n{ex.Message}", "Ошибка",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonEncode_Click(object sender, EventArgs e)
        {
            try
            {
                var edges = EdgeParser.ParseEdges(textBoxEdges.Text);
                var prufer = PruferEncoder.EncodeToPrufer(edges);
                textBoxPrufer.Text = string.Join(" ", prufer);
                DrawTree(edges, drawingPanel);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при кодировании:\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDecode_Click(object sender, EventArgs e)
        {
            try
            {
                var prufer = EdgeParser.ParsePrufer(textBoxPrufer.Text);
                var edges = PruferDecoder.DecodeFromPrufer(prufer);
                textBoxEdges.Text = string.Join(",", edges.Select(edge => $"({edge.Item1},{edge.Item2})"));
                DrawTree(edges, drawingPanel);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при декодировании:\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void рёбраToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveTextToFile(textBoxEdges.Text.Trim(), "Рёбра дерева", "edges.txt");
        }

        private void кодToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveTextToFile(textBoxPrufer.Text.Trim(), "Код Прюфера", "prufer.txt");
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            MessageBox.Show("Программа для кодирования и декодирования деревьев при помощи кода Прюфера\nбИЦ-241\nБирюков Никита\nВариант 4", "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    public static class PruferEncoder
    {
        public static List<int> EncodeToPrufer(List<(int u, int v)> edges)
        {
            if (edges.Count == 0) return new List<int>();

            var adjacency = new Dictionary<int, SortedSet<int>>();
            foreach (var (u, v) in edges)
            {
                if (!adjacency.ContainsKey(u)) adjacency[u] = new SortedSet<int>();
                if (!adjacency.ContainsKey(v)) adjacency[v] = new SortedSet<int>();
                adjacency[u].Add(v);
                adjacency[v].Add(u);
            }

            var degree = adjacency.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Count);
            var prufer = new List<int>();
            var vertices = adjacency.Keys.OrderBy(x => x).ToList();

            for (int i = 0; i < edges.Count - 1; i++)
            {
                int leaf = vertices.First(v => degree[v] == 1);
                int neighbor = adjacency[leaf].Min;
                prufer.Add(neighbor);
                degree[leaf]--;
                degree[neighbor]--;
                adjacency[neighbor].Remove(leaf);
                adjacency.Remove(leaf);
                vertices.Remove(leaf);
            }

            return prufer;
        }
    }

    public static class PruferDecoder
    {
        public static List<(int u, int v)> DecodeFromPrufer(List<int> prufer)
        {
            int n = prufer.Count + 2;
            var degree = Enumerable.Range(1, n).ToDictionary(i => i, _ => 1);

            foreach (int v in prufer)
                degree[v]++;

            var edges = new List<(int, int)>();
            var leaves = new SortedSet<int>(degree.Keys.Where(v => degree[v] == 1));

            foreach (int v in prufer)
            {
                int leaf = leaves.Min;
                leaves.Remove(leaf);
                edges.Add((leaf, v));
                degree[leaf]--;
                degree[v]--;

                if (degree[v] == 1)
                    leaves.Add(v);
            }

            var remaining = degree.Keys.Where(k => degree[k] == 1).ToList();
            if (remaining.Count == 2)
                edges.Add((remaining[0], remaining[1]));

            return edges;
        }
    }

    public static class EdgeParser
    {
        public static List<(int u, int v)> ParseEdges(string input)
        {
            var edges = new List<(int, int)>();
            string clean = input.Replace(" ", "");
            if (string.IsNullOrWhiteSpace(clean)) return edges;

            foreach (var part in clean.Trim('(', ')').Split(new[] { "),(" }, StringSplitOptions.None))
            {
                var nums = part.Split(',');
                if (nums.Length != 2)
                    throw new ArgumentException("Неверный формат рёбер.");
                int u = int.Parse(nums[0]);
                int v = int.Parse(nums[1]);
                if (u == v)
                    throw new ArgumentException("Петли запрещены.");
                edges.Add((Math.Min(u, v), Math.Max(u, v)));
            }

            int n = edges.SelectMany(e => new[] { e.Item1, e.Item2 }).Distinct().Count();
            if (edges.Count != n - 1)
                throw new ArgumentException("Введённый граф не является деревом (должно быть n-1 рёбер).");

            return edges;
        }

        public static List<int> ParsePrufer(string input)
        {
            var tokens = input.Split(new char[] { ' ', ',', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            return tokens.Select(int.Parse).ToList();
        }
    }

}
