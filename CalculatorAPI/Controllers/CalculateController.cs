using Core.Interface;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CalculatorAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculateController : ControllerBase
    {        

        private readonly ILogger<CalculateController> _logger;
        private readonly ICalculate _calculate;

        public CalculateController(ILogger<CalculateController> logger,
            ICalculate calculate)
        {
            _logger = logger;
            _calculate = calculate;
        }

       

        [HttpPost("/GetPow")]
        public IActionResult GetPow(double num, int power)
        {
            double result = Math.Pow(num, power);
            if (double.IsNaN(result))
            {
                _logger.LogInformation("Error in Expression");
                return BadRequest("Error in Expression");
            }
            return Ok(result);

        }

        [HttpPost("/GetSqrt")]
        public IActionResult GetSqrt(double num)
        {
            

            double result = Math.Sqrt(num);
            if (double.IsNaN(result))
            {
                _logger.LogInformation("You can't take the square root of a negative value");
                return BadRequest("You can't take the square root of a negative value");
            }
            return Ok(result);
        }

        [HttpPost("/Calc")]
        public IActionResult Calc(SimpleCalcModel simpleCalc)
        {
            var num1 = simpleCalc.num;
            var num2 = simpleCalc.num2;
            var sign = simpleCalc.sign;

            double result = 0;
            switch (sign)
            {
                case '+':
                    result = num1 + num2;
                    break;

                case '-':
                    result = num1 - num2;
                    break;

                case '*':
                    result = num1 * num2;
                    break;

                case '/':
                    if (num2 == 0 || num1 == 0 )
                    {
                        _logger.LogInformation("Can't divide by zero");
                        return BadRequest("Can't divide by zero");
                    }
                    result = num1 / num2;
                    break;
            }


            
            return Ok(result);
        }

        [HttpPost("/EvalCalc")]
        public IActionResult EvalCalc(EvalCalcMOdel evalCalcMOdel)
        {

            EvalCalcViewModel evalCalcViewModel = _calculate.Calculation(evalCalcMOdel.Expression);

            if (evalCalcViewModel.Ecxeption != null)
            {
                _logger.LogInformation(evalCalcViewModel.Ecxeption);
                return BadRequest(evalCalcViewModel.Ecxeption);
            }


            return Ok(evalCalcViewModel.Result);
        }
    }

   
}