using AgencySimulator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgencySimulator
{
    class DataHandler
    {
        #region Поля

        /// <summary>
        /// Делегат на метод, срабатывающий при уничтожении агентства.
        /// </summary>
        /// <param name="name">Название уничтожаемого агентства.</param>
        public delegate void DelegateAgenDestr(string name);

        /// <summary>
        /// Событие уничтожения агентства.
        /// </summary>
        private event DelegateAgenDestr EventAgencyDestroy;

        /// <summary>
        /// Процессор отрисовщиков в рамках данной модели.
        /// </summary>
        private MainDrawingProcessor drawers;

        /// <summary>
        /// Список рабочих агентств и стратегий для них.
        /// </summary>
        private List<(AgencyHandler agency, IStrategy strategy)> agencies;

        /// <summary>
        /// Обработчик города.
        /// </summary>
        private CityHandler city;

        /// <summary>
        /// Обработчик даты.
        /// </summary>
        private DateHandler date;

        /// <summary>
        /// Обработчик очереди.
        /// </summary>
        private QueueHandler queue;

        /// <summary>
        /// Список типов стратегий.
        /// </summary>
        private List<Type> strategiesTypes;
        
        #endregion

        /// <summary>
        /// Главный конструктор обработчика данных.
        /// </summary>
        public DataHandler()
        {
            agencies = new List<(AgencyHandler agency, IStrategy strategy)>();
            drawers = new MainDrawingProcessor();
            date = new DateHandler();
            city = new CityHandler();
            queue = new QueueHandler();
            strategiesTypes = new List<Type>();
        }

        #region Методы для работы со ссылками

        /// <summary>
        /// Устанавливает метод на событие уничтожения агентства.
        /// </summary>
        /// <param name="Del">Метод, срабатывающий при уничтожении агентства.</param>
        public void SetEventLink(DelegateAgenDestr Del) => EventAgencyDestroy += Del;
        
        #endregion

        #region Методы обработчика даты

        /// <summary>
        /// Возвращает нынешнюю дату как строку.
        /// </summary>
        /// <returns>Возвращает строку.</returns>
        public string DateGet() => "Дата: " + date.DateGetAsString();

        /// <summary>
        /// Проводит этот день.
        /// </summary>
        public void DateNew() => date.DateNewDay();

        #endregion

        #region Методы обработчика отрисовщиков

        /// <summary>
        /// Возвращает ссылку на отрисовщика.
        /// </summary>
        /// <returns>Возвращает экземпляр MainDrawingProcessor.</returns>
        public MainDrawingProcessor DrawerGetLink() => drawers;

        /// <summary>
        /// Устанавливает элемент рисования в обработчик отрисовщиков.
        /// </summary>
        /// <param name="Control">Элемент управления, на котором производится рисование.</param>
        public void DrawerSetCanvas(System.Windows.Forms.Control Control) => drawers.SetCanvas(Control);

        /// <summary>
        /// Вызывает метод отрисовки обработчика отрисовщиков.
        /// </summary>
        public void DrawerDraw() => drawers.Draw();

        /// <summary>
        /// Вызывает метод изменения масштаба в точке Х, Y.
        /// </summary>
        /// <param name="IX">X точки масштаба.</param>
        /// <param name="IY">Y точки масштаба.</param>
        /// <param name="Delta">Меньше 0 - увеличение, больше - уменьшение.</param>
        public void DrawerZoom(int IX, int IY, int Delta) => drawers.Zoom(IX, IY, Delta);

        /// <summary>
        /// Вызывает метод движения изображения из одной точки в другую.
        /// </summary>
        /// <param name="MouseX">Х конечной точки.</param>
        /// <param name="MouseY">Y конечной точки.</param>
        /// <param name="OldCoordsX">Х первичной точки.</param>
        /// <param name="OldCoordsY">Y первичной точки.</param>
        public void DrawerMove(int MouseX, int MouseY, int OldCoordsX, int OldCoordsY) =>
            drawers.Move(MouseX, MouseY, OldCoordsX, OldCoordsY);

        /// <summary>
        /// Вызывает метод возврата изначального масштаба.
        /// </summary>
        public void DrawerSetNormalZoom() => drawers.SetNormalZoom();

        #endregion

        #region Методы списка агентств

        /// <summary>
        /// Возвращает ссылку на список агентств.
        /// </summary>
        /// <returns>Возвращает экземпляр списка кортежей.</returns>
        public List<(AgencyHandler, IStrategy)> AgenciesGetLink() => agencies;

        /// <summary>
        /// Заставляет стратегии работать с агенствами.
        /// </summary>
        public void AgenciesAction()
        {
            int C = agencies.Count;
            for (int i = 0; i < C; i++)
                if (!agencies[i].strategy.Action(agencies[i].agency.GetAgencyLink()))
                {
                    EventAgencyDestroy(agencies[i].agency.ToString());
                    agencies[i].agency.AgencyDestroy();
                    agencies.RemoveAt(i--);
                    C--;
                }
        }

        #endregion

        #region Методы обработчика города

        /// <summary>
        /// Возвращает ссылку на город.
        /// </summary>
        /// <returns>Возвращает экземпляр CityHandler.</returns>
        public CityHandler CityGetLink() => city;

        /// <summary>
        /// Уничтожает город.
        /// </summary>
        public void CityClear() => city = new CityHandler();

        #endregion

        #region Методы обработчика очереди

        /// <summary>
        /// Возвращает ссылку на очередь клиентов.
        /// </summary>
        /// <returns>Возвращает экземпляр QueueHandler.</returns>
        public QueueClass QueueGetLink() => queue.GetQueueLink();

        /// <summary>
        /// Пытается добавить в очередь клиентов.
        /// </summary>
        /// <param name="Quant">Макс. кол-во добавляемых клиентов.</param>
        /// <param name="Intens">Частота прихода клиентов.</param>
        public void QueueNewClient(int Quant, int Intens) => queue.QueueAddRand(Quant, Intens);

        /// <summary>
        /// Возвращает текстом клиентов в очереди.
        /// </summary>
        /// <returns>Возвращает строку.</returns>
        public string QueueNames() => queue.ToString();

        #endregion

        #region Методы обработчика списка типов

        /// <summary>
        /// Возвращает true, если есть хоть одна стратегия.
        /// </summary>
        /// <returns>Возвращает логическое значение.</returns>
        public bool TypesNotExist() => strategiesTypes.Count == 0;

        /// <summary>
        /// Возвращает ссылку на список типов.
        /// </summary>
        /// <returns></returns>
        public List<Type> TypesGetLink() => strategiesTypes;

        public void TypesAdd(Type Type) => strategiesTypes.Add(Type);

        public void TypesClear() => strategiesTypes = new List<Type>();

        #endregion
    }
}
