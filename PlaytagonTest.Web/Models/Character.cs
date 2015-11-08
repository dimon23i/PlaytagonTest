using System.ComponentModel.DataAnnotations;

namespace PlaytagonTest.Web.Models
{
    public class Character
    {
        public virtual int Id { get; set; }

        [Required(ErrorMessage = "The name is required")]
        public virtual string Name { get; set; }

        [Range(1, 100, ErrorMessage = "Enter the valid number.")]
        public virtual int Health { get; set; }

        [Range(1, 100, ErrorMessage = "Enter the valid number.")]
        public virtual int Mana { get; set; }

        [Range(1, 100, ErrorMessage = "Enter the valid number.")]
        public virtual int Level { get; set; }

        [Range(1, 100, ErrorMessage = "Enter the valid number.")]
        public virtual int Gold { get; set; }

        public virtual bool IsImmortal { get; set; }
    }
}