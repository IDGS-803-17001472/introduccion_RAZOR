using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;



namespace introduccion_RAZOR.Pages
{
    public class EjercicioArreglosModel : PageModel
    {
        private static readonly Random random = new Random();

        public List<int> Numeros { get; private set; }
        public int Suma { get; private set; }
        public double Prom { get; private set; }
        public List<int> NumOrdenados { get; private set; }
        public List<int> Modas { get; private set; }
        public double Mediana { get; private set; }

        public void OnGet()
        {
            Numeros = GenerarNumerosAleatorios(20, 0, 100);
            Suma = Numeros.Sum();
            Prom = Numeros.Average();
            NumOrdenados = Numeros.OrderBy(n => n).ToList();
            Modas = CalcularModas(Numeros);
            Mediana = CalcularMediana(NumOrdenados);
        }

        private List<int> GenerarNumerosAleatorios(int cuenta, int min, int max)
        {
            var numeros = new List<int>();
            for (int i = 0; i < cuenta; i++)
            {
                numeros.Add(random.Next(min, max + 1));
            }
            return numeros;
        }

        private List<int> CalcularModas(List<int> numeros)
        {
            var frecuencia = numeros.GroupBy(n => n)
                                   .ToDictionary(g => g.Key, g => g.Count());
            int frecuenciaMaxima = frecuencia.Values.Max();
            return frecuencia.Where(pair => pair.Value == frecuenciaMaxima)
                            .Select(pair => pair.Key)
                            .ToList();
        }

        private double CalcularMediana(List<int> numerosOrdenados)
        {
            int count = numerosOrdenados.Count;
            if (count % 2 == 0)
            {
                return (numerosOrdenados[count / 2 - 1] + numerosOrdenados[count / 2]) / 2.0;
            }
            else
            {
                return numerosOrdenados[count / 2];
            }
        }
    }
}
