using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    public class Node
    {
        public int Id { get; set; }

        public double TotalCost { get; set; }

        public Node PreviousNode { get; set; }

        public IEnumerable<Connection> Connections { get; set; }

        private bool ifVisited;

        public bool Visited
        {
            get => ifVisited;
            set
            {
                {
                    ifVisited = value;
                    if (ifVisited == true)
                    {
                        GetConnections();
                    }
                }
            }
        }

        public Node(int id)
        {
            this.Id = id;
            this.TotalCost = double.MaxValue;
        }

        private void GetConnections()
        {
            String input = File.ReadAllText("graph2.txt");
            int i = 0, j;
            List<Connection> con = new List<Connection>();
            foreach (var row in input.Split('\n'))
            {
                if (i == this.Id - 1)
                {
                    j = 0;
                    foreach (var col in row.Trim().Split('\t'))
                    {
                        if(double.Parse(col.Trim()) != -1)
                        con.Add(new Connection
                        {
                            Cost = double.Parse(col.Trim()),
                            Node = NodeFlyweight.GetNode(j + 1)
                        });
                        j++;
                    }
                }
                i++;
            }
            this.Connections = con;
        }
    }
}
