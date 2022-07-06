using FluentValidation;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TouristAppBackend.Application.Common.Behaviours;
using TouristAppBackend.Application.Common.Configuration;
using TouristAppBackend.Application.Common.Interfaces;
using TouristAppBackend.Application.Common.Interfaces.Configuration;
using TouristAppBackend.Application.Common.Interfaces.Repository;
using TouristAppBackend.Application.Common.Interfaces.Validators;
using TouristAppBackend.Application.Common.Services;
using TouristAppBackend.Application.Places.Queries.GetAllPlaces;
using TouristAppBackend.Application.Repositories;
using TouristAppBackend.Application.Users.Validators;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Application
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IRequestPreProcessor<>), typeof(LogingBehaviour<>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            services.AddTransient<IAppSettings, AppSettings>();
            services.AddTransient<ISettingsRepository, SettingsRepository>();

            services.AddTransient<IUserExistsValidator, UserExistsValidator>();
            services.AddTransient(typeof(ISerachable<Place>), typeof(SortingService<Place>));
            services.AddTransient(typeof(ISerachable<Track>), typeof(SortingService<Track>));



            return services;
        }
    }
}
