using Microsoft.Extensions.DependencyInjection;
using Permission_Application.Services.Course;
using System.Collections;
using System.Runtime.CompilerServices;

namespace Permission_Application
{
    public static class Dependencyinjaction
    {
        public static IServiceCollection AddApplication ( this  IServiceCollection services)
        {
            services.AddScoped<ICourseServise, CourseServise>();

            return services;
        } 

    }   
}
