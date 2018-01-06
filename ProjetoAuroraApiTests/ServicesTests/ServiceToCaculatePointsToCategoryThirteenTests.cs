using ProjetoAuroraApi.Models;
using ProjetoAuroraApi.Services.PointsCalculation;
using Xunit;

namespace ProjetoAuroraApiTests.ServicesTests {
    public class ServiceToCaculatePointsToCategoryThirteenTests {
        [Theory]
        [InlineData(0, new [] {1,2,3,4,5})]
        [InlineData(0, new [] {1,1,1,3,5})]
        [InlineData(16, new [] {4,2,4,2,4})]
        [InlineData(21, new [] {3,3,3,6,6})]
        [InlineData(0, new [] {4,4,4,4,5})]
        [InlineData(13, new [] {1,1,1,5,5})]
        [InlineData(13, new [] {1,5,1,1,5})]
        public void CalculatePointsToCategory_should_return_20_when_has_a_pair_and_a_triplo(int points, int[] values) {
            var service = new ServiceToCaculatePointsToCategoryThirteen();
            var expected = CreateCategory(points);

            var result = service.CalculatePointsToCategory(values);

            Assert.Equal(expected, result);
        }

        private static Category CreateCategory(int points) {
            return new Category {
                Id = 13,
                Points = points,
                Name = "Full House",
                Rule = "Haver 1 par e 1 trio no rolamento.",
                Calculation = "Soma de todos os Dados."
            };
        }
    }
}