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
                case 3:
                    return new ServiceToCaculatePointsToCategoryThree();
                case 4:
                    return new ServiceToCaculatePointsToCategoryFour();
                case 5:
                    return new ServiceToCaculatePointsToCategoryFive();
                case 6:
                    return new ServiceToCaculatePointsToCategorySix();
                case 7:
                    return new ServiceToCaculatePointsToCategorySeven();
                case 8:
                    return new ServiceToCaculatePointsToCategoryEight();
                case 9:
                    return new ServiceToCaculatePointsToCategoryNine();
                case 10:
                    return new ServiceToCaculatePointsToCategoryTen();
                case 11:
                    return new ServiceToCaculatePointsToCategoryEleven();
                case 12:
                    return new ServiceToCaculatePointsToCategoryTwelve();
                case 13:
                    return new ServiceToCaculatePointsToCategoryThirteen();
                case 14:
                    return new ServiceToCaculatePointsToCategoryFourteen();
                default:
                    throw new NotImplementedException("Category not found.");
            }                        
        }
    }
}