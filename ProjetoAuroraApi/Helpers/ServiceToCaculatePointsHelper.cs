using System.Collections.Generic;
using System.Linq;
using ProjetoAuroraApi.Extensions;

namespace ProjetoAuroraApi.Helpers {
    public static class ServiceToCaculatePointsHelper {
        public static int CalculatePoints(IEnumerable<int> values, int index) {
            var validValues = values.Where(v => v == index);
            return validValues.Count() * index;
        }

        public static IEnumerable<int> GetValuesWithPairs(IEnumerable<int> values, bool onlyExacts = false) {
            var pairs = new List<int>();
            for (var i=1; i<=6; i++) {
                bool hasPair = onlyExacts ? values.HasAPairOf(i) : values.HasAtLeastAPairOf(i);
                if (hasPair) {
                    pairs.Add(i);
                }
            }
            return pairs;
        }        

        public static IEnumerable<int> GetValuesWithTrios(IEnumerable<int> values, bool onlyExacts = false) {
            var trios = new List<int>();
            for (var i=1; i<=6; i++) {
                bool hasTrio = onlyExacts ? values.HasATrioOf(i) : values.HasAtLeastATrioOf(i);
                if (hasTrio) {
                    trios.Add(i);
                }
            }
            return trios;
        }

        public static IEnumerable<int> GetValuesWithFour(IEnumerable<int> values, bool onlyExacts = false) {
            var four = new List<int>();
            for (var i=1; i<=6; i++) {
                bool hasTrio = onlyExacts ? values.HasFourValuesOf(i) : values.HasAtLeastFourValuesOf(i);
                if (hasTrio) {
                    four.Add(i);
                }
            }
            return four;
        }
    }
}