using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.DataStructure {
    public class TreeDataStructures {

        public Node[] RetrieveFullData(List<Entity> EntityList) {

            var childrenIds = from child in EntityList
                              select child.ToNodeId;

            var roots = from root in EntityList
                        where !childrenIds.Contains(root.FromNodeId)
                        select root;

            var dic = new Dictionary<int, List<int>>();

            EntityList.ForEach(e => {
                if (dic.ContainsKey(e.FromNodeId)) {
                    dic[e.FromNodeId].Add(e.ToNodeId);
                } else {
                    dic.Add(e.FromNodeId, new List<int> { e.ToNodeId });
                }
            });

            var lista = new List<Node>();
            foreach (var root in roots) {
                lista.Add(
                   new Node {
                       Id = root.FromNodeId,
                       LinkedNodes = CrieNodes(dic[root.FromNodeId], dic)
                   });
            }

            return lista.ToArray();
        }

        private Node[] CrieNodes(List<int> list, Dictionary<int, List<int>> dic) {
            var listona = new List<Node>();

            foreach (var item in list) {
                if (item >= dic.Count) {
                    listona.Add(new Node { Id = item });
                    continue;
                }

                listona.Add(
                    new Node {
                        Id = item,
                        LinkedNodes = CrieNodes(dic[item], dic)

                    });
            }

            return listona.ToArray();
        }

    }

    public class Entity {
        public Guid Id { get; set; }
        public int FromNodeId { get; set; }
        public int ToNodeId { get; set; }
    }

    public class Node {
        public int Id { get; set; }
        public Node[] LinkedNodes { get; set; }

        public override bool Equals(object obj) {
            if (obj == null || !(obj is Node)) {
                return false;
            }

            var other = obj as Node;

            return other.Id == Id
                && other.LinkedNodes.Count() == LinkedNodes.Count();
        }

        public override int GetHashCode() {
            return Id.GetHashCode() ^ LinkedNodes.GetHashCode();
        }
    }
}
