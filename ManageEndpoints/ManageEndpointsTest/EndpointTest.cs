using ManageEndpoints.Enums;
using ManageEndpoints.Models;
using ManageEndpoints.Services;
using ManageEndpoints.Services.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ManageEndpointsTest
{
    [TestClass]
    public class EndpointTest
    {
        private readonly IEndpointService _endpointService;

        /// <summary>
        /// Construtor
        /// </summary>
        public EndpointTest()
        {
            _endpointService = new EndpointService();
        }

        /// <summary>
        /// Testar cadastro
        /// </summary>
        [TestMethod]
        public void TestInsert()
        {
            _endpointService.Save(new Endpoint()
            {
                TerminalSerialNumber = "ABC",
                IdMeterModel = (int)EnumMeterModel.NSX1P2W,
                MeterNumber = 1,
                MeterFirmwareVersion = "1.0",
                ChangeState = (int)EnumChangeState.Armed
            });
        }

        /// <summary>
        /// Teste update
        /// </summary>
        [TestMethod]
        public void TestUpdate()
        {
            string terminalSerialNumber = "BB";

            InsertFake();

            var endpoint = _endpointService.Get(terminalSerialNumber);

            endpoint.ChangeState = (int)EnumChangeState.Armed;

            _endpointService.Save(endpoint);
        }

        /// <summary>
        /// Teste delete
        /// </summary>
        [TestMethod]
        public void TestDelete()
        {
            string terminalSerialNumber = "BB";

            InsertFake();

            var endpoint = _endpointService.Get(terminalSerialNumber);

            _endpointService.Delete(endpoint);
        }

        /// <summary>
        /// Testar método de listar todos
        /// </summary>
        [TestMethod]
        public void TestGetAll()
        {
            InsertFake();
           var endpoints = _endpointService.Get();
        }

        #region Cadastro de dados fakes para testar todos os métodos em tempos de execução

        /// <summary>
        /// Cadastro fake para apoiar nos demais testes em tempo de execução
        /// </summary>
        private void InsertFake()
        {
            var endpoint = new Endpoint()
            {
                TerminalSerialNumber = "AA",
                IdMeterModel = (int)EnumMeterModel.NSX1P2W,
                MeterNumber = 1,
                MeterFirmwareVersion = "1.0",
                ChangeState = (int)EnumChangeState.Armed
            };

            _endpointService.Save(endpoint);

            endpoint = new Endpoint()
            {
                TerminalSerialNumber = "BB",
                IdMeterModel = (int)EnumMeterModel.NSX1P3W,
                MeterNumber = 2,
                MeterFirmwareVersion = "2.3",
                ChangeState = (int)EnumChangeState.Disconnected
            };

            _endpointService.Save(endpoint);

            endpoint = new Endpoint()
            {
                TerminalSerialNumber = "CC",
                IdMeterModel = (int)EnumMeterModel.NSX2P3W,
                MeterNumber = 5,
                MeterFirmwareVersion = "1.9",
                ChangeState = (int)EnumChangeState.Connected
            };

            _endpointService.Save(endpoint);
        }

        #endregion

    }
}
