using System.ComponentModel.DataAnnotations;

namespace Blazor30days.Model
{
    public class UserViewModel
    {
        [Required]
        public string Name { get; set; }

        public int Age { get; set; }

        public override string ToString()
        {
            return $"Name: {this.Name}, Age:　{this.Age.ToString()}";
        }
    }
}