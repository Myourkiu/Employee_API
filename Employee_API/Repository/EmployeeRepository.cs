using Employee_API.Data;
using Employee_API.Model;
using Microsoft.EntityFrameworkCore;

namespace Employee_API.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _appDb;
        public EmployeeRepository(AppDbContext appDb)
        {
            _appDb = appDb;
        }

        public async Task<IEnumerable<Employee>> Get()
        {
            return await _appDb.Employees.ToListAsync();
        }
        public async Task<Employee> Create(Employee employee)
        {
            _appDb.Employees.Add(employee);
            await _appDb.SaveChangesAsync();

            return employee;
        }

        public async Task Delete(int ID)
        {
            var employeeToDelete = await _appDb.Employees.FindAsync(ID);
            _appDb.Employees.Remove(employeeToDelete);
            await _appDb.SaveChangesAsync();
        }

        public async Task<Employee> Get(int ID)
        {
            return await _appDb.Employees.FindAsync(ID);
        }

        public async Task Update(Employee employee)
        {
            _appDb.Entry(employee).State = EntityState.Modified;
            await _appDb.SaveChangesAsync();
        }
    }
}
