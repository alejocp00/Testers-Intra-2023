
using Xunit;
using System.Linq;

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MatCom.Tester;

public class UnitTest
{
    [Fact]
    public void CreateCalculator()
    {
        // create a new calculator
        var calculator = Utils.CreateCalculator();
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
    public void CheckSum(int seed)
    {
        // create a new calculator
        var calculator = Utils.CreateCalculator();

        // create a new operation
        var operation = Utils.CreateOperation('+', seed);

        // execute the operation
        calculator.Ejecuta(operation);

        // check the result
        Assert.Equal(seed, calculator.ResultadoActual());

        // create a new operation
        operation = Utils.CreateOperation('+', seed);

        // execute the operation
        calculator.Ejecuta(operation);

        // check the result
        Assert.Equal(seed + seed, calculator.ResultadoActual());
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
    public void CheckSubtraction(int seed)
    {
        // create a new calculator
        var calculator = Utils.CreateCalculator();

        // create a new operation
        var operation = Utils.CreateOperation('-', seed);

        // execute the operation
        calculator.Ejecuta(operation);

        // check the result
        Assert.Equal(-seed, calculator.ResultadoActual());

        // create a new operation
        operation = Utils.CreateOperation('-', seed);

        // execute the operation
        calculator.Ejecuta(operation);

        // check the result
        Assert.Equal(-seed - seed, calculator.ResultadoActual());
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
    public void CheckMultiplication(int seed)
    {
        // create a new calculator
        var calculator = Utils.CreateCalculator();


        // create a new operation
        var operation = Utils.CreateOperation('+', seed);

        // execute the operation
        calculator.Ejecuta(operation);

        // check the result
        Assert.Equal(seed, calculator.ResultadoActual());

        // create a new operation
        operation = Utils.CreateOperation('*', seed);

        // execute the operation
        calculator.Ejecuta(operation);

        // check the result
        Assert.Equal(seed * seed, calculator.ResultadoActual());

        // create a new operation for check negative numbers
        operation = Utils.CreateOperation('*', -1);

        // execute the operation
        calculator.Ejecuta(operation);

        // check the result
        Assert.Equal(-seed * seed, calculator.ResultadoActual());
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
    public void CheckDivision(int seed)
    {
        // create a new calculator
        var calculator = Utils.CreateCalculator();

        // create a new operation
        var operation = Utils.CreateOperation('+', seed);

        // execute the operation
        calculator.Ejecuta(operation);

        // check the result
        Assert.Equal(seed, calculator.ResultadoActual());

        // create a new operation
        operation = Utils.CreateOperation('/', -seed);

        // execute the operation
        calculator.Ejecuta(operation);

        // check the result
        Assert.Equal(-1, calculator.ResultadoActual());
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
    public void CheckDivisionByZero(int seed)
    {
        // create a new calculator
        var calculator = Utils.CreateCalculator();

        // create a new operation
        var operation = Utils.CreateOperation('/', 1);

        // execute the operation
        calculator.Ejecuta(operation);

        // check the result
        Assert.Equal(0, calculator.ResultadoActual());

        // create a new operation
        operation = Utils.CreateOperation('/', 0);

        // execute the operation
        Assert.Throws<DivideByZeroException>(() =>
        {
            calculator.Ejecuta(operation);
        });
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
    public void CheckUndo(int seed)
    {
        // create a new calculator
        var calculator = Utils.CreateCalculator();

        // create a new operation
        var operation = Utils.CreateOperation('+', seed);

        // execute the operation
        calculator.Ejecuta(operation);

        // check the result
        Assert.Equal(seed, calculator.ResultadoActual());

        // undo the operation
        calculator.Undo();

        // check the result
        Assert.Equal(0, calculator.ResultadoActual());
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
    public void CheckMultipleUndo(int seed)
    {
        // create a new calculator
        var calculator = Utils.CreateCalculator();

        // execute undo without operations
        calculator.Undo();

        // check the result
        Assert.Equal(0, calculator.ResultadoActual());

        // create a new operation
        var operation = Utils.CreateOperation('+', seed);

        // execute the operation
        calculator.Ejecuta(operation);

        // check the result
        Assert.Equal(seed, calculator.ResultadoActual());

        // create a new operation
        operation = Utils.CreateOperation('-', seed);

        // execute the operation
        calculator.Ejecuta(operation);

        // check the result
        Assert.Equal(0, calculator.ResultadoActual());

        // undo the operation
        calculator.Undo();

        // check the result
        Assert.Equal(seed, calculator.ResultadoActual());

        // undo the operation
        calculator.Undo();

        // check the result
        Assert.Equal(0, calculator.ResultadoActual());

        // undo the operation
        calculator.Undo();

        // check the result
        Assert.Equal(0, calculator.ResultadoActual());

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
    public void CheckRedo(int seed)
    {
        // create a new calculator
        var calculator = Utils.CreateCalculator();

        // create a new operation
        var operation = Utils.CreateOperation('+', seed);

        // execute the operation
        calculator.Ejecuta(operation);

        // check the result
        Assert.Equal(seed, calculator.ResultadoActual());

        // undo the operation
        calculator.Undo();

        // check the result
        Assert.Equal(0, calculator.ResultadoActual());

        // redo the operation
        calculator.Redo();

        // check the result
        Assert.Equal(seed, calculator.ResultadoActual());
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
    public void CheckMultipleRedo(int seed)
    {
        // create a new calculator
        var calculator = Utils.CreateCalculator();

        // execute redo without operations
        calculator.Redo();

        // check the result
        Assert.Equal(0, calculator.ResultadoActual());

        // create a new operation
        var operation = Utils.CreateOperation('+', seed);

        // execute the operation
        calculator.Ejecuta(operation);

        // check the result
        Assert.Equal(seed, calculator.ResultadoActual());

        // create a new operation
        operation = Utils.CreateOperation('+', seed);

        // execute the operation
        calculator.Ejecuta(operation);

        // check the result
        Assert.Equal(seed + seed, calculator.ResultadoActual());

        // undo the operation
        calculator.Undo();

        // check the result
        Assert.Equal(seed, calculator.ResultadoActual());

        // redo the operation
        calculator.Redo();

        // check the result
        Assert.Equal(seed + seed, calculator.ResultadoActual());

        // redo the operation
        calculator.Redo();

        // check the result
        Assert.Equal(seed + seed, calculator.ResultadoActual());
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
    public void CheckAllOperations(int seed)
    {
        // create a new calculator
        var calculator = Utils.CreateCalculator();

        // create a new operation
        var operation = Utils.CreateOperation('+', 2 * seed);

        // execute the operation
        calculator.Ejecuta(operation);

        // check the result
        Assert.Equal(2 * seed, calculator.ResultadoActual());

        // create a new operation
        operation = Utils.CreateOperation('-', seed);

        // execute the operation
        calculator.Ejecuta(operation);

        // check the result
        Assert.Equal(seed, calculator.ResultadoActual());

        // create a new operation
        operation = Utils.CreateOperation('*', seed);

        // execute the operation
        calculator.Ejecuta(operation);

        // check the result
        Assert.Equal(seed * seed, calculator.ResultadoActual());

        // create a new operation
        operation = Utils.CreateOperation('/', seed);

        // execute the operation
        calculator.Ejecuta(operation);

        // check the result
        Assert.Equal(seed, calculator.ResultadoActual());

        // undo the operation
        calculator.Undo();

        // check the result
        Assert.Equal(seed * seed, calculator.ResultadoActual());

        // undo the operation
        calculator.Undo();

        // check the result
        Assert.Equal(seed, calculator.ResultadoActual());

        // undo the operation
        calculator.Undo();

        // check the result
        Assert.Equal(2 * seed, calculator.ResultadoActual());

        // undo the operation
        calculator.Undo();

        // check the result
        Assert.Equal(0, calculator.ResultadoActual());

        for (int i = 0; i < 10; i++)
        {
            // redo the operation
            calculator.Redo();
        }
        // check the result
        Assert.Equal(seed, calculator.ResultadoActual());

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
    public void CheckEffectiveOperations(int seed)
    {
        Utils.CheckEffectiveOperations(seed);
    }

}

