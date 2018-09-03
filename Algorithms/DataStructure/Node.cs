using System.Linq;

namespace Algorithms.DataStructure {
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
