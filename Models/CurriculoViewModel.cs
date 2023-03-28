using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroCurriculos.Models
{
    public class CurriculoViewModel
    {
        public int Curriculo_id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
        public double Pretencao_salarial { get; set; }
        public string Cargo_pretendido { get; set; }
        public string Formacao_academica_1 { get; set; }
        public string Formacao_academica_2 { get; set; }
        public string Formacao_academica_3 { get; set; }
        public string Formacao_academica_4 { get; set; }
        public string Formacao_academica_5 { get; set; }
        public string Experiencia_profissional_1 { get; set; }
        public string Experiencia_profissional_2 { get; set; }
        public string Experiencia_profissional_3 { get; set; }
        public string Nivel_ingles { get; set; }
        public string Nivel_espanhol { get; set; }
    }
}
