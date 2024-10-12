// Referencias para la conectividad
using Microsoft.EntityFrameworkCore; // Framework Instalado y en uso
using AppLogin.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal; // Ubicacion de las clases
using System.Data.SqlClient; // ADO.NET

namespace AppLogin.Data
{
    // EntityFramework
    // Esta clase es para definir todo lo relacionado con las bases de datos, funcionamientos de las tablas etc
    public class AppDBContext : DbContext // Uso de Herencia Perteneciente a EntityFramework para poder acceder a Metodos Necesarios
    {
        // Creacion del constructor
        // Este constructor recibe parametros de tipo opciones, para que sepa como comunicarse con la DB
        public AppDBContext(DbContextOptions<AppDBContext>_Options) : base (_Options)
        {

        }

        // Se Definen las tablas de la DB
        // DBSet es perteneciente a EntityFramework como tipo de dato, <User> es la llamada a la clase creada en Models
        public DbSet<_User> Users { get; set; }

        public DbSet<_Employees> Employees { get; set; }

        // Metodo que ayuda a sobre escribir en la tabla
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // TB identificador personal para Tabla
            modelBuilder.Entity<_User>(TB =>
            {
                // Personalizacion de la Tabla - id_User
                TB.HasKey(Colum => Colum.id_User); // Se define id_User como llave primaria

                // Aqui se define la caracteristica de la PK
                TB.Property(Colum => Colum.id_User)
                .UseIdentityColumn() // Valor aumenta de 1 en 1
                .ValueGeneratedOnAdd(); // Se genera cada entrada de registro a la tabla

                // Personalizacion de la Tabla - Name
                TB.Property(Colum => Colum.Name)
                .HasMaxLength(50);

                // Personalizacion de la Tabla - Email
                TB.Property(Colum => Colum.Name)
                .HasMaxLength(50);

                // Personalizacion de la Tabla - Password
                TB.Property(Colum => Colum.Name)
                .HasMaxLength(50);
            });

            modelBuilder.Entity<_Employees>(tb =>
            {
                // Personalizacion de la Tabla - ID_Employees
                tb.HasKey(Colum => Colum.ID_Employees); // Se define ID_Employees como llave primaria

                // Aqui se define la caracteristica de la PK
                tb.Property(Colum => Colum.ID_Employees)
                .UseIdentityColumn() // Valor aumenta de 1 en 1
                .ValueGeneratedOnAdd(); // Se genera cada entrada de registro a la tabla

                // Personalizacion de la Tabla - Status
                tb.Property(Colum => Colum.Status);

                // Personalizacion de la Tabla - FirstName
                tb.Property(Colum => Colum.FirstName)
                .HasMaxLength(50);

                // Personalizacion de la Tabla - LastName
                tb.Property(Colum => Colum.LastName)
                .HasMaxLength(50);

                // Personalizacion de la Tabla - Gender
                tb.Property(Colum => Colum.Gender)
                .HasMaxLength(50);

                // Personalizacion de la Tabla - Position
                tb.Property(Colum => Colum.Position)
                .HasMaxLength(50);

                // Personalizacion de la Tabla - HireDate
                tb.Property(Colum => Colum.HireDate);

                // Personalizacion de la Tabla - Salary
                tb.Property(Colum => Colum.Salary);

                // Personalizacion de la Tabla - City
                tb.Property(Colum => Colum.City)
                .HasMaxLength(50);

                // Personalizacion de la Tabla - _Email
                tb.Property(Colum => Colum.Email)
                .HasMaxLength(50);
            });

            // Hacer que modelBuilder apunte hacia la tabla User
            modelBuilder.Entity<_User>().ToTable("_User");

            // Hacer que modelBuilder apunte hacia la tabla User
            modelBuilder.Entity<_Employees>().ToTable("_Employees");
        }
    }
}
