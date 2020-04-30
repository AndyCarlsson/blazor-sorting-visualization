using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SortingVisualization.Shared
{
    public class BubbleSortClass : SortingComponent
    {
        public async Task BubbleSort(int[] intArr, SortingComponentBase sortingComponentBase, CancellationToken cancellationToken)
        {
            for (int i = 0; i < intArr.Length; i++)
            {
                for (int j = 0; j < intArr.Length - i - 1; j++)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    if (intArr[j] > intArr[j + 1])
                    {
                        Swap(intArr, j, j + 1);
                        sortingComponentBase.UpdateUI();
                        await Task.Delay(20);
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
