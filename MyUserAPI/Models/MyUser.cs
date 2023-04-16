using MyUserAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyUserAPI.models
{
    public class MyUser
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Status { get; set; }
    }
}
