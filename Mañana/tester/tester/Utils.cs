
using Xunit;
using System.Linq;
using MatCom.Examen;
using System.Collections.Generic;
using System;
namespace MatCom.Tester;

public enum TestType
{
    CreateCell,
    CreateMatrix,
    InsertInRange,
    InsertCorrectly,
    InsertUpdate,
    InsertDelete,
    TakeNonCeroElements,
    TakeValueInRange,
    TakeValueInReturn,
    TakeValueInReturnCero,
    AddInRange,
    AddCorrectly,
    AddDelete,
    RowEnumerator,
    ColumnEnumerator,
}

public static class Utils
{
    private const int minRowSize = 70000;
    private const int minColumnSize = 70000;

    private const int maxCellsToCreate = 20;


    private static Tuple<int, int> GetRandomRowsAndColumns(int seed, int rowMin = minRowSize, int columnMin = minColumnSize, int rowMax = int.MaxValue - 1, int columnMax = int.MaxValue - 1)
    {
        var random = new Random();
        var rows = random.Next(rowMin, rowMax);
        var columns = random.Next(columnMin, columnMax);

        return new Tuple<int, int>(rows, columns);
    }


    public static IMatriz CreateMatrix(int seed)
    {
        // get random size
        var (rows, columns) = GetRandomRowsAndColumns(seed);

        var matrix = new Matriz(rows, columns);

        Assert.Equal(matrix.Filas, rows);
        Assert.Equal(matrix.Columnas, columns);
        Assert.Equal(0, matrix.CantidadDeElementosNoNulos);

        return matrix;
    }

    public static IMatriz CreateMatrix(IMatriz matrix1)
    {
        return new Matriz(matrix1.Filas, matrix1.Columnas);
    }


    public static CeldaMatriz CreateCell(int row, int column, int value)
    {
        var cell = new CeldaMatriz(row, column, value);

        Assert.Equal(cell.Fila, row);
        Assert.Equal(cell.Columna, column);
        Assert.Equal(cell.Valor, value);

        return cell;
    }

    private static List<CeldaMatriz> CreateCellsToInsert(int seed, int minRow = 0, int minColumn = 0, int maxRow = int.MaxValue - 1, int maxColumn = int.MaxValue - 1)
    {
        // list of cells to insert
        List<CeldaMatriz> cells = new List<CeldaMatriz>();

        // populate list
        for (int i = 0; i < seed % maxCellsToCreate; i++)
        {
            var (rows, columns) = GetRandomRowsAndColumns(seed, minRow, minColumn, maxRow, maxColumn);
            var value = new Random().Next(int.MinValue, int.MaxValue);

            var cell = CreateCell(rows, columns, value);
            cells.Add(cell);
        }

        return cells;
    }
    public static void AddCorrectly(int seed, IMatriz matrix1, IMatriz matrix2)
    {
        // list of cells to insert
        List<CeldaMatriz> cells = CreateCellsToInsert(seed, maxRow: matrix1.Filas, maxColumn: matrix1.Columnas);

        // insert cells
        Insert(cells, seed, matrix1);
        Insert(cells, seed, matrix2);

        // add matrix
        matrix1.Adiciona(matrix2);

        // check values
        foreach (var cell in cells)
        {
            Assert.Equal(cell.Valor + cell.Valor, matrix1.ValorEn(cell.Fila, cell.Columna));
        }
    }

    public static void RowEnumerator(int seed, IMatriz matrix)
    {
        // select a random row from the matrix
        var row = new Random(seed).Next(0, matrix.Filas - 1);

        // create a list of cells in the row
        var cells = CreateCellsToInsert(seed, row, 0, row, matrix.Columnas - 1);

        // insert cells
        Insert(cells, seed, matrix);

        // insert a cell in other row
        var otherRow = 0;
        while (otherRow == row)
        {
            otherRow = new Random(seed).Next(0, matrix.Filas - 1);
        }
        var otherCell = CreateCell(otherRow, 0, new Random(seed).Next(int.MinValue, 1));

        // insert cell
        matrix.Inserta(otherCell);

        // check values
        foreach (var cell in matrix.Fila(row))
        {
            Assert.Equal(cell.Valor, cells.Where(c => c.Fila == cell.Fila && c.Columna == cell.Columna).FirstOrDefault()?.Valor);
        }

    }

