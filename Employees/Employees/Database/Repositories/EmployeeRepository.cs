using Npgsql;
using Pustok.Database.DomainModels;
using Pustok.ViewModels;
using System;
using System.Collections.Generic;

namespace Pustok.Database.Repositories;

public class EmployeeRepository : IDisposable
{
    private readonly NpgsqlConnection _npgsqlConnection;

    public EmployeeRepository()
    {
        _npgsqlConnection = new NpgsqlConnection(DatabaseConstants.CONNECTION_STRING);
        _npgsqlConnection.Open();
    }

    public List<Employee> GetAll()
    {
        var selectQuery = "SELECT * FROM employee ORDER BY name";

        using NpgsqlCommand command = new NpgsqlCommand(selectQuery, _npgsqlConnection);
        using NpgsqlDataReader dataReader = command.ExecuteReader();

        List<Employee> employees = new List<Employee>();

        while (dataReader.Read())
        {
            Employee employee = new Employee
            {
                Id = Convert.ToInt32(dataReader["id"]),
                Name = Convert.ToString(dataReader["name"]),
                Surname = Convert.ToString(dataReader["surname"]),
                FatherName = Convert.ToString(dataReader["fathername"]),
                Pin = Convert.ToString(dataReader["pin"]),


            };

            employees.Add(employee);
        }

        return employees;
    }

 

    public Employee GetById(int id)
    {
        using NpgsqlCommand command = new NpgsqlCommand($"SELECT * FROM employee WHERE id={id}", _npgsqlConnection);
        using NpgsqlDataReader dataReader = command.ExecuteReader();

        Employee employee = null;

        while (dataReader.Read())
        {
            employee = new Employee
            {
                Id = Convert.ToInt32(dataReader["id"]),
                Name = Convert.ToString(dataReader["name"]),
               
            };
        }

        return employee;
    }


    public void Insert(Employee employee)
    {
        string updateQuery =
            "INSERT INTO employee(name, price, rating, categoryid)" +
            $"VALUES ('{employee.Name}', {employee.Surname}, {employee.FatherName}, {employee.FinCode})";

        using NpgsqlCommand command = new NpgsqlCommand(updateQuery, _npgsqlConnection);
        command.ExecuteNonQuery();
    }

    public void Update(Employee employee)
    {
        var query =
                $"UPDATE employee " +
                $"SET name='{employee.Name}'," +
                $"WHERE id={employee.Id}";

        using NpgsqlCommand updateCommand = new NpgsqlCommand(query, _npgsqlConnection);
        updateCommand.ExecuteNonQuery();
    }

    public void RemoveById(int id)
    {
        var query = $"DELETE FROM employee WHERE id={id}";

        using NpgsqlCommand updateCommand = new NpgsqlCommand(query, _npgsqlConnection);
        updateCommand.ExecuteNonQuery();
    }

    public void Dispose()
    {
        _npgsqlConnection.Dispose();
    }
}
