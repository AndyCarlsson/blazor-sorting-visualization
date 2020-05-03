using Microsoft.AspNetCore.Components;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SortingVisualization.Shared
{
    
    public class BubbleSortClass
    {
        [Inject]
        protected SortingComponentBase sortComponent { get; set; }


        public event Action OnChange;
        private void NotifyDataChanged() => OnChange?.Invoke();

        public async Task BubbleSort(int[] intArr)
        {
            for (int i = 0; i < intArr.Length; i++)
            {
                for (int j = 0; j < intArr.Length - i - 1; j++)
                {
                    if (intArr[j] > intArr[j + 1])
                    {
                        Swap(intArr, j, j + 1);
                        NotifyDataChanged();
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
