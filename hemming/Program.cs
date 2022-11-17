class Program
{
  static void Main(string[] args)
  {
    while (true)
    {
      Console.WriteLine("1. Проверить по биту чётности");
      Console.WriteLine("2. Код Хемминга (проверка на ошибку)");
      Console.WriteLine("3. Код Хемминга (построение)");
      Console.WriteLine("4. Симметричная матрица расстояний");
      string sel = Console.ReadLine();
      string num; // Число в двоичном коде, подаваемое на вход
      switch (sel)
      {
        case "1":
          Console.Write("Введите число: ");
          num = Console.ReadLine();
          int counter = 0;
          for (int i = 1; i < num.Length; i++) // Первая цифра - бит чётности, его не считаем
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
          }
          else
          {
            Console.WriteLine("Ошибка в бите чётности");
            Console.ReadKey();
          }
          break;


        case "2":
          Console.Write("Введите число: ");
          num = Console.ReadLine();

          int errorNum = 0; // Номер контрольного бита с ошибкой. Если остаётся равным 0 - ошибки передачи нет
          int step2 = 1; // Степени двойки
          string kusok = ""; // Кусок кода, который контролирует определённый контр. бит
          int bitCounter = 0; // Счётчик бит в выделенном куске

          while (step2 <= num.Length) // Проходим по степеням двойки (решение в общем виде для любого количества бит)
          {
            for (int i = step2 - 1; i < num.Length; i += step2 * 2) //Проход с N-ного символа и скип через N символов
            {
              if (i + step2 >= num.Length) kusok = num.Substring(i, num.Length - i); // В случае, если нужное кол-во бит выходит за границу, обрезаем
              else kusok = num.Substring(i, step2);

              for (int j = 0; j < kusok.Length; j++) // Считаем биты
              {
                bitCounter += (kusok[j] - '0'); // Преобразуем в int и считаем сумму битов
              }


            }
            if (bitCounter % 2 != 0) // Проверяем сумму на чётность, если нечётный - суммируем номер бита с ошибкой в переменную
            {
              errorNum += step2;
            }
            bitCounter = 0; // Обнуляем счётчик битов


            step2 *= 2; // Переходим к следующей степени двойки
          }

          if (errorNum != 0 && errorNum <= num.Length)
          {
            Console.WriteLine("Ошибка в " + errorNum + " бите");
            if (num[errorNum - 1] == '0') // Исправляем ошибку передачи при её наличии
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
          }
          else if (errorNum == 0)
          {
            Console.WriteLine("Ошибок передачи нет");
          }
          else if (errorNum > num.Length)
          {
            Console.WriteLine("Код содержит более одной ошибки");
          }

          Console.ReadKey();
          break;


        case "3":
          Console.Write("Введите число: ");
          num = Console.ReadLine();
          step2 = 1; // Степени двойки
          bitCounter = 0; // Счётчик бит в выделенном куске
          kusok = "";

          while (step2 <= num.Length) // Проходим по степеням двойки, вставляем нули на место контролирующих битов
          {
            num = num.Insert(step2 - 1, "0");
            step2 *= 2;
          }
          step2 = 1; // "Обнуление" степени двойки

          while (step2 <= num.Length) // Проходим по степеням двойки (решение в общем виде для любого количества бит)
          {
            for (int i = step2 - 1; i < num.Length; i += step2 * 2) //Проход с N-ного символа и скип через N символов
            {
              if (i + step2 >= num.Length) kusok = num.Substring(i, num.Length - i); // В случае, если нужное кол-во бит выходит за границу, обрезаем
              else kusok = num.Substring(i, step2);

              for (int j = 0; j < kusok.Length; j++) // Считаем биты
              {
                bitCounter += (kusok[j] - '0'); // Преобразуем в int и считаем сумму битов
              }

            }
            if (bitCounter % 2 != 0) // Проверяем сумму на чётность, если нечётный - меняем контрольный бит на 1 для чётности
            {
              num = num.Remove(step2 - 1, 1);
              num = num.Insert(step2 - 1, "1");
            }
            bitCounter = 0; // Обнуляем счётчик битов

            step2 *= 2; // Переходим к следующей степени двойки
          }
          Console.WriteLine("Код Хемминга: " + num);
          Console.ReadKey();
          break;

        case "4":
          Console.Write("Введите количество чисел для построения таблицы: ");
          string count = Console.ReadLine();
          string[,] matrixOfDistance = new string[Int32.Parse(count) + 1, Int32.Parse(count) + 1]; // Матрица расстояний. Первые единицы в строке и стобце будут занимать числа
          for(int i = 1; i <= Int32.Parse(count); i++) // Записываем числа из условия задачи
          {
            Console.Write("Число №" + i + ": ");
            matrixOfDistance[i, 0] = Console.ReadLine();
            matrixOfDistance[0, i] = matrixOfDistance[i, 0];
          }
          int dmin = 99999; // Минимальное кодовое расстояние, изначально взято большое число
          for (int i = 1; i <= Int32.Parse(count); i++) // Вычисляем кодовое расстояние для каждой пары
          {
            for (int j = 1; j <= Int32.Parse(count); j++)
            {
              matrixOfDistance[i, j] = CodeDistance(matrixOfDistance[i, 0], matrixOfDistance[0, j]).ToString();
              if(matrixOfDistance[i, j] == "0") // Замена нулевого кодового расстояния прочерком
              {
                matrixOfDistance[i, j] = "-";
              } else if(dmin > Int32.Parse(matrixOfDistance[i, j])) // Поиск минимального кодового расстояния
              {
                dmin = Int32.Parse(matrixOfDistance[i, j]);
              }
            }
          }

          Console.WriteLine();
          Console.WriteLine();
          Console.WriteLine("Матрица кодовых расстояний:");
          Console.WriteLine();
          Console.WriteLine();
          string output = "";
          for (int i = 0; i <= Int32.Parse(count); i++) // Выводим матрицу кодовых расстояний
          {
            for(int j = 0; j <= Int32.Parse(count); j++)
            {
              output = string.Format("{0, 10}", matrixOfDistance[i, j]); // Форматирование строк. На каждую выделяется количество символов, равное количеству введённых чисел
              Console.Write(output);
            }
            
            Console.WriteLine();
            
          }
          Console.WriteLine();
          Console.WriteLine("d min = " + dmin);
          Console.ReadLine();
          break;

        default:
          Console.WriteLine("Ошибка ввода!");
          Console.ReadKey();
          break;
      }

      Console.Clear();

    }

  }

  static int CodeDistance(string firstNum, string secondNum) // На вход подаются две строки, содержащие в себе два кодовых расстояния
  {
    int dist = 0; // Кодовое расстояние

    for(int i = 0; i < firstNum.Length; i++) // Считаем несовпадающие позиции
    {
      if (firstNum[i] != secondNum[i])
      {
        dist++;
      }
    }

    return dist;
  }
}
