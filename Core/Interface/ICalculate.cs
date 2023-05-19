using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface
{
    public interface ICalculate
    {
        EvalCalcViewModel Calculation(string expression);
    }

    public class SimpleCalcModel
    {
        public double num { get; set; }
        public double num2 { get; set; }
        [RegularExpression(@"[*/+-]",
         ErrorMessage = "Characters are not allowed.")]
        public char sign { get; set; }
    }

    public class EvalCalcMOdel
    {
        [Required]        
        public string Expression { get; set; }
    }

    public class EvalCalcViewModel
    {
        public double Result { get; set; }
        public string? Ecxeption { get; set; }
    }
}
