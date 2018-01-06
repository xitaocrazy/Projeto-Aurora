using ProjetoAuroraApi.Models;
using System.Collections.Generic;
using System.Linq;
using ProjetoAuroraApi.Helpers;

namespace ProjetoAuroraApi.Services.PointsCalculation  {
    public class ServiceToCaculatePointsToCategoryThirteen : IServiceToCaculatePoints {
        private const int index = 13;
        public Category CalculatePointsToCategory(IEnumerable<int> values){
            var category = new Category{
                Id = index,  
                Points = CalculatePoints(values),         
                Name = "Full House",
                Rule = "Haver 1 par e 1 trio no rolamento.",
                Calculation = "Soma de todos os Dados."
            };
            return category;
        }

        private static int CalculatePoints(IEnumerable<int> values) {
            var valuesWithTrios = ServiceToCaculatePointsHelper.GetValuesWithTrios(values, true).ToList();
            var valuesWithPair = ServiceToCaculatePointsHelper.GetValuesWithPairs(values, true).ToList();
            
            if (valuesWithTrios.Any() && valuesWithPair.Any()){
                var valueOfTrio = valuesWithTrios.Max();                          
                valueOfTrio = valueOfTrio * 3;
                var valueOfPair = valuesWithPair.Max();                          
                valueOfPair = valueOfPair * 2;
                return valueOfTrio + valueOfPair;
            }

            return 0;
        }
    }
}