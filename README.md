# Код Хемминга (построение и проверка на ошибки)
5 домашнее задание по теории информации.
# Скриншоты работы программы в соответствии с вариантом см. в присланном файле

## Меню
1. Проверить по биту чётности
2. Код Хемминга (проверка на ошибку)
3. Код Хемминга (построение)
4. Симметричная матрица расстояний


## Задание 1 (пункт 1 из меню).

На вход подаётся строка, состоящая из 0 и 1 (в противном случае, программа будет работать неправильно).

Далее, программа считает единицы в строке, начиная со второго символа, после чего проверяет чётность суммы единиц и сравнивает с первой цифрой строки (бит чётности по условию задачи).

Если бит чётности выставлен верно, программа выведет сообщение "Ошибки нет", в противном случае, программа выведет "Ошибка в бите чётности".

Подробности реализации см. в комментариях к коду программы (начиная с 15 строки).

## Задание 2 (пункт 2 из меню).

На вход подаётся строка, состоящая из 0 и 1 (в противном случае, программа будет работать неправильно).

Далее, программа ищет контрольные биты по степеням двойки (решение в общем виде для любого количества бит) и проходит по всем подконтрольным ему битам, суммируя подконтрольные биты (в том числе, сам контрольный бит), в случае, если сумма получается нечётной, номер контрольного бита суммируется с переменной, отвечающей за биты с ошибкой (errorNum).

После прохода по всем контрольным битам, программа из суммы битов чётности с ошибкой получает номер ошибочного бита, после чего исправляет его - на 0, если он был равен 1, на 1, если он был равен 0. Выводится исправленное сообщение.

В случае, если сумма контрольных битов с ошибкой равна 0, программа делает вывод, что ошибок передачи нет и выводит соответствующее сообщение.

В случае, если сумма котнрольных битов с ошибкой выходит за границы строки, программа делает вывод, что в коде более одной ошибки, бракует сообщение и выводит соответствующее сообщение.

Подробности реализации см. в комментариях к коду программы (начиная с 39 строки).

## Задание 3 (пункт 3 из меню).

На вход подаётся строка, состоящая из 0 и 1 (в противном случае, программа будет работать неправильно).

Далее, программа проходит по степеням двойки и добавляет нули на места, в которых должны быть контрольные биты.

Аналогично предыдущему пункту, программа считает сумму подконтрольных бит. В случае нечётности суммы меняет контрольный бит на 1 для чётности.

Выводит сообщение с построенным кодом Хемминга.

Подробности реализации см. в комментариях к коду программы (начиная со 101 строки).

## Задание 4 (пункт 4 из меню).

На вход подаётся сначала количество вводимых чисел, затем каждое число (предполагается, что пользователь вводит числа в двоичном коде одинаковой длины, в противном случае программа не работает).

Создаётся квадратная матрица, в которой первая строка и первый столбец - введённые числа.

Для каждой пары чисел ищется кодовое расстояние (функция получает на вход две строки - рассматриваемую пару чисел - и считает количество расхождений в них), которое записывается в матрицу. В процессе выполняется поиск минимального кодового расстояния, путём сравнения получаемых кодовых расстояний с определённым минимумом (изначально взято большое число для последующего сравнения и перезаписи).

Далее, матрица в отформатированном виде выводится на экран.

Подробности реализации см. в комментариях к коду программы (начиная со 141 строки).

Подробности реализации поиска кодового расстояния см. в комментариях к коду программы (начиная с 201 строки).
