using NUnit.Framework;
using Moq;
using UnitTestDay1.WebApp.Models;
using UnitTestDay1.WebApp.Services;
using UnitTestDay1.WebApp.Repositories;

namespace Day1Test
{
    [TestFixture]
    public class ServicesUnitTest1
    {
        private IPersonService _personService;
        private Mock<IPersonRepository> _mockPersonRepository;

        [SetUp]
        public void Setup()
        {
            _mockPersonRepository = new Mock<IPersonRepository>();
            _personService = new PersonService(_mockPersonRepository.Object);
        }

        [Test]
        public void Create_Person_Test_Calls_Repository()
        {
            // Arrange
            var person = new Person
            {
                FirstName = "John",
                LastName = "Doe",
                Gender = Gender.male,
                DateOfBirth = new DateOnly(1999, 1, 1),
                PhoneNumber = "0123456789",
                BirthPlace = "USA",
            };
            _mockPersonRepository.Setup(repo => repo.Create(It.IsAny<Person>()));
            _mockPersonRepository.Setup(repo => repo.GetAll()).Returns(new List<Person>());

            // Act
            _personService.Create(person);

            // Assert
            _mockPersonRepository.Verify(repo => repo.Create(It.IsAny<Person>()), Times.Once);
        }

        [Test]
        public void Delete_Person_Test_Calls_Repository()
        {
            // Arrange
            int id = 1;
            _mockPersonRepository.Setup(repo => repo.Delete(It.IsAny<int>()));

            //Act
            _personService.Delete(id);

            //Assert
            _mockPersonRepository.Verify(repo => repo.Delete(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void Get_All_Persons_Test_Calls_Repository()
        {
            // Arrange
            _mockPersonRepository.Setup(repo => repo.GetAll()).Returns(new List<Person>());

            // Act
            var result = _personService.GetAll();

            // Assert
            _mockPersonRepository.Verify(repo => repo.GetAll(), Times.Once);
        }

        [Test]
        public void Get_Person_By_Id_Test_Calls_Repository()
        {
            //Arrange
            int id = 1;

            //Act
            _personService.GetById(id);

            //Assert
            _mockPersonRepository.Verify(repo => repo.GetById(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void Update_Person_Test_Calls_Repository()
        {
            //Arrange
            int id = 1;
            var person = new Person
            {
                FirstName = "Test",
                LastName = "Update",
                Gender = Gender.Female,
                DateOfBirth = new DateOnly(2003, 12, 1),
                PhoneNumber = "0123456789",
                BirthPlace = "VN",
            };

            //Act
            _mockPersonRepository.Setup(repo => repo.Update(It.IsAny<int>(), It.IsAny<Person>()));
            _personService.Update(id, person);

            //Assert
            _mockPersonRepository.Verify(repo => repo.Update(It.IsAny<int>(), It.IsAny<Person>()), Times.Once);
        }
    }
}
