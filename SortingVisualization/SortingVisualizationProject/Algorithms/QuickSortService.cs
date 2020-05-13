using SortingVisualizationProject.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SortingVisualizationProject.Algorithms
{
    public class QuickSortService
    {
        public async Task Quicksort(int[] numbers, int left, int right, MainPage mainPage, CancellationToken ct)
        {
            int i = left;
            int j = right;

            var pivot = numbers[(left + right) / 2];

            while (i <= j)
            {
                while (numbers[i] < pivot)
                    i++;
                while (numbers[j] > pivot)
                    j--;

                if (ct.IsCancellationRequested)
                    ct.ThrowIfCancellationRequested();
                if (i <= j)
                {
                    var tmp = numbers[i];
                    numbers[i] = numbers[j];
                    numbers[j] = tmp;

                    i++;
                    j--;    
                }
                mainPage.UpdateUI();
                await Task.Delay(20);

            }

            if (IsSorted(numbers))
                mainPage.isPressed = false;

            if (left < j)
                await Quicksort(numbers, left, j, mainPage, ct);
            if (i < right)
                await Quicksort(numbers, i, right, mainPage, ct);
        }

        bool IsSorted(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i - 1] > arr[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
