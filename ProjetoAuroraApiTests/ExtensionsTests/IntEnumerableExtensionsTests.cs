using System.Linq;
using ProjetoAuroraApi.Extensions;
using Xunit;

namespace ProjetoAuroraApiTests.ExtensionsTests {
    public class IntEnumerableExtensionsTests {
        [Theory]
        [InlineData(false, new [] {1,2,3,4,5}, 4)]
        [InlineData(true, new [] {1,1,2,2,3}, 1)]
        [InlineData(true, new [] {6,6,6,2,3}, 6)]
        [InlineData(true, new [] {1,2,2,2,4}, 2)]
        [InlineData(false, new [] {4,1,2,2,4}, 3)]
        [InlineData(false, new [] {1,2,4,5,3}, 4)]
        [InlineData(true, new [] {6,6,6,6,6}, 6)]
        public void HasAtLeastAPairOf_should_return_the_expected_values(bool expected, int[] values, int baseValue) {
            var result = values.HasAtLeastAPairOf(baseValue);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(false, new [] {1,2,3,4,5}, 4)]
        [InlineData(true, new [] {1,1,2,2,3}, 1)]
        [InlineData(false, new [] {6,6,6,2,3}, 6)]
        [InlineData(false, new [] {1,2,2,2,4}, 2)]
        [InlineData(true, new [] {4,1,2,2,4}, 2)]
        [InlineData(false, new [] {1,2,4,5,3}, 4)]
        [InlineData(false, new [] {6,6,6,6,6}, 6)]
        public void HasAPairOf_should_return_the_expected_values(bool expected, int[] values, int baseValue) {
            var result = values.HasAPairOf(baseValue);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(false, new [] {1,2,3,4,5}, 4)]
        [InlineData(true, new [] {1,1,1,2,3}, 1)]
        [InlineData(true, new [] {6,6,6,6,3}, 6)]
        [InlineData(true, new [] {1,2,2,2,2}, 2)]
        [InlineData(false, new [] {4,1,2,2,4}, 3)]
        [InlineData(false, new [] {1,4,4,5,3}, 4)]
        [InlineData(true, new [] {6,6,6,6,6}, 6)]
        public void HasAtLeastATrioOf_should_return_the_expected_values(bool expected, int[] values, int baseValue) {
            var result = values.HasAtLeastATrioOf(baseValue);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(false, new [] {1,2,3,4,5}, 4)]
        [InlineData(true, new [] {1,1,1,2,3}, 1)]
        [InlineData(false, new [] {6,6,6,6,3}, 6)]
        [InlineData(false, new [] {1,2,2,2,2}, 2)]
        [InlineData(false, new [] {4,1,2,2,4}, 3)]
        [InlineData(true, new [] {1,4,4,4,3}, 4)]
        [InlineData(false, new [] {6,6,6,6,6}, 6)]
        public void HasATrioOf_should_return_the_expected_values(bool expected, int[] values, int baseValue) {
            var result = values.HasATrioOf(baseValue);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(false, new [] {1,2,3,4,5}, 4)]
        [InlineData(true, new [] {1,1,1,1,3}, 1)]
        [InlineData(true, new [] {5,5,5,5,5}, 5)]
        [InlineData(true, new [] {1,2,2,2,2}, 2)]
        [InlineData(false, new [] {4,1,2,2,4}, 3)]
        [InlineData(false, new [] {1,4,4,4,3}, 4)]
        [InlineData(true, new [] {6,6,6,6,6}, 6)]
        public void HasAtLeastFourValuesOf_should_return_the_expected_values(bool expected, int[] values, int baseValue) {
            var result = values.HasAtLeastFourValuesOf(baseValue);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(false, new [] {1,2,3,4,5}, 4)]
        [InlineData(true, new [] {1,1,1,1,3}, 1)]
        [InlineData(false, new [] {5,5,5,5,5}, 5)]
        [InlineData(true, new [] {1,2,2,2,2}, 2)]
        [InlineData(false, new [] {4,1,2,2,4}, 3)]
        [InlineData(false, new [] {1,4,4,4,3}, 4)]
        [InlineData(false, new [] {6,6,6,6,6}, 6)]
        public void HasFourValuesOf_should_return_the_expected_values(bool expected, int[] values, int baseValue) {
            var result = values.HasFourValuesOf(baseValue);

            Assert.Equal(expected, result);
        }
    }
}