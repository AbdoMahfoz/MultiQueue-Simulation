using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MultiQueueModels;

namespace MultiQueueSimulation
{
    /// <summary>
    /// Static class that drives the simulation
    /// </summary>
    static class Simulator
    {
        static Random rnd = new Random();
        /// <summary>
        /// Extract the random value out of a TimeDistribution object using a given random variable
        /// </summary>
        /// <param name="Distribution">Used to evaluate final random value</param>
        /// <param name="RandomVariable">The random number required by TimeDistribution parameter</param>
        /// <returns>The requested random value</returns>
        static private int CalculateRandomValue(List<TimeDistribution> Distribution, int RandomVariable)
        {
            for (int i = 0; i < Distribution.Count; i++)
            {
                if (!Distribution[i].IsCalculated)
                {
                    if(i == 0)
                    {
                       Distribution[i].CummProbability = Distribution[i].Probability;
                       Distribution[i].MinRange = 1;
                    }
                    else
                    {
                        Distribution[i].CummProbability = Distribution[i].Probability + Distribution[i - 1].CummProbability;
                        Distribution[i].MinRange = Distribution[i - 1].MaxRange + 1;
                    }
                    Distribution[i].MaxRange =(int)Distribution[i].CummProbability * 100;
                    Distribution[i].IsCalculated = true;
                }
                if(RandomVariable<=Distribution[i].MaxRange && RandomVariable>=Distribution[i].MinRange)
                {
                    return Distribution[i].Time;
                }
            }
            if (RandomVariable < 1 || RandomVariable > 100)
                throw new ArgumentOutOfRangeException("RandomValue should be between 1 and 100");
            else
                throw new Exception("Debug meeeeeeeee");
        }
        /// <summary>
        /// Finds a server to sever the current simulation case
        /// </summary>
        /// <param name="Case">The current simulation case that needs to be served</param>
        /// <param name="Servers">A list of all servers to search in</param>
        /// <returns>The server that will serve the given simulation case</returns>
        static private void GetAssignedServer(SimulationCase Case, List<Server> Servers,Enums.SelectionMethod SelectionMethod)
        {
            int serverNum = 0;
            int minServiceTime = Servers[0].FinishTime;
            int minBigger = Servers[0].FinishTime;
            bool bigger = true;
            decimal minUtilization = Servers[0].Utilization;
            if (SelectionMethod == Enums.SelectionMethod.HighestPriority)
            {
                for (int i = 0; i < Servers.Count; i++)
                {
                    if (Servers[i].FinishTime <= Case.ArrivalTime)
                    {
                        bigger = false;

                    }
                    if (Servers[i].FinishTime < minBigger)
                        minBigger = i;

                    //law bigger fdlt  b true yb2a mafish 7aga asghr wla ysawii
                    //gbt asghr w7d shelo fl minBigger
                }
                if (bigger == true)
                {
                    minServiceTime = Servers[minBigger].FinishTime;
                    serverNum = minBigger;
                }
                else
                {
                    for (int i = 0; i < Servers.Count; i++)
                    {
                        if (Servers[i].FinishTime <= Case.ArrivalTime)
                        {
                            minServiceTime = Servers[i].FinishTime;
                            serverNum = i;
                            break;
                        }
                    }
                }
            }
            else if (SelectionMethod == Enums.SelectionMethod.LeastUtilization)
            {
                int minValue = Servers[0].FinishTime;
                for (int i = 1; i < Servers.Count; i++)
                {
                    minValue = Math.Min(Servers[i].FinishTime, minValue);
                }
                bool flag = false;
                if(minValue < Case.ArrivalTime)
                {
                    minValue = Case.ArrivalTime;
                    flag = true;
                }
                decimal leastUtil = decimal.MaxValue;
                for(int i = 0; i < Servers.Count; i++)
                {
                    if (flag)
                    {
                        if (Servers[i].FinishTime <= minValue && Servers[i].Utilization < leastUtil)
                        {
                            leastUtil = Servers[i].Utilization;
                            serverNum= i;
                        }
                    }
                    else
                    {
                        if (Servers[i].FinishTime == minValue && Servers[i].Utilization < leastUtil)
                        {
                            leastUtil = Servers[i].Utilization;
                            serverNum = i;
                        }
                    }
                }
            }
            else
            {
                for (int i = 1; i < Servers.Count; i++)
                {
                    if (Servers[i].FinishTime < minServiceTime)
                    {
                        minServiceTime = Servers[i].FinishTime;
                        serverNum = i;
                    }
                }
            }
            Case.AssignedServer = Servers[serverNum];
            Case.RandomService = rnd.Next(1, 100);
            Case.ServiceTime = CalculateRandomValue(Servers[serverNum].TimeDistribution, Case.RandomService);
            Case.StartTime = Math.Max(Servers[serverNum].FinishTime, Case.ArrivalTime);
            Case.EndTime = Case.StartTime + Case.ServiceTime;
            Case.TimeInQueue = Case.StartTime - Case.ArrivalTime;
            Servers[serverNum].FinishTime = Case.StartTime + Case.ServiceTime;
            Servers[serverNum].TotalWorkingTime += Case.ServiceTime;
            Servers[serverNum].AverageServiceTime += Case.ServiceTime;
        }
        /// <summary>
        /// Entry point of the simulator
        /// </summary>
        /// <param name="System">The system to be simulated</param>
        static private void SimulationMain(SimulationSystem System)
        {
            int ClockTime = 0;
            int Total_TimeinQueue = 0;
            int Number_Of_Customers_Who_Waited = 0;
            int Max_QueueLength = 0;
            List<SimulationCase> Cases = new List<SimulationCase>();
            Cases[0].ArrivalTime = ClockTime;
            Cases[0].CustomerNumber = 1;
            GetAssignedServer(Cases[0], System.Servers, System.SelectionMethod);
            if (System.StoppingCriteria == Enums.StoppingCriteria.NumberOfCustomers)
            {
                for(int i = 1; i < System.StoppingNumber; i++)
                {
                    Cases[i].CustomerNumber = i + 1;
                    Cases[i].RandomInterArrival = rnd.Next(1, 100);
                    Cases[i].InterArrival=CalculateRandomValue(System.InterarrivalDistribution, Cases[i].RandomInterArrival);
                    Cases[i].ArrivalTime = Cases[i - 1].ArrivalTime + Cases[i].InterArrival;
                    GetAssignedServer(Cases[i], System.Servers, System.SelectionMethod);
                    if (Cases[i].TimeInQueue > 0)
                    {
                        if (Max_QueueLength < Cases[i].TimeInQueue)
                        {
                            Max_QueueLength = Cases[i].TimeInQueue;
                        }
                        Total_TimeinQueue += Cases[i].TimeInQueue;
                        Number_Of_Customers_Who_Waited++;
                    }
                }
                ClockTime = Cases[System.StoppingNumber - 1].EndTime;
            }
            else
            {
                int Counter = 1;
                while (System.StoppingNumber < ClockTime)
                {
                    Cases[Counter].CustomerNumber = Counter + 1;
                    Cases[Counter].RandomInterArrival = rnd.Next(1, 100);
                    Cases[Counter].InterArrival = CalculateRandomValue(System.InterarrivalDistribution, Cases[Counter].RandomInterArrival);
                    Cases[Counter].ArrivalTime = Cases[Counter - 1].ArrivalTime + Cases[Counter].InterArrival;
                    GetAssignedServer(Cases[Counter], System.Servers, System.SelectionMethod);
                    if (Cases[Counter].TimeInQueue > 0)
                    {
                        if (Max_QueueLength < Cases[Counter].TimeInQueue)
                        {
                            Max_QueueLength = Cases[Counter].TimeInQueue;
                        }
                        Total_TimeinQueue += Cases[Counter].TimeInQueue;
                        Number_Of_Customers_Who_Waited++;
                    }
                    ClockTime = Cases[Counter].EndTime;
                    Counter++;
                }
            }
            System.PerformanceMeasures.AverageWaitingTime = (Total_TimeinQueue / Cases.Count);
            System.PerformanceMeasures.WaitingProbability = (Number_Of_Customers_Who_Waited / Cases.Count);
            System.PerformanceMeasures.MaxQueueLength = Max_QueueLength;
        }
        /// <summary>
        /// Runs the Simulation and fills the required outputs
        /// </summary>
        /// <param name="System">The system to be simulated</param>
        static public async void StartSimulation(SimulationSystem System)
        {
            await Task.Run(() =>
            {
                SimulationMain(System);
            });
        }
    }
}
