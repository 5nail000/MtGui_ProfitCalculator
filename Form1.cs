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
        public Form1()
        {
            InitializeComponent();
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
