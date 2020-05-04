using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SortingVisualizationProject.Services
{
    public class BubbleSortClass
    {
        public void BubbleSort(int[] intArr)
        {
            for (int i = 0; i < intArr.Length; i++)
            {
                for (int j = 0; j < intArr.Length - i - 1; j++)
                {
                    if (intArr[j] > intArr[j + 1])
                    {
                        Swap(intArr, j, j + 1);
                        NotifyDataChanged();
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
        
        public event Action OnChange;
        private void NotifyDataChanged() => OnChange?.Invoke();
    }
}
