using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.Models
{
    public class WorkerTask
    {
        public int TaskId { get; }
        private static int _taskIdCounter = 0;
        public int DifficultyLevel { get; }

        public int Reward{get; set; }
        public Status Status { get; set; }
        public string Code { get; set; }
        public WorkerTask(int difficultyLevel, int reward, Status status, string code)
        {
            if (difficultyLevel < 1 || difficultyLevel > 10)
                throw new ArgumentOutOfRangeException(nameof(difficultyLevel), " Difficulty level must be in range 1-10.");
            TaskId = _taskIdCounter++;
            DifficultyLevel = difficultyLevel;
            Reward = reward;
            Status = status;
            Code = code;
        }
    }
}
