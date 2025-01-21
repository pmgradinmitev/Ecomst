using System.ComponentModel.DataAnnotations;

namespace Ecomst.Enums
{
    public enum Categories
    {
        [Display(Name="Обективи")]
        Lens = 1,
        [Display(Name = "Фотоапарати")]
        Camera = 2,
        [Display(Name = "Дронове11")]
        Drone = 3
    }
}
