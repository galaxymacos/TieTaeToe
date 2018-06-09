using System;
using System.Runtime.InteropServices;

namespace TieTaeToe
{
    public class Tietaetoe
    {
        private readonly char[,] chessboard = new char[3,3];
        public enum Player
        {
            X,
            O
        }

        public void RunGame()
        {
            DrawDiagram();
            PrintDiagram();
            while (true)
            {
                Console.WriteLine("Player one moves: ");
                char posPlayerOne = Convert.ToChar(Console.ReadLine());
                PlayerMove(Player.O,posPlayerOne);
                PrintDiagram();

                if (IsGameEnd())
                {
                    Console.WriteLine("Player one wins");
                    break;
                }
                Console.WriteLine("Player two moves");
                char posPlayerTwo = Convert.ToChar(Console.ReadLine());
                PlayerMove(Player.X,posPlayerTwo);
                PrintDiagram();
                if (IsGameEnd())
                {
                    Console.WriteLine("Player two wins");
                    break;
                }
                
            }
            
        }
        
        public void DrawDiagram()
        {
            for (int i = 0; i < chessboard.GetLength(0); i++)
            {
                for (int j = 0; j < chessboard.GetLength(1); j++)
                {
                    chessboard[i, j] = (char) ('1' + i * 3 + j);
                }
            }
        }

        public void PrintDiagram()
        {
            for (int i = 0; i < chessboard.GetLength(0); i++)
            {
                for (int j = 0; j < chessboard.GetLength(1); j++)
                {
                    Console.Write(chessboard[i,j]);
                }

                Console.WriteLine();
            }

            for (int i = 0; i < chessboard.GetLength(0); i++)
            {
                
            }
        }

        public void PlayerMove(Player player,char position)
        {
            switch (player)
            {
                case Player.O:
                    chessboard[(position-'1') / 3, (position-'1') % 3] = 'O';
                    break;
                case Player.X:
                    chessboard[(position-'1') / 3, (position-'1') % 3] = 'X';
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(player), player, null);
            }
        }

        public bool IsGameEnd()
        {
            // check each row
            for (int i = 0; i < chessboard.GetLength(0); i++)
            {
                var currentColoum = chessboard[i,0];
                for (int j = 1; j < chessboard.GetLength(1); j++)
                {
                    if (chessboard[i, j] != currentColoum)
                        break;
                    if (j == chessboard.GetLength(1) - 1)
                        return true;
                }
            }

            // check each column
            for (int i = 0; i < chessboard.GetLength(1); i++)
            {
                var currentRow = chessboard[0, i];
                for (int j = 1; j < chessboard.GetLength(0); j++)
                {
                    if (chessboard[j, i] != currentRow)
                        break;
                    if (j == chessboard.GetLength(0) - 1)
                        return true;
                }
            }
            
            // check diagonal
            var topLeft = chessboard[0, 0];
            for (int i = 1; i < chessboard.GetLength(0); i++)
            {
                if (chessboard[i, i] != topLeft)
                    break;
                if (i == chessboard.GetLength(0) - 1)
                    return true;
            }

            var topRight = chessboard[0, 2];
            for (int i = 1; i < chessboard.GetLength(0); i++)
            {
                if (chessboard[i, chessboard.GetLength(0) - i] != topRight)
                    break;
                if (i == chessboard.GetLength(0) - 1)
                    return true;
            }

            return false;
        }
    }
    
    internal class Program
    {
        public static void Main(string[] args)
        {
            Tietaetoe game = new Tietaetoe();
            game.RunGame();
        }
    }
}