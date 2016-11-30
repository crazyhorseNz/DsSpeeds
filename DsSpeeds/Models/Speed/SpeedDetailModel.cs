using Read.Models;
using System.Collections.Generic;

namespace DsSpeeds.Models.Speed
{
    public class SpeedDetailModel
    {
        public SpeedDetailModel(SpeedReadModel readModel)
        {
            SpeedData = readModel;
        }


        public SpeedReadModel SpeedData { get; set; }

        public List<string> SpeedHistory { get; set; } 
    }
}