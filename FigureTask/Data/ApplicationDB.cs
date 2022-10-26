using FigureTask.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FigureTask.Data
{
    public class ApplicationDB : DbContext
    {
        public DbSet<GeometricFigure> GeometricFigures { get; set; } 
        public ApplicationDB(DbContextOptions<ApplicationDB> options)
            : base(options)
        {
        }

        
    }
}
