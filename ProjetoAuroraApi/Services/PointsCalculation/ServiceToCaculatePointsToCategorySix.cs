using ProjetoAuroraApi.Models;
using System.Collections.Generic;
using System.Linq;
using ProjetoAuroraApi.Helpers;

namespace ProjetoAuroraApi.Services.PointsCalculation  {
    public class ServiceToCaculatePointsToCategorySix : IServiceToCaculatePoints {
        private const int index = 6;
        public Category CalculatePointsToCategory(IEnumerable<int> values){ 
            var category = new Category{
                Id = index,  
                Name= "Seis",          
                Points = ServiceToCaculatePointsHelper.CalculatePoints(values, index),
                Rule = $"Haver pelo menos 1 dado com valor {index} no rolamento.",
                Calculation = $"Soma de todos os dados de valor {index}."
            };
            return category;
        }
    }
}