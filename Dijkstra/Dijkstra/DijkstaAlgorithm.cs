using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    public class DijkstaAlgorithm
    {
        public static void GetShortestWay(int startNode, int finishNode)
        {
            Node last = NodeFlyweight.GetNode(finishNode);

            Node current = NodeFlyweight.GetNode(startNode);
            current.Visited = true;
            current.TotalCost = 0;

            while (last.Visited !=  true)
            {
                SetTotalCost(current.Id);
                current = GetNext(current.Id);
            }

            ShowWay(startNode, finishNode);
            Console.WriteLine("TotalCost: " + last.TotalCost);
        }

        private static void SetTotalCost(int current)
        {
            Node node = NodeFlyweight.GetNode(current);
            foreach (var con in node.Connections)
            {
                if (node.TotalCost + con.Cost < con.Node.TotalCost && con.Node.Visited != true)
                {
                    con.Node.TotalCost = node.TotalCost + con.Cost;
                }
            }
        }

        private static Node GetNext(int current)
        {
            int nextId = current;
            double minCost = double.MaxValue;

            foreach (var node in NodeFlyweight.GetNodesList())
            {
                if(node.TotalCost < minCost && node.Visited != true)
                {
                    nextId = node.Id;
                    minCost = node.TotalCost;
                }
            }

            Node next = NodeFlyweight.GetNode(nextId);
            next.TotalCost = minCost;
            next.PreviousNode = NodeFlyweight.GetNode(current);
            next.Visited = true;
            return next;
        }

        private static void ShowWay(int startNode, int finishNode)
        {
            List<int> way = new List<int>();
            Node node = NodeFlyweight.GetNode(finishNode);
            do
            {
                way.Add(node.Id);
                node = NodeFlyweight.GetNode(node.PreviousNode.Id);
            }
            while (node.Id != startNode);
            way.Add(startNode);
            way.Reverse();

            Console.Write("Way: ");
            foreach(var point in way)
            {
                Console.Write(point);
                if(point != way[way.Count - 1])
                {
                    Console.Write(" -> ");
                }
            }
            Console.WriteLine();
        }
    }
}
