namespace HyperLib
{
    public class IntegerSort
    {
        public IntegerSort()
        {

        }

        public static int[] bubbleSort(int[] data)
        {
            bool newLoopNeeded = false;
            int temp;
            int loop = 0;

            while (!newLoopNeeded)
            {
                newLoopNeeded = true;
                for (int i = 0; i < data.Length - 1; i++)
                {
                    if (data[i + 1] < data[i])
                    {
                        temp = data[i];
                        data[i] = data[i + 1];
                        data[i + 1] = temp;
                        newLoopNeeded = false;
                    }
                    loop++;
                }
            }

            return data;
        }

        public static int[] insertionSort(int[] data)
        {
            for (int i = 0; i < data.Length - 1; i++)
            {
                int j = i + 1;

                while (j > 0)
                {
                    if (data[j - 1] > data[j])
                    {
                        int temp = data[j - 1];
                        data[j - 1] = data[j];
                        data[j] = temp;

                    }
                    j--;
                }
            }
            return data;
        }

        public static int[] quickSort(int[] data, int start, int end)
        {
            if (start >= end)
            {
                return data;
            }

            int num = data[start];

            int i = start, j = end;

            while (i < j)
            {
                while (i < j && data[j] > num)
                {
                    j--;
                }

                data[i] = data[j];

                while (i < j && data[i] < num)
                {
                    i++;
                }

                data[j] = data[i];
            }

            data[i] = num;
            quickSort(data, start, i - 1);
            quickSort(data, i + 1, end);

            return data;
        }
    }
}
