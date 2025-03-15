using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.BL;

namespace Business.DL
{
    public class FixtureManager
    {
        public List<Fixture> fix = new List<Fixture>();
        private FixtureRepository fRepo = new FixtureRepository();

        public FixtureManager()
        {
            fix = fRepo.LoadFixtures();
        }

        public void AddFixture(string teams, string date, string venue)
        {
            int newId;
            if (fix.Count > 0)
            {
                int max = fix.Max(f => f.Id);
                newId = max + 1;
            }
            else
            {
                newId = 1;
            }
            fix.Add(new Fixture(newId, teams, date, venue));
            fRepo.SaveFixtures(fix);
        }

        public void DeleteFixture(int id)
        {
            fix.RemoveAll(f => f.Id == id);
            fRepo.SaveFixtures(fix);
        }
        public void SaveFixtures()
        {
            fRepo.SaveFixtures(fix);
        }
    }
}
