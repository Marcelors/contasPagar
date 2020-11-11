using System;
using BILLSToPAY.Domain.Interfaces;
using BILLSToPAY.Domain.Shared.Notification;
using BILLSToPAY.Infra.Data.Context;
using MediatR;

namespace BILLSToPAY.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BillToPayContext _context;
        private readonly IMediator _bus;

        public UnitOfWork(BillToPayContext context, IMediator bus)
        {
            _context = context;
            _bus = bus;
        }

        public bool Commit()
        {
            try
            {
                return _context.SaveChanges() >= 0;
            }
            catch (Exception ex)
            {
                _bus.Publish(new DomainNotification(ex.Message));
            }
            return false;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
