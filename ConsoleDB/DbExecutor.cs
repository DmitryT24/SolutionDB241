﻿using LibDB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace ConsoleDB
{
    public class DbExecutor
    {
        private MainConnector connector;
        public DbExecutor(MainConnector connector)
        {
            this.connector = connector;
        }
        public DataTable SelectAll(string table)
        {
            var selectcommandtext = "select * from " + table;
            var adapter = new SqlDataAdapter(
              selectcommandtext,
              connector.GetConnection()
            );
            var ds = new DataSet();
            adapter.Fill(ds);
            return ds.Tables[0];
        }
        public SqlDataReader SelectAllCommandReader(string table)
        {
            var command = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = "select * from " + table,
                Connection = connector.GetConnection(),
            };

            SqlDataReader reader = command.ExecuteReader();

            

            if (reader.HasRows)
            {
                return reader;
            }

            return null;
        }
        public int DeleteByColumn(string table, string column, string value)
        {
            var command = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = "delete from " + table + " where " + column + " = '" + value + "';",
                Connection = connector.GetConnection(),
            };

            return command.ExecuteNonQuery();

        }
        public int ExecProcedureAdding(string name, string login)
        {
            var command = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "AddingUserProcTest",
                Connection = connector.GetConnection(),
            };

           command.Parameters.Add(new SqlParameter("@Name", name));
           command.Parameters.Add(new SqlParameter("@Login", login));

            return command.ExecuteNonQuery();

        }
        public int UpdateByColumn(string table, string columntocheck, string valuecheck, string columntoupdate, string valueupdate)
        {
            var command = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = "update   " + table + " set " + columntoupdate + " = '" + valueupdate + "'  where " + columntocheck + " = '" + valuecheck + "';",
                Connection = connector.GetConnection(),
            };

            return command.ExecuteNonQuery();

        }

    }
}
