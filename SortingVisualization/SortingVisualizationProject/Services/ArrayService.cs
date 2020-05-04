using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SortingVisualizationProject.Services
{
    public class ArrayService
    {
        public int[] sortArr = new int[300];

        public void GetRandomArray()
        {
            int min = 20;
            int max = 620;

            Random rnd = new Random();
            for (int i = 0; i < sortArr.Length; i++)
            {
                sortArr[i] = rnd.Next(min, max);
            }
        }

    }
}
