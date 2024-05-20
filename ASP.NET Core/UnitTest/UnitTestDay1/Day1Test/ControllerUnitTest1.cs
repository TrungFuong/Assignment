using NUnit.Framework;
using Moq;
using UnitTestDay1.WebApp.Models;
using UnitTestDay1.WebApp.Services;
using UnitTestDay1.WebApp.Areas.NashTech.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework.Legacy;

namespace Day1Test
{
    [TestFixture]
    public class ControllerUnitTest1
    {
        private Mock<IPersonService> _mockPersonService;
        private RookiesController _controller;


        [SetUp]
        public void Setup()
        {
            _mockPersonService = new Mock<IPersonService>();
            _controller = new RookiesController(_mockPersonService.Object);
        }

        [Test]
        public void Test_Index_Return_Person_List()
        {
            // Arrange
            var people = new List<Person>
            {
                new Person { Id = 1, FirstName = "AA", LastName = "aa", Gender = Gender.male, DateOfBirth = new DateOnly(2002, 10, 20), IsGraduated = false},
                new Person { Id = 2, FirstName = "BB", LastName = "Doe", Gender = Gender.Female, DateOfBirth = new DateOnly(2005, 1, 1), IsGraduated = false}
            };
            _mockPersonService.Setup(service => service.GetAll()).Returns(people);

            //Act
            var result = _controller.Index();

            //Assert

            //ClassicAssert.IsNotNull(result);
            //ClassicAssert.IsInstanceOf<ViewResult>(result);
            //ClassicAssert.AreEqual(people, ((ViewResult)result).Model);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<ViewResult>());
            Assert.That(((ViewResult)result).Model, Is.EqualTo(people));
        }

        [Test]
        public void Test_Create_Return_To_Index_If_Success()
        {
            //Assert
            var person = new Person
            {
                FirstName = "HAHA",
                LastName = "LOLO",
                Gender = Gender.male,
                DateOfBirth = new DateOnly(2012, 3, 1),
                PhoneNumber = "623452645",
                BirthPlace = "HN",
                IsGraduated = true
            };

            //Act
            var result = _controller.Create(person) as RedirectToActionResult;

            //Assert
            _mockPersonService.Verify(service => service.Create(person), Times.Once);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.ActionName, Is.EqualTo("Index"));
        }

