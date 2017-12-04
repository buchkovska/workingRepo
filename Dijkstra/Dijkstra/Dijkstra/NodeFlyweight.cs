using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    public class NodeFlyweight
    {
        private static Dictionary<int, Node> nodes = new Dictionary<int, Node>();

        public static List<Node> GetNodesList()
        {
            List<Node> list = new List<Node>();
            foreach(var node in nodes)
            {
                list.Add(node.Value);
            }
            return list;
        }

        public static Node GetNode (int nodeId)
        {
            Node node = nodes.FirstOrDefault(x => x.Key == nodeId).Value;

            if(node == null)
            {
                node = new Node(nodeId);
                nodes.Add(nodeId, node);
            }

            return node;
        }
    }
}
