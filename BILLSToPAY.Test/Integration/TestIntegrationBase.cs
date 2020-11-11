using System;
using AutoMapper;
using BILLSToPAY.Domain.Shared.Notification;
using BILLSToPAY.Infra.CrossCutting.IoC;
using BILLSToPAY.Infra.Data.Context;
using BILLSToPAY.Test.Fake;
using MediatR;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BILLSToPAY.Test.Integration
{

    public class TestIntegrationBase : IDisposable
    {
        protected IServiceCollection Service;
        private SqliteConnection _connection;
        protected BillToPayContext DbContext;
        protected DomainNotificationHandler DomainNotificationHandler = new DomainNotificationHandler();
        private IServiceScope _scope;

        public TestIntegrationBase()
        {
            OpenConnection();
            Service = new ServiceCollection();


            Service.AddAutoMapper(typeof(TestIntegrationBase));
            Service.Register();
            Service.AddScoped(provider => DbContext);
            Service.AddScoped<IMediator, MediatorFake>();
            Service.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>(provider => DomainNotificationHandler);
        }

        private void OpenConnection()
        {
            _connection = new SqliteConnection("DataSource=:memory:");
            _connection.Open();

            var options = new DbContextOptionsBuilder<BillToPayContext>()
                    .UseSqlite(_connection)
                    .Options;

            DbContext = new BillToPayContext(options);
            DbContext.Database.EnsureCreated();
        }

        protected void CreateScope()
        {
            var sp = Service.BuildServiceProvider();
            _scope = sp.CreateScope();
        }

        protected T GetIntanceScope<T>()
        {
            var sp = _scope?.ServiceProvider;
            if (sp == null)
            {
                return default(T);
            }
            return sp.GetService<T>();
        }

        protected T GetInstance<T>()
        {
            var sp = Service.BuildServiceProvider();
            return sp.GetService<T>();
        }

        public void Dispose()
        {
            _connection?.Close();
        }
    }
}
