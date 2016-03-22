using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentsProgressEntities;

namespace StudentsProgress.Repositories
{
    public interface ITopicRepository
    {
        List<Topic> GetTopic();
        void DeleteTopic(string topic);
        int AddTopic(string topic);
    }
}
