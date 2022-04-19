using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyBestPractices
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAllDepartments();
    }
}
