namespace EasyPTC.Web.Infrastructure.Helpers
{
    using HtmlTags;
    using Microsoft.Web.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;

    public static class HtmlExtensions
    {
        public static MvcHtmlString Submit(this HtmlHelper helper, object htmlAttributes = null)
        {
            var input = new TagBuilder("input");
            var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes) as IDictionary<string, object>;
            input.MergeAttributes(attributes);
            input.Attributes.Add("type", "submit");
            return new MvcHtmlString(input.ToString());
        }

        public static HtmlTag ActionLink<TController>(this HtmlHelper helper, Expression<Action<TController>> action, string linkText) where TController : Controller
        {
            var actionBody = (MethodCallExpression)action.Body;
            var methodName = actionBody.Method.Name;

            var controllerName = typeof(TController).Name;
            controllerName = controllerName.Substring(0, controllerName.Length - "Controller".Length);

            return new HtmlTag("a")
                .Attr("href", "/" + controllerName + "/" + methodName)
                .AddClass("btn btn-default")
                .Text(linkText);
        }
    }
}