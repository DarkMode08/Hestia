// Esta clase representa los contactos dentro de mi base de datos

namespace Contacts_Agenda.Models
{
    public class Contacts
    {
        public int iD_Contact {  get; set; }

        public required string nameContact { get; set; }

        public required string position {  get; set; }

        public required string emailContact { get; set; }
     
        public required string phoneNumberContact { get; set; }

        public required string addres { get; set; }
    }
}
