﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiQueueModels
{
    public class Server
    {
        public Server()
        {
            this.TimeDistribution = new List<TimeDistribution>();
            this.UtilizationTimes = new List<KeyValuePair<int, int>>();
        }

        public int ID { get; set; }
        public decimal IdleProbability
        {
            get
            {
                return 1 - Utilization;
            }
            set
            {
                Utilization = 1 - value;
            }
        }
        public decimal AverageServiceTime { get; set; } 
        public decimal Utilization { get; set; }
        public List<TimeDistribution> TimeDistribution;
        //public SegmentTree UtilizationTimes;
        public List<KeyValuePair<int, int>> UtilizationTimes;

        //optional if needed use them
        public int FinishTime { get; set; }
        public int TotalWorkingTime { get; set; }
        public int ServedCount { get; set; }
    }
}
