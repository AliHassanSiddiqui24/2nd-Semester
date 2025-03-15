using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BL
{
    public class TrainingSession
    {
        public int Id;
        public string Date;
        public string Details;

        public TrainingSession(int id, string date, string details)
        {
            Id = id;
            Date = date;
            Details = details;
        }
    }
}
