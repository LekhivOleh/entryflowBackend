using entryflowBackend.API.Models;
using Microsoft.EntityFrameworkCore;

namespace entryflowBackend.API.DbContext
{
    public class EntryflowDbContext(DbContextOptions<EntryflowDbContext> options)
        : Microsoft.EntityFrameworkCore.DbContext(options)
    {
        public DbSet<Validator> Validators => Set<Validator>();
        public DbSet<Admin> Admins => Set<Admin>();
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<RfidLog> RfidLogs => Set<RfidLog>();
    }
}