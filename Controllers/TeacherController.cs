using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CumulativeProjectJigarmehta.Models;

namespace CumulativeProjectJigarmehta.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// This function returns list teachers
        /// </summary>
        /// <param name="SearchKey"></param>
        /// <returns>list of Teachers</returns>
        //GET : /Teachers/List
        public ActionResult List(string SearchKey = null)
        {

            TeachersController controller = new TeachersController();
            IEnumerable<Teacher> Teachers = controller.ListTeachers(SearchKey);
            return View(Teachers);
        }


        /// <summary>
        /// rThis function returns multiple details of teachers.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>details of NewTeacher</returns>
        //GET: /Teacher/Show/{id}

        public ActionResult Show(int id)
        {
            TeachersController controller = new TeachersController();
            Teacher SelectedTeacher = controller.FindTeacher(id);
            return View(SelectedTeacher);
        }

        //GET: /Teacher/DeleteConfirm/{id}
        public ActionResult DeleteConfirm(int id)
        {
            TeachersController controller = new TeachersController();
            Teacher NewTeacher = controller.FindTeacher(id);


            return View(NewTeacher);
        }

        //POST : /Teacher/Delete/{id}
        [HttpPost]
        public ActionResult Delete(int id)
        {
            TeachersController controller = new TeachersController();
            controller.DeleteTeacher(id);
            return RedirectToAction("List");
        }

        //GET: /Teacher/New

        public ActionResult New()
        {

            return View();
        }

        //POST : /Teacher/Create
        public ActionResult Create(string TeacherFname, string TeacherLname, string EmployeeNumber, decimal Salary)
        {

            Debug.WriteLine("This works fine");
            Debug.WriteLine(TeacherFname);
            Debug.WriteLine(TeacherLname);
            Debug.WriteLine(EmployeeNumber);
            Debug.WriteLine(Salary);

            Teacher NewTeacher = new Teacher();
            NewTeacher.TeacherFname = TeacherFname;
            NewTeacher.TeacherLname = TeacherLname;
            NewTeacher.EmployeeNumber = EmployeeNumber;
            NewTeacher.Salary = Salary;

            TeachersController Controller = new TeachersController();
            Controller.AddTeacher(NewTeacher);
            return RedirectToAction("List");
        }


        //GET : /teacher/Update/{id}
        /// <summary>
        /// This a GET request for updation.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Update(int id)
        {

            TeachersController controller = new TeachersController();
            Teacher SelectedTeacher = controller.FindTeacher(id);


            return View(SelectedTeacher);
        }

        //POST : /Teacher/Update/10
        /// <summary>
        /// This is a POST request for updation
        /// </summary>
        /// <param name="id"></param>
        /// <param name="TeacherFname"></param>
        /// <param name="TeacherLname"></param>
        /// <param name="EmployeeNumber"></param>
        /// <param name="Salary"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Update(int id, string TeacherFname, string TeacherLname, string EmployeeNumber, decimal Salary)
        {
            Teacher TeacherInfo = new Teacher();
            TeacherInfo.TeacherFname = TeacherFname;
            TeacherInfo.TeacherLname = TeacherLname;
            TeacherInfo.EmployeeNumber = EmployeeNumber;
            TeacherInfo.Salary = Salary;

            TeachersController Controller = new TeachersController();
            Controller.UpdateTeacher(id, TeacherInfo);


            return RedirectToAction("Show/" + id);
        }
    }
}