using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Algorithms.BinaryTree {
    public class TreeDataStructures {
        //private List<NodesData> NodesList { get; set; }

        public void RetrieveFullTree(int Id, List<NodesData> NodesList) {

            var test = from left in NodesList
                       where left.FromNodeId < left.ToNodeId && left.FromNodeId != left.ToNodeId
                       select left;

            var all = NodesList.Select(s => s.ToNodeId).ToList();
            var test2 = NodesList.Where(n => !all.Contains(n.FromNodeId));

            var test3 = NodesList.GroupBy(g => !all.Contains(g.FromNodeId));
        }


    }

    public class NodesData {
        public Guid Id { get; set; }
        public int FromNodeId { get; set; }
        public int ToNodeId { get; set; }
    }

    public class Node {
        public int Id { get; set; }
        public Node[] LinkedNodes { get; set; }
    }
}
