using System.Collections.Generic;
using ProjetoAuroraApi.Models;

namespace ProjetoAuroraApi.Services.PointsCalculation  {
    public interface IServiceToCaculatePoints {
        Category CalculatePointsToCategory(IEnumerable<int> values);
    }
}