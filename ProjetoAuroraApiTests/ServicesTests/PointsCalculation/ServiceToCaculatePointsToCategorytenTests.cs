using ProjetoAuroraApi.Models;
using ProjetoAuroraApi.Services.PointsCalculation;
using Xunit;

namespace ProjetoAuroraApiTests.ServicesTests.PointsCalculation {
    public class ServiceToCaculatePointsToCategoryTenTests {
        [Theory]
        [InlineData(0, new [] {2,2,3,3,5})]
        [InlineData(0, new [] {1,1,1,4,5})]
        [InlineData(8, new [] {2,2,2,2,5})]
        [InlineData(12, new [] {3,4,3,3,3})]
        [InlineData(16, new [] {4,4,4,4,5})]
        [InlineData(20, new [] {5,5,5,5,5})]
        [InlineData(24, new [] {6,6,6,4,6})]
        public void CalculatePointsToCategory_should_return_the_sum_of_four_values(int points, int[] values) {
            var service = new ServiceToCaculatePointsToCategoryTen();
            var expected = CreateCategory(points);

            var result = service.CalculatePointsToCategory(values);

            Assert.Equal(expected, result);
        }

        private static Category CreateCategory(int points) {
            return new Category {
                Id = 10,
                Points = points,
                Name = "Quadra",
                Rule = "Haver pelo menos 4 dados de mesmo valor no rolamento.",
                Calculation = "Soma dos quatro dados de mesmo valor."
            };
        }
    }
}