using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yaisp3
{
  public static class TextStorageClass
  {
    public static string[] CompanyNames;
    public static string[] BillboardTexts;

    public static void ParseTextData()
    {
      System.IO.StreamReader sr = new System.IO.StreamReader("../../Logics/TextStorage/CompanyNames.txt");
        CompanyNames = sr.ReadToEnd().Split(new string[] { "\n", "\n\r" },
          StringSplitOptions.RemoveEmptyEntries);
      sr.Close();
        sr = new System.IO.StreamReader("../../Logics/TextStorage/BillboardsTexts.txt");
      BillboardTexts = sr.ReadToEnd().Split(new string[] { "\n", "\n\r" },
        StringSplitOptions.RemoveEmptyEntries);
      sr.Close();
    }
    /// <summary>
    /// Возвращает случаное название и текст для биллборда
    /// </summary>
    /// <returns></returns>
    public static string[] GetRandomName()
    {
      Random Sychev = new Random();
      return new string[] {
        CompanyNames[Sychev.Next(0, CompanyNames.Length)],
        BillboardTexts[Sychev.Next(0, BillboardTexts.Length)] };
    }
  }
}
