using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ecomst.ViewModels.Product
{
    public class ProductViewModel
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "Полето \"Категория\" е задължително!")]
        [DisplayName("Категория")]
        public int CategoryId {  get; set; }
        [Required(ErrorMessage = "Полето \"Номер на продукта\" е задължително!")]
        [DisplayName("Номер на продукта")]
        public string CodeNumber { get; set; }
        [Required(ErrorMessage = "Полето \"Заглавие\" е задължително!")]
        [DisplayName("Заглавие")]
        public string Title {  get; set; }
        [Required(ErrorMessage = "Полето \"Описание\" е задължително!")]
        [DisplayName("Описание")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Полето \"Цена\" е задължително!")]
        [DisplayName("Цена")]
        public decimal Price {  get; set; }
        [Required(ErrorMessage = "Полето \"В наличност\" е задължително!")]
        [DisplayName("Номер на продукта")]
        public bool InStock {  get; set; }
        [DisplayName("Номер на продукта")]
        public string ThumbnailImagePath { get; set; }

        public IEnumerable<SelectListItem> CategoryList { get; set; }
    }
}
