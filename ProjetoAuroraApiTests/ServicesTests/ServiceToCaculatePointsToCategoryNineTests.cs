using ProjetoAuroraApi.Models;
using ProjetoAuroraApi.Services.PointsCalculation;
using Xunit;

namespace ProjetoAuroraApiTests.ServicesTests {
    public class ServiceToCaculatePointsToCategoryNineTests {
        [Theory]
        [InlineData(0, new [] {2,2,3,3,5})]
        [InlineData(3, new [] {1,1,1,4,5})]
        [InlineData(6, new [] {1,2,2,2,5})]
        [InlineData(9, new [] {3,4,3,3,3})]
        [InlineData(12, new [] {4,4,4,4,5})]
        [InlineData(15, new [] {5,5,5,5,5})]
        [InlineData(18, new [] {6,6,6,4,4})]
        public void CalculatePointsToCategory_should_return_the_sum_of_three_values(int points, int[] values) {
            var service = new ServiceToCaculatePointsToCategoryNine();
            var expected = CreateCategory(points);

            var result = service.CalculatePointsToCategory(values);

            Assert.Equal(expected, result);
        }

        private static Category CreateCategory(int points) {
            return new Category {
                Id = 9,
                Points = points,
                Name = "Trio",
                Rule = "Haver pelo menos 3 dados de mesmo valor no rolamento.",
                Calculation = "Soma dos três dados de mesmo valor."
            };
        }
    }
}