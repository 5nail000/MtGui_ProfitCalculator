using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Reflection;
using System.Runtime.InteropServices;

namespace MtGuiController.Published
{
    public enum BlockingControl
    {
        NotLockControl,
        LockControl
    }
    //
    // Summary:
    //     Specifies constants defining which buttons to display on a System.Windows.Forms.MessageBox.
    public enum MessageBoxButtons
    {
        //
        // Summary:
        //     The message box contains an OK button.
        OK = 0,
        //
        // Summary:
        //     The message box contains OK and Cancel buttons.
        OKCancel = 1,
        //
        // Summary:
        //     The message box contains Abort, Retry, and Ignore buttons.
        AbortRetryIgnore = 2,
        //
        // Summary:
        //     The message box contains Yes, No, and Cancel buttons.
        YesNoCancel = 3,
        //
        // Summary:
        //     The message box contains Yes and No buttons.
        YesNo = 4,
        //
        // Summary:
        //     The message box contains Retry and Cancel buttons.
        RetryCancel = 5
    }
}


namespace MtGuiController
{

    /// <summary>
    /// Type of gui event
    /// </summary>
    public enum GuiEventType
    {
        Exception,
        MessageBox,
        ClickOnElement,
        TextChange,
        ScrollChange,
        TabIndexChange,
        CheckBoxChange,
        ElementEnable,
        RadioButtonChange,
        ComboBoxChange,
        NumericChange,
        NumericFormatChange,
        NumericMaxChange,
        NumericMinChange,
        DateTimePickerChange,
        ElementHide,
        AddItem,
        ShutdownEvent,
        ListBoxSelect,
    }
    /// <summary>
    /// Container for event
    /// </summary>
    public class GuiEvent
    {
        public string assembly_name;
        public string form_name;
        public string el_name;
        public GuiEventType id;
        public long lparam;
        public double dparam;
        public string sparam;
    }

    public partial class GuiController
    {
        /// <summary>
        /// One controller for each windows form
        /// </summary>
        private static Dictionary<string, GuiController> m_controllers = new Dictionary<string, GuiController>();
        /// <summary>
        /// Events list
        /// </summary>
        private static List<GuiEvent> m_global_events = new List<GuiEvent>();

        #region private methods
        /// <summary>
        /// Create GuiController for windows form
        /// </summary>
        /// <param name="assembly_path">Path to assembly</param>
        /// <param name="form_name">Windows Form's name</param>
        /// <returns></returns>
        private static GuiController GetGuiController(string form_name)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Form form = FindForm(assembly, form_name);

            // Подписываемся на событие закрытия формы
            form.FormClosed += (sender, args) =>
            {
                // Логика для отправки сигнала при закрытии формы
                GuiEvent ShutdownEvent = new GuiEvent
                {
                    assembly_name = assembly.FullName,
                    form_name = form_name,
                    el_name = "check_shutdown",  // Имя элемента
                    id = GuiEventType.CheckBoxChange, // Тип события
                    lparam = 1, // Пример значения, указывающего на необходимость скрыть элемент
                    sparam = "" // Дополнительная информация
                };

                m_global_events.Add(ShutdownEvent); // Добавьте событие в глобальные события
            };


