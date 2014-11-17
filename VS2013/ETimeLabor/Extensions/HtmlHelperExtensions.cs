using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Helpers;
using System.Web.Mvc.Html;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ETimeLabor.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static IHtmlString EnumDropDownListFor<TModel, TEnum>(this HtmlHelper<TModel> html, Expression<Func<TModel, TEnum>> expression)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);

            var enumType = Nullable.GetUnderlyingType(metadata.ModelType) ?? metadata.ModelType;


            var enumValues = Enum.GetValues(enumType).Cast<object>();

            var items = from enumValue in enumValues
                        select new SelectListItem
                        {
                            Text = GetText(enumValue),
                            Value = (enumValue).ToString(),
                            Selected = enumValue.Equals(metadata.Model)
                        };


            return html.DropDownListFor(expression, items, string.Empty, null);
        }

        private static String GetText(Object e)
        {
            FieldInfo fieldInfo = e.GetType().GetField(e.ToString());
            DisplayAttribute[] displayAttributes = fieldInfo.GetCustomAttributes(typeof(DisplayAttribute), false) as DisplayAttribute[];
            return null != displayAttributes && displayAttributes.Length > 0 ? displayAttributes[0].Name : e.ToString();
        }
    }
}
