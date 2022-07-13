using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AWS.PUC.Modelos
{
    [Table("TorneiosPartidas")]
    public class TorneioPartida
    {
        private TorneioPartida()
        {

        }

        public TorneioPartida(Guid id, Guid torneioId, Guid partidaId)
        {
            Id = id;
            TorneioId = torneioId;
            PartidaId = partidaId;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid TorneioId { get; set; }
        
        [Required]
        public Guid PartidaId { get; set; }

        public void SetPartidaId(Guid partidaId)
        {
            PartidaId = partidaId;
        }
    }
}
