using Gym.Application.Interfaces.Repositories;
using Gym.Application.Interfaces.UnitOfWork;
using Gym.Domain.Entities;
using Gym.Infrastructure.Data;
using Gym.Infrastructure.Repositories;

namespace Gym.Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{

    private readonly GymDbContext _context;

    public IGenericRepository<Member> Members { get; }
    public IGenericRepository<Trainer> Trainers { get; }
    public IGenericRepository<Session> Sessions { get; }
    public IGenericRepository<Booking> Bookings { get; }
    public IGenericRepository<MembershipPlan> MembershipPlans { get; }

    public UnitOfWork(GymDbContext context)
    {

        _context = context;

        Members = new GenericRepository<Member>(_context);
        Trainers = new GenericRepository<Trainer>(_context);
        Sessions = new GenericRepository<Session>(_context);
        Bookings = new GenericRepository<Booking>(_context);
        MembershipPlans = new GenericRepository<MembershipPlan>(_context);
    }

    public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

    public void Dispose() => _context.Dispose();
}