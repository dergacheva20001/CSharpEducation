// See https://aka.ms/new-console-template for more information

using System;

public class TicTacToe
{
    static char[] field = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    static int player = 1;
    static int motion = 0;

    public static void Main(string[] args)
    {
        Console.WriteLine("Игра Крестики-Нолики!");

        do
        {
            Console.Clear();
            DraftingBoard();

            Console.WriteLine($"Ход игрока {player}. Введите номер ячейки (1-9):"); 
            string input = Console.ReadLine();

            if (int.TryParse(input, out int cellNumber) && cellNumber >= 1 && cellNumber <= 9)
            {
                if (field[cellNumber - 1] != 'X' && field[cellNumber - 1] != 'O')
                {
                    field[cellNumber - 1] = (player == 1) ? 'X' : 'O';
                    motion++;

                    if (CheckWin())
                    {
                        Console.Clear();
                        DraftingBoard();
                        Console.WriteLine($"Игрок {player} победил!"); 
                        break;
                    }

                    if (motion == 9)
                    {
                        Console.Clear();
                        DraftingBoard();
                        Console.WriteLine("Ничья!"); 
                        break;
                    }

                    player = (player == 1) ? 2 : 1;
                }
                else
                {
                    Console.WriteLine("Ячейка занята! Попробуйте еще раз."); 
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод! Введите число от 1 до 9."); 
                Console.ReadKey();
            }

        } while (true);

        Console.WriteLine("Игра окончена!"); 
    }

    static void DraftingBoard()
    {
        Console.WriteLine("---|---|---");
        Console.Write(" ");
        SetColor(0);
        Console.Write(field[0]);
        Console.ResetColor();
        Console.Write(" | ");
        SetColor(1);
        Console.Write(field[1]);
        Console.ResetColor();
        Console.Write(" | ");
        SetColor(2);
        Console.Write(field[2]);
        Console.ResetColor();
        Console.WriteLine(" ");
        Console.WriteLine("---|---|---");
        Console.Write(" ");
        SetColor(3);
        Console.Write(field[3]);
        Console.ResetColor();
        Console.Write(" | ");
        SetColor(4);
        Console.Write(field[4]);
        Console.ResetColor();
        Console.Write(" | ");
        SetColor(5);
        Console.Write(field[5]);
        Console.ResetColor();
        Console.WriteLine(" ");
        Console.WriteLine("---|---|---");
        Console.Write(" ");
        SetColor(6);
        Console.Write(field[6]);
        Console.ResetColor();
        Console.Write(" | ");
        SetColor(7);
        Console.Write(field[7]);
        Console.ResetColor();
        Console.Write(" | ");
        SetColor(8);
        Console.Write(field[8]);
        Console.ResetColor();
        Console.WriteLine(" ");
        Console.WriteLine("---|---|---");

    }

    static void SetColor(int position)
    {
        if (field[position] == 'X')
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
        }
        else if (field[position] == 'O')
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Black;
        }
    }


    static bool CheckWin()
    {
        if (field[0] == field[1] && field[1] == field[2]) return true;
        if (field[3] == field[4] && field[4] == field[5]) return true;
        if (field[6] == field[7] && field[7] == field[8]) return true;

        if (field[0] == field[3] && field[3] == field[6]) return true;
        if (field[1] == field[4] && field[4] == field[7]) return true;
        if (field[2] == field[5] && field[5] == field[8]) return true;

        if (field[0] == field[4] && field[4] == field[8]) return true;
        if (field[2] == field[4] && field[4] == field[6]) return true;

        return false;
    }
}