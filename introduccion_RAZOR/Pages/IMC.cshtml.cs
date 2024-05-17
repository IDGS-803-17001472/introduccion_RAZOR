using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace introduccion_RAZOR.Pages
{
    public class IMCModel : PageModel
    {
        //Definimos los atributos
        [BindProperty]
        public string peso { get; set; } = "";
        [BindProperty]
        public string altura { get; set; } = "";
        public double imc = 0;
        public void OnGet()
        {
        }
        public void OnPost()
        {
            double pesoN = Convert.ToDouble(peso);
            double alturaN = Convert.ToDouble(altura);
            imc = pesoN / (Math.Pow(alturaN, 2));
            ModelState.Clear();
        }
    }
}
