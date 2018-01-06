using ProjetoAuroraApi.Models;
using ProjetoAuroraApi.Services.PointsCalculation;
using Xunit;

namespace ProjetoAuroraApiTests.ServicesTests {
    public class ServiceToCaculatePointsToCategoryEightTests {
        [Theory]
        [InlineData(0, new [] {1,2,3,4,5})]
        [InlineData(6, new [] {1,1,2,2,3})]
        [InlineData(16, new [] {6,6,2,2,3})]
        [InlineData(6, new [] {1,1,2,2,4})]
        [InlineData(12, new [] {4,1,2,2,4})]
        [InlineData(0, new [] {1,2,5,5,3})]
        [InlineData(22, new [] {6,6,5,5,3})]
        public void CalculatePointsToCategory_should_return_the_sum_of_two_highest_pairs(int points, int[] values) {
            var service = new ServiceToCaculatePointsToCategoryEight();
            var expected = CreateCategory(points);

            var result = service.CalculatePointsToCategory(values);

            Assert.Equal(expected, result);
        }

        private static Category CreateCategory(int points) {
            return new Category {
                Id = 8,
                Points = points,
                Name = "Dois Pares",                
                Rule = "Haver pelo menos 2 pares de dados distintos no rolamento.",
                Calculation = "Soma dos quatro dados que integram os pares."
            };
        }
    }
}