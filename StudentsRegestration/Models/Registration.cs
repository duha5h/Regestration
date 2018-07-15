using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SQLite;
using System.Data;

namespace StudentsRegestration.Models
{
    public class Registration
    {

        string connection = @" Data Source = C:\Users\dodu_\Downloads\sqlite_maestro_executable\RegisterationSystem; Version = 3; ";

        public string GetData()
        {
            DataTable dt = new DataTable();
            string query = "SELECT S.FirstName, S.LASTNAME, C.COURSENAME FROM STUDENTREGISTERINCOURSE SC, STUDENT S, COURSES C WHERE SC.CourseID = C.CourseID AND SC.StudentID = S.ID ORDER BY S.ID";

            using (SQLiteConnection con = new SQLiteConnection(connection))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    con.Open();

                    SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                    da.Fill(dt);
                    System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                    List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                    Dictionary<string, object> row;
                    foreach (DataRow dr in dt.Rows)
                    {
                        row = new Dictionary<string, object>();
                        foreach (DataColumn col in dt.Columns)
                        {
                            row.Add(col.ColumnName, dr[col]);
                        }
                        rows.Add(row);
                    }
                    return serializer.Serialize(rows);
                }
            }
        }


        public int Register(int CourseID, int StudentID)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connection))
            {
                try
                {
                    conn.Open();

                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        string sql = "INSERT INTO STUDENTREGISTERINCOURSE (CourseID, StudentID) VALUES('" + CourseID + "','" + StudentID + "')";
                        SQLiteCommand command = new SQLiteCommand(sql, conn);
                        command.ExecuteNonQuery();
                    }

                    return 1;
                }
                catch (Exception e)
                {
                    return -1;
                }
            }
        }
    }
}