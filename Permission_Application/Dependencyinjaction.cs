using Microsoft.Extensions.DependencyInjection;
using System.Collections;
using System.Runtime.CompilerServices;

namespace Permission_Application
{
    public static class Dependencyinjaction
    {
        public static IServiceCollection AddApplication ( this  IServiceCollection services)
        {
            return services;
        } 

    }   
}
