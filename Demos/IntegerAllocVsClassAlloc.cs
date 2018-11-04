﻿using Measurements;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demos
{
    class IntegerAllocVsClassAlloc:IRunnable
    {
        static readonly int arraySize = 5_000;
        static readonly int n = 5_000;
        static readonly int reps = 5;

        public void Compare()
        {
            ExecutionTime.Measure("AllocateInteger", reps, () =>
            {
                for (int i = 0; i < n; i++)
                {
                    AllocateInteger(i % n);
                }
            });

            ExecutionTime.Measure("AllocateClass", reps, () =>
            {
                for (int i = 0; i < n; i++)
                {
                    AllocateClass();
                }
            });
        }

        private static void AllocateInteger(int val)
        {
            int[] arr = new int[arraySize];
            for (int i = 0; i < arraySize; i++)
            {
                arr[i] = val;
            }
        }

        private static void AllocateClass()
        {
            IntegerAllocVsClassAlloc[] arr = new IntegerAllocVsClassAlloc[arraySize];
            for (int i = 0; i < arraySize; i++)
            {
                arr[i] = new IntegerAllocVsClassAlloc();
            }
        }

        
    }
}