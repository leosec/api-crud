using api_crud.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_crud.Repository
{

    public interface IClienteRepository
    {
        Cliente Selecionar(int id);
        IEnumerable<Cliente> Listar();
        void Persistir(Cliente cliente);
        void Atualizar(Cliente cliente);
        void Excluir(int id);
    }


    public class ClienteRepository : IClienteRepository
    {
        private IConfiguration _configuracoes;
        private string _conexao { get { return _configuracoes.GetConnectionString("mysqldb"); } }

        public ClienteRepository(IConfiguration config)
        {
            _configuracoes = config;
        }

        public Cliente Selecionar(int id)
        {
            using (var conexao = new MySqlConnection(_conexao))
            {
                return conexao.Query<Cliente>("SELECT Id, Nome, Cpf WHERE Id = @Id", new { Id = id }).FirstOrDefault();
            }
        }

        public IEnumerable<Cliente> Listar()
        {
            using (var conexao = new MySqlConnection(_conexao))
            {
                return conexao.Query<Cliente>("SELECT Id, Nome, Cpf FROM Cliente");
            }
        }

        public void Persistir(Cliente cliente)
        {
            using (var conexao = new MySqlConnection(_conexao))
            {
                conexao.Execute("INSERT INTO Cliente (Nome, Cpf) VALUES (@Nome, @Cpf)", new
                {
                    Nome = cliente.Nome,
                    Cpf = cliente.Cpf
                });
            }
        }

        public void Atualizar(Cliente cliente)
        {
            using (var conexao = new MySqlConnection(_conexao))
            {
                conexao.Execute("UPDATE Cliente SET Nome = @Nome, Cpf = @Cpf WHERE Id = @Id", new
                {
                    Nome = cliente.Nome,
                    Cpf = cliente.Cpf,
                    Id = cliente.Id
                });
            }
        }

        public void Excluir(int id)
        {
            using (var conexao = new MySqlConnection(_conexao))
            {
                conexao.Execute("DELETE FROM Cliente WHERE Id = @Id", new
                {
                    Id = id
                });
            }
        }
    }
}
