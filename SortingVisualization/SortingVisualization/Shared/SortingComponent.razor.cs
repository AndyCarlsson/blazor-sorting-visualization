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
        [Inject]
        public SortingComponentBase sortComponent { get; set; }

        public int[] numArr = new int[5];

        public bool bubbleSort = false;
        public bool mergeSort = false;

        public async Task OnNotifyDataChanged()
        {
            await InvokeAsync(() =>
            {
                StateHasChanged();
            });
        }

        protected override void OnInitialized()
        {
            FillArray();
            sortComponent.OnChange += StateHasChanged;
        }

        public void UpdateUI()
        {
            NotifyDataChanged();
        }

        public async void RunSort()
        {
            if (bubbleSort)
            {
                bubbleSort = false;
                BubbleSortClass bubbleSortClass = new BubbleSortClass();
                await bubbleSortClass.BubbleSort(numArr);
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
            NotifyDataChanged();
        }

        public event Action OnChange;

        private void NotifyDataChanged() => OnChange?.Invoke();
    }
}
