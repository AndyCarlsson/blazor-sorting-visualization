using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SortingVisualization.Shared
{
    public class SortingComponentBase : ComponentBase
    {
        public static int[] numArr = new int[80];

        protected override void OnInitialized()
        {
            FillArray();
        }

        public void FillArray()
        {
            int min = 20;
            int max = 620;

            Random rnd = new Random();
            for (int i = 0; i < numArr.Length; i++)
            {
                numArr[i] = rnd.Next(min, max);
            }
            this.StateHasChanged();
        }

        public async Task BubbleSort(int[] intArr)
        {       
            for (int i = 0; i < intArr.Length; i++)
            {
                for (int j = 0; j < intArr.Length - i - 1; j++)
                {
                    if (intArr[j] > intArr[j + 1])
                    {
                        Swap(intArr, j, j + 1);
                        this.StateHasChanged();
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
