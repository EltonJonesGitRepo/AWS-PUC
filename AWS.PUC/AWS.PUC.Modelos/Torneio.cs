using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AWS.PUC.Modelos
{
    [Table("Torneios")]
    public class Torneio
    {

        //Obrigatorio para EntityFramework
        private Torneio()
        {

        }

        public Torneio(Guid id, string nome, string anoCalendario)
        {
            Id = id;
            Nome = nome;
            AnoCalendario = anoCalendario;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; private set; }

        [Column(TypeName = "VARCHAR(100)")]
        public string Nome { get; private set; }

        [Column(TypeName = "VARCHAR(4)")]
        public string AnoCalendario { get; private set; }


    }
}
