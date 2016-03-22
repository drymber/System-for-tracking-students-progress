using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentsProgressEntities;

namespace StudentsProgress.Repositories
{
    interface IMarkRepository
    {
        List<Mark> GetMarks(string studentId);
        int AddMark(int studentId, int topicId, decimal mark);
    }
}
