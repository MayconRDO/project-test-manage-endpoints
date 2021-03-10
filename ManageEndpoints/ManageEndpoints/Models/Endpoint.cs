using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageEndpoints.Models
{
    /// <summary>
    /// Classe do objeto Endpoint
    /// </summary>
    public class Endpoint
    {
        /// <summary>
        /// Número de série do terminal
        /// </summary>
        public string TerminalSerialNumber { get; set; }

        /// <summary>
        /// Id do modelo do medidor
        /// </summary>
        public int IdMeterModel { get; set; }

        /// <summary>
        /// Número do medidor   
        /// </summary>
        public int MeterNumber { get; set; }

        /// <summary>
        /// Versão do firmware do medidor
        /// </summary>
        public string MeterFirmwareVersion { get; set; }

        /// <summary>
        /// Mudança de estado
        /// </summary>
        public int ChangeState { get; set; }
    }
}
