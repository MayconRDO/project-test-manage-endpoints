using ManageEndpoints.Models;
using System.Collections.Generic;

namespace ManageEndpoints.Services.Interfaces
{
    /// <summary>
    /// Interface do serviço de EndPoint
    /// </summary>
    public interface IEndpointService
    {
        /// <summary>
        /// Obter todos os Endpoints cadastrados
        /// </summary>
        /// <param name="endpoints">Lista de enpoints</param>
        List<Endpoint> Get();

        /// <summary>
        /// Cadastrar o endpoint em memória
        /// </summary>
        /// <param name="endpoint"></param>
        void Insert(Endpoint endpoint);

        /// <summary>
        /// Obter endpoint por número de série
        /// </summary>
        /// <param name="terminalSerialNumber">Número de série</param>
        /// <returns>Objeto Endpoint</returns>
        Endpoint Get(string terminalSerialNumber);
    }
}
