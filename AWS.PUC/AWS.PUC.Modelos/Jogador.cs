using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AWS.PUC.Modelos
{

    [Table("Jogadores")]
    public class Jogador
    {
        //Obrigatorio para EntityFramework
        private Jogador()
        {

        }

        public Jogador(Guid id, string nome, DateTime dataNascimento,string pais,Guid timeId)
        {
            Id = id;
            Nome = nome;
            Pais = pais;
            DataNascimento = dataNascimento;
            TimeId = timeId;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; private set; }

        [Column(TypeName = "VARCHAR(100)")]
        public string Nome { get; private set; }

        [Column(TypeName = "VARCHAR(100)")]
        public string Pais { get; private set; }

        public DateTime DataNascimento { get; set; }

        public Guid TimeId { get; private set; }

        [JsonIgnore]
        public virtual Time Time { get; set; }
    }
}
