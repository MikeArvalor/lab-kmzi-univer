
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Text;
using System.Windows.Documents;
using System.Windows.Input;

namespace _4.Crypt
{
    class RouteCrypter : Crypter
    {
        enum State
        {
            Right,
            Left
        }

        Tuple<int, int> getNextIndexes()
        {
            int resultRow = currentRow;
            int resultCol = currentCol;

            if (currentRow == rowcount - 1)
                Tuple.Create(resultRow, resultCol);

            if (state == State.Right)
            {
                if (currentCol + 1 < colcount)
                {
                    currentCol += 1;
                }
                else
                {
                    ++currentRow;
                    state = State.Left;
                }
            }
            else if (state == State.Left)
            {
                if (currentCol - 1 >= 0)
                {
                    currentCol -= 1;
                }
                else
                {
                    ++currentRow;
                    state = State.Right;
                }
            }

            return Tuple.Create(resultRow, resultCol);
        }

        int rowcount = 0;
        int colcount = 0;
        int currentRow = 0;
        int currentCol = 0;
        int counter = 0;
        State state = State.Right;

        private void Reset()
        {
            rowcount = 0;
            colcount = 0;
            currentRow = 0;
            currentCol = 0;
            counter = 0;
            state = State.Right;
            tableSize = 0;
        }

        public string decrypt(string source)
        {
            state = State.Right;
            currentRow = 0;
            currentCol = 0;
            string result = "";
            for (int i = 0; i < source.Length; ++i)
            {
                var pos = getNextIndexes();
                int row = pos.Item1;
                int col = pos.Item2;
                result += (char)table[row, col];
            }
            return result;
        }

        int[,] table;
        int tableSize = 0;

        public string encrypt(string source)
        {
            Reset();
            tableSize = (int)Math.Ceiling(Math.Sqrt(source.Length));
            rowcount = tableSize;
            colcount = tableSize;
            table = new int[tableSize, tableSize];
            for (int i = 0; i < tableSize; ++i)
            {
                for (int j = 0; j < tableSize; ++j)
                {
                    int currentStringPos = i * tableSize + j;
                    if (currentStringPos < source.Length)
                        table[i, j] = source[currentStringPos];
                    else
                        table[i, j] = 'k';
                }
            }

            string result = "";

            for (int i = 0; i < tableSize * tableSize; ++i)
            {
                var pos = getNextIndexes();
                int row = pos.Item1;
                int col = pos.Item2;
                result += (char)table[col, row];
            }
            //getNextIndexes();
            return result;
        }
    }
}
