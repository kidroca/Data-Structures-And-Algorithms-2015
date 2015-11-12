﻿namespace T14TheLabyrinthOfDoom
{
    using System;
    using System.Collections.Generic;
    using HomeworkHelpers;

    /// <summary>
    /// We are given a matrix of passable and non-passable cells.
    ///     Write a recursive program for finding all paths between two cells in the matrix.
    /// 
    /// This is the task from Linear Data Structures Homework that is similar
    /// We are given a labyrinth of size N x N.
    /// 
    /// Some of its cells are empty (0) and some are full (x).
    /// We can move from an empty cell to another empty cell if they share common wall.
    /// Given a starting position (*) calculate and fill in the array the minimal distance from this position 
    /// to any other cell in the array. Use "u" for all unreachable cells.
    /// </summary>
    public class Program
    {
        private static Queue<MatrixPosition> unexploredPositions;

        private static HomeworkHelper helper = new HomeworkHelper();

        private static string[,] maze;

        private static void Main(string[] args)
        {
            helper.ConsoleMio.Setup();

            while ((maze = TestMazeFactory.GetNext()) != null)
            {
                helper.ConsoleMio.PrintHeading("Minimal Distances In The Labytinth Of Doom");

                helper.ConsoleMio.WriteLine("Labyrinth Before: ", ConsoleColor.DarkCyan);
                PrintLabyrinth(maze);
                Console.WriteLine();

                unexploredPositions = new Queue<MatrixPosition>();
                DoNextLabyrinth();

                helper.ConsoleMio.WriteLine("Labyrinth After: ", ConsoleColor.DarkGreen);
                PrintLabyrinth(maze);
                Console.WriteLine();

                helper.ConsoleMio.WriteLine("Press a key to test the next labyrinth...", ConsoleColor.DarkRed);
                Console.ReadKey(true);
                Console.Clear();
            }

            helper.ConsoleMio.WriteLine(
                "Completed!!!",
                ConsoleColor.DarkGreen);
        }

        private static void DoNextLabyrinth()
        {
            MatrixPosition start = GetStartingPosition(maze, "*");
            start.DistanceFromStartPosition = 0;
            MarkPossibleDirections(start);

            while (start.Unexplored.Count > 0)
            {
                var next = start.Next;
                next.DistanceFromStartPosition = 1;

                unexploredPositions.Enqueue(next);
            }

            ExploreMaze(unexploredPositions.Dequeue());

            MarkUnreachedPlaeces(maze, "0", "u");
        }

        private static void MarkUnreachedPlaeces(string[,] maze, string unreachedPlaceToken, string markToken)
        {
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    if (maze[i, j].Equals(unreachedPlaceToken, StringComparison.Ordinal))
                    {
                        maze[i, j] = markToken;
                    }
                }
            }
        }

        private static void PrintLabyrinth(string[,] maze)
        {
            int parseResult;

            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    string current = maze[i, j];

                    if (current.Equals("x", StringComparison.OrdinalIgnoreCase))
                    {
                        helper.ConsoleMio.Write("x ", ConsoleColor.Red);
                    }
                    else if (!current.Equals("0") &&
                             int.TryParse(current, out parseResult))
                    {
                        helper.ConsoleMio.Write("{0} ", ConsoleColor.Green, current);
                    }
                    else
                    {
                        Console.Write("{0} ", current);
                    }
                }

                Console.WriteLine();
            }
        }

        private static void ExploreMaze(MatrixPosition position)
        {
            maze[position.Row, position.Col] = position.DistanceFromStartPosition.ToString();

            MarkPossibleDirections(position);

            while (position.Unexplored.Count > 0)
            {
                var next = position.Next;
                next.DistanceFromStartPosition = position.DistanceFromStartPosition + 1;

                unexploredPositions.Enqueue(next);
            }

            if (unexploredPositions.Count > 0)
            {
                ExploreMaze(unexploredPositions.Dequeue());
            }
        }

        private static MatrixPosition GetStartingPosition(string[,] maze, string startToken)
        {
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    if (maze[i, j].Equals(startToken, StringComparison.Ordinal))
                    {
                        return new MatrixPosition(i, j);
                    }
                }
            }

            throw new ArgumentException("Expected start position to exist in the given maze");
        }

        private static int MarkPossibleDirections(MatrixPosition matrixPosition)
        {
            int rowsLength = maze.GetLength(0),
                colsLength = maze.GetLength(1);

            MatrixPosition[] allPositions =
            {
                new MatrixPosition(matrixPosition.Row - 1, matrixPosition.Col),
                new MatrixPosition(matrixPosition.Row, matrixPosition.Col + 1),
                new MatrixPosition(matrixPosition.Row + 1, matrixPosition.Col),
                new MatrixPosition(matrixPosition.Row, matrixPosition.Col - 1)
            };

            int unexploredCount = 0;
            foreach (var position in allPositions)
            {
                if (position.IsWithinRange(rowsLength, colsLength))
                {
                    if (maze[position.Row, position.Col].Equals("0", StringComparison.Ordinal))
                    {
                        matrixPosition.Unexplored.Push(position);
                        unexploredCount++;
                    }
                }
            }

            return unexploredCount;
        }
    }
}
