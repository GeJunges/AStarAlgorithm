using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Algorithms.TwoDimensionalMap {
    public class FindOutHowToGetOut {

        private const int Start = 2;
        private const int Goal = 3;
        private const int Blocked = 1;
        private const int Free = 0;

        public int CalculateStepsNumber(int[][] map) {
            var start = map.GetPositionXY(Start);
            var end = map.GetPositionXY(Goal);

            var current = new Location {
                X = start.X,
                Y = start.Y,
                ScoreG = 0,
            };

            var closedList = new List<Location>();
            var openList = new List<Location> {
                current
            };

            return PlayTheGame(map, start, end, current, openList, closedList);
        }

        private int PlayTheGame(int[][] map, Point start, Point end, Location current, List<Location> openList, List<Location> closedList) {
            if (current.X == end.X && current.Y == end.Y) {
                return current.ScoreGH;
            }

            var locations = GetPossibleLocations(map, end, current);

            closedList.Add(current);
            openList.Remove(current);

            foreach (var location in locations) {
                if (closedList.FirstOrDefault(l => l.X == location.X && l.Y == location.Y) != null) {
                    continue;
                }
                if (openList.FirstOrDefault(l => l.X == location.X && l.Y == location.Y) == null) {
                    openList.Add(location);
                }
            };

            var lowest = openList.Min(l => l.ScoreGH);
            var result = openList.Where(l => l.ScoreGH == lowest).ToList();

            GetNewCurrent(result, ref current);

            return PlayTheGame(map, start, end, current, openList, closedList);
        }

        private static void GetNewCurrent(List<Location> result, ref Location current) {
            if (result.Count > 1) {
                var tieBreaker = result.Min(t => t.ScoreH);
                current = result.Where(t => t.ScoreH == tieBreaker).First();
            } else {
                current = result.First();
            }
        }

        private List<Location> GetPossibleLocations(int[][] map, Point end, Location current) {
            var listNextSteps = CreateNextPossibleSteps(current);
            var nextStepsFiltered = FilterValidSteps(map, listNextSteps);

            return nextStepsFiltered.Select(step => {
                return new Location {
                    X = step.X,
                    Y = step.Y,
                    ScoreG = current.ScoreG + 1,
                    ScoreH = CalculateDistance(step, end),
                    Parent = current
                };
            }).ToList();
        }

        private static List<Point> FilterValidSteps(int[][] map, List<Point> listNextSteps) {
            return listNextSteps.Where(point => ValidCoordinates(map, point)
              && (map[point.X][point.Y] == Free || map[point.X][point.Y] == Goal)).ToList();
        }

        private static bool ValidCoordinates(int[][] map, Point point) {
            var maxSizeX = map.Length - 1;
            var maxSizeY = map[0].Length - 1;
            const int minSize = 0;
            return point.X <= maxSizeX && point.X >= minSize && point.Y <= maxSizeY && point.Y >= minSize;
        }

        private static List<Point> CreateNextPossibleSteps(Location current) {
            return new List<Point> {
                new Point {
                    X= current.X + 1,
                    Y = current.Y
                },
                new Point {
                    X= current.X - 1,
                    Y = current.Y
                },
                new Point {
                    X= current.X,
                    Y = current.Y + 1
                },
                new Point {
                    X= current.X,
                    Y = current.Y - 1
                },
            };
        }

        private int CalculateDistance(Point step, Point end) {
            return (int)(Math.Pow(Math.Abs(end.X - step.X), 2) + Math.Pow(Math.Abs(end.Y - step.Y), 2));
        }
    }
}
