using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BL
{
    public class Fixture
    {
        public int Id;
        public string Teams;
        public string Date;
        public string Venue;

        public Fixture(int id, string teams, string date, string venue)
        {
            Id = id;
            Teams = teams;
            Date = date;
            Venue = venue;
        }
    }
}
