using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MethodsOptimization.src.Views
{
    /// <summary>
    /// Форма создает объект и заполняет публичные поля и свойства данными
    /// </summary>
    public partial class FormObj : Form
    {

        /// <summary>
        /// Функция обратного вызова для передачи обновленного или нового объекта 
        /// </summary>
        /// <param name="param"></param>
        public delegate void CallbackObj(object obj);

        /// <summary>
        /// Функция обратного вызова для передачи сообщения об ошибке
        /// </summary>
        /// <param name="s"></param>
        public delegate void CallbackError(string s);

        /// <summary>
        /// Событие о создании нового объекта
        /// </summary>
        public event CallbackObj CreateObj;

        /// <summary>
        /// Событие о возникновении ошибки
        /// </summary>
        public event CallbackError ErrorMessage;

        /// <summary>
        /// Тип объекта, с которым работаем
        /// </summary>
        Type typeObj;

        /// <summary>
        /// Объект
        /// </summary>
        object obj;
        
        public FormObj(Type typeObj, object obj = null)
        {
            // сохраняем тип объекта
            this.typeObj = typeObj;
            this.obj = obj;

            InitializeComponent();

            // создаем форму
            CreateForm(obj);
        }

        /// <summary>
        /// Сгенерировать форму по публичным свойствам и полям
        /// Если параметров нет, то пустую форму
        /// </summary>
        /// <param name="param"></param>
        private void CreateForm(object obj)
        {
            // получаю свойства
            PropertyInfo[] propInfos = typeObj.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            Text = "Форма " + typeObj.Name;

            if (propInfos.Length == 0) ErrorMessage?.Invoke("Класс " + typeObj.Name + "публичных свойств не имеет.");



            // Обход свойств
            for (int i = propInfos.Length - 1; i >= 0; i--)
            {
                PropertyInfo info = propInfos[i];
                bool read = info.CanRead;
                bool write = info.CanWrite;

                // Если мы можем получать и изменять свойство
                if (read && write)
                {
                    //, то определяем тип свойства
                    string nameTypeProperty = info.PropertyType.Name;

                    if (nameTypeProperty == "String" || 
                        nameTypeProperty == "Double" || 
                        nameTypeProperty == "Int32" || 
                        nameTypeProperty == "Vector" ||
                        nameTypeProperty == "UInt32" ||
                        nameTypeProperty == "Function")
                    {
                        CreateTextBox(info);
                    } else if (nameTypeProperty == "Boolean")
                    {
                        CreateCheckBox(info);
                    } else
                    {
                        FormObj formObj = new FormObj(info.PropertyType, info.GetValue(obj));
                        formObj.Show();
                    }
                }
            }
        }

        /// <summary>
        /// Текстовое поле
        /// </summary>
        /// <param name="info"></param>
        private void CreateTextBox(PropertyInfo info)
        {
            TextBox textbox = new TextBox();
            textbox.Name = info.Name;
            object value = obj != null ? info.GetValue(obj) : null;
            textbox.Text = value != null ? value.ToString() : "";
            textbox.Dock = DockStyle.Top;
            Controls.Add(textbox);
            textbox.Show();
            CreateLabel(info);
        }

        /// <summary>
        /// Чекбокс
        /// </summary>
        /// <param name="info"></param>
        private void CreateCheckBox(PropertyInfo info)
        {
            //CreateLabel(info);
            CheckBox checkBox = new CheckBox();
            checkBox.Name = info.Name;
            checkBox.Text = info.Name;
            checkBox.Checked = obj != null ? (bool)info.GetValue(obj) : false;
            checkBox.Dock = DockStyle.Top;
            Controls.Add(checkBox);
            checkBox.Show();
        }

        /// <summary>
        /// Подпись для элементов
        /// </summary>
        /// <param name="info"></param>
        private void CreateLabel(PropertyInfo info)
        {
            Label label = new Label();
            label.Name = "label" + info.Name;
            label.Dock = DockStyle.Top;
            label.Text = info.Name;
            Controls.Add(label);
            label.Show();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            /*if (CreateObj != null)
            {
                object obj = CreateParamsByForm();
                if (obj != null)
                {
                    CreateObj(obj);
                    Close();
                }
            }*/
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        /*private object CreateParamsByForm()
        {
            try
            {
                ConstructorInfo constructor = typeObj.GetConstructor(new Type[] { });
                if (constructor != null)
                {
                    object obj = constructor.Invoke(null);
                    if (obj != null)
                    {
                        PropertyInfo[] propInfos = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
                        foreach (PropertyInfo info in propInfos)
                        {
                            object elem = Controls.Find(info.Name, false);
                            TextBox textBox = elem as TextBox;
                            CheckBox checkBox = elem as CheckBox;
                            if (textBox != null)
                            {
                                info.SetValue(obj, )
                            }
                        }
                    }
                    return obj;
                }
            } catch (Exception exc)
            {
                return null;
            }
        }*/
    }
}
