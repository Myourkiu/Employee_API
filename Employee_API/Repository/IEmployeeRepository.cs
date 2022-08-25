using Employee_API.Model;

namespace Employee_API.Repository
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> Get();
        Task<Employee> Get(int ID);
        Task<Employee> Create(Employee employee);
        Task Update(Employee employee);
        Task Delete(int ID);

    }
}
