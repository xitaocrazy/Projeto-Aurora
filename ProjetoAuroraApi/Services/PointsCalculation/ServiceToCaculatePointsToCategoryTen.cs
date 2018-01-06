using ProjetoAuroraApi.Models;
using System.Collections.Generic;
using System.Linq;
using ProjetoAuroraApi.Helpers;

namespace ProjetoAuroraApi.Services.PointsCalculation  {
    public class ServiceToCaculatePointsToCategoryTen : IServiceToCaculatePoints {
        private const int index = 10;
        public Category CalculatePointsToCategory(IEnumerable<int> values){
            var category = new Category{
                Id = index,  
                Points = CalculatePoints(values),         
                Name = "Quadra",
                Rule = "Haver pelo menos 4 dados de mesmo valor no rolamento.",
                Calculation = "Soma dos quatro dados de mesmo valor."
            };
            return category;
        }

        private static int CalculatePoints(IEnumerable<int> values) {
            var valuesWithFour = ServiceToCaculatePointsHelper.GetValuesWithFour(values).ToList();
            
            if (valuesWithFour.Any()){
                var value = valuesWithFour.Max();                          
                return value * 4;
            }

            return 0;
        }
    }
}