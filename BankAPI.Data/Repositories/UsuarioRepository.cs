using BankAPI.Data.Services;
using BankAPI.Model;
using Dapper;
using MySql.Data.MySqlClient;

namespace BankAPI.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private MySQLConfiguration _connectionString;
        public UsuarioRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            var db = dbConnection();

            var sql = @"SELECT * FROM usuarios ";

            return await db.QueryAsync<Usuario>(sql, new { });
        }

        public Task<Usuario?> GetUsuarioById(int id)
        {
            var db = dbConnection();

            var sql = @"SELECT * FROM usuarios WHERE id_usuario = @Id ";

            return db.QueryFirstOrDefaultAsync<Usuario>(sql, new { Id = id });
        }

        public Task<Usuario?> GetUsuarioByDNI(string DNI)
        {
            var db = dbConnection();

            var sql = @"SELECT * FROM usuarios WHERE dni_usuario = @DNI ";

            return db.QueryFirstOrDefaultAsync<Usuario>(sql, new { DNI= DNI });
        }

        public async Task<bool> InsertUsuario(Usuario usuario)
        {
            var db = dbConnection();

            var sql = @"INSERT INTO usuarios (dni_usuario, nombre_usuario, apellido_usuario, contra_usuario) VALUES (@DNI, @Nombre, @Apellido, @Contra) ";

            var result = await db.ExecuteAsync(sql, new { usuario.dni_usuario, usuario.nombre_usuario, usuario.apellido_usuario, usuario.contra_usuario });

            return result > 0;
        }

        public async Task<bool> UpdateUsuario(Usuario usuario)
        {
            var db = dbConnection();

            var sql = @"UPDATE usuarios SET dni_usuario = @DNI, nombre_usuario = @Nombre, apellido_usuario = @Apellido, contra_usuario = @Contra WHERE id_usuario = @Id "; // Corrección aquí

            var result = await db.ExecuteAsync(sql, new { usuario.dni_usuario, usuario.nombre_usuario, usuario.apellido_usuario, usuario.contra_usuario, usuario.id_usuario });

            return result > 0;
        }


        public async Task<bool> DeleteUsuario(Usuario usuario)
        {
            var db = dbConnection();

            var sql = @"DELETE FROM usuarios WHERE id_usuario = @Id ";

            var result = await db.ExecuteAsync(sql, new { usuario.id_usuario });

            return result > 0;
        }
    }
}
