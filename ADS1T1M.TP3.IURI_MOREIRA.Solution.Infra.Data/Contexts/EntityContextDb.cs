using ADS1T1M.TP3.IURI_MOREIRA.Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ADS1T1M.TP3.IURI_MOREIRA.Solution.Infra.Data.Contexts
{
    class EntityContextDb : DbContext
    {
        public DbSet<Aluno> aluno { get; set; }
    }
}
