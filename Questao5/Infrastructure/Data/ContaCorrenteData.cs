using Dapper;
using Microsoft.Data.Sqlite;
using Questao5.Infrastructure.Models;
using Questao5.Infrastructure.Sqlite;

namespace Questao5.Infrastructure.Data
{
    public class ContaCorrenteData
    {
        private readonly DatabaseConfig databaseConfig;

        public ContaCorrenteData(DatabaseConfig databaseConfig)
        {
            this.databaseConfig = databaseConfig;
        }

        public void Setup()
        {
            using var connection = new SqliteConnection(databaseConfig.Name);

            var table = connection.Query<ContaCorrente>("SELECT * FROM contacorrente;");
            var tableName = table.FirstOrDefault();                  

           
        }
    }
}
