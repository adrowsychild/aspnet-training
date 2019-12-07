using System;

namespace NET.W._2019.Dyl._01
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter the size of the array:");
                string sizeInput = Console.ReadLine();
                if (Int32.TryParse(sizeInput, out int arrSize))
                {
                    Console.WriteLine("Enter the numbers:");

                    int[] arr = new int[arrSize];

                    for (int i = 0; i < arrSize; )
                    {
                        Int32.TryParse(Console.ReadLine(), out int x);
                        if (x.GetType() == typeof(int))
                        {
                            arr[i] = x;
                            i++;
                        }
                    }

                    Console.WriteLine();

                    for (int i = 0; i < arrSize; i++)
                    {
                        Console.WriteLine(arr[i]);
                    }

                    Console.WriteLine();

                    Console.WriteLine("Select the type of sort: ");
                    Console.WriteLine("1 - quickSort");
                    Console.WriteLine("2 - mergeSort");

                    Int32.TryParse(Console.ReadLine(), out int ans);

                    if (ans == 1)
                        quickSort(arr, 0, arrSize - 1);
                    else if (ans == 2)
                        mergeSort(arr, arrSize);


                    Console.WriteLine();

                    for (int i = 0; i < arrSize; i++)
                    {
                        Console.WriteLine(arr[i]);
                    }
                }

                else
                {
                    Console.WriteLine("Incorrect input.");
                }

            }

        }

        static void quickSort(int[] arr, int start, int end)
        {
            if (start < end)
            {
                int pIndex = partition(arr, start, end);

                // recuirsively sort array from the both sides
                quickSort(arr, start, pIndex - 1);
                quickSort(arr, pIndex + 1, end);
            }
        }

        static int partition(int[] arr, int start, int end)
        {
            int pivot = arr[end];
            int pIndex = start;
            int temp;

            for (int i = start; i < end; i++)
            {
                if (arr[i] <= pivot)
                {
                    // swap
                    temp = arr[i];
                    arr[i] = arr[pIndex];
                    arr[pIndex] = temp;
                    pIndex++;
                }
            }

            // swap
            temp = arr[pIndex];
            arr[pIndex] = arr[end];
            arr[end] = temp;

            return pIndex;
        }


        static int[] mergeSort(int[] arr, int arrSize)
        {
            // stops the recursion
            if (arrSize < 2)
                return null;

            int mid = arrSize / 2;
            int llen = mid;
            int rlen = arrSize - mid;

            int[] left = new int[llen];
            int[] right = new int[rlen];

            for (int i = 0; i < llen; i++)
                left[i] = arr[i];

            for (int j = mid; j < arrSize; j++)
                right[j-mid] = arr[j];

            // sort both subarrays and merge them
            mergeSort(left, llen);
            mergeSort(right, rlen);
            merge(arr, left, right, llen, rlen);

            return arr;

        }

        static int[] merge(int[] arr, int[] left, int[] right, int llen, int rlen)
        {
            int i, j, k;

            i = 0; // index of the left subarray
            j = 0; // index of the right subarray
            k = 0; // index of the merge array

            while ((i < llen) && (j < rlen))
            {
                if (left[i] <= right[j])
                {
                    arr[k] = left[i];
                    i++;
                }
                else 
                {
                    arr[k] = right[j];
                    j++;
                }
                k++;
            }

            // we copy the remains of the both subarrays
            while (i < llen)
            {
                arr[k] = left[i];
                k++; i++;
            }

            while (j < rlen)
            {
                arr[k] = right[j];
                k++; j++;
            }

            return arr;
        }
    }
}
