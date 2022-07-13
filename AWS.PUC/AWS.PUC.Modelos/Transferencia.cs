using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AWS.PUC.Modelos
{
    [Table("Transferencias")]
    public class Transferencia
    {
        //Obrigatorio para EntityFramework
        private Transferencia()
        {

        }

        public Transferencia(Guid id, Guid jogadorId, Guid idTimeOrigem, Guid idTimeDestino, decimal valor, DateTime data)
        {
            Id = id;
            IdTimeOrigem = idTimeOrigem;
            IdTimeDestino = idTimeDestino;
            Valor = valor;
            Data = data;
            JogadorId = jogadorId;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; private set; }

        [Required]
        public Guid JogadorId { get; private set; }

        [Required]
        public Guid IdTimeOrigem { get; private set; }

        [Required]
        public Guid IdTimeDestino { get; private set; }

        [Required]
        public decimal Valor { get; private set; }

        [Required]
        public DateTime Data { get; private set; }
    }
}
