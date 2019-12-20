using CrudMVCPractice.Gateway;
using CrudMVCPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudMVCPractice.Manager
{
    public class StudentManager
    {
        StudentGateway studentGateway = new StudentGateway();
       
        public string Save(StudentModel studentModel)
        {
            if(studentGateway.Save(studentModel)>0)
            {
                return "Save succeful";
            }
            else
            {
                return "Save failed";
            }
        }
        public List<StudentModel> GetAllStudent()
        {
            return studentGateway.GetAllStudent();
        }
        public StudentModel GetStudentById(int id)
        {
            return studentGateway.GetStudentById(id);
        }
        public int UpdateStudentById(StudentModel student)
        {
            return studentGateway.UpdateStudentById(student);
        }
        public string DeleteById(int id)
        {
            if (studentGateway.DeleteById(id)>0)
            {
                return "Delete Successful";
            }
            else
            {
                return "Delete Failed";
            }
        }
    }
}