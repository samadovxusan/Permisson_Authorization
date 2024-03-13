using Moq;
using Permission_Application.Abstractions.Repositories;
using Permission_Application.Dto_s;
using Permission_Application.Services.Teacher_S;
using Permission_Domen.Entityes;
using Permission_Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class TechaerTest
    {
        private readonly Mock<IServiceTeacher> _mock = new Mock<IServiceTeacher>();

        public TechaerTest()
        {
        }
        [Fact]
        public async Task AddAsync_ReturnCreateTeacher()
        {
            //Arrange
            var teacher = new TeacherDto 
            {
                Name = "Ahmad",
                Description = "Description",
                Experience = "10 Year",
                PhoneNumber = "99 123-45-67",
                Price = "$120 000"
            };
            var expectedteacher = new Teacher
            {
                Id = 1,
                Name = "Ahmad",
                Description = "Description",
                Experience = "10 Year ",
                PhoneNumber = "99 123-45-67",
                Price = "$120 000"
                
            };
            _mock.Setup(r => r.CreateAsync(It.IsAny<TeacherDto>()))
                .ReturnsAsync(expectedteacher);  

            //Act

            var result = await _mock.Object.CreateAsync(teacher);

            Assert.NotNull(result);
             Assert.Equal(expectedteacher, result);



            // Assert
            _mock.Verify(r =>r.CreateAsync(It.IsAny<TeacherDto>()),Times.Once);
        }
    }
}
