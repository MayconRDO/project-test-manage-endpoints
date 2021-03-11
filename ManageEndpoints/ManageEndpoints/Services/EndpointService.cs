﻿using ManageEndpoints.Models;
using ManageEndpoints.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;

namespace ManageEndpoints.Services
{
    /// <summary>
    /// Classe de serviço do Endpoint
    /// </summary>
    public class EndpointService : IEndpointService
    {
        /// <summary>
        /// Obter todos os Endpoints cadastrados
        /// </summary>
        /// <param name="endpoints">Lista de enpoints</param>
        public List<Endpoint> Get()
        {
            List<Endpoint> endpoints = new List<Endpoint>();
            foreach (var item in MemoryCache.Default)
            {
                endpoints.Add((Endpoint)item.Value);
            }
            return endpoints;
        }

        /// <summary>
        /// Obter endpoint por número de série
        /// </summary>
        /// <param name="terminalSerialNumber">Número de série</param>
        /// <returns>Objeto Endpoint</returns>
        public Endpoint Get(string terminalSerialNumber)
        {
            var obj = MemoryCache.Default.Where(x => x.Key == terminalSerialNumber).FirstOrDefault();
            var endpoint = (Endpoint)obj.Value;
            return endpoint;
        }

        /// <summary>
        /// Cadastrar/Alterar o objeto Endpoint na memória
        /// </summary>
        /// <param name="endpoint">Endpoint</param>
        public void Save(Endpoint endpoint)
        {
            ObjectCache cache = MemoryCache.Default;
            CacheItemPolicy policy = new CacheItemPolicy();
            cache.Set(endpoint.TerminalSerialNumber, endpoint, policy);
        }

        /// <summary>
        /// Excluir objeto Endpoint da memória
        /// </summary>
        /// <param name="endpoint"></param>
        public void Delete(Endpoint endpoint)
        {
            ObjectCache cache = MemoryCache.Default;
            cache.Remove(endpoint.TerminalSerialNumber);
        }
    }
}
