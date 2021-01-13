using System;

// ReSharper disable InconsistentNaming
#pragma warning disable SA1611

namespace SelectionSort
{
    public static class Sorter
    {
        /// <summary>
        /// Sorts an <paramref name="array"/> with selection sort algorithm.
        /// </summary>
        public static void SelectionSort(this int[] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            int temp, index;
            for (int i = 0; i < array.Length - 1; i++)
            {
                index = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[index])
                    {
                        index = j;
                    }
                }

                temp = array[index];
                array[index] = array[i];
                array[i] = temp;
            }
        }

        /// <summary>
        /// Sorts an <paramref name="array"/> with recursive selection sort algorithm.
        /// </summary>
        public static void RecursiveSelectionSort(this int[] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            SortArray(array, array.Length);
        }

        private static void SortArray(int[] array, int length, int index = 0)
        {
            if (index == length)
            {
                return;
            }

            int k = MinIndex(array, index, length - 1);

            if (k != index)
            {
                int temp = array[k];
                array[k] = array[index];
                array[index] = temp;
            }

            SortArray(array, length, index + 1);
        }

        private static int MinIndex(int[] array, int i, int j)
        {
            if (i == j)
            {
                return i;
            }

            int k = MinIndex(array, i + 1, j);

            return (array[i] < array[k]) ? i : k;
        }
    }
}
