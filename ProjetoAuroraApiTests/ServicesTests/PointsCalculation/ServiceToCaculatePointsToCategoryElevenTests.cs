using ProjetoAuroraApi.Models;
using ProjetoAuroraApi.Services.PointsCalculation;
using Xunit;

namespace ProjetoAuroraApiTests.ServicesTests.PointsCalculation {
    public class ServiceToCaculatePointsToCategoryElevenTests {
        [Theory]
        [InlineData(15, new [] {1,2,3,4,5})]
        [InlineData(15, new [] {4,3,2,1,1})]
        [InlineData(15, new [] {3,2,4,4,5})]
        [InlineData(15, new [] {1,3,4,6,5})]
        [InlineData(0, new [] {1,1,3,4,5})]
        [InlineData(0, new [] {1,1,1,4,5})]
        [InlineData(0, new [] {1,1,1,1,5})]
        public void CalculatePointsToCategory_should_return_15_when_has_a_sequence_of_four(int points, int[] values) {
            var service = new ServiceToCaculatePointsToCategoryEleven();
            var expected = CreateCategory(points);

            var result = service.CalculatePointsToCategory(values);

            Assert.Equal(expected, result);
        }

        private static Category CreateCategory(int points) {
            return new Category {
                Id = 11,
                Points = points,
                Name = "Sequencia Menor",
                Rule = "Haver pelo menos 4 dados em ordem numérica no rolamento.",
                Calculation = "15 Pontos."
            };
        }
    }
}