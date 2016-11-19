using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yaisp3
{
    public static class TextStorageClass
    {
        private static string[] BillboardTexts;
        private static string[] ClientNames;
        private static string[] CompanyNames;
        private static string[] GovernNames;

        public static void ParseTextData()
        {
            System.IO.StreamReader sr = new System.IO.StreamReader("../../Logics/TextStorage/CompanyNames.txt");
            string[] Arr = sr.ReadToEnd().Split(';');
            sr.Close();
            ClientNames = Arr[0].Split(new string[] { "\n", "\n\r" },
              StringSplitOptions.RemoveEmptyEntries);
            CompanyNames = Arr[1].Split(new string[] { "\n", "\n\r" },
              StringSplitOptions.RemoveEmptyEntries);
            GovernNames = Arr[2].Split(new string[] { "\n", "\n\r" },
              StringSplitOptions.RemoveEmptyEntries);
            sr = new System.IO.StreamReader("../../Logics/TextStorage/BillboardsTexts.txt");
            BillboardTexts = sr.ReadToEnd().Split(new string[] { "\n", "\n\r" },
              StringSplitOptions.RemoveEmptyEntries);
            sr.Close();
        }
        /// <summary>
        /// Возвращает случаное название и текст для биллборда
        /// </summary>
        /// <returns></returns>
        public static string[] GetRandomData(byte Rank)
        {
            return new string[] {
          Rank == 2 ? ClientNames[MainUnitProcessor.GetRandomValue(0, ClientNames.Length)] :
          Rank == 3 ? CompanyNames[MainUnitProcessor.GetRandomValue(0, CompanyNames.Length)] :
          GovernNames[MainUnitProcessor.GetRandomValue(0, GovernNames.Length)],
        BillboardTexts[MainUnitProcessor.GetRandomValue(0, BillboardTexts.Length)] };
        }
    }
}
