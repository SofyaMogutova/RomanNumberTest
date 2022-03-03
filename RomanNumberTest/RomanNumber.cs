﻿using System;

[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("Test")]

namespace RomanNumberTest
{
    internal class RomanNumber : ICloneable, IComparable
    {
        private ushort number;
        public RomanNumber(ushort n)
        {
            if (n <= 0 || n >= 4000)
            {
                throw new RomanNumberException("Некорректное десятичное число");
            }
            number = n;
        }
        //Сложение римских чисел
        public static RomanNumber operator +(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 == null || n2 == null || n1.number + n2.number > 3999)
            {
                throw new RomanNumberException("Невозможно выполнить сложение");
            }
            return new RomanNumber((ushort)(n1.number + n2.number));

        }
        //Вычитание римских чисел
        public static RomanNumber operator -(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 == null || n2 == null || n1.number - n2.number <= 0)
            {
                throw new RomanNumberException("Невозможно выполнить вычитание");
            }
            return new RomanNumber((ushort)(n1.number - n2.number));
        }
        //Умножение римских чисел
        public static RomanNumber operator *(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 == null || n2 == null || n1.number * n2.number > 3999)
            {
                throw new RomanNumberException("Невозможно выполнить умножение");
            }
            return new RomanNumber((ushort)(n1.number * n2.number));
        }
        //Целочисленное деление римских чисел
        public static RomanNumber operator /(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 == null || n2 == null || n1.number / n2.number <= 0)
            {
                throw new RomanNumberException("Невозможно выполнить деление");
            }
            return new RomanNumber((ushort)(n1.number / n2.number));
        }

        //Возвращает строковое представление римского числа
        public override string ToString()
        {
            string str = "";
            ushort n = number;

            ushort[] digit = new ushort[] { 1, 4, 5, 9, 10, 40, 50, 90, 100, 400, 500, 900, 1000 };
            string[] roman_num = new string[] { "I", "IV", "V", "IX", "X", "XL", "L", "XC", "C", "CD", "D", "CM", "M" };

            for (int i = 12; i >= 0; --i)
            {
                if (n / digit[i] != 0)
                {
                    for (int j = 0; j < n / digit[i]; ++j)
                        str += roman_num[i];
                    n %= digit[i];
                }
            }
            return str;
        }
        //Реализация интерфейса IClonable
        public object Clone()
        {
            return new RomanNumber(number);
        }
        //Реализация интерфейса IComparable
        public int CompareTo(object? obj)
        {
            if (obj is RomanNumber num)
                return number.CompareTo(num.number);
            else
                throw new RomanNumberException("Error: сравнение невозможно");
        }
    }
}