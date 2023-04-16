using Microsoft.AspNetCore.Mvc;
using MyUserAPI.Data;
using MyUserAPI.Models;
using MyUserAPI.models;


namespace MyUserAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MyUserController : Controller
    {
        private readonly MyUserAPIDBContext dbContext;

        public MyUserController(MyUserAPIDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet(Name = "GetUsers")]
        public IActionResult GetMyUsers()
        {
            return Ok(dbContext.Users.ToList());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetMyUser([FromRoute] Guid Id)
        {
            var user = dbContext.Users.Find(Id);
            if (user != null)
            {
                return Ok(user);
            }

            return NotFound();
        }





        [HttpPost]
        public async Task<IActionResult> AddMyUsers(AddMyUser myUser2bAdded)
        {
            var user = new MyUser()
            {
                Id = Guid.NewGuid(),
                Name = myUser2bAdded.Name,
                Email = myUser2bAdded.Email,
                Status = myUser2bAdded.Status
            };
            dbContext.Users.Add(user);
            await dbContext.SaveChangesAsync();

            return Ok(user);
        }


        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateMyUser([FromRoute] Guid Id, MyUser myUser)
        {
            var user = dbContext.Users.Find(Id);
            if (user != null)
            {
                Id = myUser.Id;
                user.Name = myUser.Name;
                user.Status = myUser.Status;
                user.Email = myUser.Email;

                await dbContext.SaveChangesAsync();

                return Ok(user);
            }

            return NotFound();
        }

    }
}