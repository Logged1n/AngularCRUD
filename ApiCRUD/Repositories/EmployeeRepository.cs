using ApiCRUD.Data;
using ApiCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCRUD.Repositories;

public class EmployeeRepository: IEmployeeRepository {
    private readonly ApiDbContext _appDbContext;
    public EmployeeRepository(ApiDbContext context) {
        _appDbContext = context ??
                        throw new ArgumentNullException(nameof(context));
    }
    public async Task<IEnumerable<Employee?>> GetEmployees() {
        return await _appDbContext.Employees.ToListAsync();
    }
    public async Task<Employee?> GetEmployeeById(int id) {
        return await _appDbContext.Employees.FindAsync(id);
    }
    public async Task<Employee?> InsertEmployee(Employee? objEmployee) {
        _appDbContext.Employees.Add(objEmployee);
        await _appDbContext.SaveChangesAsync();
        return objEmployee;
    }
    public async Task <Employee> UpdateEmployee(Employee objEmployee) {
        _appDbContext.Entry(objEmployee).State = EntityState.Modified;
        await _appDbContext.SaveChangesAsync();
        return objEmployee;
    }
    public bool DeleteEmployee(int id) {
        bool result = false;
        var department = _appDbContext.Employees.Find(id);
        if (department != null) {
            _appDbContext.Entry(department).State = EntityState.Deleted;
            _appDbContext.SaveChanges();
            result = true;
        } else {
            result = false;
        }
        return result;
    }
}