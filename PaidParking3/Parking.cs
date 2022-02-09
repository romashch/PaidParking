using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace PaidParking3
{
    [Serializable]
    public class Parking
    {
        Sample[,] topology;

        static List<Vertice> vertices;

        static List<List<Vertice>> adjacencyList;

        [NonSerialized]
        List<List<Vertice>> entryWays;

        [NonSerialized]
        List<List<Vertice>> exitWays;

        [NonSerialized]
        Dictionary<int, Vertice> ps;
        
        public bool[] IsBusy { get; set; }

        public List<List<Vertice>> EntryWays { get { return entryWays; } }

        public List<List<Vertice>> ExitWays { get { return exitWays; } }

        public Dictionary<int, Vertice> PS { get { return ps; } }

        public Sample[,] Topology { get { return topology; } }

        public Parking(Sample[,] topology)
        {
            this.topology = topology;
        }

        public Parking(List<Cell> cells)
        {
            int maxY = 5;
            int maxX = 5;
            foreach (Cell cell in cells)
            {
                if (cell.X > maxX)
                    maxX = cell.X;
                if (cell.Y > maxY)
                    maxY = cell.Y;
            }
            topology = new Sample[maxX + 1, maxY + 1];
            foreach (Cell cell in cells)
            {
                topology[cell.X, cell.Y] = (Sample)cell.Sample;
            }
        }

        public int Length { get { return topology.GetLength(1); } }

        public int Width { get { return topology.GetLength(0); } }

        public static Parking Validation(Sample[,] topology)
        {
            int entryX = -1, entryY = -1, ticketOfficeX = -1, ticketOfficeY = -1;
            bool isEntry = false, isExit = false, isTicketOffice = false, isPS = false;
            for (int i = 0; i < topology.GetLength(0); i++)
            {
                for (int j = 0; j < topology.GetLength(1); j++)
                {
                    if (topology[i, j] == Sample.Entry)
                    {
                        isEntry = true;
                        entryX = i;
                        entryY = j;
                        if (i != topology.GetLength(0) - 1)
                        {
                            return null;
                        }
                    }
                    if (topology[i, j] == Sample.TicketOffice)
                    {
                        isTicketOffice = true;
                        ticketOfficeX = i;
                        ticketOfficeY = j;
                    }
                    if (topology[i, j] == Sample.Exit)
                    {
                        isExit = true;
                        if (i != topology.GetLength(0) - 1)
                        {
                            return null;
                        }
                    }
                    if (topology[i, j] == Sample.TPS || topology[i, j] == Sample.CPS)
                    {
                        isPS = true;
                    }
                }
            }
            if (!(isExit && isEntry && isTicketOffice && isPS))
            {
                return null;
            }
            if (!(Math.Abs(entryY - ticketOfficeY) == 1 && entryX == ticketOfficeX || Math.Abs(entryX - ticketOfficeX) == 1 && entryY == ticketOfficeY))
            {
                return null;
            }
            if (!DijkstrasAlgorithm(topology))
            {
                return null;
            }
            return new Parking(topology);
        }

        private static bool DijkstrasAlgorithm(Sample[,] topology)
        {
            vertices = new List<Vertice>();
            adjacencyList = new List<List<Vertice>>();
            GraphFormation(topology, out vertices, out adjacencyList);

            //StreamWriter sw = new StreamWriter(@"C:\Users\dvt21\Documents\Универ\ПИ\PaidParking3\graph.txt", false);
            //for (int i = 0; i < topology.GetLength(0); i++)
            //{
            //    for (int j = 0; j < topology.GetLength(1); j++)
            //    {
            //        sw.Write(topology[i, j] + "\t");
            //    }
            //    sw.WriteLine();
            //}
            //for (int i = 0; i < vertices.Count; i++)
            //{
            //    sw.Write(vertices[i].x + " " + vertices[i].y + " | ");
            //    for (int j = 0; j < adjacencyList[i].Count; j++)
            //    {
            //        sw.Write(adjacencyList[i][j].x + " " + adjacencyList[i][j].y + "; ");
            //    }
            //    sw.WriteLine();
            //}

            int[] d = new int[vertices.Count];
            bool[] u = new bool[vertices.Count];
            for (int k = 0; k < 2; k++)
            {
                for (int i = 0; i < vertices.Count; i++)
                {
                    if (k == 0 && vertices[i].s == Sample.Entry)
                        d[i] = 0;
                    else if (k == 1 && vertices[i].s == Sample.Exit)
                        d[i] = 0;
                    else
                        d[i] = int.MaxValue;
                    u[i] = false;
                }
                for (int i = 0; i < vertices.Count; i++)
                {
                    int min = d.Where((elem, idx) => u[idx] == false).Min();
                    int minIndex = -1;
                    for (int j = 0; j < d.Length; j++)
                    {
                        if (d[j] == min && u[j] == false)
                        {
                            minIndex = j;
                        }
                    }
                    u[minIndex] = true;
                    for (int j = 0; j < adjacencyList[minIndex].Count; j++)
                    {
                        int idx = vertices.FindIndex(v => v.Equals(adjacencyList[minIndex][j]));
                        bool isPass = d[idx] != int.MaxValue;
                        if (!isPass)
                            d[idx] = Math.Min(d[idx], d[minIndex] + 1);
                        if (d[idx] == int.MinValue)
                            d[idx] = int.MaxValue;
                    }
                }
                for (int i = 0; i < d.Length; i++)
                {
                    if (d[i] == int.MaxValue && (vertices[i].s == Sample.CPS || vertices[i].s == Sample.TPS))
                    {

                        //sw.WriteLine("Неуспех " + (k + 1));
                        //for (int j = 0; j < d.Length; j++)
                        //{
                        //    sw.Write(vertices[j].x + "\t" + vertices[j].y + "\t" + vertices[j].s + "\t" + d[j] + "\t" + u[j] + "\t" + " | ");
                        //    for (int n = 0; n < adjacencyList[j].Count; n++)
                        //    {
                        //        sw.Write(adjacencyList[j][n].x + " " + adjacencyList[j][n].y + "; ");
                        //    }
                        //    sw.WriteLine();
                        //}
                        //sw.Close();

                        return false;
                    }
                }

                //sw.WriteLine("Успех " + (k + 1));
                //for (int j = 0; j < d.Length; j++)
                //{
                //    sw.Write(vertices[j].x + "\t" + vertices[j].y + "\t" + vertices[j].s + "\t" + d[j] + "\t" + u[j] + "\t" + " | ");
                //    for (int n = 0; n < adjacencyList[j].Count; n++)
                //    {
                //        sw.Write(adjacencyList[j][n].x + " " + adjacencyList[j][n].y + "; ");
                //    }
                //    sw.WriteLine();
                //}

            }

            //sw.Close();

            return true;
        }

        private static void GraphFormation(Sample[,] topology, out List<Vertice> vertices, out List<List<Vertice>> adjacencyList)
        {
            vertices = new List<Vertice>();
            adjacencyList = new List<List<Vertice>>();
            for (int i = 0; i < topology.GetLength(0); i++)
            {
                for (int j = 0; j < topology.GetLength(1); j++)
                {
                    if (topology[i, j] == Sample.Road)
                    {
                        vertices.Add(new Vertice(i, j, topology[i, j]));
                        adjacencyList.Add(getAdjacentVertices(i, j, topology));
                    }
                    else if (topology[i, j] == Sample.TPS)
                    {
                        vertices.Add(new Vertice(i, j, topology[i, j]));
                        adjacencyList.Add(getAdjacentVertices(i, j, topology));
                    }
                    else if (topology[i, j] == Sample.CPS)
                    {
                        vertices.Add(new Vertice(i, j, topology[i, j]));
                        adjacencyList.Add(getAdjacentVertices(i, j, topology));
                    }
                    else if (topology[i, j] == Sample.Entry)
                    {
                        vertices.Add(new Vertice(i, j, topology[i, j]));
                        adjacencyList.Add(getAdjacentVertices(i, j, topology));
                    }
                    else if (topology[i, j] == Sample.Exit)
                    {
                        vertices.Add(new Vertice(i, j, topology[i, j]));
                        adjacencyList.Add(getAdjacentVertices(i, j, topology));
                    }
                }
            }
        }

        private static List<Vertice> getAdjacentVertices(int i, int j, Sample[,] topology)
        {
            List<Vertice> res = new List<Vertice>();
            if (topology[i, j] == Sample.CPS || topology[i, j] == Sample.TPS)
                return res;
            if (i != 0 && (topology[i - 1, j] == Sample.Road || topology[i - 1, j] == Sample.TPS || topology[i - 1, j] == Sample.None || topology[i - 1, j] == Sample.CPS))
            {
                if (topology[i - 1, j] != Sample.None)
                    res.Add(new Vertice(i - 1, j, topology[i - 1, j]));
                else
                    res.Add(new Vertice(i - 2, j, topology[i - 2, j]));
            }
            if (i != topology.GetLength(0) - 1 && (topology[i + 1, j] == Sample.Road || topology[i + 1, j] == Sample.TPS || topology[i + 1, j] == Sample.CPS))
            {
                res.Add(new Vertice(i + 1, j, topology[i + 1, j]));
            }
            if (j != 0 && (topology[i, j - 1] == Sample.Road || topology[i, j - 1] == Sample.TPS || topology[i, j - 1] == Sample.None || topology[i, j - 1] == Sample.CPS))
            {
                if (topology[i, j - 1] != Sample.None)
                    res.Add(new Vertice(i, j - 1, topology[i, j - 1]));
                else
                    res.Add(new Vertice(i - 1, j - 1, topology[i - 1, j - 1]));
            }
            if (j != topology.GetLength(1) - 1 && (topology[i, j + 1] == Sample.Road || topology[i, j + 1] == Sample.TPS || topology[i, j + 1] == Sample.None || topology[i, j + 1] == Sample.CPS))
            {
                if (topology[i, j + 1] != Sample.None)
                    res.Add(new Vertice(i, j + 1, topology[i, j + 1]));
                else
                    res.Add(new Vertice(i - 1, j + 1, topology[i - 1, j + 1]));
            }
            return res;
        }

        public void AddParking(string name)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                if (ParkingLoadingForm.IsDBConnection(db))
                {
                    int k = 0;
                    while (k < db.Cells.Count() && !db.Cells.ToList()[k].ParkingName.Equals(name))
                    {
                        k++;
                    }
                    if (k < db.Cells.Count())
                        throw new ArgumentException("Парковка с таким названием уже существует.");
                    for (int i = 0; i < topology.GetLength(0); i++)
                    {
                        for (int j = 0; j < topology.GetLength(1); j++)
                        {
                            db.Cells.Add(new Cell(name, i, j, (int)topology[i, j]));
                        }
                    }
                    db.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Нет соединения с базой данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public const string Path = @"parking.dat";

        public void Serialize()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(Path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, this);
            }
        }

        public static Parking Deserialize()
        {
            if (File.Exists(Path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream fs = new FileStream(Path, FileMode.OpenOrCreate))
                {
                    try
                    {
                        Parking p = (Parking)formatter.Deserialize(fs);
                        return p;
                    }
                    catch
                    {
                        return null;
                    }
                }
            }
            else
            {
                throw new FileNotFoundException();
            }
        }

        public void DijkstrasAlgorithmWithWays()
        {
            vertices = new List<Vertice>();
            adjacencyList = new List<List<Vertice>>();
            GraphFormation(topology, out vertices, out adjacencyList);

            int[] d = new int[vertices.Count];
            bool[] u = new bool[vertices.Count];
            Vertice[] p = new Vertice[vertices.Count];
            entryWays = new List<List<Vertice>>();
            exitWays = new List<List<Vertice>>();
            int startIndex = -1;
            for (int k = 0; k < 2; k++)
            {
                for (int i = 0; i < vertices.Count; i++)
                {
                    if (k == 0 && vertices[i].s == Sample.Entry || k == 1 && vertices[i].s == Sample.Exit)
                    {
                        d[i] = 0;
                        startIndex = i;
                    }
                    else
                        d[i] = int.MaxValue;
                    u[i] = false;
                }
                for (int i = 0; i < vertices.Count; i++)
                {
                    int min = d.Where((elem, idx) => u[idx] == false).Min();
                    int minIndex = -1;
                    for (int j = 0; j < d.Length; j++)
                        if (d[j] == min && u[j] == false)
                            minIndex = j;
                    u[minIndex] = true;
                    for (int j = 0; j < adjacencyList[minIndex].Count; j++)
                    {
                        int idx = vertices.FindIndex(v => v.Equals(adjacencyList[minIndex][j]));
                        bool isPass = d[idx] != int.MaxValue;
                        if (!isPass)
                        {
                            if (d[idx] > d[minIndex] + 1)
                                p[idx] = vertices[minIndex];
                            d[idx] = Math.Min(d[idx], d[minIndex] + 1);
                        }
                        if (d[idx] == int.MinValue)
                            d[idx] = int.MaxValue;
                    }
                }
                for (int i = 0; i < p.Length; i++)
                {
                    if (vertices[i].s == Sample.TPS || vertices[i].s == Sample.CPS)
                    {
                        List<Vertice> cur = new List<Vertice>();
                        for (Vertice v = vertices[i]; !v.Equals(vertices[startIndex]); v = p[vertices.IndexOf(v)])
                            cur.Add(v);
                        cur.Add(vertices[startIndex]);
                        Vertice ps = cur[0];
                        if (ps.s == Sample.TPS)
                        {
                            if (cur[1].x <= ps.x)
                            {
                                cur.Reverse();
                                cur.Add(new Vertice(ps.x + 1, ps.y, Sample.None));
                                cur.Reverse();
                            }
                            else
                            {
                                cur.Reverse();
                                cur.RemoveAt(cur.Count - 1);
                                cur.Add(new Vertice(ps.x + 1, ps.y, Sample.None));
                                cur.Add(ps);
                                cur.Reverse();
                            }
                        }
                        if (k == 0)
                        {                           
                            cur.Reverse();
                            entryWays.Add(cur);
                        }
                        else
                        {
                            cur.RemoveAt(0);
                            exitWays.Add(cur);
                        }
                    }
                }
            }

            //StreamWriter sw = new StreamWriter(@"C:\Users\dvt21\Documents\Универ\ПИ\PaidParking3\graph.txt", false);
            //for (int i = 0; i < entryWays.Count; i++)
            //{
            //    sw.Write(vertices[i] + " | ");
            //    for (int j = 0; j < entryWays[i].Count; j++)
            //    {
            //        sw.Write(entryWays[i][j] + " ; ");
            //    }
            //    sw.WriteLine();
            //}
            //for (int i = 0; i < exitWays.Count; i++)
            //{
            //    sw.Write(vertices[i] + " | ");
            //    for (int j = 0; j < exitWays[i].Count; j++)
            //    {
            //        sw.Write(exitWays[i][j] + " ; ");
            //    }
            //    sw.WriteLine();
            //}
            //sw.Close();

        }

        public void GetPS()
        {
            ps = new Dictionary<int, Vertice>();
            int k = 0;
            for (int i = 0; i < topology.GetLength(0); i++)
            {
                for (int j = 0; j < topology.GetLength(1); j++)
                {
                    if (topology[i, j] == Sample.CPS || topology[i, j] == Sample.TPS)
                    {
                        ps.Add(k, new Vertice(i, j, topology[i, j]));
                        k++;
                    }
                }
            }
        }
    }
}
