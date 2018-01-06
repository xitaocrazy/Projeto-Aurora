using ProjetoAuroraApi.Models;
using ProjetoAuroraApi.Services.PointsCalculation;
using Xunit;

namespace ProjetoAuroraApiTests.ServicesTests {
    public class ServiceToCaculatePointsToCategoryOneTests {
        [Theory]
        [InlineData(0, new [] {2,2,3,4,5})]
        [InlineData(1, new [] {1,2,3,4,5})]
        [InlineData(2, new [] {1,1,3,4,5})]
        [InlineData(3, new [] {1,1,1,4,5})]
        [InlineData(4, new [] {1,1,1,1,5})]
        [InlineData(5, new [] {1,1,1,1,1})]
        public void CalculatePointsToCategory_should_return_the_sum_of_all_values_one(int points, int[] values) {
            var service = new ServiceToCaculatePointsToCategoryOne();
            var expected = CreateCategory(points);

            var result = service.CalculatePointsToCategory(values);

            Assert.Equal(expected, result);
        }

        private static Category CreateCategory(int points) {
            return new Category {
                Id = 1,
                Points = points,
                Name = "Um",                
                Rule = "Haver pelo menos 1 dado com valor 1 no rolamento.",
                Calculation = "Soma de todos os dados de valor 1."
            };
        }
    }
}