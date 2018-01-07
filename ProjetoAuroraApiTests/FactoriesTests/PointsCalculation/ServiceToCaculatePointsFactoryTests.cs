using System;
using ProjetoAuroraApi.Factories.PointsCalculation;
using ProjetoAuroraApi.Services.PointsCalculation;
using Xunit;

namespace ProjetoAuroraApiTests.FactoriesTests.PointsCalculation {
    public class ServiceToCaculatePointsFactoryTests {
        [Theory]
        [InlineData(1, typeof(ServiceToCaculatePointsToCategoryOne))]
        [InlineData(2, typeof(ServiceToCaculatePointsToCategoryTwo))]
        [InlineData(3, typeof(ServiceToCaculatePointsToCategoryThree))]
        [InlineData(4, typeof(ServiceToCaculatePointsToCategoryFour))]
        [InlineData(5, typeof(ServiceToCaculatePointsToCategoryFive))]
        [InlineData(6, typeof(ServiceToCaculatePointsToCategorySix))]
        [InlineData(7, typeof(ServiceToCaculatePointsToCategorySeven))]
        [InlineData(8, typeof(ServiceToCaculatePointsToCategoryEight))]
        [InlineData(9, typeof(ServiceToCaculatePointsToCategoryNine))]
        [InlineData(10, typeof(ServiceToCaculatePointsToCategoryTen))]
        [InlineData(11, typeof(ServiceToCaculatePointsToCategoryEleven))]
        [InlineData(12, typeof(ServiceToCaculatePointsToCategoryTwelve))]
        [InlineData(13, typeof(ServiceToCaculatePointsToCategoryThirteen))]
        [InlineData(14, typeof(ServiceToCaculatePointsToCategoryFourteen))]
        public void CreateServiceToCaculatePoints_should_return_the_expected_type(int categoryId, Type type) {
            var factory = new ServiceToCaculatePointsFactory();

            var category = factory.CreateServiceToCaculatePoints(categoryId);

            Assert.Equal(type, category.GetType());
        }
    }
}