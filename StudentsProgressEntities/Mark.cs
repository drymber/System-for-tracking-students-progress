using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsProgressEntities
{
    public class Mark
    {
        public Mark(int id, int studentId, string topic, decimal value)
        {
            Id = id;
            StudentId = studentId;
            Topic = topic;
            Value = value;
        }
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string Topic { get; set; }
        public decimal Value { get; set; }

    }
}
