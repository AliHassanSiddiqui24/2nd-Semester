using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.BL;
using System.IO;
using System.Data;

namespace Business.DL
{
    public class FixtureRepository
    {
        public List<Fixture> LoadFixtures()
        {
            List<Fixture> fixtures = new List<Fixture>();
            DataTable dt = SqlHelper.GetTable("SELECT * FROM Fixtures");

            foreach (DataRow r in dt.Rows)
            {
                fixtures.Add(new Fixture(
                    (int)r["Id"],
                        r["Teams"].ToString(),
                        r["Date"].ToString(),
                        r["Venue"].ToString()
                ));
            }
            return fixtures;
        }

        public void SaveFixtures(List<Fixture> fixtures)
        {
            SqlHelper.ExecuteDML("DELETE FROM Fixtures");

            foreach (Fixture f in fixtures)
            {
                string query = $@"INSERT INTO Fixtures VALUES(
                {f.Id}, '{f.Teams}', '{f.Date}', '{f.Venue}')";

                SqlHelper.ExecuteDML(query);
            }
        }
    }
}