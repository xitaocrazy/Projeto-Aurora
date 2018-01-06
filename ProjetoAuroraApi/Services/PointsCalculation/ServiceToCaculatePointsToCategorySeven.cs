using ProjetoAuroraApi.Models;
using System.Collections.Generic;
using System.Linq;
using ProjetoAuroraApi.Helpers;

namespace ProjetoAuroraApi.Services.PointsCalculation  {
    public class ServiceToCaculatePointsToCategorySeven : IServiceToCaculatePoints {
        private const int index = 7;
        public Category CalculatePointsToCategory(IEnumerable<int> values){ 
            var category = new Category{
                Id = index,  
                Points = CalculatePoints(values),         
                Name = "Par",
                Rule = "Haver pelo menos 2 dados de mesmo valor no rolamento.",
                Calculation = "Soma dos dois dados de mesmo valor."
            };
            return category;
        }

        private static int CalculatePoints(IEnumerable<int> values) {
            var valuesWithPairs = ServiceToCaculatePointsHelper.GetValuesWithPairs(values);
            
            if (!valuesWithPairs.Any()){
                return 0;
            }

            var value = valuesWithPairs.Max();
            return value * 2;
        }
    }
}