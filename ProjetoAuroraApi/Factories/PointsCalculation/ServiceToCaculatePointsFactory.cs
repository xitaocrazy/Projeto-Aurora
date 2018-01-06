using System;
using ProjetoAuroraApi.Services.PointsCalculation ;

namespace ProjetoAuroraApi.Factories.PointsCalculation  {
    public class ServiceToCaculatePointsFactory : IServiceToCaculatePointsFactory {                
        public IServiceToCaculatePoints CreateServiceToCaculatePoints(int categoryId){
            switch (categoryId) {
                case 1:
                    return new ServiceToCaculatePointsToCategoryOne();
                case 2:
                    return new ServiceToCaculatePointsToCategoryTwo();
                default:
                    throw new NotImplementedException("Category not found.");
            }                        
        }
    }
}