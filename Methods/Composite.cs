using MethodsOptimization.src.Functions;
using MethodsOptimization.src.Parametrs;
using System;
using System.Collections;
using System.Collections.Generic;

namespace MethodsOptimization.src.Methods
{
    /// <summary>
    /// Компановщик методов
    /// </summary>
    public class Composite : EmptyMethod, IEnumerable
    {
        /// <summary>
        /// Функция обратного вызова для сообщения результатов выполнения методов
        /// </summary>
        /// <param name="result">Результат</param>
        /// <param name="param">Параметры из которых был полученн результат</param>
        /// <param name="method">Метод, который был выполнен</param>
        public delegate void CallBackNotifyOfResult(Result result, Params param, EmptyMethod method);

        /// <summary>
        /// Сообщение об ошибке
        /// </summary>
        /// <param name="param"></param>
        /// <param name="method"></param>
        public delegate void CallBackNotifyError(Params param, EmptyMethod method, string messageErr);

        /// <summary>
        /// Событие о сообщение результатов
        /// </summary>
        public event CallBackNotifyOfResult EventNotifyOfResult;

        /// <summary>
        /// Событие о сообщении об ошибке
        /// </summary>
        public event CallBackNotifyError EventNotifyOfErrorRuning;

        /// <summary>
        /// Запуск методов по отдельности
        /// </summary>
        public bool RunMethodsSeparately { get; set; } = false;
        
        /// <summary>
        /// Скомпонованные методы
        /// </summary>
        private List<EmptyMethod> listMs = null;

        /// <summary>
        /// Создать компановщик методов
        /// </summary>
        /// <param name="name"></param>
        public Composite(string name)
        {
            Name = (string)name.Clone();
            listMs = new List<EmptyMethod>();
        }

        public Composite()
        {
            Name = "Composer methods";
            listMs = new List<EmptyMethod>();
        }

        /// <summary>
        /// Запустить все методы на исполнение
        /// </summary>
        /// <param name="p">Параметры</param>
        /// <param name="m">Методы линейного поиска</param>
        /// <returns></returns>
        override public Result Run(Params p)
        {
            // Копируем параметры, для того чтобы была возможность их изменять
            Params copyP = (Params)p.Clone();
            // Переменная результат
            Result result = null;
            // Обходим все методы
            foreach(EmptyMethod Ms in listMs)
            {
                // Определяем мы встретили компановщик
                Composite composite = Ms as Composite;
                if (composite != null)
                {
                    // Если да, то говорим что методы, которые он содержит, нужно исполнять последовательно
                    composite.RunMethodsSeparately = false;
                    // Сообщаем куда передавать результат
                    if (EventNotifyOfResult != null)
                    {
                        composite.EventNotifyOfErrorRuning += EventNotifyOfErrorRuning;
                    }
                }

                try
                {
                    // Выполняем метод
                    result = Ms.Run(copyP);
                } catch (Exception exc)
                {
                    EventNotifyOfErrorRuning?.Invoke(copyP, Ms, exc.Message);
                    return null;
                }
                
                // Передаем сообщение с результатом
                EventNotifyOfResult?.Invoke(result, copyP, Ms);

                // Если методы нужно выполнять последовательно
                if (!RunMethodsSeparately)
                {
                    //, то обновляем параметры по результату
                    copyP.UpdateByResult(result);                    
                }
            }

            return result;
        }

        /// <summary>
        /// Получение метода по имени
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        override public EmptyMethod GetMethodByName(string name)
        {
            if (listMs != null)
            {
                foreach (EmptyMethod Ms in listMs)
                {
                    if (Ms.Name == name)
                    {
                        return Ms;
                    } else if (Ms as Composite != null)
                    {
                        EmptyMethod method = ((Composite)Ms).GetMethodByName(name);
                        if (method != null) { return method; }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Добавление метода в компановщик
        /// </summary>
        /// <param name="m"></param>
        override public void Add(EmptyMethod m)
        {
            if (listMs != null) listMs.Add(m);
        }

        protected override double F(Vector x, double Alfa = 0, Vector p = null)
        {
            throw new System.NotImplementedException();
        }

        protected override Vector X(Vector x, double Alfa = 0, Vector p = null)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
            return listMs.GetEnumerator();
        }

        public List<EmptyMethod> GetList()
        {
            return listMs;
        }

        public void SwapMethods(int indexFirst, int indexSecond)
        {
            if (listMs.Count > indexFirst && listMs.Count > indexSecond)
            {
                EmptyMethod t = listMs[indexFirst];
                listMs[indexFirst] = listMs[indexSecond];
                listMs[indexSecond] = t;
            }
        }

        public EmptyMethod this[int index]
        {
            get
            {
                if (index < listMs.Count)
                {
                    return listMs[index];
                }
                return null;
            }
            set
            {
                if (value != null)
                {
                    listMs[index] = value;
                }
            }
        }
    }
}
