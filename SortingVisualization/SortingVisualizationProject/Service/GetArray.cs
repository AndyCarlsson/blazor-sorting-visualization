using SortingVisualizationProject.Pages;
using SortingVisualizationProject.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SortingVisualizationProject.Service
{
    public class GetArray
    {
        public int[] sortArr = new int[250];

        public int[] smallArr = new int[50];
        public int[] mediumArr = new int[150];
        public int[] bigArr = new int[250];

        public void GetRandomArray(MainPage mainPage)
        {
            int min = 20;
            int max = 620;

            Random rnd = new Random();
            for (int i = 0; i < sortArr.Length; i++)
            {
                sortArr[i] = rnd.Next(min, max);
            }
            mainPage.UpdateUI();
        }

        public void GetSmallArray(MainPage mainPage)
        {
            sortArr = smallArr;

            int min = 20;
            int max = 620;

            Random rnd = new Random();
            for (int i = 0; i < sortArr.Length; i++)
            {
                sortArr[i] = rnd.Next(min, max);
            }
            mainPage.UpdateUI();
        }
        public void GetMediumArray(MainPage mainPage)
        {
            sortArr = mediumArr;

            int min = 20;
            int max = 620;

            Random rnd = new Random();
            for (int i = 0; i < sortArr.Length; i++)
            {
                sortArr[i] = rnd.Next(min, max);
            }
            mainPage.UpdateUI();
        }
        public void GetBigArray(MainPage mainPage)
        {
            sortArr = bigArr;

            int min = 20;
            int max = 620;

            Random rnd = new Random();
            for (int i = 0; i < sortArr.Length; i++)
            {
                sortArr[i] = rnd.Next(min, max);
            }
            mainPage.UpdateUI();
        }
    }
}
