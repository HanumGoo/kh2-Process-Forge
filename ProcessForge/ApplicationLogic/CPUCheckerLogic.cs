using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ProcessForge.ApplicationLogic
{
    public class CpuMonitor
    {
        private readonly PerformanceCounter _cpuCounter;

        public CpuMonitor()
        {
            _cpuCounter = new PerformanceCounter(
                "Processor",
                "% Processor Time",
                "_Total");

            // First call always returns 0
            _cpuCounter.NextValue();
        }

        public async Task<float> GetCpuUsage()
        {
            return _cpuCounter.NextValue();
        }
    }
}
