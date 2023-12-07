using System;


namespace Lab4
{
    public class MyArr
    {
        private int[] arr;
        private int size;
        public int Size
        {
            get { return size; }
        }


        public MyArr(int n)
        {
            size = n;
            arr = new int[n];
        }
        public void InputData()
        {
            Console.WriteLine("Введите данные массива:");
            for (int i = 0; i < size; i++)
            {
                Console.Write(i+1 +")");
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
        }
        public void InputDataRandom()
        {
            Console.WriteLine("Случайное задание числами от 0 до 10");
            Random rnd = new Random();
            for (int i = 0; i < size; i++)
                arr[i] = rnd.Next(0, 10);
        }
        public void Print()
        {
            Console.Write("Массив: ");
            for (int i = 0; i < size; i++)
                Console.Write($"{arr[i]} ");
            Console.WriteLine();
        }
        public void PrintArray(int[] array)
        {
            Console.Write("Массив: ");
            foreach (int item in array)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
        public string FindValue(in int num)
        {
            string res = "Индексы: ";
            int counter = 0;
            for (int i = 0; i < size; i++)
            {
                if (arr[i] == num)
                {
                    counter++;
                    res += $"{i + 1} ";
                }
            }
            return res;
        }
        public void DelValue(int num)
        {
            int counter = 0;
            for (int i = 0; i < size; i++)
            {
                if (arr[i] == num)
                    counter++;
            }
            if (counter == 0)
            {
                Console.WriteLine("Искомый элемент не найден");
                return;
            }
            int[] newArr = new int[size - counter];
            int ind = 0;
            for (int i = 0; i < size; i++)
            {
                if (arr[i] == num)
                    continue;
                newArr[ind++] = arr[i];
            }
            arr = newArr;
            size -= counter;
        }
        public void FindMax(out int res)
        {
            res = 0;
            foreach (int i in arr)
            {
                if (i > res)
                    res = i;
            }
        }
        public int this[int index]
        {
            get { return arr[index]; }
            set { arr[index] = value; }
        }
        public static void Sort(ref MyArr myArr)
        {
            for (int i = 0; i < myArr.size; i++)
            {
                for (int j = i + 1; j < myArr.size; j++)
                {
                    if (myArr.arr[i] > myArr.arr[j])
                    {
                        int temp = myArr.arr[i];
                        myArr.arr[i] = myArr.arr[j];
                        myArr.arr[j] = temp;
                    }
                }
            }
        }
    }
    public class Program3
    {
        static void Main(string[] args)
        {
            
            MyArr arr = new MyArr(5);

            while (true)
            {
                Console.WriteLine("1. InputData - задание массива пользователем");
                Console.WriteLine("2. InputDataRandom - задание случайными числами");
                Console.WriteLine("3. Print - вывод массива");
                Console.WriteLine("4. FindValue - возвращает список индексов для искомого элемента");
                Console.WriteLine("5. DelValue - удаляет из массива искомый элемент");
                Console.WriteLine("6. FindMax- возвращает максимальное значение");
                Console.WriteLine("7. Add - сложение двух массивов одинаковой длины поэлементно");
                Console.WriteLine("8. Сортировка");
                Console.WriteLine("0. Выход");

                Console.Write("Выберите опцию: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        arr.InputData();
                        //arr.Print();
                        break;

                    case "2":
                        arr.InputDataRandom();
                        //arr.Print();
                        break;

                    case "3":
                        arr.Print();
                        break;

                    case "4":
                        Console.Write("Введите число для поиска: ");
                        if (int.TryParse(Console.ReadLine(), out int searchNumber))
                        {
                            string result = arr.FindValue(searchNumber);
                            Console.WriteLine(result);
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ввод числа.");
                        }
                        break;

                    case "5":
                        Console.Write("Введите число для удаления: ");
                        if (int.TryParse(Console.ReadLine(), out int deleteNumber))
                        {
                            arr.DelValue(deleteNumber);
                            Console.WriteLine($"Элементы {deleteNumber} удалены из массива.");
                            arr.Print(); 
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ввод числа.");
                        }
                        break;

                    
                    case "6":
                        int max;
                        arr.FindMax(out max);
                        Console.WriteLine($"Максимальный элемент в массиве: {max}");
                        break;


                    case "7":
                        Console.WriteLine("Введите данные для второго массива:");
                        MyArr arr2 = new MyArr(arr.Size);
                        arr2.InputData();

                        
                        if (arr.Size != arr2.Size)
                        {
                            Console.WriteLine("Невозможно выполнить сложение. Размеры массивов не совпадают.");
                        }
                        else
                        {
                            int[] resultArr = new int[arr.Size];
                            for (int i = 0; i < arr.Size; i++)
                            {
                                resultArr[i] = arr[i] + arr2[i];
                            }

                            Console.WriteLine("Результат сложения массивов:");
                            arr.PrintArray(resultArr);
                        }
                        break;

                    case "8":
                        MyArr.Sort(ref arr);
                        
                        break;

                    case "0":
                        Console.WriteLine("Выход из программы. До свидания!");
                        return;

                    default:
                        Console.WriteLine("Некорректный ввод. Пожалуйста, введите число от 0 до 8.");
                        break;
                }


                Console.WriteLine();
            }

        }
    }
}