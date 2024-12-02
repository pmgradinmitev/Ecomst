using Ecomst.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ecomst.Areas.Admin.ViewModels.Category
{
    public class CategoryViewModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Полето \"Име\" е задължително!")]
        [DisplayName("Име")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Полето \"Ред на показване\" е задължително!")]
        [DisplayName("Ред на показване")]
        public int DisplayOrder { get; set; }

        public void PopulateCategory(Entities.Category categoty)
        {
            categoty.Name = Name;
            categoty.DisplayOrder = DisplayOrder;
        }

        public void PopulateFromCategory(Entities.Category? category)
        {
            if (category == null)
                return;

            Id = category.Id;
            Name = category.Name;
            DisplayOrder = category.DisplayOrder;
        }
    }
}
