using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UtilityTest
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ConclusionButton_Click(object sender, EventArgs e)
        {
            // Создаем экземпляр класса ManagementObjectSearcher,
            // указываем запрос для получения информации о видеокарте, процессоре и оперативной памяти
            var videoCardSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_VideoController");
            var processorSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
            var memorySearcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMemory");

            StringBuilder sb = new StringBuilder();

            // Обрабатываем информацию о видеокарте
            foreach (var videoCard in videoCardSearcher.Get())
            {
                // Получаем свойства видеокарты
                var videoCardName = (string)videoCard["Name"];

                // Добавляем информацию о видеокарте в StringBuilder
                sb.AppendLine($"Video Card: {videoCardName}");
            }

            // Обрабатываем информацию о процессоре
            foreach (var processor in processorSearcher.Get())
            {
                // Получаем свойства процессора
                var processorName = (string)processor["Name"];

                // Добавляем информацию о процессоре в StringBuilder
                sb.AppendLine($"Processor: {processorName}");
            }

            // Обрабатываем информацию об оперативной памяти
            foreach (var memory in memorySearcher.Get())
            {
                // Получаем свойства оперативной памяти
                var memoryCapacity = Convert.ToUInt64(memory["Capacity"]);
                var memorySize = memoryCapacity / (1024 * 1024 * 1024); // Преобразуем к гигабайтам

                // Добавляем информацию об оперативной памяти в StringBuilder
                sb.AppendLine($"Memory: {memorySize}GB");
            }

            // Записываем результат в textBox1
            InfoBox.Text = sb.ToString();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Закрыть приложение
        }
    }
}
