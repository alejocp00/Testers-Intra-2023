
using Xunit;
using System.Linq;

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MatCom.Tester;

public class UnitTest
{
    [Fact]
    public void CreateCell()
    {
        // create a new cell
        var cell = Utils.CreateCell(1, 1, 1);
    }

    [Theory]
    [InlineData(2894)]
    // [InlineData(492)]
    // [InlineData(4958)]
    // [InlineData(952)]
    // [InlineData(2439)]
    // [InlineData(2984)]
    // [InlineData(492)]
    // [InlineData(405)]
    // [InlineData(112)]
    public void CreateMatrix(int seed)
    {
        // create a new matrix
        var matrix = Utils.CreateMatrix(seed);
    }


    [Theory]
    [InlineData(240)]
    // [InlineData(2409)]
    // [InlineData(24092)]
    // [InlineData(283)]
    // [InlineData(9403)]
    // [InlineData(2942)]
    // [InlineData(2984)]
    // [InlineData(439)]
    // [InlineData(293)]
    // [InlineData(12377)]
    public void InsertInRange(int seed)
    {
        // create the new matrix
        var matrix = Utils.CreateMatrix(seed);

        // insert a new cell out of range upper
        Assert.Throws<IndexOutOfRangeException>(() =>
        {
            matrix.Inserta(Utils.CreateCell(matrix.Filas + 1, matrix.Columnas + 1, 1));
        });

        // insert a new cell out of range lower
        Assert.Throws<IndexOutOfRangeException>(() =>
        {
            matrix.Inserta(Utils.CreateCell(-1, -1, 1));
        });
    }

    [Theory]
    [InlineData(1)]
    // [InlineData(292)]
    // [InlineData(514)]
    // [InlineData(482)] 
    // [InlineData(582)]
    // [InlineData(2894)]
    // [InlineData(9292)]
    // [InlineData(294)]
    // [InlineData(444)]
    // [InlineData(298)]
    // [InlineData(43)]
    public void InsertCorrectly(int seed)
    {

        var matrix = Utils.CreateMatrix(seed);

        Utils.Insert(seed, matrix);

    }

    [Theory]
    [InlineData(4398)]
    // [InlineData(439)]
    // [InlineData(292)]
    // [InlineData(50)]
    // [InlineData(15)]
    // [InlineData(11894)]
    // [InlineData(4781)]
    // [InlineData(192)]
    // [InlineData(289)]
    // [InlineData(5471)]
    public void InsertUpdate(int seed)
    {

        var matrix = Utils.CreateMatrix(seed);

        Utils.InsertUpdate(seed, matrix);
    }

    [Theory]
    [InlineData(583)]
    // [InlineData(8592)]
    // [InlineData(20)]
    // [InlineData(415)]
    // [InlineData(221)]
    // [InlineData(228)]
    // [InlineData(243)]
    // [InlineData(340)]
    // [InlineData(209)]
    // [InlineData(4293)]
    public void InsertDelete(int seed)
    {

        var matrix = Utils.CreateMatrix(seed);

        Utils.InsertDelete(seed, matrix);
    }

    [Theory]
    [InlineData(242)]
    // [InlineData(349)]
    // [InlineData(1895)]
    // [InlineData(2951)]
    // [InlineData(195)]
    // [InlineData(1985)]
    // [InlineData(189)]
    // [InlineData(289)]
    // [InlineData(19815)]
    // [InlineData(8349)]
    public void TakeNonCeroElements(int seed)
    {
        InsertDelete(seed);
    }

    [Theory]
    [InlineData(1932)]
    // [InlineData(5115)]
    // [InlineData(51)]
    // [InlineData(15641)]
    // [InlineData(2984)]
    // [InlineData(98741)]
    // [InlineData(151)]
    // [InlineData(981)]
    // [InlineData(9126)]
    // [InlineData(8941)]
    public void TakeValueInRange(int seed)
    {
        var matrix = Utils.CreateMatrix(seed);

        // poblate
        Utils.Insert(seed, matrix);

        // take a value that are out of range upper
        Assert.Throws<IndexOutOfRangeException>(() =>
        {
            matrix.ValorEn(matrix.Filas + 1, matrix.Columnas + 1);
        });

        // take a value that are of range lower
        Assert.Throws<IndexOutOfRangeException>(() =>
        {
            matrix.ValorEn(-1, -1);
        });
    }

