using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace introduccion_RAZOR.Pages
{
    public class SumaFormularioModel : PageModel
    {
        //Definimos los atributos
        [BindProperty]
        public string num1 { get; set; } = "";
        [BindProperty]
        public string num2 { get; set; } = "";
        public double Suma = 0;
        public void OnGet()
        {
        }
        public void OnPost()
        {
            double numero1 = Convert.ToDouble(num1);
            double numero2 = Convert.ToDouble(num2);
            Suma = numero1 + numero2;
            ModelState.Clear();
        }
}
}
