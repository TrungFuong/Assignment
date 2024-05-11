using Day2.WebApp.Models;
using Day2.WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace Day2.WebApp.Areas.NashTech.Controllers
{
    [Area("NashTech")]

    public class RookiesController : Controller
    {
        private readonly IPersonService _personService;

        public RookiesController(IPersonService personService)
        {
            _personService = personService;
        }

        public IActionResult Index()
        {
            List<Person> people = _personService.GetAll();
            return View(people);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("FirstName, LastName, Gender, DateOfBirth, PhoneNumber, BirthPlace, IsGraduated")] Person person)
        {
            
            if (ModelState.IsValid)
            {
                _personService.Create(person);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Person person = _personService.GetById(id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([Bind("Id, FirstName, LastName, Gender, DateOfBirth, PhoneNumber, BirthPlace, IsGraduated")] Person person)
        {
            if (ModelState.IsValid)
            {
                _personService.Update(person.Id, person);
            return RedirectToAction("Index");
            }
            return View(person);
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            Person person = _personService.GetById(id);
            return View(person);
        }

        public IActionResult Delete(int id)
        {
            Person person = _personService.GetById(id);
            return View("ConfirmDelete", person);
        }

        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            _personService.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult GetMalePeople()
        {
            List<Person> people = _personService.GetAll();
            List<Person> male = people.Where(people => people.Gender == Gender.male).ToList();
            return View("Male", male);
        }

        public IActionResult GetOldestPerson()
        { 
            List<Person> people = _personService.GetAll();
            Person oldestPerson = people.OrderBy(people => people.DateOfBirth).First();

            return View("Oldest", oldestPerson);
        }

        public IActionResult GetFullName()
        {
            List<Person> people = _personService.GetAll();
            List<string> fullName = new List<string>();
            foreach (var person in people)
            {
                fullName.Add(person.FirstName + " " + person.LastName);
            }            
            return View("FullName", fullName);
        }

        public IActionResult Get2kList(string actionParam)
        {
            List<Person> people = _personService.GetAll();
            List<Person> filteredPeople;

            if (actionParam == "birthYear2000")
            {
                filteredPeople = people.Where(people => people.DateOfBirth.Year == 2000).ToList();
            }
            else if (actionParam == "birthYearGreaterThan2000")
            {
                filteredPeople = people.Where(people => people.DateOfBirth.Year > 2000).ToList();
            }
            else if (actionParam == "birthYearLessThan2000")
            {
                filteredPeople = people.Where(people => people.DateOfBirth.Year < 2000).ToList();
            }
            else
            {
                // Handle invalid actionParam value here
                return BadRequest("Invalid actionParam value");
            }

            return Ok(filteredPeople);
        }

        public IActionResult DownloadExcel()
        {
            List<Person> people = _personService.GetAll();

            var stream = new MemoryStream();
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            using (var package = new ExcelPackage(stream))
            {
                var workSheet = package.Workbook.Worksheets.Add("Sheet1");
                workSheet.Cells.LoadFromCollection(people, true);
                package.Save();
            }
            stream.Position = 0;
            string excelName = $"UserList-{DateTime.Now.ToString("yyyyMMdd")}.xlsx";

            return File(stream, "application/octet-stream", excelName);

        }
       
    }
}
