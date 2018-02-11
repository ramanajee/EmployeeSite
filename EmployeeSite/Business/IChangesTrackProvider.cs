using EmployeeSite.Data.Entities;
using System.Threading.Tasks;

namespace EmployeeSite.Business
{
    public interface IChangesTrackProvider
    {
        Task LogChanges(Employee employee);
    }
}