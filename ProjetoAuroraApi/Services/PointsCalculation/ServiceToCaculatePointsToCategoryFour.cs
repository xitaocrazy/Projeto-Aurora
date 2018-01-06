using ProjetoAuroraApi.Models;
using System.Collections.Generic;
using System.Linq;
using ProjetoAuroraApi.Helpers;

namespace ProjetoAuroraApi.Services.PointsCalculation  {
    public class ServiceToCaculatePointsToCategoryFour : IServiceToCaculatePoints {
        private const int index = 4;
        public Category CalculatePointsToCategory(IEnumerable<int> values){ 
            var category = new Category{
                Id = index, 
                Name= "Quatro",          
                Points = ServiceToCaculatePointsHelper.CalculatePoints(values, index),
                Rule = $"Haver pelo menos 1 dado com valor {index} no rolamento.",
                Calculation = $"Soma de todos os dados de valor {index}."
            };
            return category;
        }
    }
}