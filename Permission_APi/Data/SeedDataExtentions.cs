using Permission_Domen.Entityes;
using Permission_Infrastructure;

namespace Permission_APi.Data
{
    public static class SeedDataExtentions
    {
        public static async Task InitiliazeDataAsync(this IServiceProvider serviceProvider)
        {
            var db = serviceProvider.GetRequiredService<AppDbContext>();
            if (!db.Students.Any())
            {
                List<Student> students = [
                    new Student(){
                        UserID = "123",
                        Name = "Xushnud",
                        Phone_Number = "99 123-45-67",
                        Email = "Xushnud@gmail.com"
                    },
                     new Student(){
                        UserID = "124",
                        Name = "Abdumutal",
                        Phone_Number = "99 123-77-67",
                        Email = "Abdumutal@gmail.com"
                    },
                     new Student(){
                        UserID = "125",
                        Name = "Muxtor",
                        Phone_Number = "99 321-45-67",
                        Email = "Muxtor@gmail.com"
                    }
                    ];
                db.Students.AddRange(students);
                await db.SaveChangesAsync();
            }
        }

    }
}
