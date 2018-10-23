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
        /// <summary>
        /// Extract the random value out of a TimeDistribution object using a given random variable
        /// </summary>
        /// <param name="Distribution">Used to evaluate final random value</param>
        /// <param name="RandomVariable">The random number required by TimeDistribution parameter</param>
        /// <returns>The requested random value</returns>
        static private int CalculateRandomValue(List<TimeDistribution> Distribution, int RandomVariable)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Finds a server to sever the current simulation case
        /// </summary>
        /// <param name="Case">The current simulation case that needs to be served</param>
        /// <param name="Servers">A list of all servers to search in</param>
        /// <returns>The server that will serve the given simulation case</returns>
        static private void GetAssignedServer(SimulationCase Case, List<Server> Servers)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Entry point of the simulator
        /// </summary>
        /// <param name="System">The system to be simulated</param>
        static private void SimulationMain(SimulationSystem System)
        {
            throw new NotImplementedException();
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
