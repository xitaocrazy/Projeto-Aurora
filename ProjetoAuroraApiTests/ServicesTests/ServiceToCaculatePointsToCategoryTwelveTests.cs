using ProjetoAuroraApi.Models;
using ProjetoAuroraApi.Services.PointsCalculation;
using Xunit;

namespace ProjetoAuroraApiTests.ServicesTests {
    public class ServiceToCaculatePointsToCategoryTwelveTests {
        [Theory]
        [InlineData(20, new [] {1,2,3,4,5})]
        [InlineData(20, new [] {4,3,2,1,5})]
        [InlineData(20, new [] {3,2,4,6,5})]
        [InlineData(20, new [] {2,3,4,5,6})]
        [InlineData(0, new [] {1,1,3,4,5})]
        [InlineData(0, new [] {1,1,1,4,5})]
        [InlineData(0, new [] {1,1,1,1,5})]
        public void CalculatePointsToCategory_should_return_20_when_has_a_sequence_of_five(int points, int[] values) {
            var service = new ServiceToCaculatePointsToCategoryTwelve();
            var expected = CreateCategory(points);

            var result = service.CalculatePointsToCategory(values);

            Assert.Equal(expected, result);
        }

        private static Category CreateCategory(int points) {
            return new Category {
                Id = 12,
                Points = points,
                Name = "Sequencia Maior",
                Rule = "Haver os 5 dados em ordem numérica no rolamento.",
                Calculation = "20 Pontos."
            };
        }
    }
}