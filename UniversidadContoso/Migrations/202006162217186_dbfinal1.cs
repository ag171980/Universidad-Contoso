namespace UniversidadContoso.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbfinal1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Alumno", newName: "Alumnoo");
            RenameTable(name: "dbo.Curso", newName: "Cursoo");
            RenameTable(name: "dbo.Departamento", newName: "Departamentoo");
            RenameTable(name: "dbo.Instructor", newName: "Instructoor");
            RenameTable(name: "dbo.CursoAlumno", newName: "CursooAlumnoo");
            RenameColumn(table: "dbo.CursooAlumnoo", name: "Curso_ID_Curso", newName: "Cursoo_ID_Curso");
            RenameColumn(table: "dbo.CursooAlumnoo", name: "Alumno_ID_Alumno", newName: "Alumnoo_ID_Alumno");
            RenameIndex(table: "dbo.CursooAlumnoo", name: "IX_Curso_ID_Curso", newName: "IX_Cursoo_ID_Curso");
            RenameIndex(table: "dbo.CursooAlumnoo", name: "IX_Alumno_ID_Alumno", newName: "IX_Alumnoo_ID_Alumno");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.CursooAlumnoo", name: "IX_Alumnoo_ID_Alumno", newName: "IX_Alumno_ID_Alumno");
            RenameIndex(table: "dbo.CursooAlumnoo", name: "IX_Cursoo_ID_Curso", newName: "IX_Curso_ID_Curso");
            RenameColumn(table: "dbo.CursooAlumnoo", name: "Alumnoo_ID_Alumno", newName: "Alumno_ID_Alumno");
            RenameColumn(table: "dbo.CursooAlumnoo", name: "Cursoo_ID_Curso", newName: "Curso_ID_Curso");
            RenameTable(name: "dbo.CursooAlumnoo", newName: "CursoAlumno");
            RenameTable(name: "dbo.Instructoor", newName: "Instructor");
            RenameTable(name: "dbo.Departamentoo", newName: "Departamento");
            RenameTable(name: "dbo.Cursoo", newName: "Curso");
            RenameTable(name: "dbo.Alumnoo", newName: "Alumno");
        }
    }
}
