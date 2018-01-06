using ProjetoAuroraApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoAuroraApi.Services.PointsCalculation  {
    public class ServiceToCaculatePointsToCategoryFourteen : IServiceToCaculatePoints {
        private const int index = 14;
        public Category CalculatePointsToCategory(IEnumerable<int> values){ 
            var category = new Category{
                Id = index,  
                Points = CalculatePoints(values),
                Name= "Aurora",                         
                Rule = "Haver 5 dados de mesmo valor no rolamento.",
                Calculation = "50 Pontos."
            };
            return category;
        }

        private static int CalculatePoints(IEnumerable<int> values) {
            var minValue = values.Min();
            var maxValue = values.Max();

            for (var i = minValue; i <= maxValue; i++){
                var isAurora = values.Where(v => v == i).Count() == 5;
                if (isAurora){
                    return 50;
                }
            }

            return 0;
        }
    }
}