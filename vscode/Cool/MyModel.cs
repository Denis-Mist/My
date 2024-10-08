using System.ComponentModel.DataAnnotations;

namespace MyApi.Models
{
    public class MyModel
    {
        public int Id { get; set; } // Добавим первичный ключ
        [Required]
        public string? Name { get; set; }
    }
}
