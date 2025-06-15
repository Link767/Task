using System.IO;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CleverensSoftTask3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileReadAndParsFormat();
        }

        static void FileReadAndParsFormat()
        {
            string text;
            string Problempath = "C:\\Users\\BUddha\\Git\\Task\\CleverensSoftTask3\\CleverensSoftTask3\\bin\\Debug\\net8.0\\problems.txt";
            Console.WriteLine("Укажите путь к файлу:");
            string filePath = Console.ReadLine();
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    while ((text = reader.ReadLine()) != null)
                    {
                        try
                        {
                            if (text.Contains("|"))
                            {
                                var parst = text.Split('|');
                                if (parst.Length > 0)
                                    ParsLineFormat2(text);
                            }
                            else if (text.Contains(" "))
                            {
                                var parst = text.Split(' ', 4);
                                if (parst.Length >= 4)
                                    ParsLineFormat1(text);
                            }
                        }
                        catch
                        {
                            using (StreamWriter writer = new StreamWriter(Problempath, true))
                            {
                                writer.WriteLineAsync("Не валидные данные");
                            }
                        }
                    }
                }
            }
            catch
            {
                using (StreamWriter writer = new StreamWriter(Problempath, true))
                {
                    writer.WriteLineAsync("Ошибка открытия файла");
                }
            }
        }
        static void ParsLineFormat1(string line)
        {
            string[] lines = line.Split(new char[] {' '}, 4, StringSplitOptions.RemoveEmptyEntries);
            //Получаем дату и приводим ее к нормальному виду
            DateOnly formatdate = DateOnly.Parse(lines[0]);
            string normalDate = formatdate.ToString("dd-MM-yyyy");
            string normaltime = lines[1];
            string normalLog = null;
            string normalMet = null;
            string mess = lines[3];
            string defa = "DEFAULT";
            switch (lines[2])
            {
                case "INFORMATION":
                    normalLog = "INFO";
                    break;
                case "WARNING":
                    normalLog = "WARN";
                    break;
                case "ERROR":
                    normalLog = "ERROR";
                    break;
                case "DEBUG":
                    normalLog = "DEBUG";
                    break;
                case "INFO":
                    normalLog = "INFO";
                    break;
                case "WARN":
                    normalLog = "WARN";
                    break;
            }
            string normLine = $"{normalDate}\t{normaltime}\t{normalLog}\t{defa}\t{mess}";
            CreateLogFile(normLine);


        }
        static void ParsLineFormat2(string line)
        {
            string[] lines = line.Split(new char[] { '|', ' '}, 6, StringSplitOptions.RemoveEmptyEntries);
            DateOnly formatdate = DateOnly.Parse(lines[0]);
            string normalDate = formatdate.ToString("dd-MM-yyyy");
            string normaltime = lines[1];
            string normalLog = null;
            string normalMet = lines[4];
            string mess = line.Substring(line.IndexOf(lines[5]));
            switch (lines[2])
            {
                case "INFORMATION":
                    normalLog = "INFO";
                    break;
                case "WARNING":
                    normalLog = "WARN";
                    break;
                case "ERROR":
                    normalLog = "ERROR";
                    break;
                case "DEBUG":
                    normalLog = "DEBUG";
                    break;
                case "INFO":
                    normalLog = "INFO";
                    break;
                case "WARN":
                    normalLog = "WARN";
                    break;
            }
            string normLine = $"{normalDate}\t{normaltime}\t{normalLog}\t{normalMet}\t{mess}";
            CreateLogFile(normLine);
        }
        static void CreateLogFile(string normalLine)
        {
            Console.WriteLine("Введите путь сохранения файла");
            string path = Console.ReadLine();
            Console.WriteLine("Перезаписать[0]|Добавить[1]");
            int flag = Convert.ToInt32(Console.ReadLine());
            try 
            { 
                switch (flag)
                {
                    case 0:
                       using (StreamWriter writer = new StreamWriter(path, false))
                       {
                            writer.WriteLineAsync(normalLine);
                       }
                    break;
                    case 1:
                        using (StreamWriter writer = new StreamWriter(path, true))
                        {
                            writer.WriteLine(normalLine);
                        }
                    break;
                } 
            }
            catch
            {
                using (StreamWriter writer = new StreamWriter(path, false))
                {
                    writer.WriteLineAsync("Ошибка записи в файл");
                }
            }
        }
    }
}