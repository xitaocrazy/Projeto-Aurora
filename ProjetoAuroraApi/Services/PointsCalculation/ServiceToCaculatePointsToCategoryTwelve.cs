using ProjetoAuroraApi.Models;
using System.Collections.Generic;
using System.Linq;
using ProjetoAuroraApi.Helpers;

namespace ProjetoAuroraApi.Services.PointsCalculation  {
    public class ServiceToCaculatePointsToCategoryTwelve : IServiceToCaculatePoints {
        private const int index = 12;
        public Category CalculatePointsToCategory(IEnumerable<int> values){
            var category = new Category{
                Id = index,  
                Points = CalculatePoints(values),         
                Name = "Sequencia Maior",
                Rule = "Haver os 5 dados em ordem numérica no rolamento.",
                Calculation = "20 Pontos."
            };
            return category;
        }

        private static int CalculatePoints(IEnumerable<int> values) {
            values = values.OrderBy(v => v).Distinct().ToList(); 
            var max = values.Count();
            var firstValue = values.ElementAt(0);
            var nextValue = firstValue + 1;
            var index = 1;                                   
            var sequency = 1;    
            do{
                var value = values.ElementAt(index);
                if (value == nextValue){
                    sequency++;
                    if (sequency >= 5){
                        return 20;
                    }
                    nextValue++;
                } 
                else{                    
                    firstValue = value;
                    nextValue = firstValue + 1;
                    sequency = 1;
                }
                index++;
            }while(index < max);
            return 0;
        }
    }
}