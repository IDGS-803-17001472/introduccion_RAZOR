using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace introduccion_RAZOR.Pages
{
    public class EvaluarExpresionModel : PageModel
    {
        [BindProperty]
        public double a { get; set; }
        [BindProperty]
        public double b { get; set; }
        [BindProperty]
        public double x { get; set; }
        [BindProperty]
        public double y { get; set; }
        [BindProperty]
        public int n { get; set; }

        public double? Resultado { get; private set; }

        public void OnPost()
        {
            Resultado = EvaluarExpresionBinomial(a, b, x, y, n);
        }

        private double EvaluarExpresionBinomial(double a, double b, double x, double y, int n)
        {
            double resultado = 0;
            for (int k = 0; k <= n; k++)
            {
                double CoeficienteBinomial = Factorial(n) / (Factorial(k) * Factorial(n - k));
                resultado += CoeficienteBinomial * Math.Pow(a * x, n - k) * Math.Pow(b * y, k);
            }
            return resultado;
        }

        private double Factorial(int num)
        {
            if (num == 0) return 1;
            double resultado = 1;
            for (int i = 1; i <= num; i++)
            {
                resultado *= i;
            }
            return resultado;
        }
    }
}
