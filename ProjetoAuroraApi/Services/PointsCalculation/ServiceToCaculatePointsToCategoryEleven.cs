using ProjetoAuroraApi.Models;
using System.Collections.Generic;
using System.Linq;
using ProjetoAuroraApi.Helpers;

namespace ProjetoAuroraApi.Services.PointsCalculation  {
    public class ServiceToCaculatePointsToCategoryEleven : IServiceToCaculatePoints {
        private const int index = 11;
        public Category CalculatePointsToCategory(IEnumerable<int> values){
            var category = new Category{
                Id = index,  
                Points = CalculatePoints(values),         
                Name = "Sequencia Menor",
                Rule = "Haver pelo menos 4 dados em ordem numérica no rolamento.",
                Calculation = "15 Pontos."
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
                    if (sequency >= 4){
                        return 15;
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