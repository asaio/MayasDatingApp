using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] //rota para usar esses controllers da API
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet] //endpoints modificam o comportamento da API com métodos específicos
        //public async ActionResult<IEnumerable<AppUser>> GetUsers()
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers() //faz uma Task Assíncrona que espera uma ActionResult com uma coleção IEnumerable do tipo AppUser
        {
            //return _context.Users.ToList();
            return await _context.Users.ToListAsync();
        }

        [HttpGet("{id}")] //o endpoint api/users agora recebe um parâmetro para retornar o AppUser de ID = id: api/users/1 retorna user com ID=1;
        //public ActionResult<AppUser> GetUser(int id)
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            //return _context.Users.Find(id);
            return await _context.Users.FindAsync(id); //find por PK
        }
    }
}