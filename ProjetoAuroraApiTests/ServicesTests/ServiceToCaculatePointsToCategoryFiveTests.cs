using ProjetoAuroraApi.Models;
using ProjetoAuroraApi.Services.PointsCalculation;
using Xunit;

namespace ProjetoAuroraApiTests.ServicesTests {
    public class ServiceToCaculatePointsToCategoryFiveTests {
        [Theory]
        [InlineData(0, new [] {2,2,2,4,4})]
        [InlineData(5, new [] {1,2,3,4,5})]
        [InlineData(10, new [] {1,3,3,5,5})]
        [InlineData(15, new [] {3,3,5,5,5})]
        [InlineData(20, new [] {3,5,5,5,5})]
        [InlineData(25, new [] {5,5,5,5,5})]
        public void CalculatePointsToCategory_should_return_the_sum_of_all_values_five(int points, int[] values) {
            var service = new ServiceToCaculatePointsToCategoryFive();
            var expected = CreateCategory(points);

            var result = service.CalculatePointsToCategory(values);

            Assert.Equal(expected, result);
        }

        private static Category CreateCategory(int points) {
            return new Category {
                Id = 5,
                Points = points,
                Name = "Cinco",                
                Rule = "Haver pelo menos 1 dado com valor 5 no rolamento.",
                Calculation = "Soma de todos os dados de valor 5."
            };
        }
    }
}