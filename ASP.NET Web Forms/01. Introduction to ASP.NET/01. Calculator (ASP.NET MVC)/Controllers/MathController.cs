namespace CalculatorMvc.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    public class MathController : Controller
    {
        public ActionResult Index(double? firstNumber, double? secondNumber)
        {
            if (firstNumber.HasValue && secondNumber.HasValue)
            {
                double result = firstNumber.Value + secondNumber.Value;

                this.ViewBag.firstNumber = firstNumber.ToString();
                this.ViewBag.secondNumber = secondNumber.ToString();
                this.ViewBag.Sum = result.ToString();

                return this.View();
            }

            this.ViewBag.Sum = this.ViewBag.firstNumber = this.ViewBag.secondNumber = 0;
            return this.View();  
        }
    }
}