using System.Text;

int PerfectSquare(int number)
{
    while (HasDecimalPlaces(Math.Sqrt(number)))
        number++;

    return number;
}

bool HasDecimalPlaces(double number)
{
    return number.ToString().Any(c => c == ',');
}

Console.WriteLine(PerfectSquare(26));

string ConvertToRomanianNumeral(int number)
{
    var stringBuilder = new StringBuilder();
    while (number > 0)
    {
        switch (number)
        {
            case >= 1000:
                stringBuilder.Append('M');
                number -= 1000;
                break;
            case >= 900:
                stringBuilder.Append("CM");
                number -= 900;
                break;
            case >= 500:
                stringBuilder.Append('D');
                number -= 500;
                break;
            case >= 400:
                stringBuilder.Append("CD");
                number -= 400;
                break;
            case >= 100:
                stringBuilder.Append('C');
                number -= 100;
                break;
            case >= 90:
                stringBuilder.Append("XC");
                number -= 90;
                break;
            case >= 50:
                stringBuilder.Append('L');
                number -= 50;
                break;
            case >= 40:
                stringBuilder.Append("XL");
                number -= 40;
                break;
            case >= 10:
                stringBuilder.Append('X');
                number -= 10;
                break;
            case >= 9:
                stringBuilder.Append("IX");
                number -= 9;
                break;
            case >= 5:
                stringBuilder.Append('V');
                number -= 5;
                break;
            case >= 4:
                stringBuilder.Append("IV");
                number -= 4;
                break;
            default:
                stringBuilder.Append('I');
                number -= 1;
                break;
        }
    }
    return stringBuilder.ToString();
}
Console.WriteLine(ConvertToRomanianNumeral(2091));


bool CheckSudoku(int[,] array)
{
    int numberOfColumns = array.GetLength(1);
    int numberOfRows = array.GetLength(0);

    //Check if input data is correct
    if (numberOfColumns != 9 || numberOfRows != 9)
        throw new ArgumentException($"Incorrect input array size, correct array size is 9x9, entered array size: {numberOfColumns}x{numberOfRows}");
    if (array.Cast<int>().Any(i => i > 9 || i < 1))
        throw new ArgumentException("Incorrect input array elements, correct array elements are intiger numbers from 1 to 9.");

    const int SquareSize = 3;
    int numberOfSquares = numberOfColumns / SquareSize * numberOfRows / SquareSize;

    //Checks for duplicates in every row
    for (int row = 0; row < array.GetLength(0); row++)
    {
        var stringBuilder = new StringBuilder();
        for (int column = 0; column < array.GetLength(1); column++)
        {
            stringBuilder.Append(array[row, column]);
        }
        var result = stringBuilder.ToString();
        if (result.Distinct().Count() != result.Length)
            return false;
    }

    //Checks for duplicates in every column
    for (int column = 0; column < array.GetLength(1); column++)
    {
        var stringBuilder = new StringBuilder();
        for (int row = 0; row < array.GetLength(0); row++)
        {
            stringBuilder.Append(array[row, column]);
        }
        var result = stringBuilder.ToString();
        if (result.Distinct().Count() != result.Length)
            return false;
    }

    //Checks for duplicates in every 3x3 square
    for (int squareCount = 0; squareCount < numberOfSquares; squareCount++)
    {
        for(int squareColumn = 0; squareColumn < numberOfColumns / SquareSize; squareColumn++)
        {
            for(int squareRow = 0; squareRow < numberOfRows / SquareSize; squareRow++)
            {
                var stringBuilder = new StringBuilder();
                var startingColumn = squareColumn * SquareSize;
                var startingRow = squareRow * SquareSize;
                for (int column = startingColumn; column < SquareSize + startingColumn; column++)
                {
                    for (int rows = startingRow; rows < SquareSize + startingRow; rows++)
                    {
                        stringBuilder.Append(array[column, rows]);
                    }
                }
                var result = stringBuilder.ToString();
                if (result.Distinct().Count() != result.Length)
                    return false;
            }
        }
    }

    return true;
}
Console.WriteLine(CheckSudoku(new int[9, 9] {
    { 1, 5, 7, 4, 8, 3, 6, 2, 9},
    { 6, 3, 8, 1, 2, 9, 7, 5, 4},
    { 4, 9, 2, 5, 6, 7, 1, 3, 8},
    { 8, 4, 5, 9, 7, 6, 3, 1, 2},
    { 7, 2, 1, 3, 5, 8, 9, 4, 6},
    { 3, 6, 9, 2, 1, 4, 5, 8, 7},
    { 5, 1, 6, 7, 4, 2, 8, 9, 3},
    { 2, 8, 3, 6, 9, 1, 4, 7, 5},
    { 9, 7, 4, 8, 3, 5, 2, 6, 1},}));
