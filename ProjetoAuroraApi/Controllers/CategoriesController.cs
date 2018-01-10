using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProjetoAuroraApi.Factories.PointsCalculation;
using ProjetoAuroraApi.Models;

namespace ProjetoAuroraApi.Controllers {
    [Route("api/[controller]")]
    public class CategoriesController : Controller {
        private IServiceToCaculatePointsFactory _serviceToCaculatePointsFactory;

        public CategoriesController(IServiceToCaculatePointsFactory serviceToCaculatePointsFactory) {
            _serviceToCaculatePointsFactory = serviceToCaculatePointsFactory;
        }

        [HttpPost]
        public IActionResult Post([FromBody]Bet bet) {
            if (string.IsNullOrEmpty(bet.Dices)){
                return BadRequest();
            }

            var service = _serviceToCaculatePointsFactory.CreateServiceToCaculatePoints(bet.CategoryID);
            var listValues = bet.Dices.Split(',').Select(v => int.Parse(v)).ToList();
            var category = service.CalculatePointsToCategory(listValues);
            return Ok(category);
        }
    }
}
