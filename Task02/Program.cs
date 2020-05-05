using System;
using System.Linq;

/* В задаче не использовать циклы for, while. Все действия по обработке данных выполнять с использованием LINQ
 * 
 * На вход подается строка, состоящая из целых чисел типа int, разделенных одним или несколькими пробелами.
 * Необходимо оставить только те элементы коллекции, которые предшествуют нулю, или все, если нуля нет.
 * Дважды вывести среднее арифметическое квадратов элементов новой последовательности.
 * Вывести элементы коллекции через пробел.
 * Остальные указания см. непосредственно в коде.
 * 
 * Пример входных данных:
 * 1 2 0 4 5
 * 
 * Пример выходных:
 * 2,500
 * 2,500
 * 1 2
 * 
 * Обрабатывайте возможные исключения путем вывода на экран типа этого исключения 
 * (не использовать GetType(), пишите тип руками).
 * Например, 
 *          catch (SomeException)
            {
                Console.WriteLine("SomeException");
            }
 * В случае возникновения иных нештатных ситуаций (например, в случае попытки итерирования по пустой коллекции) 
 * выбрасывайте InvalidOperationException!
 */
namespace Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            RunTesk02();
        }

        public static void RunTesk02()
        {
            int[] arr;
            try
            {
                // Попробуйте осуществить считывание целочисленного массива, записав это ОДНИМ ВЫРАЖЕНИЕМ.
                arr = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(str => int.Parse(str)).ToArray();
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("ArgumentNullException");
                return;
            }
            catch (ArgumentException)
            {
                Console.WriteLine("ArgumentException");
                return;
            }
            catch (FormatException)
            {
                Console.WriteLine("FormatException");
                return;
            }
            catch (OverflowException)
            {
                Console.WriteLine("OverflowException");
                return;
            }


            var filteredCollection = arr.TakeWhile(a => a != 0).ToArray();

            try
            {

                // использовать статическую форму вызова метода подсчета среднего
                double averageUsingStaticForm = Enumerable.Aggregate(filteredCollection, 0,
                    (int prev, int next) => checked(prev + next * next),
                    (int result) => (double)result / filteredCollection.Length);
                Console.WriteLine($"{averageUsingStaticForm:F3}".Replace('.', ','));
                // использовать объектную форму вызова метода подсчета среднего
                double averageUsingInstanceForm = filteredCollection.Aggregate(0,
                    (prev, next) => prev + next * next,
                    result => (double)result / filteredCollection.Length);
                Console.WriteLine($"{averageUsingInstanceForm:F3}".Replace('.', ','));

                // вывести элементы коллекции в одну строку
                Console.WriteLine(filteredCollection.Select(el => el.ToString()).Aggregate("",
                (string prev, string next) => prev + next + " ",
                (string result) => result.Substring(0, result.Length - 1)));
            }
            catch (OverflowException)
            {
                Console.WriteLine("OverflowException");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("ArgumentNullException");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("InvalidOperationException");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("ArgumentOutOfRangeException");
            }
        }

    }
}
