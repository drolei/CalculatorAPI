using Core.Interface;
using Microsoft.Extensions.Logging;
using org.mariuszgromada.math.mxparser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CalculateService : ICalculate
    {
        private readonly ILogger<CalculateService> _logger;

        public CalculateService(ILogger<CalculateService> logger) 
        {
            _logger = logger;      
        }

        public EvalCalcViewModel Calculation(string expression)
        {
            bool isCallSuccessful = License.iConfirmNonCommercialUse("Dvar Raii");
            bool isConfirmed = License.checkIfUseTypeConfirmed();
            String message = License.getUseTypeConfirmationMessage();
            double e = 0;

            Expression expressionClass = new Expression(expression);
             e = expressionClass.calculate();

            EvalCalcViewModel evalCalcViewModel = new EvalCalcViewModel
            {
                Result = e
            };

            if (double.IsNaN(e)) {
                _logger.LogInformation("Error in Expression");
                evalCalcViewModel.Ecxeption = "Error in Expression";
                evalCalcViewModel.Result = 0;
            }
            return evalCalcViewModel;
        }
    }
}
