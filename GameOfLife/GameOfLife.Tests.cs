using System.Text;
using Xunit;

namespace GameOfLife
{
    public class GameOfLife
    {
        [Theory]
        [InlineData("000_111_000", "010_010_010")]
        [InlineData("11", "00")]
        public void NextGeneration_Test(string str, string expected)
        {
            bool[,] booleanArray = ConvertToBooleanArray(str);
            var nextGeneration = new StringBuilder();

            for (int i = 1; i < booleanArray.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < booleanArray.GetLength(1) - 1; j++)
                {
                    bool[] neighbors = GetNeighbors(booleanArray, i, j);

                    nextGeneration.Append(isAlive(booleanArray[i,j], neighbors) ? '1' : '0');
                }

                nextGeneration.Append('_');
            }

            var actual = nextGeneration.ToString()[..(nextGeneration.Length - 1)];

            Assert.Equal(expected, actual);
        }

        private bool[,] ConvertToBooleanArray(string str)
        {
            string[] lines = str.Split('_');
            bool[,] booleanArray = new bool[lines.Length + 2, lines[0].Length + 2];

            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[0].Length; j++)
                {
                    booleanArray[i + 1, j + 1] = lines[i][j] == '1';
                }
            }            

            return booleanArray;
        }

        private bool[] GetNeighbors(bool[,] booleanArray, int y, int x)
        {
            bool[] neighbors = new bool[8];

            int i = y - 1;
            int j = x - 1;

            int index = 0;

            neighbors[index] = booleanArray[i, j];
            index++;
            MoveRight(ref j);
            neighbors[index] = booleanArray[i, j];
            index++;
            MoveRight(ref j);
            neighbors[index] = booleanArray[i, j];
            index++;
            MoveDown(ref i);
            neighbors[index] = booleanArray[i, j];
            index++;
            MoveDown(ref i);
            neighbors[index] = booleanArray[i, j];
            index++;
            MoveLeft(ref j);
            neighbors[index] = booleanArray[i, j];
            index++;
            MoveLeft(ref j);
            neighbors[index] = booleanArray[i, j];
            index++;
            MoveUp(ref i);
            neighbors[index] = booleanArray[i, j];

            return neighbors;
        }

        private void MoveRight(ref int j)
        {
            j++;
        }

        private void MoveDown(ref int i)
        {
            i++;
        }

        private void MoveLeft(ref int j)
        {
            j--;
        }

        private void MoveUp(ref int i)
        {
            i--;
        }

        private bool isAlive(bool cell, bool[] neighbors)
        {
            var aliveNeighbors = neighbors.Where(x => x).Count();

            if (cell && aliveNeighbors < 2)
            {
                return false;
            }

            if (cell && (aliveNeighbors == 2 || aliveNeighbors == 3))
            {
                return true;
            }

            if (cell && (aliveNeighbors == 2 || aliveNeighbors > 3))
            {
                return false;
            }

            if (!cell && (aliveNeighbors == 3))
            {
                return true;
            }

            return false;
        }
    }
}
