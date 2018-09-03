using System;

namespace Algorithms.DataStructure {
    public class Entity {
        public Guid Id { get; set; }
        public int FromNodeId { get; set; }
        public int ToNodeId { get; set; }
    }
}
