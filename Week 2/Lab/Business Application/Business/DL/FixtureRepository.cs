using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.BL;
using System.IO;

namespace Business.DL
{
    public class FixtureRepository
    {
        public List<Fixture> LoadFixtures()
        {
            List<Fixture> fixtures = new List<Fixture>();
            if (File.Exists("fixtures.txt"))
            {
                foreach (string line in File.ReadAllLines("fixtures.txt"))
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 4)
                    {
                        fixtures.Add(new Fixture(
                            int.Parse(parts[0]),
                            parts[1],
                            parts[2],
                            parts[3]
                        ));
                    }
                }
            }
            return fixtures;
        }

        public void SaveFixtures(List<Fixture> fixtures)
        {
            List<string> lines = new List<string>();
            foreach (Fixture f in fixtures)
            {
                lines.Add($"{f.Id},{f.Teams},{f.Date},{f.Venue}");
            }
            File.WriteAllLines("fixtures.txt", lines);
        }
    }
}
