using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentsProgressEntities;

namespace StudentsProgress.Repositories
{
    public interface IGroupRepository
    {
        List<Group> GetGroup(string year);
        List<int> GetAcademicYears();
        void DeleteGroup(string group, int year);
        int AddGroup(string group, int year);
    }
}
