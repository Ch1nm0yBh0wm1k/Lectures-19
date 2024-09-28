//// See https://aka.ms/new-console-template for more information
////using System.Security.Cryptography;

////Console.WriteLine("Hello, World!");
//using System;

//int b = 2;
//double a = b;
//int c = (int)a;
////int d = Convert.ToInt(a);

////scan input
////int x = Convert.ToInt32(Console.ReadLine());

//string isTrue = "";
//String xyz = "";

//int[] arr = { 1, 3, 5};

//foreach(var item in arr)
//{
//    Console.WriteLine(item);
//}
//PrintSomething();

//static void PrintSomething()
//{
//    Console.WriteLine("I am from method");
//}

//binary search

int[] array = { 1, 2, 3, 4, 8, 0 };
Array.Sort(array);
int key = Convert.ToInt32(Console.ReadLine());
Console.WriteLine(BinarySearch(array, key));
static string BinarySearch(int[] arr, int key)
{
    int min = 0;
    int max = arr.Length - 1;
    int mid = 0;

    while (min <= max)
    {
        mid = (min + max) / 2;

        if (key == arr[mid])
            return "Found";
        else if (key < arr[mid])
            max = mid - 1;
        else if (key > arr[mid])
            min = mid + 1;

    }
    return "Not Found";



}

