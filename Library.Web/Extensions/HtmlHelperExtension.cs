using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
namespace Library.Web.Extensions
{
    public static class HtmlHelperExtension
    {
        public static MvcHtmlString TemplateFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            var label = new TagBuilder("div") {InnerHtml = html.LabelFor(expression).ToHtmlString()};
            label.AddCssClass("editor-label");

            var field = new TagBuilder("div")
                            {
                                InnerHtml =
                                    html.EditorFor(expression).ToHtmlString() +
                                    html.ValidationMessageFor(expression).ToHtmlString()
                            };
            field.AddCssClass("editor-label");

            var row = new TagBuilder("div") {InnerHtml = label.ToString() + field};
            return
                new MvcHtmlString(
                    row.ToString());
        }
    }
}