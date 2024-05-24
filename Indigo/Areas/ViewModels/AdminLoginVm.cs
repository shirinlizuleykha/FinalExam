using System.ComponentModel.DataAnnotations;

namespace Indigo.Areas.ViewModels;

public class AdminLoginVm
{
    [Required]
    [MaxLength(50)]
    public string UserName { get; set; }
    [DataType(DataType.Password)]
    [MinLength(8)]
    public string Pasword { get; set; } 
}
