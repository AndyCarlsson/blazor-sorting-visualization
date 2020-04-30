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
    public class SortingComponentBase : ComponentBase, IDisposable
    {
        public int[] numArr = new int[300];

        private CancellationTokenSource _cts = new CancellationTokenSource();
        public bool cancel = false;

        protected override void OnInitialized()
        {
            FillArray();
            _cts = new CancellationTokenSource();
        }

        public void UpdateUI()
        {
            this.StateHasChanged();
        }

        public async void CallBubbleSort()
        {
            if (cancel == true)
            {
                
                _cts.Cancel();
                cancel = false;
            }
            else 
            {
                try
                {
                    if (cancel == false)
                    {
                        cancel = true;
                        BubbleSortClass bubbleSortClass = new BubbleSortClass();
                        await bubbleSortClass.BubbleSort(numArr, this, _cts.Token);
                    }

                }
                catch (OperationCanceledException)
                {
                    _cts = new CancellationTokenSource();
                }
            } 
        }
        public async void CallMergeSort()
        {
                MergeSortClass mergeSortClass = new MergeSortClass();
                await mergeSortClass.MergeSort(numArr, 0, numArr.Length -1, this);
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

        public void Dispose()
        {
            if (_cts != null)
            {
                _cts.Dispose();
                _cts = null;
            }
        }
    }
}
