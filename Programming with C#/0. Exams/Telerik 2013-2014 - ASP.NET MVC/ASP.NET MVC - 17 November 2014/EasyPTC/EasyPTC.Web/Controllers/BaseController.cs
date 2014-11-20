namespace EasyPTC.Web.Controllers
{
    using System.Web.Mvc;

    using EasyPTC.Web.ViewModels;
    using System.Data.Entity;
    using EasyPTC.Models;
    using EasyPTC.Data;
using System.Linq.Expressions;
using System;

    public abstract class BaseController : Controller
    {
        public BaseController(IEasyPtcData data)
        {
            this.Data = data;
        }

        protected IEasyPtcData Data { get; set; }

        protected User CurrentUser { get; set; }

        protected ActionResult RedirectToAction<TController>(Expression<Action<TController>> action) where TController : Controller
        {
            var actionBody = (MethodCallExpression)action.Body;
            var methodName = actionBody.Method.Name;

            var controllerName = typeof(TController).Name;
            controllerName = controllerName.Substring(0, controllerName.Length - "Controller".Length);

            return RedirectToAction(methodName, controllerName);
        }
    }
}