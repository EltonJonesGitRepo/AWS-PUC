using System;

namespace AWS.PUC.DTO
{
    public class TorneioPartidaInputDTO
    {
        public Guid Id { get; set; }
        public Guid TorneioId { get; set; }
        public Guid PartidaId { get; set; }
    }
}
