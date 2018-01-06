using ProjetoAuroraApi.Models;
using ProjetoAuroraApi.Services.PointsCalculation;
using Xunit;

namespace ProjetoAuroraApiTests.ServicesTests {
    public class ServiceToCaculatePointsToCategorySixTests {
        [Theory]
        [InlineData(0, new [] {2,2,2,4,5})]
        [InlineData(6, new [] {1,2,3,4,6})]
        [InlineData(12, new [] {1,3,3,6,6})]
        [InlineData(18, new [] {3,3,6,6,6})]
        [InlineData(24, new [] {3,6,6,6,6})]
        [InlineData(30, new [] {6,6,6,6,6})]
        public void CalculatePointsToCategory_should_return_the_sum_of_all_values_six(int points, int[] values) {
            var service = new ServiceToCaculatePointsToCategorySix();
            var expected = CreateCategory(points);

            var result = service.CalculatePointsToCategory(values);

            Assert.Equal(expected, result);
        }

        private static Category CreateCategory(int points) {
            return new Category {
                Id = 6,
                Points = points,
                Name = "Seis",                
                Rule = "Haver pelo menos 1 dado com valor 6 no rolamento.",
                Calculation = "Soma de todos os dados de valor 6."
            };
        }
    }
}