using CrudMVCPractice.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CrudMVCPractice.Gateway
{
    public class StudentGateway:Base
    {
        public int Save(StudentModel studentModel)
        {
            string query = "INSERT INTO TblStudent(Name,Description) VALUES (@Name,@Description)";
            command = new SqlCommand(query, connection);
          
            command.Parameters.AddWithValue("@Name", studentModel.Name);
            command.Parameters.AddWithValue("@Description", studentModel.Description);

            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();

            return rowAffect;
        }
        public List<StudentModel> GetAllStudent()
        {
            string query = "SELECT * FROM TblStudent";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            List<StudentModel> studentList = new List<StudentModel>();

            while (reader.Read())
            {
                StudentModel student = new StudentModel();
                student.Id = Convert.ToInt32(reader["Id"]);
                student.Name = reader["Name"].ToString();
                student.Description = reader["Description"].ToString();
                studentList.Add(student);
            }
            reader.Close();
            connection.Close();
            return studentList;
        }
        public StudentModel GetStudentById(int id)
        {
            string query = "SELECT * FROM TblStudent where Id=@id";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);
            connection.Open();
            reader = command.ExecuteReader();
            //List<Teacher> teacherList = new List<Teacher>();
            StudentModel department = null;
            if (reader.HasRows)
            {
                reader.Read();
                department = new StudentModel();
                department.Name = reader["Name"].ToString();
                department.Description = reader["Description"].ToString();

            }
            return department;
        }
        public int UpdateStudentById(StudentModel student)
        {
            string query = "Update TblStudent SET Name=@Name,Description=@Description where Id=@id";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", student.Name);
            command.Parameters.AddWithValue("@Description", student.Description);
            command.Parameters.AddWithValue("@id", student.Id);

            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();

            return rowAffect;
        }
        public int DeleteById(int id)
        {
            string query = "Delete from TblStudent where Id=@id";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);

            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();

            return rowAffect;
        }
    }
}