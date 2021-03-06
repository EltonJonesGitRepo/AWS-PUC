using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AWS.PUC.Modelos
{

    [Table("Times")]
    public class Time
    {
        //Obrigatorio para EntityFramework
        private Time()
        {

        }

        public Time(Guid id, string nome, string localidade)
        {
            Id = id;
            Nome = nome;
            Localidade = localidade;            
        }

        public void IncluirJogador(Jogador jogador)
        {
            Jogadores.Add(jogador);
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; private set; }

        [Column(TypeName = "VARCHAR(100)")]
        public string Nome { get; private set; }

        [Column(TypeName = "VARCHAR(100)")]
        public string Localidade { get; private set; }

        public virtual List<Jogador> Jogadores { get; set; } = new List<Jogador>();
    }
}
