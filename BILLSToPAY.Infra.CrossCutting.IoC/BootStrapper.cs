using System;
using AutoMapper;
using BILLSToPAY.ApplicationService.Application;
using BILLSToPAY.ApplicationService.AutoMapper;
using BILLSToPAY.ApplicationService.Interfaces;
using BILLSToPAY.Domain.Interfaces;
using BILLSToPAY.Domain.Interfaces.Repositories;
using BILLSToPAY.Domain.Interfaces.Services;
using BILLSToPAY.Domain.Services;
using BILLSToPAY.Domain.Shared.Notification;
using BILLSToPAY.Infra.Data.Context;
using BILLSToPAY.Infra.Data.Repositories;
using BILLSToPAY.Infra.Data.UoW;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BILLSToPAY.Infra.CrossCutting.IoC
{
    public static class BootStrapper
    {
        public static void Register(this IServiceCollection services)
        {
            services.AddSingleton<IConfigurationProvider>(AutoMapperConfig.RegisterMappings());

            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            services.AddScoped<IRuleApplicationService, RuleApplicationService>();
            services.AddScoped<IAccountApplicationService, AccountApplicationService>();

            services.AddScoped<IRuleService, RuleService>();
            services.AddScoped<IAccountService, AccountService>();

            services.AddScoped<IRuleRepository, RuleRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();

            services.AddScoped<BillToPayContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
