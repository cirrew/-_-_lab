using System;
using System.Collections.Specialized;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq.Expressions;
using System.Numerics;


int[,] tabl = new int[4, 4];
string f = "";



bool chek = false;
Console.WriteLine("1. Вручную\n2. Случайным образом");
string ch = "";
while (ch!="1" && ch!="2")
{
    ch = Console.ReadLine()!;
    switch (ch)
    {
        case "1":
            {
                Console.WriteLine("16 символов");
                while (!chek)
                {
                    chek = true;
                    f = Console.ReadLine()!;
                    for (int i=0; i<f.Length; i++)
                    {
                        if (f[i]!='1' && f[i]!='0')
                        {
                            chek = false;
                        }
                    }
                    if (f.Length != 16)
                        chek = false;
                    if (!chek)
                    {
                        Console.WriteLine("Не удовлетворяет условиям");
                    }
                }
                break;
            }
        case "2":
            {
                Random rnd = new Random();
                for (int i=0; i<16; i++)
                {
                    f = f + (rnd.Next() % 2).ToString();
                }
                break;
            }
        default:
            {
                Console.WriteLine("wrong");
                break;
            }
    }
}
int q = 0;
string SDNF = "";
string SKNF = "";
//Console.WriteLine($"\n\n{f}    {f.Length}");
Console.WriteLine("a|b|c|d | F\n___________");
for (int a = 0; a<=1; a++)
{
    for (int b=0; b<=1; b++)
    {
        for (int c=0; c<=1; c++)
        {
            for (int d=0; d<=1; d++)
            {
                Console.WriteLine($"{a}|{b}|{c}|{d} | {f[q]}");
                switch (f[q])
                {
                    case '1':
                        {
                            //для СДНФ
                            SDNF += "(";
                            if (a == 0)
                                SDNF += "-a";
                            else
                                SDNF += "a";
                            SDNF += " & ";
                            if (b == 0)
                                SDNF += "-b";
                            else
                                SDNF += "b";
                            SDNF += " & ";
                            if (c == 0)
                                SDNF += "-c";
                            else
                                SDNF += "c";
                            SDNF += " & ";
                            if (d == 0)
                                SDNF += "-d";
                            else
                                SDNF += "d";
                            SDNF += ") v ";
                            break;
                        }
                    case '0':
                        {
                            //для СКНФ
                            SKNF += "(";
                            if (a == 0)
                                SKNF += "a";
                            else
                                SKNF += "-a";
                            SKNF += " v ";
                            if (b == 0)
                                SKNF += "b";
                            else
                                SKNF += "-b";
                            SKNF += " v ";
                            if (c == 0)
                                SKNF += "c";
                            else
                                SKNF += "-c";
                            SKNF += " v ";
                            if (d == 0)
                                SKNF += "d";
                            else
                                SKNF += "-d";
                            SKNF += ") & ";
                            break;
                        }
                }
                q++;
            }
        }
    }
}
/*
СТРОКИ
a = {1, 2}
-a = {3, 4}
b = {2, 3}
-b = {1, 4}
СТОЛБЦЫ
c = {3, 4}
-c = {1, 2}
d = {2, 3}
-d = {1, 4}
*/
Console.WriteLine();
tabl[3, 0] = f[0] - '0';
tabl[3, 1] = f[1] - '0';
tabl[3, 3] = f[2] - '0';
tabl[3, 2] = f[3] - '0';
tabl[2, 0] = f[4] - '0';
tabl[2, 1] = f[5] - '0';
tabl[2, 3] = f[6] - '0';
tabl[2, 2] = f[7] - '0';
tabl[0, 0] = f[8] - '0';
tabl[0, 1] = f[9] - '0';
tabl[0, 3] = f[10] - '0';
tabl[0, 2] = f[11] - '0';
tabl[1, 0] = f[12] - '0';
tabl[1, 1] = f[13] - '0';
tabl[1, 3] = f[14] - '0';
tabl[1, 2] = f[15] - '0';
Console.WriteLine("     -c -c  c  c\n    ______________");
for (int i=0; i<4; i++)
{
    string tmp1 = "";
    string tmp2 = "";
    switch (i)
    {
        case 1:
            {
                tmp1 = " a";
                tmp2 = " b";
                break;
            }
        case 2:
            {
                tmp1 = "-a";
                tmp2 = " b";
                break;
            }
        case 3:
            {
                tmp1 = "-a";
                tmp2 = "-b";
                break;
            }
        case 0:
            {
                tmp1 = " a";
                tmp2 = "-b";
                break;
            }
    }
    Console.Write($"{tmp1} |  ");
    for (int j=0; j<4; j++)
    {
        Console.Write($"{tabl[i,j]}  ");
    }
    Console.WriteLine($"|{tmp2}");
}
Console.WriteLine("    ______________\n     -d  d  d -d");

Console.WriteLine($"\nСКНФ: {SKNF.Remove(SKNF.Length-3,3)}\n\nСДНФ: {SDNF.Remove(SDNF.Length-3, 3)}");