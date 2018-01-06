using ProjetoAuroraApi.Models;
using System.Collections.Generic;
using System.Linq;
using ProjetoAuroraApi.Helpers;

namespace ProjetoAuroraApi.Services.PointsCalculation  {
    public class ServiceToCaculatePointsToCategoryNine : IServiceToCaculatePoints {
        private const int index = 9;
        public Category CalculatePointsToCategory(IEnumerable<int> values){
            var category = new Category{
                Id = index,  
                Points = CalculatePoints(values),         
                Name = "Trio",
                Rule = "Haver pelo menos 3 dados de mesmo valor no rolamento.",
                Calculation = "Soma dos três dados de mesmo valor."
            };
            return category;
        }

        private static int CalculatePoints(IEnumerable<int> values) {
            var valuesWithTrios = ServiceToCaculatePointsHelper.GetValuesWithTrios(values).ToList();
            
            if (valuesWithTrios.Any()){
                var value = valuesWithTrios.Max();                          
                return value * 3;
            }

            return 0;
        }
    }
}