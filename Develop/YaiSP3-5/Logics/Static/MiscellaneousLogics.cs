using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgencySimulator
{
    /// <summary>
    /// Статический класс миск логики.
    /// </summary>
    public static class MiscellaneousLogics
    {
        /// <summary>
        /// Генератор случайных чисел.
        /// </summary>
        private static Random Sychev = new Random();

        /// <summary>
        /// Считывает тексты в память.
        /// </summary>
        public static void MainParseTexts() => TextStorageClass.ParseTextData();

        /// <summary>
        /// Возвращает случайное целое число от Min до Max.
        /// </summary>
        /// <param name="Min">Минимальное случайное число.</param>
        /// <param name="Max">Максимальное случайное число.</param>
        /// <returns>Возвращает целочисленное значение.</returns>
        public static int MainGetRandomValue(int Min, int Max) => Sychev.Next(Min, Max);
    }
}
