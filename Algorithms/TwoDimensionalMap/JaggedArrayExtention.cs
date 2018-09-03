using System.Drawing;

namespace Algorithms.TwoDimensionalMap {
    public static class JaggedArrayExtention {

        public static Point GetPositionXY<T>(this T[][] map, T value) {
            for (int i = 0; i < map.Length; i++) {
                T[] array = map[i];
                for (int j = 0; j < array.Length; j++)
                    if (array[j].Equals(value))
                        return new Point(i, j);
            }
            return new Point(-1, -1);
        }
    }
}
