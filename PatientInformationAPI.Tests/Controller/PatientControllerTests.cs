using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using PatientsInformationAPI.Controllers;
using PatientsInformationAPI.Repositories.Interface;

namespace PatientInformationAPI.Tests.Controller
{
    public class PatientControllerTests
    {
        private readonly IPatientRepository patientRepository;
        private readonly INCDRepository NCDRepository;
        private readonly IAllergyRepository allergyRepository;
        private readonly IDiseaseRepository diseaseRepository;

        public PatientControllerTests()
        {
            this.patientRepository = A.Fake<IPatientRepository>();
            this.NCDRepository = A.Fake<INCDRepository>();
            this.allergyRepository = A.Fake<IAllergyRepository>();
            this.diseaseRepository = A.Fake<IDiseaseRepository>();
        }

        [Fact]
        public async Task PatientController_Delete_ReturnOkAsync()
        {
            //Arrange
            var patientID = Guid.NewGuid();
            var controller = new PatientController(patientRepository, diseaseRepository,
                allergyRepository, NCDRepository);

            //Act
            var result = await controller.Delete(patientID);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }
    }
}
