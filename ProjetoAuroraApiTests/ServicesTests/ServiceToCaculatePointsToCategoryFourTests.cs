using ProjetoAuroraApi.Models;
using ProjetoAuroraApi.Services.PointsCalculation;
using Xunit;

namespace ProjetoAuroraApiTests.ServicesTests {
    public class ServiceToCaculatePointsToCategoryFourTests {
        [Theory]
        [InlineData(0, new [] {2,2,3,3,5})]
        [InlineData(4, new [] {1,2,3,4,5})]
        [InlineData(8, new [] {1,1,4,4,5})]
        [InlineData(12, new [] {3,4,4,4,5})]
        [InlineData(16, new [] {4,4,4,4,5})]
        [InlineData(20, new [] {4,4,4,4,4})]
        public void CalculatePointsToCategory_should_return_the_sum_of_all_values_four(int points, int[] values) {
            var service = new ServiceToCaculatePointsToCategoryFour();
            var expected = CreateCategory(points);

            var result = service.CalculatePointsToCategory(values);

            Assert.Equal(expected, result);
        }

        private static Category CreateCategory(int points) {
            return new Category {
                Id = 4,
                Points = points,
                Name = "Quatro",                
                Rule = "Haver pelo menos 1 dado com valor 4 no rolamento.",
                Calculation = "Soma de todos os dados de valor 4."
            };
        }
    }
}