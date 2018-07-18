using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SQLite;
using System.Data;

namespace StudentsRegestration.Models
{
    public class Student
    {

        public static int StudentID { get; set; }

        string connection = @" Data Source = C:\Users\dodu_\Downloads\sqlite_maestro_executable\RegisterationSystem; Version = 3; ";

        public string GetData()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM student";

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

        public string GetStudentData(int studentID)
        {
            DataTable dt = new DataTable();

            string query = "SELECT S.FirstName, S.LASTNAME, C.COURSENAME, S.ID " +
                           "FROM STUDENTREGISTERINCOURSE SC, STUDENT S, COURSES C " +
                           "WHERE SC.CourseID = C.CourseID AND SC.StudentID = S.ID AND SC.StudentID = " + studentID;

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
    }
}