using System.Linq;
using ProjetoAuroraApi.Helpers;
using Xunit;

namespace ProjetoAuroraApiTests.HelpersTests {
    public class ServiceToCaculatePointsHelperTests {
        [Theory]
        [InlineData(4, new [] {1,2,3,4,5}, 4)]
        [InlineData(2, new [] {1,1,2,2,3}, 1)]
        [InlineData(18, new [] {6,6,6,2,3}, 6)]
        [InlineData(6, new [] {1,2,2,2,4}, 2)]
        [InlineData(0, new [] {4,1,2,2,4}, 3)]
        [InlineData(0, new [] {1,2,5,5,3}, 4)]
        [InlineData(30, new [] {6,6,6,6,6}, 6)]
        public void CalculatePointsToCategory_should_return_the_expected_values(int expected, int[] values, int baseValue) {
            var result = ServiceToCaculatePointsHelper.CalculatePoints(values, baseValue);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new int[]{}, new [] {1,2,3,4,5})]
        [InlineData(new int[]{1}, new [] {1,1,3,1,5})]
        [InlineData(new int[]{1,2}, new [] {1,1,2,2,2})]
        [InlineData(new int[]{2,3}, new [] {1,2,2,3,3})]
        [InlineData(new int[]{2,4}, new [] {4,2,2,4,4})]
        [InlineData(new int[]{1,5}, new [] {1,1,5,5,3})]
        [InlineData(new int[]{2,6}, new [] {6,6,2,2,3})]
        public void GetValuesWithPairs_should_return_all_values_that_has_at_least_a_pair(int[] expected, int[] values){
            var result = ServiceToCaculatePointsHelper.GetValuesWithPairs(values).OrderBy(v => v).ToArray();
            expected = expected.OrderBy(v => v).ToArray();

            Assert.Equal(expected.Length, result.Length);
            for (var i=0; i<expected.Length; i++){
                Assert.Equal(expected[i], result[i]);
            }
        }

        [Theory]
        [InlineData(new int[]{}, new [] {1,2,3,4,5})]
        [InlineData(new int[]{}, new [] {1,1,3,1,5})]
        [InlineData(new int[]{1}, new [] {1,1,2,2,2})]
        [InlineData(new int[]{2,3}, new [] {1,2,2,3,3})]
        [InlineData(new int[]{2}, new [] {4,2,2,4,4})]
        [InlineData(new int[]{1,5}, new [] {1,1,5,5,3})]
        [InlineData(new int[]{2}, new [] {6,6,2,2,6})]
        public void GetValuesWithPairs_should_return_all_values_that_has_exactly_a_pair(int[] expected, int[] values){
            var result = ServiceToCaculatePointsHelper.GetValuesWithPairs(values, true).OrderBy(v => v).ToArray();
            expected = expected.OrderBy(v => v).ToArray();

            Assert.Equal(expected.Length, result.Length);
            for (var i=0; i<expected.Length; i++){
                Assert.Equal(expected[i], result[i]);
            }
        }

        [Theory]
        [InlineData(new int[]{}, new [] {1,2,3,4,5})]
        [InlineData(new int[]{1}, new [] {1,1,3,1,5})]
        [InlineData(new int[]{2}, new [] {1,2,2,2,2})]
        [InlineData(new int[]{}, new [] {1,2,2,3,3})]
        [InlineData(new int[]{4}, new [] {4,2,2,4,4})]
        [InlineData(new int[]{5}, new [] {5,5,5,5,5})]
        [InlineData(new int[]{6}, new [] {6,6,2,2,6})]
        public void GetValuesWithTrios_should_return_all_values_that_has_at_least_a_trio(int[] expected, int[] values){
            var result = ServiceToCaculatePointsHelper.GetValuesWithTrios(values).OrderBy(v => v).ToArray();
            expected = expected.OrderBy(v => v).ToArray();

            Assert.Equal(expected.Length, result.Length);
            for (var i=0; i<expected.Length; i++){
                Assert.Equal(expected[i], result[i]);
            }
        }

        [Theory]
        [InlineData(new int[]{}, new [] {1,2,3,4,5})]
        [InlineData(new int[]{1}, new [] {1,1,3,1,5})]
        [InlineData(new int[]{}, new [] {1,2,2,2,2})]
        [InlineData(new int[]{}, new [] {1,2,2,3,3})]
        [InlineData(new int[]{4}, new [] {4,2,2,4,4})]
        [InlineData(new int[]{}, new [] {5,5,5,5,5})]
        [InlineData(new int[]{6}, new [] {6,6,2,2,6})]
        public void GetValuesWithTrios_should_return_all_values_that_has_exactly_a_trio(int[] expected, int[] values){
            var result = ServiceToCaculatePointsHelper.GetValuesWithTrios(values, true).OrderBy(v => v).ToArray();
            expected = expected.OrderBy(v => v).ToArray();

            Assert.Equal(expected.Length, result.Length);
            for (var i=0; i<expected.Length; i++){
                Assert.Equal(expected[i], result[i]);
            }
        }

        [Theory]
        [InlineData(new int[]{}, new [] {1,2,3,4,5})]
        [InlineData(new int[]{1}, new [] {1,1,1,1,5})]
        [InlineData(new int[]{2}, new [] {1,2,2,2,2})]
        [InlineData(new int[]{}, new [] {1,2,2,3,3})]
        [InlineData(new int[]{4}, new [] {4,4,2,4,4})]
        [InlineData(new int[]{5}, new [] {5,5,5,5,5})]
        [InlineData(new int[]{}, new [] {6,6,2,2,6})]
        public void GetValuesWithFour_should_return_all_values_that_has_at_least_a_four_equal_numbers(int[] expected, int[] values){
            var result = ServiceToCaculatePointsHelper.GetValuesWithFour(values).OrderBy(v => v).ToArray();
            expected = expected.OrderBy(v => v).ToArray();

            Assert.Equal(expected.Length, result.Length);
            for (var i=0; i<expected.Length; i++){
                Assert.Equal(expected[i], result[i]);
            }
        }

        [Theory]
        [InlineData(new int[]{}, new [] {1,2,3,4,5})]
        [InlineData(new int[]{1}, new [] {1,1,1,1,5})]
        [InlineData(new int[]{2}, new [] {1,2,2,2,2})]
        [InlineData(new int[]{}, new [] {1,2,2,3,3})]
        [InlineData(new int[]{4}, new [] {4,4,2,4,4})]
        [InlineData(new int[]{}, new [] {5,5,5,5,5})]
        [InlineData(new int[]{}, new [] {6,6,6,6,6})]
        public void GetValuesWithFour_should_return_all_values_that_has_exactly_a_four_equal_numbers(int[] expected, int[] values){
            var result = ServiceToCaculatePointsHelper.GetValuesWithFour(values, true).OrderBy(v => v).ToArray();
            expected = expected.OrderBy(v => v).ToArray();

            Assert.Equal(expected.Length, result.Length);
            for (var i=0; i<expected.Length; i++){
                Assert.Equal(expected[i], result[i]);
            }
        }
    }
}