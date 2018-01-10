using ProjetoAuroraApi.Factories.PointsCalculation;
using Moq;
using ProjetoAuroraApi.Controllers;
using ProjetoAuroraApi.Services.PointsCalculation;
using Xunit;
using System.Collections.Generic;
using ProjetoAuroraApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ProjetoAuroraApiTests.ControllersTests {
    public class CategoriesControllerTests {
        private Mock<IServiceToCaculatePointsFactory> _serviceToCaculatePointsFactoryMock;
        private Mock<IServiceToCaculatePoints> _serviceToCaculatePointsMock;

        [Fact]
        public void Get_should_return_the_expected_category() {
            var categoriesController = CreateController();
            Bet bet = CreateBet();
            var expected = CreateCategory();

            var returned = (OkObjectResult)categoriesController.Post(bet);
            var data = (Category)returned.Value;

            Assert.Equal(expected, data);
        }        

        [Fact]
        public void Get_should_call_CreateServiceToCaculatePoints() {
            var categoriesController = CreateController();
            Bet bet = CreateBet();
            var expected = CreateCategory();

            categoriesController.Post(bet);

            _serviceToCaculatePointsFactoryMock.Verify(s => s.CreateServiceToCaculatePoints(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public void Get_should_call_CalculatePointsToCategory() {
            var categoriesController = CreateController();
            Bet bet = CreateBet();
            var expected = CreateCategory();

            categoriesController.Post(bet);

            _serviceToCaculatePointsMock.Verify(s => s.CalculatePointsToCategory(It.IsAny<IEnumerable<int>>()), Times.Once);
        }

        private CategoriesController CreateController(){
            var category = CreateCategory();
            _serviceToCaculatePointsMock = new Mock<IServiceToCaculatePoints>(MockBehavior.Strict);
            _serviceToCaculatePointsFactoryMock = new Mock<IServiceToCaculatePointsFactory>(MockBehavior.Strict);
            _serviceToCaculatePointsMock.Setup(s => s.CalculatePointsToCategory(It.IsAny<IEnumerable<int>>())).Returns(category);
            _serviceToCaculatePointsFactoryMock.Setup(s => s.CreateServiceToCaculatePoints(It.IsAny<int>())).Returns(_serviceToCaculatePointsMock.Object);
            var controller = new CategoriesController(_serviceToCaculatePointsFactoryMock.Object);
            return controller;
        }

        private static Bet CreateBet() {
            return new Bet {
                CategoryID = 8,
                Dices = "1,2,3,4,5"
            };
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