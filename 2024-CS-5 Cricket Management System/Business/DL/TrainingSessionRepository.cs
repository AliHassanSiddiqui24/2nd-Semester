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
    public class TrainingSessionRepository
    {
        
        public List<TrainingSession> LoadTrainingSessions()
        {
            List<TrainingSession> sessions = new List<TrainingSession>();
            DataTable dt = SqlHelper.GetTable("SELECT * FROM Trainingsessions");

            foreach (DataRow row in dt.Rows)
            {
                sessions.Add(new TrainingSession(
                    (int)row["Id"],
                    row["Date"].ToString(),
                    row["Details"].ToString()
                ));
            }
            return sessions;
        }
        public void SaveTrainingSessions(List<TrainingSession> sessions)
        {
            SqlHelper.ExecuteDML("DELETE FROM TrainingSessions");

            foreach (TrainingSession t in sessions)
            {
                string query = $@"INSERT INTO TrainingSessions VALUES(
            {t.Id}, '{t.Date.Replace("'", "''")}', '{t.Details.Replace("'", "''")}')";

                SqlHelper.ExecuteDML(query);
            }
        }
    }
}
