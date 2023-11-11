using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'dayOfProgrammer' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts INTEGER year as parameter.
     */

    public static string dayOfProgrammer(int year)
    {
        string date;
        List<int> mounths = new List<int> {31, 28, 31, 30, 31, 30,
                                            31, 31, 30, 31, 30, 31};
        bool calendarNew = year > 1918 ? true : false;

        if (calendarNew)
        {
            if (year % 400 == 0 || (year % 4 == 0 && year % 100 != 0))
            {
                mounths[1]++;
                date = findDay(year, mounths);

            }
            else
            {
                date = findDay(year, mounths);
            }
        }
        else
        {
            if (year == 1918)
            {
                mounths[1] = 15;
                date = findDay(year, mounths);
            }
            else
            {
                if (year % 4 == 0)
                {
                    mounths[1]++;
                    date = findDay(year, mounths);
                }
                else
                {
                    date = findDay(year, mounths);
                }
            }
        }
        return date;
    }

    public static string findDay(int year, List<int> mounths)
    {
        StringBuilder date = new StringBuilder();
        int auxProgrammerDay = 256;
        for (int i = 0; i < mounths.Count; i++)
        {
            if (auxProgrammerDay <= mounths[i])
            {
                date.Append(auxProgrammerDay.ToString() +
                "." + 0 + (i + 1) + "." + year);
                break;
            }
            else
            {
                auxProgrammerDay -= mounths[i];
            }
        }

        return date.ToString();
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        int year = 2017;

        string result = Result.dayOfProgrammer(year);

        Console.WriteLine(result);
    }
}