            GuiController controller = new GuiController(assembly, form, m_global_events);
            return controller;
        }
        /// <summary>
        /// Find needed form
        /// </summary>
        /// <param name="assembly">Assembly</param>
        /// <returns></returns>
        private static Form FindForm(Assembly assembly, string form_name)
        {
            Type[] types = assembly.GetTypes();
            foreach (Type type in types)
            {
                //assembly.CreateInstance()
                if (type.BaseType == typeof(Form) && type.Name == form_name)
                {
                    object obj_form = Activator.CreateInstance(type);
                    return (Form)obj_form;
                }
            }
            throw new Exception("Form with name " + form_name + " in assembly " + assembly.FullName + "  not find");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        private static void SendExceptionEvent(Exception ex)
        {
            GuiEvent ex_event = new GuiEvent()
            {
                id = (int)GuiEventType.Exception,
                sparam = ex.Message
            };
            m_global_events.Add(ex_event);
        }

        #endregion
        #region MetaTrader Interface methods
        /// <summary>
        /// Show Windows form
        /// </summary>
        [STAThread]
        public static void ShowForm(string form_name)
        {
            try
            {
                GuiController controller = GetGuiController(form_name);
                string full_name = form_name;
                m_controllers.Add(full_name, controller);
                controller.RunForm();
            }
            catch (ArgumentException e)
            {
                Type t = e.GetType();
                SendExceptionEvent(e);
            }
        }

        /// <summary>
        /// Hide Windows Form
        /// </summary>
        public static void HideForm(string form_name)
        {
            try
            {
                string full_name = form_name;
                if (!m_controllers.ContainsKey(full_name))
                    return;
                GuiController controller = m_controllers[full_name];
                controller.DisposeForm();
                m_controllers.Remove(full_name);
            }
            catch (Exception ex)
            {
                SendExceptionEvent(ex);
            }
        }

        /// <summary>
        /// Send event
        /// </summary>
        /// <param name="el_name">name of control</param>
        /// <param name="id">Event type</param>
        /// <param name="lparam">long value</param>
        /// <param name="dparam">double value</param>
        /// <param name="sparam">string value</param>
        public static void SendEvent(string el_name, int id, long lparam, double dparam, string sparam)
        {
            SendEventRef(el_name, ref id, ref lparam, ref dparam, sparam);
        }
        /// <summary>
        /// Send event
        /// </summary>
        /// <param name="el_name">name of control</param>
        /// <param name="id">Event type</param>
        /// <param name="lparam">long value</param>
        /// <param name="dparam">double value</param>
        /// <param name="sparam">string value</param>
        public static void SendEventRef(string el_name, ref int id, ref long lparam, ref double dparam, string sparam)
        {
            try
            {
                foreach (var kvp in m_controllers)
                {
                    GuiController controller = kvp.Value;
                    if (controller.IsDiposed)
                    {
                        m_controllers.Remove(kvp.Key);
                        return;
                    }
                    Control control = null;
                    if (!controller.m_controls.TryGetValue(el_name, out control))
                    {
                        SendExceptionEvent(new Exception("SendEvent: element with name '" + el_name + "' not find"));
                        continue;
                    }
                    GuiEventType event_type = (GuiEventType)id;
                    switch (event_type)
                    {
                        case GuiEventType.TextChange:
                            control.Invoke((MethodInvoker)delegate { control.Text = sparam; });
                            break;
                        case GuiEventType.CheckBoxChange:
                            {
                                CheckBox checkBox = (CheckBox)control;
                                CheckState state = (CheckState)lparam;
                                control.Invoke((MethodInvoker)delegate { checkBox.CheckState = state; });
                                break;
                            }
                        case GuiEventType.RadioButtonChange:
                            RadioButton radio_btn = (RadioButton)control;
                            bool check = lparam == 0 ? false : true;
                            control.Invoke((MethodInvoker)delegate { radio_btn.Checked = check; });
                            break;
                        case GuiEventType.ComboBoxChange:
                            ComboBox combo_box = (ComboBox)control;
                            if (combo_box.SelectedIndex != (int)lparam)
                                combo_box.SelectedIndex = (int)lparam;
                            break;
                        case GuiEventType.ListBoxSelect:
                            {
                                if (control is ListBox listBox)
                                {
                                    string[] indices = sparam.Split(new char[] { ',', ';' });
                                    listBox.Invoke((MethodInvoker)delegate
                                    {
                                        listBox.SelectedIndices.Clear();  // Очищаем выбранные элементы
                                        foreach (string index in indices)
                                        {
                                            if (int.TryParse(index, out int idx) && idx >= 0 && idx < listBox.Items.Count)
                                            {
                                                listBox.SelectedIndices.Add(idx);  // Добавляем выбранный элемент
                                            }
                                        }
                                    });
                                }
                                else if (control is CheckedListBox checkedListBox)
                                {
                                    string[] indices = sparam.Split(new char[] { ',', ';' });
                                    checkedListBox.Invoke((MethodInvoker)delegate
                                    {
                                        for (int i = 0; i < checkedListBox.Items.Count; i++)
                                            checkedListBox.SetItemChecked(i, false);  // Сбрасываем все выборы

                                        foreach (string index in indices)
                                        {
                                            if (int.TryParse(index, out int idx) && idx >= 0 && idx < checkedListBox.Items.Count)
                                            {
                                                checkedListBox.SetItemChecked(idx, true);  // Устанавливаем выбор
                                            }
                                        }
                                    });
                                }
                                else
                                {
                                    SendExceptionEvent(new Exception("Element " + control.Name + " doesn't support 'MultiSelectChange' event"));
                                }
                                break;
                            }
                        case GuiEventType.NumericChange:
                            NumericUpDown numeric = (NumericUpDown)control;
                            if (numeric.Value != (decimal)dparam)
                                numeric.Value = (decimal)dparam;
                            break;
                        case GuiEventType.NumericFormatChange:
                            if (control.GetType() != typeof(NumericUpDown))
                            {
                                SendExceptionEvent(new Exception("Element " + control.Name + " doesn't support 'NumericStepsChange' event"));
                                break;
                            }
                            NumericUpDown num = (NumericUpDown)control;
                            num.DecimalPlaces = (int)lparam;
                            num.Increment = (decimal)dparam;
                            break;
                        case GuiEventType.NumericMaxChange:
                            if (control.GetType() != typeof(NumericUpDown))
                            {
                                SendExceptionEvent(new Exception("Element " + control.Name + " doesn't support 'NumericMaxChange' event"));
                                break;
                            }
                            NumericUpDown nummax = (NumericUpDown)control;
                            nummax.Maximum = (decimal)dparam;
                            break;
                        case GuiEventType.NumericMinChange:
                            if (control.GetType() != typeof(NumericUpDown))
                            {
                                SendExceptionEvent(new Exception("Element " + control.Name + " doesn't support 'NumericMinChange' event"));
                                break;
                            }
                            NumericUpDown nummin = (NumericUpDown)control;
                            nummin.Minimum = (decimal)dparam;
                            break;
                        case GuiEventType.ElementHide:
                            if (lparam != 0)
                                control.Hide();
                            else
                                control.Show();
                            break;
                        case GuiEventType.DateTimePickerChange:
                            DateTimePicker picker = (DateTimePicker)control;
                            picker.Value = MtConverter.ToSharpDateTime(lparam);
                            break;
                        case GuiEventType.ElementEnable:
                            {
                                bool enable = lparam == 0 ? false : true;
                                if (enable != control.Enabled)
                                {
                                    control.Invoke((MethodInvoker)delegate { control.Enabled = enable; });
                                    controller.OnEnableChange(control, new EventArgs());
                                }
                                break;
                            }
                        case GuiEventType.MessageBox:
                            {
                                if (lparam == 1)
                                    control.Enabled = false;
                                string[] nodes = sparam.Split('|');
                                MessageBoxButtons buttons;
                                if (dparam == 0.0)
                                    buttons = MessageBoxButtons.OK;
                                else
                                    buttons = (MessageBoxButtons)(int)dparam;
                                if (nodes.Length == 1)
                                    MessageBox.Show(sparam, sparam, buttons);
                                else if (nodes.Length == 2)
                                {
                                    var icon = ParseIcon(nodes[0]);
                                    if (icon == MessageBoxIcon.None)
                                        MessageBox.Show(nodes[0], nodes[1], buttons);
                                    else
                                        MessageBox.Show(nodes[1], nodes[1], buttons, icon);
                                }
                                else
                                {
                                    var icon = ParseIcon(nodes[0]);
                                    MessageBox.Show(nodes[1], nodes[2], buttons, icon);
                                }
                                control.Enabled = true;
                                break;
                            }
                        case GuiEventType.AddItem:
                            if (control.GetType() == typeof(ComboBox))
                            {
                                ComboBox box = (ComboBox)control;
                                box.Items.Add(sparam);
                            }
                            else if (control.GetType() == typeof(ListBox))
                            {
                                ListBox listBox = (ListBox)control;
                                listBox.Items.Clear();
                                string[] items = sparam.Split(new char[] { ',', ';' });
                                foreach (var item in items)
                                {
                                    listBox.Items.Add(item.Trim()); // Добавление элемента и удаление лишних пробелов
                                }
                            }
                            else
                            {
                                SendExceptionEvent(new Exception("Element " + control.Name + " doesn't support 'Add Item' event"));
                            }

                            SendExceptionEvent(new Exception($"Received event: {event_type} for element: {el_name}"));

                            break;

                    }
                }
            }
            catch (Exception ex)
            {
                SendExceptionEvent(ex);
            }
        }
        /// <summary>
        /// Parse Icon
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private static MessageBoxIcon ParseIcon(string text)
        {
            if (text == "i" || text == "Info")
                return MessageBoxIcon.Information;
            else if (text == "?" || text == "Question")
                return MessageBoxIcon.Question;
            else if (text == "!!!" || text == "Error")
                return MessageBoxIcon.Error;
            else if (text == "!" || text == "Warning")
                return MessageBoxIcon.Warning;
            return MessageBoxIcon.None;
        }
        /// <summary>
        /// Get event
        /// </summary>
        /// <param name="event_n">Number of event</param>
        /// <param name="el_name">element name</param>
        /// <param name="id">Event type</param>
        /// <param name="lparam">long value</param>
        /// <param name="dparam">double value</param>
        /// <param name="sparam">string value</param>
        public static void GetEvent(int event_n, ref string el_name, ref int id, ref long lparam, ref double dparam, ref string sparam)
        {
            GuiEvent e = m_global_events[event_n];
            el_name = e.el_name;
            id = (int)e.id;
            lparam = e.lparam;
            dparam = e.dparam;
            sparam = e.sparam;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static int EventsTotal()
        {
            return m_global_events.Count;
        }
        #endregion
    }
    /// <summary>
    /// System Converter MetaTrader - C# 
    /// </summary>
    public static class MtConverter
    {
        /// <summary>
        /// Convert C# DateTime format to MQL (POSIX) DateTime format.
        /// </summary>
        /// <param name="date_time"></param>
        /// <returns></returns>
        public static long ToMqlDateTime(DateTime date_time)
        {
            DateTime tiks_1970 = new DateTime(1970, 01, 01);
            if (date_time < tiks_1970)
                return 0;
            TimeSpan time_delta = date_time - tiks_1970;
            return (long)Math.Floor(time_delta.TotalSeconds);
        }
        /// <summary>
        /// Convert MQL (Posix) time format to sharp DateTime value.
        /// </summary>
        /// <param name="mql_time">MQL datetime as tiks</param>
        /// <returns></returns>
        public static DateTime ToSharpDateTime(long mql_time)
        {
            DateTime tiks_1970 = new DateTime(1970, 01, 01);
            if (mql_time <= 0 || mql_time > int.MaxValue)
                return tiks_1970;
            TimeSpan time_delta = new TimeSpan(0, 0, (int)mql_time);
            DateTime sharp_time = tiks_1970 + time_delta;
            return sharp_time;
        }

        public static double DecimalMax()
        {
            return (double)decimal.MaxValue;
        }
    }
}
