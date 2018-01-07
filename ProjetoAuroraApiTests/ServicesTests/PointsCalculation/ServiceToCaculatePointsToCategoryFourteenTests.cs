using ProjetoAuroraApi.Models;
using ProjetoAuroraApi.Services.PointsCalculation;
using Xunit;

namespace ProjetoAuroraApiTests.ServicesTests.PointsCalculation {
    public class ServiceToCaculatePointsToCategoryFourteenTests {
        [Theory]
        [InlineData(50, new [] {1,1,1,1,1})]
        [InlineData(50, new [] {2,2,2,2,2})]
        [InlineData(50, new [] {3,3,3,3,3})]
        [InlineData(50, new [] {4,4,4,4,4})]
        [InlineData(50, new [] {5,5,5,5,5})]
        [InlineData(50, new [] {6,6,6,6,6})]
        [InlineData(0, new [] {1,2,3,4,5})]
        [InlineData(0, new [] {1,1,3,3,3})]
        [InlineData(0, new [] {4,4,4,4,5})]
        public void CalculatePointsToCategory_should_return_50_when_five_numbers_are_equals(int points, int[] values) {
            var service = new ServiceToCaculatePointsToCategoryFourteen();
            var expected = CreateCategory(points);

            var result = service.CalculatePointsToCategory(values);

            Assert.Equal(expected, result);
        }

        private static Category CreateCategory(int points) {
            return new Category {
                Id = 14,
                Points = points,
                Name= "Aurora",                         
                Rule = "Haver 5 dados de mesmo valor no rolamento.",
                Calculation = "50 Pontos."
            };
        }
    }
}