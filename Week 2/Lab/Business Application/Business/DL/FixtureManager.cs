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
        public List<Fixture> Fixtures = new List<Fixture>();
        private FixtureRepository fixtureRepo = new FixtureRepository();

        public FixtureManager()
        {
            Fixtures = fixtureRepo.LoadFixtures();
        }

        public void AddFixture(string teams, string date, string venue)
        {
            int newId = Fixtures.Count > 0 ? Fixtures.Max(f => f.Id) + 1 : 1;
            Fixtures.Add(new Fixture(newId, teams, date, venue));
            fixtureRepo.SaveFixtures(Fixtures);
        }

        public void DeleteFixture(int id)
        {
            Fixtures.RemoveAll(f => f.Id == id);
            fixtureRepo.SaveFixtures(Fixtures);
        }
        public void SaveFixtures()
        {
            fixtureRepo.SaveFixtures(Fixtures);
        }
    }
}
