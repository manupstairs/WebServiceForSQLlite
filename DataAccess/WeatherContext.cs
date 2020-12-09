using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccess
{
    public class WeatherContext : DbContext
    {
        public WeatherContext(DbContextOptions<WeatherContext> options)
            : base(options)
        {
        }

        public DbSet<WeatherForecast> WeatherForecastItems { get; set; }
    }
}
