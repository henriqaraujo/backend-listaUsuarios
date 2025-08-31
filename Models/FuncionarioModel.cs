using System;
using System.ComponentModel.DataAnnotations;
using web_api_lista_funcionarios.Enuns;

namespace web_api_lista_funcionarios.Models {
    public class FuncionarioModel {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DepartamentoEnum Departamento { get; set; }    
        public int Ativo { get; set; } 
        public TurnoEnum Turno{ get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now.ToLocalTime();
        public DateTime DataAlteracao { get; set; } = DateTime.Now.ToLocalTime();
    }
}
