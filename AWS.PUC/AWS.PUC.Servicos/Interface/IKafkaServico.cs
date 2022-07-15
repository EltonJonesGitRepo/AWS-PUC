using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS.PUC.Servicos
{
    public interface IKafkaServico
    {
        string Enviar(string mensagem);
    }
}
