using System.ComponentModel.DataAnnotations;

namespace IEEEWebsite.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }

        public ICollection<User>? Users { get; set; }
        public ICollection<Task>? Tasks { get; set; }

    }
}
