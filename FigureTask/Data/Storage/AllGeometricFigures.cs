using FigureTask.Data.Interfaces;
using FigureTask.Data.Models;

namespace FigureTask.Data.Storage
{
    public class AllGeometricFigures : IAllGeometricFigures
    {
        private readonly ApplicationDB _applicationDB;

        public AllGeometricFigures(ApplicationDB applicationDB)
        {
            _applicationDB = applicationDB;
        }
        public IEnumerable<GeometricFigure> ShowAllGeometricFigures() => _applicationDB.GeometricFigures;
    }
}
