using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcWebApi.Controllers
{
    public class StudentAPIController : ApiController
    {
        /// <summary>
        /// "db"= create a object schoolEntities model
        /// </summary>
        private schoolEntities db = new schoolEntities();

       
        /// <summary>
        /// Get StudentAPI API
        /// Retrive all students details
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Student> GETStudents()
        {
           
            return db.Students.AsEnumerable();
        }

       //  GET api/StudentsAPI/5  
        /// <summary>
        /// Get a student against id 
        /// </summary>
        /// <param name="id">contained a filed of id</param>
        /// <returns></returns>
        public Student GETStudent(int id)
        {

            Student student = db.Students.Find(id);
            if(student==null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));  
            }
            return student;
        }

       /// <summary>
       /// edit the student details against id
       /// </summary>
        /// <param name="id">contained a filed of id</param>
        /// <param name="student">contained a filed of students model</param>
       /// <returns></returns>
        public HttpResponseMessage PutStudent(int id, Student student)
        {
            if (ModelState.IsValid && id == student.studentID)
            {
                db.Entry(student).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
                }

                catch (DbUpdateConcurrencyException)

                {
                    return Request.CreateResponse(HttpStatusCode.NotFound); 
 
                }  
  
                return Request.CreateResponse(HttpStatusCode.OK);  
               }  
            
            else  

            {  
                return Request.CreateResponse(HttpStatusCode.BadRequest);  
            }  
                               
            }

       /// <summary>
       /// save the student details 
       /// </summary>
        /// <param name="student">contained a filed of students model</param>
       /// <returns></returns>
        public HttpResponseMessage PostStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, student);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = student.studentID }));
                return response;  
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }  
        }


        /// <summary>
        /// delete the student detail against id 
        /// </summary>
        /// <param name="id">contained a filed of id</param>
        /// <returns></returns>
        public HttpResponseMessage DeleteStudent(int id)
        {
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Students.Remove(student);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, student);
        }
        /// <summary>
        /// dispose the variables
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        } 

        }

    }

