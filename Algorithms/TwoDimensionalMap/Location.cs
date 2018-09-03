namespace Algorithms.TwoDimensionalMap {
    public class Location {
        public int X { get; set; }
        public int Y { get; set; }

        public int ScoreG { get; set; }
        public int ScoreH { get; set; }
        public int ScoreGH {
            get { return ScoreG + ScoreH; }
        }

        public Location Parent { get; set; }
    }
}
