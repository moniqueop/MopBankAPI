using ClientAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClientAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly DataContext _context;

        public ClientController(DataContext context)
        {
            _context = context; 

        }

        [HttpGet]
        public async Task<ActionResult<List<Client>>> GetClient()
        {
            return Ok(await _context.Clients.ToListAsync());
        }

        [HttpPost]  
        public async Task<ActionResult<List<Client>>> CreateClient(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();

            return Ok(await _context.Clients.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Client>>> UpdateClient(Client client)

        {
            var dbClient = await _context.Clients.FindAsync(client.Id);
            if (dbClient == null)
                return BadRequest("Cliente não encontrado");

            dbClient.FirstName = client.FirstName;
            dbClient.LastName = client.LastName;
            dbClient.PhoneNumber = client.PhoneNumber;
            dbClient.Adress = client.Adress;    
            dbClient.City = client.City;

            await _context.SaveChangesAsync();

            return Ok(await _context.Clients.ToListAsync());       
         
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Client>>> DeleteClient(int id)
        {
            var dbClient = await _context.Clients.FindAsync(id);
            if (dbClient == null)
                return BadRequest("Cliente não encontrado");

            _context.Clients.Remove(dbClient);
            await _context.SaveChangesAsync();

            return Ok(await _context.Clients.ToListAsync());

        }
    }
}
