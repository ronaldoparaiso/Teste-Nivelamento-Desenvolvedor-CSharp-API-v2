using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Questao5.Infrastructure.Models;
using Questao5.Infrastructure.Sqlite;
using System.Collections.Generic;

namespace Questao5.Infrastructure.Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovimentacaoContaController : ControllerBase 
    {
        private readonly DatabaseConfig databaseConfig;

        public MovimentacaoContaController(DatabaseConfig databaseConfig)
        {
            this.databaseConfig = databaseConfig;
        }

        [HttpGet(Name = "GetMovimentacaoConta")]
        public IEnumerable<ContaCorrente> Get()
        {
           
                using (var conexao = new SqliteConnection(databaseConfig.Name))
                {
                    string query = "SELECT * FROM NomeDaTabela";
                   return IEnumerable<ContaCorrente> contaCorrente = conexao.Query<ContaCorrente>(query);
            }           
        }
    }
}