    [Theory]
    [InlineData(489)]
    // [InlineData(927)]
    // [InlineData(98115)]
    // [InlineData(156)]
    // [InlineData(9811)]
    // [InlineData(6516)]
    // [InlineData(166)]
    // [InlineData(19561)]
    // [InlineData(1981)]
    // [InlineData(9156)]
    public void TakeValueInReturn(int seed)
    {
        InsertCorrectly(seed);
    }

    [Theory]
    [InlineData(24)]
    // [InlineData(294)]
    // [InlineData(402)]
    // [InlineData(923)]
    // [InlineData(194)]
    // [InlineData(924)]
    // [InlineData(249)]
    // [InlineData(9035)]
    // [InlineData(5892)]
    // [InlineData(489)]
    public void TakeValueInReturnCero(int seed)
    {
        var matrix = Utils.CreateMatrix(seed);
        Utils.TakeValueInReturnCero(seed, matrix);
    }

    [Theory]
    [InlineData(8912)]
    // [InlineData(554)]
    // [InlineData(515)]
    // [InlineData(152)]
    // [InlineData(5165)]
    // [InlineData(87512)]
    // [InlineData(1781)]
    // [InlineData(861)]
    // [InlineData(516)]
    // [InlineData(8941)]
    public void AddInRange(int seed)
    {
        var matrix1 = Utils.CreateMatrix(seed);

        var matrix2 = Utils.CreateMatrix(seed + 1);
        while (matrix1.Filas == matrix2.Filas && matrix1.Columnas == matrix2.Columnas)
        {
            matrix2 = Utils.CreateMatrix(seed + 1);
        }

        Assert.Throws<InvalidOperationException>(() => matrix1.Adiciona(matrix2));

    }

    [Theory]
    [InlineData(65)]
    // [InlineData(45)]
    // [InlineData(5416)]
    // [InlineData(89512)]
    // [InlineData(51631)]
    // [InlineData(1561)]
    // [InlineData(8910)]
    // [InlineData(78615)]
    // [InlineData(815)]
    // [InlineData(6516)]
    public void AddCorrectly(int seed)
    {
        var matrix1 = Utils.CreateMatrix(seed);

        var matrix2 = Utils.CreateMatrix(matrix1);

        Utils.AddCorrectly(seed, matrix1, matrix2);
    }

    [Theory]
    [InlineData(5844)]
    // [InlineData(151)]
    // [InlineData(8888)]
    // [InlineData(865)]
    // [InlineData(21684)]
    // [InlineData(6841)]
    // [InlineData(611)]
    // [InlineData(651)]
    // [InlineData(1651)]
    // [InlineData(489)]
    public void AddDelete(int seed)
    {
        var matrix1 = Utils.CreateMatrix(seed);

        var matrix2 = Utils.CreateMatrix(matrix1);

        Utils.AddDelete(seed, matrix1, matrix2);
    }

    [Theory]
    [InlineData(321)]
    // [InlineData(654)]
    // [InlineData(115)]
    // [InlineData(8544)]
    // [InlineData(556)]
    // [InlineData(111)]
    // [InlineData(455)]
    // [InlineData(894)]
    // [InlineData(8965)]
    // [InlineData(788)]
    public void RowEnumerator(int seed)
    {
        var matrix = Utils.CreateMatrix(seed);

        Utils.RowEnumerator(seed, matrix);
    }

    [Theory]
    [InlineData(4811)]
    // [InlineData(1981)]
    // [InlineData(165)]
    // [InlineData(5611)]
    // [InlineData(4651)]
    // [InlineData(1651)]
    // [InlineData(891)]
    // [InlineData(415)]
    // [InlineData(8941)]
    // [InlineData(489)]
    public void ColumnEnumerator(int seed)
    {
        var matrix = Utils.CreateMatrix(seed);

        Utils.ColumnEnumerator(seed, matrix);
    }
}

