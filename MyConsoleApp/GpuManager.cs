using System;
using ManagedCuda;

namespace MyConsoleApp
{
    public class GpuManager : IGpuManager
    {
        // Implementation of IGpuManager
        public bool IsRunningOnGPU()
        {
            try
            {
                // Attempt to create a CUDA context to check for GPU availability
                using (var cudaContext = new ManagedCuda.CudaContext())
                {
                    return true; // GPU is available
                }
            }
            catch
            {
                return false; // GPU is not available
            }
        }
    }
}