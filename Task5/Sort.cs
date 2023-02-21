using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5;

namespace Task5_sort
{
    public class Sort
    {
        public void Sorts()
        {
            string inputString = Task5.Program.GlobalRev;
            Console.Write("Выберите метод сортировки цифрой (Quicksort(1) / Tree Sort(2)): ");
            string sortingAlgorithm = Console.ReadLine();

            if (sortingAlgorithm == "1")
            {
                Quicksort(inputString);
            }
            else if (sortingAlgorithm == "2")
            {
                TreeSort(inputString);
            }
            else
            {
                Console.WriteLine("Не верно введенные данные");
            }
        }

        public static void Quicksort(string inputString)
        {
            char[] inputArray = inputString.ToCharArray();
            int left = 0;
            int right = inputArray.Length - 1;

            QuickSort(inputArray, left, right);

            Console.WriteLine(inputArray);
        }

        public static void QuickSort(char[] inputArray, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(inputArray, left, right);

                if (pivot > 1)
                {
                    QuickSort(inputArray, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    QuickSort(inputArray, pivot + 1, right);
                }
            }
        }

        public static int Partition(char[] inputArray, int left, int right)
        {
            char pivot = inputArray[left];
            while (true)
            {
                while (inputArray[left] < pivot)
                {
                    left++;
                }

                while (inputArray[right] > pivot)
                {
                    right--;
                }

                if (left < right)
                {
                    if (inputArray[left] == inputArray[right])
                        return right;

                    char temp = inputArray[left];
                    inputArray[left] = inputArray[right];
                    inputArray[right] = temp;
                }
                else
                {
                    return right;
                }
            }
        }

        public static void TreeSort(string inputString)
        {
            char[] inputArray = inputString.ToCharArray();
            Tree tree = new Tree();

            for (int i = 0; i < inputArray.Length; i++)
            {
                tree.Insert(inputArray[i]);
            }

            tree.PrintInorder();
        }



        public class Tree
        {
            public char Value { get; set; }
            public Tree Left { get; set; }
            public Tree Right { get; set; }

            public void Insert(char value)
            {
                if (this.Value == 0)
                {
                    this.Value = value;
                }
                else
                {
                    if (value < this.Value)
                    {
                        if (this.Left == null)
                        {
                            this.Left = new Tree();
                        }
                        this.Left.Insert(value);
                    }
                    else
                    {
                        if (this.Right == null)
                        {
                            this.Right = new Tree();
                        }
                        this.Right.Insert(value);
                    }
                }
            }

            public void PrintInorder()
            {
                if (this.Left != null)
                {
                    this.Left.PrintInorder();
                }

                Console.Write(this.Value + " ");

                if (this.Right != null)
                {
                    this.Right.PrintInorder();
                }
            }
        }
    }
}