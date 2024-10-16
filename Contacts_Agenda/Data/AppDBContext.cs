// Referencias para la conectividad

using Contacts_Agenda.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal; // Ubicacion de las clases

namespace Contacts_Agenda.Data
{
    public class AppDBContext : DbContext
    {
        // Creacion del constructor
        // Este constructor recibe parametros de tipo opciones, para que sepa como comunicarse con la DB
        public AppDBContext(DbContextOptions<AppDBContext> _Options) : base(_Options)
        {

        }

        // Se Definen las tablas de la DB
        // DBSet es perteneciente a EntityFramework como tipo de dato, <Contacts> es la llamada a la clase creada en Models
        public DbSet<Contacts> Contacts { get; set; }

        //Metodo para escribir en la tabla de mi DB
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            // TB es el identificador que asigne para la tabla
            modelBuilder.Entity<Contacts>(TB => {
                //En este espacio se personaliza la tabla

                // Personalizacion de iD_Contact
                TB.HasKey(colum => colum.iD_Contact); // Se define como llave primaria al ID

                TB.Property(Colum => Colum.iD_Contact)
                .UseIdentityColumn() // Hace que el id aumente de 1 en 1
                .ValueGeneratedOnAdd(); // Genera cada entrada de registro en la tabla

                // Personalizacion de nameContact
                TB.Property(Colum => Colum.nameContact)
                .HasMaxLength(50);

                // Personalizacion de position
                TB.Property(Colum => Colum.position)
                .HasMaxLength(50);

                // Personalizacion de emailContact
                TB.Property(Colum => Colum.emailContact)
                .HasMaxLength(50);

                // Personalizacion de phoneNumberContact
                TB.Property(Colum => Colum.phoneNumberContact)
                .HasMaxLength(50);

                // Personalizacion de addres
                TB.Property(Colum => Colum.addres)
                .HasMaxLength(50);
            });

            // Hacer que modelBuilder apunte hacia la tabla Contacts
            modelBuilder.Entity<Contacts>().ToTable("Contacts");
        }
    }
}
