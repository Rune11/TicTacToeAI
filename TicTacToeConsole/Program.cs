using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameModel;

namespace TicTacToeConsole
{
    class Program
    {
        static Field field;
        static int size;
        static void Main(string[] args)
        {
            field = new Field(3);
            size = field.Size;
            

            Console.ReadLine();

        }

        private static void WriteField()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (field.GetValue(i,j) == 0)
                    {
                        Console.Write("-");
                    }
                    else if (field.GetValue(i,j) == 1)
                    {
                        Console.Write("X");
                    }
                    else
                    {
                        Console.Write("O");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
