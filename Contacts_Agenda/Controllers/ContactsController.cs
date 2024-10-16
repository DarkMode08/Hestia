using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;
using Microsoft.EntityFrameworkCore;
using Contacts_Agenda.Models;
using Contacts_Agenda.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;

namespace Contacts_Agenda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        // Define un campo privado y de solo lectura para almacenar el contexto de la base de datos
        private readonly AppDBContext _context;

        // Contructor que recibe una instancia del contexto de la DB
        public ContactsController(AppDBContext context)
        {
            // Asigna la instancia del contexto ya que fue creado como private
            _context = context;
        }

        // Atributo que indica que este método responde a solicitudes HTTP GET
        [HttpGet]
        // Metodo que retorna la lista completa de contactos
        public async Task<ActionResult<IEnumerable<Contacts>>> GetContactos()
        {
            // Consulta todos los contactos de la base de datos y los devuelve como una lista
            return await _context.Contacts.ToListAsync();
        }

        // Define un método POST para agregar un nuevo contacto
        [HttpPost]
        // Atributo que indica que este método responde a solicitudes HTTP POST
        public async Task<ActionResult<Contacts>> PostContacto(Contacts contacto)
        {
            // Agrega el nuevo contacto al contexto
            _context.Contacts.Add(contacto);
            // Guarda los cambios en la base de datos
            await _context.SaveChangesAsync();

            // Retorna el contacto creado con un código de respuesta 201 (Created)
            return CreatedAtAction(nameof(GetContactos), new { id = contacto.iD_Contact }, contacto);
        }

        // Define un método PUT para actualizar un contacto existente
        [HttpPut("{iD_Contact}")]
        // Atributo que indica que este método responde a solicitudes HTTP PUT
        public async Task<IActionResult> PutContacto(int id, Contacts contacto)
        {
            // Verifica si el ID proporcionado coincide con el ID del contacto
            if (id != contacto.iD_Contact)
            {
                return BadRequest();
            }

            // Marca el contacto como modificado en el contexto
            _context.Entry(contacto).State = EntityState.Modified;

            // Guarda los cambios en la base de datos
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Verifica si el contacto existe
                if (!ContactoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // Define un método DELETE para eliminar un contacto por ID
        [HttpDelete("{iD_Contact}")]
        // Atributo que indica que este método responde a solicitudes HTTP DELETE
        public async Task<IActionResult> DeleteContacto(int id)
        {
            // Busca el contacto en la base de datos por su ID
            var contacto = await _context.Contacts.FindAsync(id);
            // Si no se encuentra el contacto, retorna un código de respuesta 404 (Not Found)
            if (contacto == null)
            {
                return NotFound();
            }

            // Elimina el contacto del contexto
            _context.Contacts.Remove(contacto);
            // Guarda los cambios en la base de datos
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Método auxiliar para verificar si un contacto existe en la base de datos
        private bool ContactoExists(int id)
        {
            return _context.Contacts.Any(e => e.iD_Contact == id);
        }

    }
}
