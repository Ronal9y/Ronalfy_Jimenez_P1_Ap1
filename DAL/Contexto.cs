using Microsoft.EntityFrameworkCore;
using Ronalfy_Jimenez_P1_Ap1.Models;
using Ronalfy_Jimenez_P1_Ap1.DAL;
using Ronalfy_Jimenez_P1_Ap1.Models;
using System.Collections.Generic;

namespace Ronalfy_Jimenez_P1_Ap1.DAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }
        public DbSet<Modelo> Modelos { get; set; }
    }
