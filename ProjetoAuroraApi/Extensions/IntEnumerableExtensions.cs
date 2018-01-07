using System.Collections.Generic;
using System.Linq;

namespace ProjetoAuroraApi.Extensions{
    public static class IntEnumerableExtensions{
        public static bool HasAtLeastAPairOf(this IEnumerable<int> values, int i) {
            return values.Where(v => v == i).Count() > 1;
        }

        public static bool HasAtLeastATrioOf(this IEnumerable<int> values, int i) {
            return values.Where(v => v == i).Count() > 2;
        }

        public static bool HasAtLeastFourValuesOf(this IEnumerable<int> values, int i) {
            return values.Where(v => v == i).Count() > 3;
        }

        public static bool HasAPairOf(this IEnumerable<int> values, int i) {
            return values.Where(v => v == i).Count() == 2;
        }

        public static bool HasATrioOf(this IEnumerable<int> values, int i) {
            return values.Where(v => v == i).Count() == 3;
        }

        public static bool HasFourValuesOf(this IEnumerable<int> values, int i) {
            return values.Where(v => v == i).Count() == 4;
        }
    }
}