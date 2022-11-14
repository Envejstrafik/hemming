﻿
while (true)
{
  Console.WriteLine("1. Проверить по биту чётности");
  Console.WriteLine("2. Код Хемминга (проверка на ошибку)");
  Console.WriteLine("3. Код Хемминга (построение)");
  string sel = Console.ReadLine();
  string num;
  switch (sel)
  {
    case "1":
      Console.Write("Введите число: ");
      num = Console.ReadLine();
      int counter = 0;
      for(int i = 1; i < num.Length; i++) // Первая цифра - бит чётности, его не считаем
      {
        if (num[i] == '1')
        {
          counter++;
        }
      }
      if (((counter % 2 == 0) && (num[0] == '0')) || (counter % 2 != 0) && (num[0] == '1'))
      {
        Console.WriteLine("Ошибки нет");
        Console.ReadKey();
      } else
      {
        Console.WriteLine("Ошибка в бите чётности");
        Console.ReadKey();
      }
      break;


    case "2":
      Console.Write("Введите число: ");
      num = Console.ReadLine();

      int errorNum = 0;
      int step2 = 1; // Степени двойки
      string kusok = ""; // Кусок кода, который контролирует определённый контр. бит
      int bitCounter = 0; // Счётчик бит в выделенном куске
      
      while (step2 <= num.Length) // Проходим по степеням двойки (решение в общем виде для любого количества бит)
      {
        for (int i = step2 - 1; i < num.Length; i += step2 * 2) //Проход с N-ного символа и скип через N символов
        {
          if (i + step2 >= num.Length) kusok = num.Substring(i, num.Length - i); // В случае, если нужное кол-во бит выходит за границу, обрезаем
          else  kusok = num.Substring(i, step2);
         // Console.WriteLine("контр бит = " + step2 + ",  биты = " + kusok);

          for(int j = 0; j < kusok.Length; j++) // Считаем биты
          {
            bitCounter += (kusok[j] - '0'); // Преобразуем в int и считаем сумму битов
          }
      
         // Console.WriteLine("контр бит = " + step2 + ",  биты = " + kusok + ",  сумма = " + bitCounter + ",  бит с ошибкой = " + errorNum);
          
        }
        if (bitCounter % 2 != 0) // Проверяем сумму на чётность, если нечётный - суммируем номер бита с ошибкой в переменную
        {
          errorNum += step2;
        }
        bitCounter = 0;


        step2 *= 2;
      }
      Console.WriteLine("Ошибка в " + errorNum + " бите");

      if (num[errorNum - 1] == '0') // Исправляем ошибку передачи
      {
        num = num.Remove(errorNum - 1, 1);
        num = num.Insert(errorNum - 1, "1");
      }
      else
      if (num[errorNum - 1] == '1')
      {
        num = num.Remove(errorNum - 1, 1);
        num = num.Insert(errorNum - 1, "0");
      }

      Console.WriteLine("Исправленное сообщение: " + num);
      Console.ReadKey();
      break;


    case "3":
      Console.Write("Введите число: ");
      num = Console.ReadLine();
      step2 = 1; // Степени двойки
      int startLen = num.Length; // Запоминаем изначальную длину строки
      bitCounter = 0; // Счётчик бит в выделенном куске
      kusok = "";
      while (step2 <= num.Length) // Проходим по степеням двойки, добавляем нули на место контролирующих битов
      {
        num = num.Insert(step2 - 1, "0");
        step2 *= 2;
      }
      step2 = 1;

      while (step2 <= num.Length) // Проходим по степеням двойки (решение в общем виде для любого количества бит)
      {
        for (int i = step2 - 1; i < num.Length; i += step2 * 2) //Проход с N-ного символа и скип через N символов
        {
          if (i + step2 >= num.Length) kusok = num.Substring(i, num.Length - i); // В случае, если нужное кол-во бит выходит за границу, обрезаем
          else kusok = num.Substring(i, step2);
          // Console.WriteLine("контр бит = " + step2 + ",  биты = " + kusok);

          for (int j = 0; j < kusok.Length; j++) // Считаем биты
          {
            bitCounter += (kusok[j] - '0'); // Преобразуем в int и считаем сумму битов
          }
          
          Console.WriteLine("контр бит = " + step2 + ",  биты = " + kusok + ",  сумма = " + bitCounter);

          

        }
        if (bitCounter % 2 != 0) // Проверяем сумму на чётность, если нечётный - суммируем номер бита с ошибкой в переменную
        {
          num = num.Remove(step2 - 1, 1);
          num = num.Insert(step2 - 1, "1");
        }
        bitCounter = 0;
        // Console.WriteLine("контр бит = " + step2 + ",  биты = " + kusok + ",  сумма = " + bitCounter + ",  бит с ошибкой = " + errorNum);


        step2 *= 2;
      }
      Console.WriteLine("Код Хемминга: " + num);
      Console.ReadKey();
      break;



    default:
      Console.WriteLine("Ошибка ввода!");
      Console.ReadKey();
      break;
  }

  Console.Clear();

}