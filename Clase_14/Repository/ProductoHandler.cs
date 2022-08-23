using Clase_14.Modelo;
using System.Data;
using System.Data.SqlClient;

namespace Clase_14.Repository
{
    public class ProductoHandler
    {
        public const string ConnectionString = "Server=DESKTOP-JU65CF5;Database=SistemaGestion;Trusted_Connection=true";

        public static bool CrearProducto(Producto producto)
        {
            bool resultado = false;
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryInsert = "Insert Into Producto (Descripciones, Costo, PrecioVenta, Stock, IdUsuario)" +
                    "Values (@descripcionesParameter, @costoParameter, @precioventaParameter, @stockParameter, @idUsuarioParameter)";

                SqlParameter descripcionesParameter = new SqlParameter("descripcionesParameter", SqlDbType.VarChar) { Value = producto.Descripciones };
                SqlParameter costoParameter = new SqlParameter("costoParameter", SqlDbType.VarChar) { Value = producto.Costo };
                SqlParameter precioventaParameter = new SqlParameter("precioventaParameter", SqlDbType.VarChar) { Value = producto.PrecioVenta };
                SqlParameter stockParameter = new SqlParameter("stockParameter", SqlDbType.VarChar) { Value = producto.Stock };
                SqlParameter idUsuarioParameter = new SqlParameter("idUsuarioParameter", SqlDbType.VarChar) { Value = producto.IdUsuario};

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
                {
                    sqlCommand.Parameters.Add(descripcionesParameter);
                    sqlCommand.Parameters.Add(costoParameter);
                    sqlCommand.Parameters.Add(precioventaParameter);
                    sqlCommand.Parameters.Add(stockParameter);
                    sqlCommand.Parameters.Add(idUsuarioParameter);

                    int numberOfRows = sqlCommand.ExecuteNonQuery();

                    if(numberOfRows > 0)
                    {
                        resultado = true;
                    }

                }
                sqlConnection.Close();
            }
            return resultado;
        }

        public static bool ModificarProducto(Producto producto)
        {
            bool resultado = false;
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryUpdate = "Update Producto Set Descripciones = @descripciones Where Id = @id";

                SqlParameter descripcionesParameter = new SqlParameter("descripciones", SqlDbType.VarChar) { Value = producto.Descripciones };
                SqlParameter idParameter = new SqlParameter("id", SqlDbType.BigInt) { Value = producto.Id };

                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(queryUpdate, sqlConnection))
                {
                    sqlCommand.Parameters.Add(descripcionesParameter);
                    sqlCommand.Parameters.Add(idParameter);

                    int numberOfRows = sqlCommand.ExecuteNonQuery();

                    if (numberOfRows > 0)
                    {
                        resultado = true;
                    }
                }
                sqlConnection.Close();
            }
            return resultado;
        }

        public static bool EliminarProducto(Producto producto)
        {
            bool resultado = false;
            using(SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryDelete = "Delete From Producto Where Id = @id";

                SqlParameter idParameter = new SqlParameter("id", SqlDbType.BigInt) { Value = producto.Id};

                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(queryDelete, sqlConnection))
                {
                    sqlCommand.Parameters.Add(idParameter);

                    int numberOfRows = sqlCommand.ExecuteNonQuery();

                    if(numberOfRows > 0)
                    {
                        resultado = true;
                    }
                }
                sqlConnection.Close();
            }
            return resultado;
        }
    }
}