    public static void ColumnEnumerator(int seed, IMatriz matrix)
    {
        // select a random column from the matrix
        var column = new Random(seed).Next(0, matrix.Columnas - 1);

        // create a list of cells in the column
        var cells = CreateCellsToInsert(seed, 0, column, matrix.Filas - 1, column);

        // insert cells
        Insert(cells, seed, matrix);

        // insert a cell in other column
        var otherColumn = 0;
        while (otherColumn == column)
        {
            otherColumn = new Random(seed).Next(0, matrix.Columnas - 1);
        }
        var otherCell = CreateCell(0, otherColumn, new Random(seed).Next(int.MinValue, 1));

        // insert cell
        matrix.Inserta(otherCell);

        // check values
        foreach (var cell in matrix.Columna(column))
        {
            Assert.Equal(cell.Valor, cells.Where(c => c.Fila == cell.Fila && c.Columna == cell.Columna).FirstOrDefault()?.Valor);
        }

    }

    public static void AddDelete(int seed, IMatriz matrix1, IMatriz matrix2)
    {
        // list of cells to insert
        List<CeldaMatriz> cells = CreateCellsToInsert(seed, maxRow: matrix1.Filas, maxColumn: matrix1.Columnas);

        // insert cells
        Insert(cells, seed, matrix1);

        // create another list with the negative cells
        List<CeldaMatriz> negativeCells = new List<CeldaMatriz>();
        foreach (var cell in cells)
        {
            negativeCells.Add(CreateCell(cell.Fila, cell.Columna, -cell.Valor));
        }

        Insert(negativeCells, seed, matrix2);

        // add matrix
        matrix1.Adiciona(matrix2);

        Assert.Equal(0, matrix1.CantidadDeElementosNoNulos);
    }
    public static void Insert(int seed, IMatriz matrix)
    {
        // list of cells to insert
        List<CeldaMatriz> cells = CreateCellsToInsert(seed, maxRow: matrix.Filas, maxColumn: matrix.Columnas);

        // insert cells
        Insert(cells, seed, matrix);
    }

    private static void Insert(List<CeldaMatriz> cellsToInsert, int seed, IMatriz matrix)
    {
        foreach (var cell in cellsToInsert)
        {
            matrix.Inserta(cell);
            Assert.Equal(cell.Valor, matrix.ValorEn(cell.Fila, cell.Columna));
        }
    }

    public static void InsertUpdate(int seed, IMatriz matrix)
    {
        // list of cells to insert
        List<CeldaMatriz> cells = CreateCellsToInsert(seed, maxRow: matrix.Filas, maxColumn: matrix.Columnas);

        // insert cells
        Insert(cells, seed, matrix);

        // update cells
        foreach (var cell in cells)
        {
            var newValue = new Random().Next(int.MinValue, int.MaxValue);
            cell.Valor = newValue;
        }

        // insert cells
        Insert(cells, seed, matrix);
    }

    public static void InsertDelete(int seed, IMatriz matrix)
    {
        // list of cells to insert
        List<CeldaMatriz> cells = CreateCellsToInsert(seed, maxRow: matrix.Filas, maxColumn: matrix.Columnas);

        // insert cells
        Insert(cells, seed, matrix);

        // update cells value to 0
        foreach (var cell in cells)
        {
            cell.Valor = 0;
        }

        // add cells
        Insert(cells, seed, matrix);

        Assert.Equal(0, matrix.CantidadDeElementosNoNulos);

    }

    public static void TakeValueInReturnCero(int seed, IMatriz matrix)
    {
        // take 10 elements of a random valid range
        int cellsToTake = 10;

        for (int i = 0; i < cellsToTake; i++)
        {
            var (rows, columns) = GetRandomRowsAndColumns(seed, 0, 0, matrix.Filas - 1, matrix.Columnas - 1);
            var value = matrix.ValorEn(rows, columns);

            Assert.Equal(0, value);
        }
    }
}
