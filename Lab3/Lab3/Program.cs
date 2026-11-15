using System;
using System.Text;

namespace ExtensionsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("=== 1. ДЕМОНСТРАЦІЯ МЕТОДІВ РОЗШИРЕННЯ ===");

            string text = "Програмування на C#";
            char searchChar = 'а';
            Console.WriteLine($"Оригінальний рядок: {text}");
            Console.WriteLine($"Інвертований рядок: {text.ReverseString()}");
            Console.WriteLine($"Кількість входжень символа '{searchChar}': {text.CountChar(searchChar)}\n");

            int[] numbers = { 10, 20, 10, 30, 40, 20, 10, 50 };
            Console.WriteLine("Масив чисел: " + string.Join(", ", numbers));
            Console.WriteLine($"Число 10 зустрічається: {numbers.CountOccurrences(10)} раз(и)");
            int[] uniqueNumbers = numbers.GetUniqueElements();
            Console.WriteLine("Унікальні числа: " + string.Join(", ", uniqueNumbers) + "\n");

            string[] words = { "apple", "banana", "apple", "orange", "banana" };
            Console.WriteLine("Масив слів: " + string.Join(", ", words));
            Console.WriteLine($"Слово 'apple' зустрічається: {words.CountOccurrences("apple")} раз(и)");
            string[] uniqueWords = words.GetUniqueElements();
            Console.WriteLine("Унікальні слова: " + string.Join(", ", uniqueWords));

            Console.WriteLine("\n=== 2. ДЕМОНСТРАЦІЯ EXTENDED DICTIONARY ===");

            var products = new ExtendedDictionary<int, string, double>();

            products.Add(101, "Ноутбук", 32500.50);
            products.Add(102, "Мишка", 850.00);
            products.Add(103, "Клавіатура", 1900.75);

            Console.WriteLine($"Кількість товарів у словнику: {products.Count}");

            Console.WriteLine("\nВміст словника:");
            foreach (var item in products)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"\nПошук за індексатором [102]: {products[102]}");

            Console.WriteLine($"Чи є ключ 101? -> {products.ContainsKey(101)}");
            Console.WriteLine($"Чи є товар ('Мишка', 850.00)? -> {products.ContainsValues("Мишка", 850.00)}");
            Console.WriteLine($"Чи є товар ('Монітор', 5000)? -> {products.ContainsValues("Монітор", 5000)}");

            Console.WriteLine("\nВидаляємо елемент із ключем 102...");
            products.Remove(102);
            Console.WriteLine($"Кількість елементів після видалення: {products.Count}");

            Console.WriteLine("Оновлений список:");
            foreach (var item in products)
            {
                Console.WriteLine($"ID: {item.Key} -> {item.Value1} ({item.Value2} грн)");
            }
        }
    }
}