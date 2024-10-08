using System.ComponentModel.DataAnnotations;

namespace MyApi.Hobbys
{
    public class Hobby
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? HobbyName { get; set; }
    }
}
