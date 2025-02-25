using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.BL;
using System.IO;

namespace Business.DL
{
    public class TrainingSessionRepository
    {
        public List<TrainingSession> LoadTrainingSessions()
        {
            List<TrainingSession> sessions = new List<TrainingSession>();
            if (File.Exists("training.txt"))
            {
                foreach (string line in File.ReadAllLines("training.txt"))
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 3)
                    {
                        sessions.Add(new TrainingSession(
                            int.Parse(parts[0]),
                            parts[1],
                            parts[2]
                        ));
                    }
                }
            }
            return sessions;
        }

        public void SaveTrainingSessions(List<TrainingSession> sessions)
        {
            List<string> lines = new List<string>();
            foreach (TrainingSession t in sessions)
            {
                lines.Add($"{t.Id},{t.Date},{t.Details}");
            }
            File.WriteAllLines("training.txt", lines);
        }
    }
}
