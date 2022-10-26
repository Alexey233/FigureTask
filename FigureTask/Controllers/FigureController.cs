using FigureTask.Data;
using FigureTask.Data.Interfaces;
using FigureTask.Data.Models;
using FigureTask.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FigureTask.Controllers
{
    public class FigureController : Controller
    {
        private readonly ApplicationDB _applicationDB;
        private readonly IAllGeometricFigures _allGeometricFigures;

        public FigureController(ApplicationDB applicationDB, IAllGeometricFigures allGeometricFigures)
        {
            _applicationDB = applicationDB;
            _allGeometricFigures = allGeometricFigures;
        }

        public List<GeometricFigure> newInstance()
        {
            List<GeometricFigure> geometricFigure = new List<GeometricFigure>()
           {
               new GeometricFigure() {Type = "Треугольник", Sides = "5 6 7", CreateDate = DateOnly.FromDateTime(DateTime.Now)},
               new GeometricFigure() {Type = "Прямоугольник", Sides = "5 6 5 6", CreateDate = DateOnly.FromDateTime(DateTime.Now)},
               new GeometricFigure() {Type = "Прямоугольный-треугольник", Sides = "3 4 5", CreateDate = DateOnly.FromDateTime(DateTime.Now)},
           };
            return geometricFigure;
        }

        public IActionResult ShowFigure()
        {
            List<GeometricFigure> geometricFigure = new List<GeometricFigure>();

            if (_applicationDB.GeometricFigures.Count() == 0)
            {
                geometricFigure = newInstance();
                foreach (var item in geometricFigure)
                {
                    _applicationDB.GeometricFigures.Add(item);
                }
                _applicationDB.SaveChanges();
            };


            var geometricFiguresView = new GeometricFiguresViewModel
            {
                GeometricFigures = _allGeometricFigures.ShowAllGeometricFigures()
            };


            return View(geometricFiguresView);
        }
    }
}
