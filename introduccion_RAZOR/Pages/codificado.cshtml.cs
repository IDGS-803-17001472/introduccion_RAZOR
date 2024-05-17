using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Text;

namespace introduccion_RAZOR.Pages
{
    public class codificadoModel : PageModel
    {
        public string OriginalMessage { get; set; } = "";
        public string EncryptedMessage { get; set; } = "";
        public string DecryptedMessage { get; set; } = "";

        public void OnGet()
        {

        }

        public void OnPostEncrypt(string originalMessage, int n)
        {
            EncryptedMessage = Encrypt(originalMessage, n);
        }

        public void OnPostDecrypt(string encryptedMessage, int n)
        {
            DecryptedMessage = Decrypt(encryptedMessage, n);
        }

        private string Encrypt(string message, int n)
        {
            StringBuilder encrypted = new StringBuilder();

            foreach (char c in message.ToUpper())
            {
                if (char.IsLetter(c))
                {
                    int x = (int)c - 'A';
                    int newPosition = (x + n) % 26;
                    encrypted.Append((char)('A' + newPosition));
                }
                else
                {
                    encrypted.Append(c);
                }
            }

            return encrypted.ToString();
        }

        private string Decrypt(string encryptedMessage, int n)
        {
            StringBuilder decrypted = new StringBuilder();

            foreach (char c in encryptedMessage.ToUpper())
            {
                if (char.IsLetter(c))
                {
                    int x = (int)c - 'A';
                    int newPosition = (x - n + 26) % 26;
                    decrypted.Append((char)('A' + newPosition));
                }
                else
                {
                    decrypted.Append(c);
                }
            }

            return decrypted.ToString();
        }
    }
}