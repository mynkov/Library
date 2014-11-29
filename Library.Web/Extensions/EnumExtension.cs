using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Library.BusinessLayer.Extensions;
using Library.Common.Extensions;

namespace Library.Web.Extensions
{
    public static class EnumExtension
    {
        public static IList<SelectListItem> ToSelectList(this Enum obj, Type type)
        {
            var underlyingType = Nullable.GetUnderlyingType(type);
            var isNullable = underlyingType != null;

            return isNullable
                       ? ToSelectListWithEmptyItem(obj, underlyingType)
                       : ToSelectListInner(obj, type);
        }

        private static IList<SelectListItem> ToSelectListInner(this Enum obj, Type type)
        {
            return
                Enum.GetValues(type).Cast<Enum>().Select(
                    x => new SelectListItem
                             {
                                 Value = x.ToString(),
                                 Text = x.GetFriendlyName(),
                                 Selected = x.ToString() == obj.ToStr()
                             }).ToList();
        }

        private static IList<SelectListItem> ToSelectListWithEmptyItem(this Enum obj, Type type)
        {
            return new List<SelectListItem> {new SelectListItem {Text = string.Empty}}.
                Union(ToSelectList(obj, type)).ToList();
        }
    }
}
