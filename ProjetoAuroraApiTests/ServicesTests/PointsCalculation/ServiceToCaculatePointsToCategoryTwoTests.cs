using ProjetoAuroraApi.Models;
using ProjetoAuroraApi.Services.PointsCalculation;
using Xunit;

namespace ProjetoAuroraApiTests.ServicesTests.PointsCalculation {
    public class ServiceToCaculatePointsToCategoryTwoTests {
        [Theory]
        [InlineData(0, new [] {1,1,3,4,5})]
        [InlineData(2, new [] {1,2,3,4,5})]
        [InlineData(4, new [] {2,2,3,4,5})]
        [InlineData(6, new [] {2,2,2,4,5})]
        [InlineData(8, new [] {2,2,2,2,5})]
        [InlineData(10, new [] {2,2,2,2,2})]
        public void CalculatePointsToCategory_should_return_the_sum_of_all_values_two(int points, int[] values) {
            var service = new ServiceToCaculatePointsToCategoryTwo();
            var expected = CreateCategory(points);

            var result = service.CalculatePointsToCategory(values);

            Assert.Equal(expected, result);
        }

        private static Category CreateCategory(int points) {
            return new Category {
                Id = 2,
                Points = points,
                Name = "Dois",                
                Rule = "Haver pelo menos 1 dado com valor 2 no rolamento.",
                Calculation = "Soma de todos os dados de valor 2."
            };
        }
    }
}