using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

class Program
{
    const int N = 100000; // Розмір списків
    const int InsertCount = 1000; // Кількість вставок

    static void Main()
    {
        ArrayList arrayList = new ArrayList();
        LinkedList<int> linkedList = new LinkedList<int>();

        // 1. Заповнення списків випадковими числами
        Console.WriteLine("Заповнення списків...");
        Random random = new Random();

        Stopwatch stopwatch = new Stopwatch();

        // ArrayList
        stopwatch.Start();
        for (int i = 0; i < N; i++)
        {
            arrayList.Add(random.Next(N));
        }
        stopwatch.Stop();
        Console.WriteLine($"ArrayList заповнено за: {stopwatch.ElapsedMilliseconds} мс");

        // LinkedList
        stopwatch.Restart();
        for (int i = 0; i < N; i++)
        {
            linkedList.AddLast(random.Next(N));
        }
        stopwatch.Stop();
        Console.WriteLine($"LinkedList заповнено за: {stopwatch.ElapsedMilliseconds} мс");

        // 2. Random Access
        Console.WriteLine("\nRandom Access (доступ за індексом):");

        // ArrayList
        stopwatch.Restart();
        for (int i = 0; i < N; i++)
        {
            var item = arrayList[random.Next(N)];
        }
        stopwatch.Stop();
        Console.WriteLine($"ArrayList доступ за індексом: {stopwatch.ElapsedMilliseconds} мс");

        // LinkedList
        stopwatch.Restart();
        for (int i = 0; i < N; i++)
        {
            var item = GetElementAt(linkedList, random.Next(N));
        }
        stopwatch.Stop();
        Console.WriteLine($"LinkedList доступ за індексом: {stopwatch.ElapsedMilliseconds} мс");

        // 3. Sequential Access (ітерація списком)
        Console.WriteLine("\nSequential Access (ітерація списком):");

        // ArrayList
        stopwatch.Restart();
        foreach (var item in arrayList) { }
        stopwatch.Stop();
        Console.WriteLine($"ArrayList ітерація: {stopwatch.ElapsedMilliseconds} мс");

        // LinkedList
        stopwatch.Restart();
        foreach (var item in linkedList) { }
        stopwatch.Stop();
        Console.WriteLine($"LinkedList ітерація: {stopwatch.ElapsedMilliseconds} мс");

        // 4. Вставка елементу на початок
        Console.WriteLine("\nВставка на початок:");

        // ArrayList
        stopwatch.Restart();
        for (int i = 0; i < InsertCount; i++)
        {
            arrayList.Insert(0, random.Next(N));
        }
        stopwatch.Stop();
        Console.WriteLine($"ArrayList вставка на початок: {stopwatch.ElapsedMilliseconds} мс");

        // LinkedList
        stopwatch.Restart();
        for (int i = 0; i < InsertCount; i++)
        {
            linkedList.AddFirst(random.Next(N));
        }
        stopwatch.Stop();
        Console.WriteLine($"LinkedList вставка на початок: {stopwatch.ElapsedMilliseconds} мс");

        // 5. Вставка елементу в кінець
        Console.WriteLine("\nВставка в кінець:");

        // ArrayList
        stopwatch.Restart();
        for (int i = 0; i < InsertCount; i++)
        {
            arrayList.Add(random.Next(N));
        }
        stopwatch.Stop();
        Console.WriteLine($"ArrayList вставка в кінець: {stopwatch.ElapsedMilliseconds} мс");

        // LinkedList
        stopwatch.Restart();
        for (int i = 0; i < InsertCount; i++)
        {
            linkedList.AddLast(random.Next(N));
        }
        stopwatch.Stop();
        Console.WriteLine($"LinkedList вставка в кінець: {stopwatch.ElapsedMilliseconds} мс");

        // 6. Вставка елементу в середину
        Console.WriteLine("\nВставка в середину:");

        int middleIndex = N / 2;

        // ArrayList
        stopwatch.Restart();
        for (int i = 0; i < InsertCount; i++)
        {
            arrayList.Insert(middleIndex, random.Next(N));
        }
        stopwatch.Stop();
        Console.WriteLine($"ArrayList вставка в середину: {stopwatch.ElapsedMilliseconds} мс");

        // LinkedList
        var middleNode = GetElementAtNode(linkedList, middleIndex);
        stopwatch.Restart();
        for (int i = 0; i < InsertCount; i++)
        {
            linkedList.AddBefore(middleNode, random.Next(N));
        }
        stopwatch.Stop();
        Console.WriteLine($"LinkedList вставка в середину: {stopwatch.ElapsedMilliseconds} мс");
    }

    // Метод для отримання елемента LinkedList за індексом
    static int GetElementAt(LinkedList<int> list, int index)
    {
        var node = list.First;
        for (int i = 0; i < index; i++)
        {
            node = node.Next;
        }
        return node.Value;
    }

    // Метод для отримання вузла LinkedList за індексом
    static LinkedListNode<int> GetElementAtNode(LinkedList<int> list, int index)
    {
        var node = list.First;
        for (int i = 0; i < index; i++)
        {
            node = node.Next;
        }
        return node;
    }
}
