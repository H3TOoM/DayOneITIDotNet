namespace MVC_Trainning.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MVC_Trainning.Models;

    
    public class EmployeeController : Controller
    {
       
        internal static List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Omar Elshenawy", Age = 28, Address = "Cairo" },
            new Employee { Id = 2, Name = "Sara Hamed", Age = 32, Address = "Alexandria" },
            new Employee { Id = 3, Name = "Mohamed Khaled", Age = 24, Address = "Giza" },
            new Employee { Id = 4, Name = "Mona Ahmed", Age = 30, Address = "Tanta" },
            new Employee { Id = 5, Name = "Ahmed Nour", Age = 26, Address = "Mansoura" },
            new Employee { Id = 6, Name = "Laila Samir", Age = 29, Address = "Aswan" },
            new Employee { Id = 7, Name = "Youssef Adel", Age = 35, Address = "Suez" },
            new Employee { Id = 8, Name = "Rana Fathy", Age = 27, Address = "Fayoum" },
         };

        // GET: Employee
        public IActionResult Index()
        {
            return View(employees);
        }

        
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
