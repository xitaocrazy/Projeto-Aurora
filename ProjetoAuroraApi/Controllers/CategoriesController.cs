using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProjetoAuroraApi.Factories.PointsCalculation;
using ProjetoAuroraApi.Models;

namespace ProjetoAuroraApi.Controllers {
    [Route("api/[controller]")]
    public class CategoriesController : Controller{
        private IServiceToCaculatePointsFactory _serviceToCaculatePointsFactory;

        public CategoriesController(IServiceToCaculatePointsFactory serviceToCaculatePointsFactory) {
            _serviceToCaculatePointsFactory = serviceToCaculatePointsFactory;
        }

        [HttpGet]
        public Category Get(int categoryId, string values) {
            var service = _serviceToCaculatePointsFactory.CreateServiceToCaculatePoints(categoryId);
            var listValues = values.Split(',').Select(v => int.Parse(v)).ToList();
            var category = service.CalculatePointsToCategory(listValues);
            return category;
        }
    }
}
