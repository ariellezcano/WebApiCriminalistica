using System.ComponentModel.DataAnnotations;

namespace WebApiCriminalistica.Models.component
{
    public class authApi
    {
        [Required]
        public int usuarioRepo { get; set; }
    }
}