        [Test]
        public void Test_Update_Return_To_View_Of_New_Person()
        {
            //Arrange
            var person = new Person
            {
                Id = 1,
                FirstName = "Test",
                LastName = "Update",
                Gender = Gender.male,
                DateOfBirth = new DateOnly(2010, 1, 1),
                PhoneNumber = "98768765476546",
                BirthPlace = "HN",
            };
            _mockPersonService.Setup(service => service.GetById(1)).Returns(person);

            //Act
            var result = _controller.Update(1) as ViewResult;

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<ViewResult>());
            Assert.That(((ViewResult)result).Model, Is.EqualTo(person));
        }

        [Test]
        public void Test_Update_Return_To_Index_If_Success()
        {
            //Arrange
            var person = new Person
            {
                Id = 1,
                FirstName = "Test",
                LastName = "Update",
                Gender = Gender.male,
                DateOfBirth = new DateOnly(2010, 1, 1),
                PhoneNumber = "4230959872",
                BirthPlace = "HN",
            };

            //Act
            var result = _controller.Update(person) as RedirectToActionResult;

            //Assert
            _mockPersonService.Verify(service => service.Update(person.Id, person), Times.Once);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.ActionName, Is.EqualTo("Index"));
        }

        [Test]
        public void Test_Detail_Return_View_Person()
        {
            //Arrange
            var person = new Person
            {
                Id = 1,
                FirstName = "Test",
                LastName = "Details",
                Gender = Gender.male,
                DateOfBirth = new DateOnly(2010, 1, 1),
                PhoneNumber = "4230959872",
                BirthPlace = "HN",
            };
            _mockPersonService.Setup(service => service.GetById(1)).Returns(person);

            //Act
            var result = _controller.Detail(1) as ViewResult;

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<ViewResult>());
            Assert.That(((ViewResult)result).Model, Is.EqualTo(person));
        }

        [Test]
        public void Test_Delete_Return_View_Person()
        {
            //Arrange
            var person = new Person
            {
                Id = 1,
                FirstName = "Test",
                LastName = "Delete",
            };
            _mockPersonService.Setup(service => service.GetById(1)).Returns(person);

            //Act
            var result = _controller.Delete(1) as ViewResult;

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<ViewResult>());
            Assert.That(((ViewResult)result).Model, Is.EqualTo(person));

        }

        [Test]
        public void Test_ConfirmDelete_Return_To_Index_If_Success()
        {
            //Arrange
            int id = 1;

            //Act
            var result = _controller.ConfirmDelete(id) as RedirectToActionResult;

            //Assert
            _mockPersonService.Verify(service => service.Delete(id), Times.Once);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.ActionName, Is.EqualTo("Index"));
        }

        [Test]
        public void Test_Get_Male_People_Return_View_With_Male_People()
        {
            //Arrange
            var people = new List<Person>
            {
                new Person { Id = 1, FirstName = "AA", LastName = "AA", Gender = Gender.male},
                new Person { Id = 2, FirstName = "BB", LastName = "BB", Gender = Gender.Unknown},
                new Person { Id = 3, FirstName = "CC", LastName = "CC", Gender = Gender.Female},
                new Person { Id = 4, FirstName = "DD", LastName = "DD", Gender = Gender.male}
            };
            _mockPersonService.Setup(service => service.GetAll()).Returns(people);

            //Act
            var result = _controller.GetMalePeople() as ViewResult;

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<ViewResult>());
            Assert.That(((ViewResult)result).Model, Is.EqualTo(people.Where(p => p.Gender == Gender.male)));
        }

        [Test]
        public void Test_Get_Oldest_Person_Return_View_With_Oldest_Person()
        {
            //Arrange
            var people = new List<Person>
            {
                new Person { Id = 1, FirstName = "AA", LastName = "AA", Gender = Gender.male, DateOfBirth = new DateOnly(2003, 1, 1) },
                new Person { Id = 2, FirstName = "BB", LastName = "BB", Gender = Gender.Female, DateOfBirth = new DateOnly(1995, 1, 1) },
                new Person { Id = 2, FirstName = "CC", LastName = "CC", Gender = Gender.Female, DateOfBirth = new DateOnly(1997, 1, 1) }
            };
            _mockPersonService.Setup(service => service.GetAll()).Returns(people);

            //Act
            var result = _controller.GetOldestPerson() as ViewResult;

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<ViewResult>());
            Assert.That(((ViewResult)result).Model, Is.EqualTo(people.OrderBy(p => p.DateOfBirth).First()));
        }

        [Test]
        public void Test_Get_Full_Name_Return_View_With_Full_Name()
        {
            //Arrange
            var people = new List<Person>
            {
                new Person { Id = 1, FirstName = "AA", LastName = "aa"},
                new Person { Id = 2, FirstName = "BB", LastName = "bb"},
            };
            _mockPersonService.Setup(service => service.GetAll()).Returns(people);

            //Act
            var result = _controller.GetFullName() as ViewResult;

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<ViewResult>());
            Assert.That(((ViewResult)result).Model, Is.EqualTo(people.Select(p => p.FirstName + " " + p.LastName)));
        }

        [Test]
        [TestCase("birthYear2000", 1)]
        [TestCase("birthYearGreaterThan2000", 1)]
        [TestCase("birthYearLessThan2000", 1)]
        public void Test_Get2kList_Returns_Correct_People(string actionParam, int expectedCount)
        {
            // Arrange
            var people = new List<Person>
            {
                new Person { Id = 1, FirstName = "AA", LastName = "AA", Gender = Gender.male, DateOfBirth = new DateOnly(2000, 1, 1) },
                new Person { Id = 2, FirstName = "BB", LastName = "BB", Gender = Gender.Female, DateOfBirth = new DateOnly(2001, 1, 1) },
                new Person { Id = 3, FirstName = "CC", LastName = "CC", Gender = Gender.male, DateOfBirth = new DateOnly(1999, 1, 1) }
            };
            _mockPersonService.Setup(service => service.GetAll()).Returns(people);

            // Act
            var result = _controller.Get2kList(actionParam) as OkObjectResult;

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<ViewResult>());
            var model = result.Value as List<Person>;
            Assert.That(model, Is.Not.Null);
            Assert.That(expectedCount, Is.EqualTo(model.Count));
        }



        [TearDown]
        public void Dispose()
        {
            _controller?.Dispose();
        }
    }
}
