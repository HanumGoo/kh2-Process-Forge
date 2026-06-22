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

        public float GetCpuUsage()
        {
            Thread.Sleep(1000); // Wait 1 second for a valid reading
            return _cpuCounter.NextValue();
        }

        public bool IsCpuAbove80()
        {
            return GetCpuUsage() > 80f;
        }
    }
}
