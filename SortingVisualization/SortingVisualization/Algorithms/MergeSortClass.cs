using SortingVisualization.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SortingVisualization.Algorithms
{
    public class MergeSortClass : SortingComponent
    {
        public void Merge(int[] array, int lowIndex, int middleIndex, int highIndex)
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
            }
            ;
        }

        // merge sort
        public async Task MergeSort(int[] array, int lowIndex, int highIndex, SortingComponentBase sortingComponentBase)
        {
            if (lowIndex < highIndex)
            {
                var middleIndex = (lowIndex + highIndex) / 2;
                await MergeSort(array, lowIndex, middleIndex, sortingComponentBase);
                await MergeSort(array, middleIndex + 1, highIndex, sortingComponentBase);
                Merge(array, lowIndex, middleIndex, highIndex);


                await Task.Delay(50);
                sortingComponentBase.UpdateUI();
            }
        }
    }
}
