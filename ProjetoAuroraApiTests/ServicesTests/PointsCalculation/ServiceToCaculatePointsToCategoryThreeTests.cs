using ProjetoAuroraApi.Models;
using ProjetoAuroraApi.Services.PointsCalculation;
using Xunit;

namespace ProjetoAuroraApiTests.ServicesTests.PointsCalculation {
    public class ServiceToCaculatePointsToCategoryThreeTests {
        [Theory]
        [InlineData(0, new [] {2,2,2,4,5,6})]
        [InlineData(3, new [] {1,2,3,4,5,6})]
        [InlineData(6, new [] {1,3,3,4,5,6})]
        [InlineData(9, new [] {3,3,3,4,5,6})]
        [InlineData(12, new [] {3,3,3,3,5,6})]
        [InlineData(15, new [] {3,3,3,3,3,6})]
        [InlineData(18, new [] {3,3,3,3,3,3})]
        public void CalculatePointsToCategory_should_return_the_sum_of_all_values_three(int points, int[] values) {
            var service = new ServiceToCaculatePointsToCategoryThree();
            var expected = CreateCategory(points);

            var result = service.CalculatePointsToCategory(values);

            Assert.Equal(expected, result);
        }

        private static Category CreateCategory(int points) {
            return new Category {
                Id = 3,
                Points = points,
                Name = "Três",                
                Rule = "Haver pelo menos 1 dado com valor 3 no rolamento.",
                Calculation = "Soma de todos os dados de valor 3."
            };
        }
    }
}