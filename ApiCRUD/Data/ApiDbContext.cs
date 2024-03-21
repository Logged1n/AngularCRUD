using ApiCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCRUD.Data;

public class ApiDbContext: DbContext {
    public ApiDbContext(DbContextOptions <ApiDbContext> options): base(options) {}
    public DbSet<Employee> Employees { get; set; }
}