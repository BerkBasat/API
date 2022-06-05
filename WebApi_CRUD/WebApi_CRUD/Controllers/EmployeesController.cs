using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi_CRUD.Models;
using WebApi_CRUD.Models.DTO;

namespace WebApi_CRUD.Controllers
{
    public class EmployeesController : ApiController
    {
        NORTHWNDEntities db = new NORTHWNDEntities();

        public IHttpActionResult GetEmployees()
        {
            
            return Json(EmployeeList());
        }


        [HttpPost]
        public IHttpActionResult AddEmployee(Employee employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }
            else
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return Json(employee);
            }
        }

        //todo: Update System.Reflection.TargetException hatası veriyor!
        [HttpPut]
        public IHttpActionResult UpdateEmployee (Employee employee)
        {
            Employee updated = db.Employees.FirstOrDefault(x => x.EmployeeID == employee.EmployeeID);
            if (updated == null)
            {
                return NotFound();
            }
            else
            {
                db.Entry(updated).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Json(updated);
            }
        }


        [HttpDelete]
        public IHttpActionResult DeleteEmployee(int id)
        {
            var employee = db.Employees.Find(id);
            if (employee != null)
            {
                db.Employees.Remove(employee);
                db.SaveChanges();
                return Json(EmployeeList());
            }
            else
            {
                return BadRequest();
            }
        }

        public List<EmployeeDTO> EmployeeList()
        {
            var employees = db.Employees.Select(x => new EmployeeDTO { Id = x.EmployeeID, Title = x.Title, FirstName = x.FirstName, LastName = x.LastName }).ToList();
            return employees;
        }
    }
}
