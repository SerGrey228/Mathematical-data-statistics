using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursovia_Mat_Stat
{
    static class Data
    {
        public static DataGridView DGV { get; set; }
        //используется для хранения значения dataGredView1 и переноса в другие формы

        public static double Median(double[] arr)
        {
            double[] copyArr = (double[])arr.Clone();
            Array.Sort(copyArr);

            return copyArr[copyArr.Length / 2];
        }

        public static double Mode(double[] arr)
        {
            if (arr.Length == 0)
                throw new ArgumentException("Маccив не может быть пустым");

            Dictionary<double, int> dict = new Dictionary<double, int>();
            foreach (double elem in arr)
            {
                if (dict.ContainsKey(elem))
                    dict[elem]++;
                else
                    dict[elem] = 1;
            }

            int maxCount = 0;
            double mode = Double.NaN; //double mode = 0.0;

            foreach (double elem in dict.Keys)
            {
                if (dict[elem] > maxCount)
                {
                    maxCount = dict[elem];
                    mode = elem;
                }
            }
            return mode;
        }

        public static double Dispersion(double[] arr) // дисперсия
        {
            double result = 0.0;
            double avarage = Data.Average(arr);

            for (int i = 0; i < arr.Length; i++)
            {
                result += Math.Pow((arr[i] - avarage), 2);
            }
            result = result / (arr.Length - 1);

            return result;
        }

        public static double AvarageDeviation(double[] arr) //среднее арифметическое отклонение
        {
            double result = 0.0;
            double avarage = 0.0;

            foreach (double num in arr)
                avarage += num;
            avarage = avarage / arr.Length;

            for (int i = 0; i < arr.Length; i++)
            {
                result += Math.Pow((arr[i] - avarage), 2);
            }
            result = result / (arr.Length - 1);
            result = Math.Sqrt(result);

            return result;
        }

        public static double Excess(double[] arr)
        {
            double s = AvarageDeviation(arr); //стандартное отклонение выборки (ср. арифм. отклонение)
            double avarage = Average(arr);
            double result = 0.0;
            double count = arr.Length;

            for (int i = 0; i < arr.Length; i++)
            {
                result += Math.Pow(((arr[i] - avarage) / s), 4.0);
            }
            result *= (count * (count + 1)) / ((count - 1) * (count - 2) * (count - 3));
            result -= (3 * Math.Pow((count - 1), 2.0)) / ((count - 2) * (count - 3));

            return result;
        }

        public static double MeanError(double[] arr) //средняя ошибка
        {
            //result = Dispersion(arr) / arr.Length;
            //result = Math.Sqrt(result);

            return Math.Sqrt(AvarageDeviation(arr) / 21);
        }

        public static double RequiredSampleSize(double[] arr) //необходимый объем выборки
        {
            double result = (Math.Pow(0.95, 2) * AvarageDeviation(arr) * 21) / ((Math.Pow(0.95, 2) * AvarageDeviation(arr)) 
                + (MarginalError(arr) * 21));
            return result;
        }

        public static double ConfidenceInterval(double[] arr) //доверительный интервал
        {
            double result1 = 0.0;
            double result2 = 0.0;

            //1.96 - коэфф надежности для 0,95
            result1 = Average(arr) - 1.96 * (AvarageDeviation(arr) / Math.Sqrt(arr.Length));
            result2 = Average(arr) + 1.96 * (AvarageDeviation(arr) / Math.Sqrt(arr.Length));
            result1 = result2 - result1;
            return result1;
        }

        public static double MarginalError(double[] arr) //предельная ошибка
        {
            return 0.95 * MeanError(arr);
        }

        public static double RequiredSample(double[] arr) //необходимая выборка для повтор отбора
        {
            return (Dispersion(arr) * 4) / (Math.Pow(MarginalError(arr), 2)); //(для тупых 4 - это коэфф доверия)
        }

        public static double mathExpectation(double[] mas) // мат ожидание
        {
            double result = 0;
            for (int i = 0; i < mas.Length; i++)
                result += mas[i];
            result /= mas.Length;
            return result;
        }
        public static double assymetry(double[] mas) //коэффециент ассиметрии
        {
            return centralMoment(mas, 3) / Math.Pow(Math.Sqrt(centralMoment(mas, 2)), 3);
        }
        public static double centralMoment(double[] mas, int K) // центральный момент
        {
            double MX = mathExpectation(mas);
            double[] temp = new double[mas.Length];
            for (int i = 0; i < mas.Length; i++)
                temp[i] = Math.Pow(mas[i] - MX, K);
            return mathExpectation(temp);
        }

        public static double MaxElem(double[] arr)
        {
            return arr.Max();
        }
        public static double MinElem(double[] arr)
        {
            return arr.Min();
        }

        public static double Determinant(double[,] array) // определитель
        {
            int n = (int)Math.Sqrt(array.Length);

            if (n == 1)
            {
                return array[0, 0];
            }

            double det = 0;

            for (int k = 0; k < n; k++)
            {
                det += array[0, k] * Cofactor(array, 0, k);
            }

            return det;
        } 

        private static double Cofactor(double[,] array, int row, int column)
        {
            return Convert.ToDouble(Math.Pow(-1, column + row)) * Determinant(Minor(array, row, column));
        }

        public static double[,] Minor(double[,] array, int row, int column)
        {
            int n = (int)Math.Sqrt(array.Length);
            double[,] minor = new double[n - 1, n - 1];

            int _i = 0;
            for (int i = 0; i < n; i++)
            {
                if (i == row)
                {
                    continue;
                }
                int _j = 0;
                for (int j = 0; j < n; j++)
                {
                    if (j == column)
                    {
                        continue;
                    }
                    minor[_i, _j] = array[i, j];
                    _j++;
                }
                _i++;
            }
            return minor;
        }

        public static double Average(double[] arr)
        {
            double avarage = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                avarage += arr[i];
            }
            return avarage / arr.Length;
        }

        public static Color GetColor(double correlationValue) //дает цвет в зависимости от переданого значения коэфф корреляции
        {
            Color color = Color.White;

            if (Math.Abs(correlationValue) >= 0 && Math.Abs(correlationValue) < 0.3)
            {
                color = Color.Red;
            }
            else if (Math.Abs(correlationValue) >= 0.3 && Math.Abs(correlationValue) < 0.4)
            {
                color = Color.Orange;
            }
            else if (Math.Abs(correlationValue) >= 0.4 && Math.Abs(correlationValue) < 0.6)
            {
                color = Color.Yellow;
            }
            else if (Math.Abs(correlationValue) >= 0.6 && Math.Abs(correlationValue) < 0.7)
            {
                color = Color.GreenYellow;
            }
            else if (Math.Abs(correlationValue) >= 0.7 && Math.Abs(correlationValue) < 0.99)
            {
                color = Color.LimeGreen;
            }
            else if (Math.Abs(correlationValue) >= 0.99)
            {
                color = Color.DarkGreen;
            }
            return color;
        }

        //функции для расчета парной корреляции
        private static double[] Difference(double[] arr)
        {
            double[] resultArr = new double[arr.Length];
            double avarage = Average(arr);
            for (int i = 0; i < arr.Length; i++)
            {
                resultArr[i] += arr[i] - avarage;
            }
            return resultArr;
        }

        private static double SumNumerator(double[] arr1, double[] arr2)
        {
            double resultArr = 0;
            for (int i = 0; i < arr1.Length; i++)
            {
                resultArr += Difference(arr1)[i] * Difference(arr2)[i];
            }
            return resultArr;
        }

        private static double ComDenominator(double[] arr1, double[] arr2)
        {
            double resultArr1 = 0;
            double resultArr2 = 0;
            for (int i = 0; i < arr1.Length; i++)
            {
                resultArr1 += Math.Pow(Difference(arr1)[i], 2);
                resultArr2 += Math.Pow(Difference(arr2)[i], 2);
            }
            resultArr1 = Math.Sqrt(resultArr1);
            resultArr2 = Math.Sqrt(resultArr2);

            return resultArr1 * resultArr2;
        }

        public static double Сorrelation(double[] arr1, double[] arr2)
        {
            double[] a1 = arr1;
            double[] a2 = arr2;
            double correl = 0;
            double some1 = SumNumerator(arr1, arr2);
            double some2 = ComDenominator(arr1, arr2);
            correl = some1 / some2;

            return correl;
        }

        public static double[,] MultiplicationMatrix(double[,] a, double[,] b) // умножение матриц
        {
            if (a.GetLength(1) != b.GetLength(0)) throw new Exception("Матрицы нельзя перемножить");
            double[,] r = new double[a.GetLength(0), b.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    for (int k = 0; k < b.GetLength(0); k++)
                    {
                        r[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return r;
        }
        public static double[,] TranspositionMatrix(double[,] arr)//транспонирует матрицу.
        {
            double[,] trans = new double[arr.GetLength(1), arr.GetLength(0)];

            for (int i = 0; i < arr.GetLength(1); i++)
            {
                for (int j = 0; j < arr.GetLength(0); j++)
                {
                    trans[i, j] = arr[j, i];
                }
            }
            return trans;
        }

        public static double[] MultiplicationMatrixOnColumn(double[,] arr, double[] column) // умножение матрицы на строку
        {
            double[] result = new double[arr.GetLength(1)];
            for (int i = 0; i < arr.GetLength(1); i++)
            {
                for (int j = 0; j < arr.GetLength(0); j++)
                {
                    result[i] += arr[j, i] * column[j];
                }
            }
            return result;
        }

        public static double[,] TranspositionMinorMatrix(double[,] matrix) // *A^T - транспонированая матрица алгебраических дополнений
        {
            double[,] minorMatrix = new double[matrix.GetLength(0), matrix.GetLength(1)];
            int count = 0;

            for(int i = 0; i < minorMatrix.GetLength(1); i++)
            {
                for (int j = 0; j < minorMatrix.GetLength(0); j++)
                {
                    minorMatrix[i, j] = Determinant(Minor(matrix, i, j));
                    if (count % 2 == 0 && j % 2 != 0)
                    {
                        minorMatrix[i, j] = minorMatrix[i, j] * (-1);
                    }
                    else if (count % 2 != 0 && j % 2 == 0)
                    {
                        minorMatrix[i, j] = minorMatrix[i, j] * (-1);
                    }
                }
                count++;
            }

            return TranspositionMatrix(minorMatrix);
        }

        public static double[,] InverseMatrix(double[,] matrix, int size) //обратная матрица
        {
            double[,] inverseMatrix = new double[size, size];
            double[,] transponMatrix = new double[size, size];
            double determinant = Determinant(matrix); //определитель

            transponMatrix = TranspositionMinorMatrix(matrix); // транспонированная матрицы
          
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    inverseMatrix[i, j] = transponMatrix[i, j] * (1 / determinant);
                }
            }
            return inverseMatrix;
        }
    }
}
