using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.DataStructure {
    public class TreeDataStructures {

        public Node[] RetrieveFullData(List<Entity> EntityList) {

            var childrenIds = GetChildrenIds(EntityList);
            var roots = GetRoots(EntityList, childrenIds);
            var dic = CreateDicionaryOfIds(EntityList);

            var lista = new List<Node>();
            foreach (var root in roots) {
                lista.Add(
                   new Node {
                       Id = root.FromNodeId,
                       LinkedNodes = CreateNodes(dic[root.FromNodeId], dic)
                   });
            }

            return lista.ToArray();
        }

        private Node[] CreateNodes(List<int> list, Dictionary<int, List<int>> dic) {
            var linkedNodes = new List<Node>();

            foreach (var item in list) {
                if (item >= dic.Count) {
                    linkedNodes.Add(new Node { Id = item });
                    continue;
                }

                linkedNodes.Add(
                    new Node {
                        Id = item,
                        LinkedNodes = CreateNodes(dic[item], dic)

                    });
            }

            return linkedNodes.ToArray();
        }

        private static Dictionary<int, List<int>> CreateDicionaryOfIds(List<Entity> EntityList) {
            var dic = new Dictionary<int, List<int>>();

            EntityList.ForEach(e => {
                if (dic.ContainsKey(e.FromNodeId)) {
                    dic[e.FromNodeId].Add(e.ToNodeId);
                } else {
                    dic.Add(e.FromNodeId, new List<int> { e.ToNodeId });
                }
            });
            return dic;
        }

        private static IEnumerable<int> GetChildrenIds(List<Entity> EntityList) {
            return EntityList.Select(child => child.ToNodeId);
        }

        private static IEnumerable<Entity> GetRoots(List<Entity> EntityList, IEnumerable<int> childrenIds) {
            return EntityList.Where(root => !childrenIds.Contains(root.FromNodeId));
        }
    }
}
