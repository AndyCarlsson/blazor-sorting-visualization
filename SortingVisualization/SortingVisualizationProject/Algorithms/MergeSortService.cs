using SortingVisualizationProject.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SortingVisualizationProject.Algorithms
{
    public class MergeSortService
    {
        public async Task Merge(int[] array, int lowIndex, int middleIndex, int highIndex, MainPage mainPage, CancellationToken ct)
        {
                var left = lowIndex;
                var right = middleIndex + 1;
                var tempArray = new int[highIndex - lowIndex + 1];
                var index = 0;

                while ((left <= middleIndex) && (right <= highIndex))
                {
                    if (array[left] < array[right])
                    {
                        tempArray[index] = array[left];
                        left++;
                    }
                    else
                    {
                        tempArray[index] = array[right];
                        right++;
                    }
                    index++;
                }
                for (var i = left; i <= middleIndex; i++)
                {
                    tempArray[index] = array[i];
                    index++;
                }
                for (var i = right; i <= highIndex; i++)
                {
                    tempArray[index] = array[i];
                    index++;
                }
                for (var i = 0; i < tempArray.Length; i++)
                {
                    array[lowIndex + i] = tempArray[i];

                    mainPage.UpdateUI();
                    await Task.Delay(5);
                }
            if (IsSorted(array))
                mainPage.isPressed = false;
        }
        public async Task MergeSort(int[] array, int lowIndex, int highIndex, MainPage mainPage, CancellationToken ct)
        {
            if (lowIndex < highIndex)
            {
                var middleIndex = (lowIndex + highIndex) / 2;

                await MergeSort(array, lowIndex, middleIndex, mainPage, ct);
                await MergeSort(array, middleIndex + 1, highIndex, mainPage, ct);
                if (ct.IsCancellationRequested)
                    ct.ThrowIfCancellationRequested();
                await Merge(array, lowIndex, middleIndex, highIndex, mainPage, ct);   
            }
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
