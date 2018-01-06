using ProjetoAuroraApi.Models;
using System.Collections.Generic;
using System.Linq;
using ProjetoAuroraApi.Helpers;

namespace ProjetoAuroraApi.Services.PointsCalculation  {
    public class ServiceToCaculatePointsToCategoryEight : IServiceToCaculatePoints {
        private const int index = 8;
        public Category CalculatePointsToCategory(IEnumerable<int> values){ 
            var category = new Category{
                Id = index,  
                Points = CalculatePoints(values),         
                Name = "Dois Pares",
                Rule = "Haver pelo menos 2 pares de dados distintos no rolamento.",
                Calculation = "Soma dos quatro dados que integram os pares."
            };
            return category;
        }

        private static int CalculatePoints(IEnumerable<int> values) {
            var valuesWithPairs = ServiceToCaculatePointsHelper.GetValuesWithPairs(values).ToList();
            
            if (valuesWithPairs.Count() > 1){
                var value1 = valuesWithPairs.Max();
                valuesWithPairs.Remove(value1);
                value1 = value1 * 2;
                var value2 = valuesWithPairs.Max();
                value2 = value2 * 2;            
                return value1 + value2;
            }

            return 0;
        }
    }
}