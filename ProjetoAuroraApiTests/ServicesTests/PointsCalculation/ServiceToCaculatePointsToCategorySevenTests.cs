using ProjetoAuroraApi.Models;
using ProjetoAuroraApi.Services.PointsCalculation;
using Xunit;

namespace ProjetoAuroraApiTests.ServicesTests.PointsCalculation {
    public class ServiceToCaculatePointsToCategorySevenTests {
        [Theory]
        [InlineData(0, new [] {1,2,3,4,5})]
        [InlineData(2, new [] {1,1,3,4,5})]
        [InlineData(4, new [] {1,1,2,2,5})]
        [InlineData(6, new [] {1,2,2,3,3})]
        [InlineData(8, new [] {1,2,2,4,4})]
        [InlineData(10, new [] {1,1,5,5,3})]
        [InlineData(12, new [] {6,6,2,2,3})]
        public void CalculatePointsToCategory_should_return_the_sum_of_highest_pair(int points, int[] values) {
            var service = new ServiceToCaculatePointsToCategorySeven();
            var expected = CreateCategory(points);

            var result = service.CalculatePointsToCategory(values);

            Assert.Equal(expected, result);
        }

        private static Category CreateCategory(int points) {
            return new Category {
                Id = 7,
                Points = points,
                Name = "Par",                
                Rule = "Haver pelo menos 2 dados de mesmo valor no rolamento.",
                Calculation = "Soma dos dois dados de mesmo valor."
            };
        }
    }
}