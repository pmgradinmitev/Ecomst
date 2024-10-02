using Ecomst.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ecomst.ViewModels.Category
{
    public class CategoryViewModel
    {
        public int? Id { get; set; }

        [Required]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Category Order")]
        public int DisplayOrder {  get; set; }

        public void PopulateCategory(Ecomst.Entities.Category categoty)
        {
            if (Id != null && Id != 0)
                categoty.Id = (int)Id;

            categoty.Name = Name;
            categoty.DisplayOrder = DisplayOrder;
        }

        public void PopulateFromCategory(Ecomst.Entities.Category? category)
        {
            if (category == null)
                return;

            Id = category.Id;
            Name = category.Name;
            DisplayOrder = category.DisplayOrder;
        }
    }
}
