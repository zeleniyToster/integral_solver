# integral_solver
IntegralSolver - программа для решения интегралов числено методом трапеций с шагом 0.1.
Для работы с программой из архива с бинарными файлами:
- Перейдите в каталог с файлом `IntegralSolver.exe` и запустите в нем командную строку cmd;
- Наберите `IntegralSolver.exe "<Подынтегральная функия>" "<Верхняя граница интеграла>" "<Нижняя граница интеграла>"`, двойные кавычки обязательны;
Например: `IntegralSolver.exe "(x-1)^2" "2" "1"`

Важное замечание! При вводе подинтегральной функции есть ряд ограничений:
- Избегайте использования пробелов;
- Для степеней используйте только степени из чисел, избегайте использования функций в степенях;
- Избегайте сильно вложенных функций, максимум который удалость посчитать это - `Cos(x^2)^4`;
- Всегда набирайте функции с большой буквы, это ограничение библиотеки для парсинга функций из строки, например `Cos(x^2)^4+Ln(x+5)^2`;
- Для функций действуют их стандратные ограничения;
- Также ниже представлен список поддерживаемых операций и функций;
Список поддерживаемых функций: +, -, *, ^, Exp, Ln, Sin, Cos, Tan


TestIntegralSolver - соответственно программа для загрузки тестовых кейсов и проверки основной программы;
Для работы с программой из архива с бинарными файлами:
- Перейдите в папку с файлом TestIntegralSolver.exe и запустите в нем командную строку cmd;
- Наберите `TestIntegralSolver.exe "<Путь до файла с тестовыми кейсами>"`, двойные кавычки обязательны.
Возьмите файл с тест кейсами, зажмите шифт и нажмите ПКМ по файлу, выберите строку "Копировать как путь" и далее вставьте его в командную строку, например `TestIntegralSolver.exe "C:\test_cases.txt"`


Для работы с программами из архива с исходными файлами.
- Перейдите в папку IntegralSolver и откройте файл `IntegralSolver.sln` в Visual Studio 2022;
- Соберите оба проекта;
- В папках `IntegralSolver` и `TestIntegralSolver` найдите папки bin и провалитесь в них до конца;
- Далее все файлы из этих папок скопируйте в одну;
- Дальше работайте как по инструкции для архива с бинарными данными.