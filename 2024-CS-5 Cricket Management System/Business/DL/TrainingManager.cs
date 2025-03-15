using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.BL;

namespace Business.DL
{
    public class TrainingManager
    {
        public List<TrainingSession> TrainingSessions = new List<TrainingSession>();
        private TrainingSessionRepository trainingRepo = new TrainingSessionRepository();

        public TrainingManager()
        {
            TrainingSessions = trainingRepo.LoadTrainingSessions();
        }

        public void AddTrainingSession(string date, string details)
        {
            int newId = 1;
            if (TrainingSessions.Count > 0)
            {
                newId = TrainingSessions.Max(t => t.Id) + 1;
            }
            TrainingSessions.Add(new TrainingSession(newId, date, details));
            trainingRepo.SaveTrainingSessions(TrainingSessions);
        }

        public void DeleteTrainingSession(int id)
        {
            TrainingSessions.RemoveAll(t => t.Id == id);
            trainingRepo.SaveTrainingSessions(TrainingSessions);
        }
        public void SaveTrainingSessions()
        {
            trainingRepo.SaveTrainingSessions(TrainingSessions);
        }
    }
}
