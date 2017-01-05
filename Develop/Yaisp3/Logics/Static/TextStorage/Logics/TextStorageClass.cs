using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgencySimulator
{
    /// <summary>
    /// Класс работы с текстами заказчиков.
    /// </summary>
    public static class TextStorageClass
    {
        #region Поля

        /// <summary>
        /// Тексты заказов.
        /// </summary>
        private static string[] BillboardTexts;

        /// <summary>
        /// Названия частных клиентов.
        /// </summary>
        private static string[] ClientNames;

        /// <summary>
        /// Названия компаний.
        /// </summary>
        private static string[] CompanyNames;

        /// <summary>
        /// Названия правительственных организаций.
        /// </summary>
        private static string[] GovernNames;

        #endregion

        #region Методы

        /// <summary>
        /// Считывает и сохраняет в память все имена и тексты.
        /// </summary>
        public static void ParseTextData()
        {
            System.IO.StreamReader sr = new System.IO.StreamReader("../../Logics/Static/TextStorage/Texts/CompanyNames.txt");
            string[] Arr = sr.ReadToEnd().Split(';');
            sr.Close();
            ClientNames = Arr[0].Split(new string[] { "\n", "\r\n", "\n\r" },
              StringSplitOptions.RemoveEmptyEntries);
            CompanyNames = Arr[1].Split(new string[] { "\n", "\r\n", "\n\r" },
              StringSplitOptions.RemoveEmptyEntries);
            GovernNames = Arr[2].Split(new string[] { "\n", "\r\n", "\n\r" },
              StringSplitOptions.RemoveEmptyEntries);
            sr = new System.IO.StreamReader("../../Logics/Static/TextStorage/Texts/BillboardsTexts.txt");
            BillboardTexts = sr.ReadToEnd().Split(new string[] { "\n", "\r\n", "\n\r" },
              StringSplitOptions.RemoveEmptyEntries);
            sr.Close();
        }

        /// <summary>
        /// Возвращает случаное название и текст для биллборда.
        /// </summary>
        /// <returns>Возвращает кортеж из двух строк</returns>
        public static Tuple<string, string> GetRandomData(int Rank)
        {
            return Tuple.Create(
          Rank == 2 ? ClientNames[MiscellaneousLogics.MainGetRandomValue(0, ClientNames.Length)] :
          Rank == 3 ? CompanyNames[MiscellaneousLogics.MainGetRandomValue(0, CompanyNames.Length)] :
          GovernNames[MiscellaneousLogics.MainGetRandomValue(0, GovernNames.Length)],
        BillboardTexts[MiscellaneousLogics.MainGetRandomValue(0, BillboardTexts.Length)]);
        }

        #endregion
    }
}
