using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBusQueueTriggerFunction
{
    public static class Sorting
    {
        private static void MergeSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;
                MergeSort(array, left, mid);
                MergeSort(array, mid + 1, right);
                Merge(array, left, mid, right);
            }
        }

        public static void MergeSort(int[] array)
        {
            MergeSort(array, 0, array.Length - 1);
        }

        private static void Merge(int[] array, int begin, int mid, int end)
        {

            int left = begin;
            int right = mid + 1;
            int[] temp = new int[(end - begin) + 1];
            int tempIndex = 0;

            while ((left <= mid) && (right <= end))
            {
                if (array[left] < array[right])
                {
                    temp[tempIndex] = array[left];
                    left++;
                }
                else
                {
                    temp[tempIndex] = array[right];
                    right++;
                }
                tempIndex++;
            }

            while (left <= mid)
            {
                temp[tempIndex] = array[left];
                left++;
                tempIndex++;
            }

            while (right <= end)
            {
                temp[tempIndex] = array[right];
                right++;
                tempIndex++;
            }

            for (int i = 0; i < temp.Length; i++)
            {
                array[begin + i] = temp[i];
            }

        }
    }
}
