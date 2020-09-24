using System.ComponentModel.DataAnnotations;

namespace Blazor30days.Model
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "姓名欄位為必填！")]
        public string Name { get; set; }

        public int Age { get; set; }

        public override string ToString()
        {
            return $"Name: {this.Name}, Age:　{this.Age.ToString()}";
        }
    }
}