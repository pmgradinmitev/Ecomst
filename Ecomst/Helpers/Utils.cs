using Ecomst.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection.Metadata.Ecma335;

namespace Ecomst.Helpers
{
    public class Utils
    {
       public static IEnumerable<SelectListItem> ListToSelectListItem<T>(List<T> data, string propertyForText, string propertyForValue)
       {
            IEnumerable<SelectListItem> itemList = data.ConvertAll(a =>
            {
                return new SelectListItem()
                {
                    Text = a.GetType().GetProperty(propertyForText).GetValue(a, null).ToString(),
                    Value = a.GetType().GetProperty(propertyForValue).GetValue(a, null).ToString(),
                };
            });
            return itemList;
       }
    }
}
