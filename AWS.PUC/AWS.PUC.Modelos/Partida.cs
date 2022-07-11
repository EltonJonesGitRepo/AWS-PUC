using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AWS.PUC.Modelos
{
    [Table("Partidas")]
    public class Partida
    {
        private Partida()
        {
        }

        public Partida(Guid id, string nomeMandante, int golsMandante, string nomeVisitante, int golsVisitante, string localidade)
        {
            Id = id;
            NomeMandante = nomeMandante;
            NomeVisitante = nomeVisitante;
            GolsMandante = golsMandante;
            GolsVisitante = golsVisitante;
            Localidade = localidade;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; private set; }

        [Column(TypeName = "VARCHAR(100)")]
        public string NomeMandante { get; private set; }

        [Column(TypeName = "INT")]
        public int GolsMandante { get; private set; }

        [Column(TypeName = "VARCHAR(100)")]
        public string NomeVisitante { get; private set; }

        [Column(TypeName = "INT")]
        public int GolsVisitante { get; private set; }

        [Column(TypeName = "VARCHAR(100)")]
        public string Localidade { get; private set; }
    }
}
