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
        private readonly IServiceTeacher _serviceTeacher;
        private readonly Mock<ITeacherRepositories> mock;
        public TechaerTest()
        {
            this.mock = new Mock<ITeacherRepositories>();
            this._serviceTeacher = new ServiceTeacher(this.mock.Object);
        }
        [Fact]
        public async Task AddAsync_ReturnCreateTeacher()
        {
            //Arrange
            var teacher = new TeacherDto 
            {
                Name = "SUlton",
                Description = "Description",
                Experience = "100 yil ",
                PhoneNumber = "99 123-45-67",
                Price = "$120 000"
            };
            var expectedteacher = new Teacher
            {
                Id = 0,
                Name = "SUlton",
                Description = "Description",
                Experience = "100 yil ",
                PhoneNumber = "99 123-45-67",
                Price = "$120 000"
            };
            mock.Setup(r => r.CreateAsync(It.IsAny<Teacher>()))
                .ReturnsAsync(expectedteacher); 

            //Act

            var result = await this._serviceTeacher.CreateAsync(teacher);

            Assert.NotNull(result);
            Assert.Equal(expectedteacher, result);

            mock.Verify(r =>r.CreateAsync(It.IsAny<Teacher>()),Times.Once);
        }
    }
}
