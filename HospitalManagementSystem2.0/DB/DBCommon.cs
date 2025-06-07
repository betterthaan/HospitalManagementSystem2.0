using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.DB
{
    public static class DBCommon
    {
        public static string ConString = @"Data Source=DESKTOP-2KEFNFM;Initial Catalog=HMSystem;Integrated Security=True;Trust Server Certificate=True;MultipleActiveResultSets=true";

        public static void StartServer()
        {
            try
            {
                // Укажите имя вашего сервера (exe файла) без пути
                string serverExeName = "server.exe"; // Замените на ваше имя файла

                // Получаем полный путь к исполняемому файлу сервера
                string serverExePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dist", "server", serverExeName);

                // Создаем новый процесс для запуска сервера
                Process serverProcess = new Process();
                serverProcess.StartInfo.FileName = serverExePath;
                serverProcess.StartInfo.UseShellExecute = false; // Если нужно, чтобы сервер работал в фоновом режиме
                serverProcess.StartInfo.CreateNoWindow = true; // Если не нужно открывать окно консоли

                //Console.WriteLine($"Путь к серверу: {serverExePath}");
                MessageBox.Show($"Путь к серверу: {serverExePath}");


                if (!File.Exists(serverExePath))
                {
                    //Console.WriteLine("Файл server.exe не найден!");
                    MessageBox.Show($"Файл server.exe не найден!");
                }

                Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);

                // Запускаем сервер
                serverProcess.Start();
            }
            catch (Exception ex)
            {
                // Обработка ошибок, например, логирование или вывод сообщения
                //Console.WriteLine($"Ошибка при запуске сервера: {ex.Message}");
                MessageBox.Show($"Ошибка при запуске сервера: {ex.Message}");
            }
        }
    }
}
