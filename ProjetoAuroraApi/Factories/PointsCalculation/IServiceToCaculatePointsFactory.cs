using ProjetoAuroraApi.Services.PointsCalculation ;

namespace ProjetoAuroraApi.Factories.PointsCalculation  {
    public interface IServiceToCaculatePointsFactory {                
        IServiceToCaculatePoints CreateServiceToCaculatePoints(int categoryId);
    }
}