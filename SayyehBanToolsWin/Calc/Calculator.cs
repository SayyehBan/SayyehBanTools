using System;

namespace SayyehBanToolsWin.Calc
{
    public class Calculator
    {
        /// <summary>
        /// انجام عملیات ضرب
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public double Multiply(params double[] numbers)
        {
            double result = 1;
            foreach (double number in numbers)
            {
                result *= number;
            }
            return result;
        }
        /// <summary>
        /// انجام عملیات جمع
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public double Add(params double[] numbers)
        {
            double result = 0;
            foreach (double number in numbers)
            {
                result += number;
            }
            return result;
        }
        /// <summary>
        /// انجام عملیات منفی
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public double Subtract(params double[] numbers)
        {
            double result = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                result -= numbers[i];
            }
            return result;
        }
        /// <summary>
        /// انجام عملیات تقسیم
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="DivideByZeroException"></exception>
        public double Divide(params double[] numbers)
        {
            if (numbers.Length < 2)
            {
                throw new ArgumentException("At least two numbers are required for division.");
            }

            double result = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] == 0)
                {
                    throw new DivideByZeroException("Division by zero is not allowed.");
                }
                result /= numbers[i];
            }
            return result;
        }
        /// <summary>
        /// محاسبه درصد تخفیف
        /// </summary>
        /// <param name="Amount"></param>
        /// <param name="percent"></param>
        /// <returns></returns>
        public decimal Discount(decimal Amount, short percent)
        {
            decimal total = Math.Round(Amount - ((Amount * percent) / 100));
            return total;
        }
        /// <summary>
        /// محاسباه درصد مالیات
        /// </summary>
        /// <param name="Amount"></param>
        /// <param name="percent"></param>
        /// <returns></returns>
        public decimal Taxation(decimal Amount, short percent)
        {
            decimal total = Math.Round(Amount + ((Amount * percent) / 100));
            return total;
        }
    }
}