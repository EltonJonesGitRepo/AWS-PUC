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

        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public DateTime? DataInicioIntervalo { get; set; }
        public DateTime? DataFimIntervalo { get; set; }
        
        /// <summary>
        /// Dado em minutos
        /// </summary>
        public int? AcrescimoEtapaInicial { get; private set; }
        public int? Substituicoes { get; private set; }
        public int? Advertencias { get; private set; }

        /// <summary>
        /// Dado em minutos
        /// </summary>
        public int? AcrescimoEtapaFinal { get; set; }


        public void MarcarGol(bool mandante)
        {
            if (mandante)
            {
                GolsMandante++;
                return;
            }

            GolsVisitante++;
        }

        public void IniciarPartida()
        {
            DataInicio = DateTime.Now;
        }

        public void EncerrarPartida()
        {
            DataFim = DateTime.Now;
        }

        public void IniciarIntervalo()
        {
            DataInicioIntervalo = DateTime.Now;
        }

        public void EncerrarIntervalo()
        {
            DataFimIntervalo = DateTime.Now;
        }

        public void Acrescimo(bool etapaInicial, int minutos)
        {
            if (etapaInicial)
            {
                AcrescimoEtapaInicial = minutos;
                return;
            }

            AcrescimoEtapaFinal = minutos;
        }

        public void IncrementarAdvertencia()
        {
            if (!Advertencias.HasValue)
            {
                Advertencias = 1;
                return;
            }
            Advertencias++;
        }

        public void IncrementarSubstituicoes()
        {
            if (!Substituicoes.HasValue)
            {
                Substituicoes = 1;
                return;
            }
            Substituicoes++;
        }
    }
}
