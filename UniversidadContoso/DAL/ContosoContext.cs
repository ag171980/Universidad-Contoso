using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace UniversidadContoso.DAL
{
    //Con DBContext heredamos del FW la clase del contexto.
    public class ContosoContext : DbContext
    {

        public ContosoContext() : base("ContosoContext") { }

        public DbSet<Models.Departamento> Departamentoo { get; set; }
        public DbSet<Models.Instructor> Instructoor { get; set; }
        public DbSet<Models.Curso> Cursoo { get; set; }
        public DbSet<Models.Alumno> Alumnoo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}