namespace Task1CleverensSoft
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string line = InputLine();
            ErrorPrint(line);
            int flag = InputFlags();

            switch (flag)
            {
                case 0:
                    CompressString(line);
                    break;
                case 1:
                    DecompressString(line);
                    break;
            }
        }
        static string InputLine()
        {
            Console.WriteLine("Введите строку:");
            string line = Console.ReadLine();
            return line;
        }
        static int InputFlags()
        {
            Console.WriteLine("Сжать строку[0] или Разжать строку[1]");
            int flag = Convert.ToInt32(Console.ReadLine());
            return flag;
        }

        static void CompressString(string line)
        {
            char x = line[0];
            int count = 1;
            var res = new System.Text.StringBuilder();

            for (int i = 1; i < line.Length; i++)
            {
                if (line[i] == x)
                    count++;
                else
                {
                    res.Append(x);
                    if (count > 1)
                        res.Append(count);

                    x = line[i];
                    count = 1;
                }
            }

            res.Append(x);
            if (count > 1)
                res.Append(count);

            Console.WriteLine($"Вывод:{res}");
        }
        static void DecompressString(string line)
        {
            var res = new System.Text.StringBuilder();
            char x = '\0';
            string NumBuffer = "";

            foreach (char c in line)
            {
                if (char.IsLetter(c))
                {
                    if (NumBuffer.Length > 0 && x != '\0')
                    {
                        int count = int.Parse(NumBuffer);
                        res.Append(new string(x, count));
                        NumBuffer = "";
                    }
                    else
                        res.Append(x);

                    x = c;
                }
                else if (char.IsDigit(c))
                {
                    NumBuffer += c;
                }
            }
            if (NumBuffer.Length > 0 && x != '\0')
            {
                int count = int.Parse(NumBuffer);
                res.Append(new string(x, count));
            }
            else if (x != '\0')
                res.Append(x);

            Console.WriteLine($"Вывод:{res}");
        }
        static void ErrorPrint(string line)
        {
            if (string.IsNullOrEmpty(line))
            {
                Console.WriteLine("Ошибка: пустрая строка");
                Environment.Exit(0);
            }
        }
    }
}
