using SortingVisualizationProject.Pages;
using SortingVisualizationProject.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SortingVisualizationProject.Algorithms
{
    public class BubbleSortService
    {
        public async Task BubbleSort(int[] intArr, MainPage mainPage, CancellationToken ct)
        {
            for (int i = 0; i < intArr.Length; i++)
            {
                
                for (int j = 0; j < intArr.Length - i - 1; j++)
                {
                    if (ct.IsCancellationRequested)
                        break;
                    if (intArr[j] > intArr[j + 1])
                    {
                        Swap(intArr, j, j + 1);
                        mainPage.UpdateUI();
                        await Task.Delay(2);
                    }
                }
            }
        }

        public void Swap(int[] arr, int a, int b)
        {
            int temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
        }
    }
}
