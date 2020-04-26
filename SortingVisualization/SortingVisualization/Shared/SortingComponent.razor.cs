using Microsoft.AspNetCore.Components;
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
        public int[] numArr = new int[80];
        

        protected override void OnInitialized()
        {
            FillArray();
        }

        public void UpdateUI()
        {
            this.StateHasChanged();
        }

        public async void CallBubbleSort()
        {
                BubbleSortClass bubbleSortClass = new BubbleSortClass();
                await bubbleSortClass.BubbleSort(numArr, this);
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
