using Microsoft.AspNetCore.Components;
using SortingVisualization.Algorithms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SortingVisualization.Shared
{
    public class SortingComponentBase : ComponentBase
    {
        public int[] numArr = new int[300];

        public bool bubbleSort = false;
        public bool mergeSort = false;

        protected override void OnInitialized()
        {
            FillArray();
        }

        public void UpdateUI()
        {
            this.StateHasChanged();
        }

        public void CallBubbleSort()
        {
            bubbleSort = true;
        }
        public void CallMergeSort()
        {
            mergeSort = true;
        }

        public async void RunSort()
        {
            if (bubbleSort)
            {
                bubbleSort = false;
                BubbleSortClass bubbleSortClass = new BubbleSortClass();
                await bubbleSortClass.BubbleSort(numArr, this);
            }
            if (mergeSort)
            {
                mergeSort = false;
                MergeSortClass mergeSortClass = new MergeSortClass();
                await mergeSortClass.MergeSort(numArr, 0, numArr.Length - 1, this);
            }
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
    }
}
