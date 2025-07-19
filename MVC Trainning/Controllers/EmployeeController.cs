namespace MVC_Trainning.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MVC_Trainning.Models;


    public class EmployeeController : Controller
    {

        internal static List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Hatim Rajab", Age = 30, Address = "Elminia" },
            new Employee { Id = 2, Name = "Hatim ", Age = 20, Address = "Elminia" },
         };


        // GET: Employee
        public IActionResult Index()
        {
            return View(employees);
        }



        // GET
        [HttpGet]
        public IActionResult Add()
        {
            return View(new Employee());
        }

        // POST: Employee/Add
        [HttpPost]
        public IActionResult Add(Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.Id = employees.Count + 1;
                employees.Add(employee);
                return RedirectToAction("Index");
            }

            return View(employee);
        }



        // POST: Employee/Edit
        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                var existingEmployee = employees.FirstOrDefault(e => e.Id == employee.Id);
                if (existingEmployee != null)
                {
                    existingEmployee.Name = employee.Name;
                    existingEmployee.Age = employee.Age;
                    existingEmployee.Address = employee.Address;
                }
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // DELETE: Employee/Delete/id
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                employees.Remove(employee);
            }
            return RedirectToAction("Index");
        }



    }
}
