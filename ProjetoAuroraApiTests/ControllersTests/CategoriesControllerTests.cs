using ProjetoAuroraApi.Factories.PointsCalculation;
using Moq;
using ProjetoAuroraApi.Controllers;
using ProjetoAuroraApi.Services.PointsCalculation;
using Xunit;
using System.Collections.Generic;
using ProjetoAuroraApi.Models;

namespace ProjetoAuroraApiTests.ControllersTests {
    public class CategoriesControllerTests {
        private Mock<IServiceToCaculatePointsFactory> _serviceToCaculatePointsFactoryMock;
        private Mock<IServiceToCaculatePoints> _serviceToCaculatePointsMock;

        [Fact]
        public void Get_should_return_the_expected_category() {
            var categoriesController = CrieController();
            var expected = CreateCategory();

            var returned = categoriesController.Get(8, "1,2,3,4,5");

            Assert.Equal(expected, returned);
        }

        [Fact]
        public void Get_should_call_CreateServiceToCaculatePoints() {
            var categoriesController = CrieController();
            var expected = CreateCategory();

            categoriesController.Get(8, "1,2,3,4,5");

            _serviceToCaculatePointsFactoryMock.Verify(s => s.CreateServiceToCaculatePoints(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public void Get_should_call_CalculatePointsToCategory() {
            var categoriesController = CrieController();
            var expected = CreateCategory();

            categoriesController.Get(8, "1,2,3,4,5");

            _serviceToCaculatePointsMock.Verify(s => s.CalculatePointsToCategory(It.IsAny<IEnumerable<int>>()), Times.Once);
        }

        private CategoriesController CrieController(){
            var category = CreateCategory();
            _serviceToCaculatePointsMock = new Mock<IServiceToCaculatePoints>(MockBehavior.Strict);
            _serviceToCaculatePointsFactoryMock = new Mock<IServiceToCaculatePointsFactory>(MockBehavior.Strict);
            _serviceToCaculatePointsMock.Setup(s => s.CalculatePointsToCategory(It.IsAny<IEnumerable<int>>())).Returns(category);
            _serviceToCaculatePointsFactoryMock.Setup(s => s.CreateServiceToCaculatePoints(It.IsAny<int>())).Returns(_serviceToCaculatePointsMock.Object);
            var controller = new CategoriesController(_serviceToCaculatePointsFactoryMock.Object);
            return controller;
        }

        private static Category CreateCategory(){
            var category = new Category{
                Id = 8,  
                Points = 10,         
                Name = "Dois Pares",
                Rule = "Haver pelo menos 2 pares de dados distintos no rolamento.",
                Calculation = "Soma dos quatro dados que integram os pares."
            };
            return category;
        }
    }
}