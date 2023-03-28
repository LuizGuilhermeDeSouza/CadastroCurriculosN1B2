using System;

namespace CadastroCurriculos.Models
{
    public class ErrorViewModel
    {
        public ErrorViewModel(string erro)
        {
            this.Erro = erro;
        }

        public ErrorViewModel()
        {

        }
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
        public string Erro { get; set; }
    }
}
