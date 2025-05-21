using LMS.Constants;
using Microsoft.Data.SqlClient;
using System.Windows;

namespace LMS.Data;

internal class DatabaseService
{
    private readonly SqlConnection _connection;

    public DatabaseService()
    {
        _connection = new SqlConnection(DatabaseConstants.CONNECTION_STRING);
    }

    public int ExecuteNonQuery(SqlCommand command)
    {
        int affectedRows = 0;

        try
        {
            _connection.Open();

            command.Connection = _connection;

            affectedRows = command.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            MessageBox.Show(
                $"There was an error while loading data from database {e.Message}",
                "Error",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
        }
        finally
        {
            _connection.Close();
        }

        return affectedRows;
    }

    public List<T> ExecuteReader<T>(SqlCommand command, Func<SqlDataReader, List<T>> converter)
    {
        List<T> values = new();

        try
        {
            _connection.Open();

            command.Connection = _connection;
            
            var reader = command.ExecuteReader();

            values = converter(reader);
        }
        catch (Exception e)
        {
            MessageBox.Show(
                $"There was an error while loading data from database {e.Message}",
                "Error",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
        }
        finally
        {
            _connection.Close();
        }

        return values;
    }
}
