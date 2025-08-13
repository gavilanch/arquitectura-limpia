using DientesLimpios.Identidad.Modelos;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DientesLimpios.Identidad
{
    public class DientesLimpiosIdentityDbContext : IdentityDbContext<Usuario>
    {
        public DientesLimpiosIdentityDbContext(DbContextOptions<DientesLimpiosIdentityDbContext> options) : 
            base(options)
        {
        }

        protected DientesLimpiosIdentityDbContext()
        {
        }
    }
}
