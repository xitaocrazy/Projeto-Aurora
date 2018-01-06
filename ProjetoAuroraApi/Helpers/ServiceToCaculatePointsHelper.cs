using System.Collections.Generic;
using System.Linq;

namespace ProjetoAuroraApi.Helpers {
    public static class ServiceToCaculatePointsHelper {
        public static int CalculatePoints(IEnumerable<int> values, int index) {
            var validValues = values.Where(v => v == index);
            return validValues.Count() * index;
        }

        public static IEnumerable<int> GetValuesWithPairs(IEnumerable<int> values, bool onlyExacts = false) {
            var pairs = new List<int>();
            for (var i=1; i<=6; i++) {
                bool hasPair = onlyExacts ? HasAPairOf(values, i) : HasAtLeastAPairOf(values, i);
                if (hasPair) {
                    pairs.Add(i);
                }
            }
            return pairs;
        }        

        public static IEnumerable<int> GetValuesWithTrios(IEnumerable<int> values, bool onlyExacts = false) {
            var trios = new List<int>();
            for (var i=1; i<=6; i++) {
                bool hasTrio = onlyExacts ? HasATrioOf(values, i) : HasAtLeastATrioOf(values, i);
                if (hasTrio) {
                    trios.Add(i);
                }
            }
            return trios;
        }

        public static IEnumerable<int> GetValuesWithFour(IEnumerable<int> values) {
            var four = new List<int>();
            for (var i=1; i<=6; i++) {
                bool hasTrio = HasAtLeastFourValuesOf(values, i);
                if (hasTrio) {
                    four.Add(i);
                }
            }
            return four;
        }

        private static bool HasAtLeastAPairOf(IEnumerable<int> values, int i) {
            return values.Where(v => v == i).Count() > 1;
        }

        private static bool HasAtLeastATrioOf(IEnumerable<int> values, int i) {
            return values.Where(v => v == i).Count() > 2;
        }

        private static bool HasAtLeastFourValuesOf(IEnumerable<int> values, int i) {
            return values.Where(v => v == i).Count() > 3;
        }

        private static bool HasAPairOf(IEnumerable<int> values, int i) {
            return values.Where(v => v == i).Count() == 2;
        }

        private static bool HasATrioOf(IEnumerable<int> values, int i) {
            return values.Where(v => v == i).Count() == 3;
        }
    }
}