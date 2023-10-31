using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ex1
{
    public class User
    {
        [EmailAddress(ErrorMessage ="your email not correct")]
        public string Email { get; set; }

        [MinLength(3,ErrorMessage ="incorrect first name")]
        public string FirstName { get; set; }

        [MinLength(3, ErrorMessage = "incorrect last name")]
        public string LastName { get; set; }
        
        public string Password { get; set; }
        public int Id { get; set; }

    }
}
