using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MtGuiController
{
    public partial class Form1 : Form
    {

        Form newForm = new Form();
        private bool isFormVisible = false;

        public Form1()
        {
            InitializeComponent();
            newForm.FormBorderStyle = FormBorderStyle.None;  // Убираем заголовок
            newForm.StartPosition = FormStartPosition.Manual;
            newForm.Size = new Size(400, 200); // Размер новой формы

            // Добавляем DataGridView
            DataGridView dataGridView = new DataGridView();
            dataGridView.Size = new Size(400, 200);
            dataGridView.Location = new Point(0, 0);
            dataGridView.ColumnCount = 3;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Установка режима выделения

            // Настройка столбцов
            dataGridView.Columns[0].Name = "Magic";
            dataGridView.Columns[1].Name = "Symbol";
            dataGridView.Columns[2].Name = "Profit";

            // Пример данных
            string[] row1 = new string[] { "123456", "EURUSD", "150.50" };
            string[] row2 = new string[] { "654321", "GBPUSD", "-75.25" };

            // Добавление строк
            dataGridView.Rows.Add(row1);
            dataGridView.Rows.Add(row2);

            // Добавляем DataGridView на новую форму
            newForm.Controls.Add(dataGridView);
        }

        private void btn_actual_Click(object sender, EventArgs e)
        {
            if (isFormVisible)
            {
                newForm.Hide();
            }
            else
            {
                newForm.Location = new Point(this.Right, this.Top);  // Позиция справа от основной формы
                newForm.Show();
            }
            isFormVisible = !isFormVisible;
        }

        private void Form1_LocationChanged(object sender, EventArgs e)
        {
            // Обновляем позицию дополнительной формы при перемещении главной
            newForm.Location = new Point(this.Location.X + this.Width, this.Location.Y);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Piсker_DateStart_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = Picker_DateStart.Value;
        }

        private void Piсker_DateEnd_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = Picker_DateEnd.Value;
        }

        private void listBox_magics_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Получаем список всех выбранных элементов
            var selectedItems = listBox_magics.SelectedItems;

            // Пример: отправляем выбранные индексы в контроллер
            string selectedIndices = string.Join(",", listBox_magics.SelectedIndices.Cast<int>().ToArray());
        }
    }
}
