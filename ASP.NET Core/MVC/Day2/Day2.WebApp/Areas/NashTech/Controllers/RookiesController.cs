using Day2.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace Day2.WebApp.Areas.NashTech.Controllers
{
    [Area("NashTech")]

    public class RookiesController : Controller
    {
        public List<People> ReadFile()
        {
            string filePath = "D:\\Currently working on\\Work\\Assignment\\ASP.NET Core\\MVC\\Day2\\Day2.WebApp\\Data\\MOCK_DATA.csv";
            string fileContent = "";

            using (var reader = new StreamReader(filePath))
            {
                fileContent = reader.ReadToEnd();
            }

            List<People> people = ParsePeople(fileContent);
            return people;
        }
        public IActionResult Index()
        {
            List<People> people = ReadFile();

            return View(people);
        }

        public List<People> ParsePeople(string fileContent)
        {
            List<People> people = new List<People>();

            string[] lines = fileContent.Split('\n', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] values = lines[i].Split(',');

                People person = new People
                {
                    FirstName = values[0],
                    LastName = values[1],
                    Gender = (Gender)Enum.Parse(typeof(Gender), values[2]),
                    DateOfBirth = DateOnly.Parse(values[3]),
                    PhoneNumber = values[4],
                    BirthPlace = values[5],
                    IsGraduated = bool.Parse(values[6])
                };

                people.Add(person);
            }

            return people;
        }

        public IActionResult GetMalePeople()
        {
            List<People> people = ReadFile();
            List<People> male = people.Where(people => people.Gender == Gender.male).ToList();
            return View("Male", male);
        }

        public IActionResult GetOldestPerson()
        { 
            List<People> people = ReadFile();
            People oldestPerson = people.OrderBy(people => people.DateOfBirth).First();

            return View("Oldest", oldestPerson);
        }

        public IActionResult GetFullName()
        {
            List<People> people = ReadFile();
            List<string> fullName = new List<string>();
            foreach (var person in people)
            {
                fullName.Add(person.FirstName + " " + person.LastName);
            }            
            return View("FullName", fullName);
        }

        public IActionResult Get2kList(string actionParam)
        {
            string filePath = "D:\\Currently working on\\Work\\Assignment\\ASP.NET Core\\MVC\\Day2\\Day2.WebApp\\Data\\MOCK_DATA.csv";
            string fileContent = "";

            using (var reader = new StreamReader(filePath))
            {
                fileContent = reader.ReadToEnd();
            }

            List<People> people = ParsePeople(fileContent);
            List<People> filteredPeople;

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
            string filePath = "D:\\Currently working on\\Work\\Assignment\\ASP.NET Core\\MVC\\Day2\\Day2.WebApp\\Data\\MOCK_DATA.csv";
            string fileContent = "";

            using (var reader = new StreamReader(filePath))
            {
                fileContent = reader.ReadToEnd();
            }

            List<People> people = ParsePeople(fileContent);

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
