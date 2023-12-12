
using Xunit;
using System.Linq;
using MatCom.Examen;
using System.Collections.Generic;
using System;
namespace MatCom.Tester;

public enum TestType
{
    CreateCalculator, //done
    CheckSum, //done
    CheckSubtraction, //done
    CheckMultiplication, //done
    CheckDivision, //done
    CheckDivisionByZero, //done
    CheckUndo, //done
    CheckMultipleUndo, //done
    CheckRedo, //done
    CheckMultipleRedo, //done
    CheckAllOperations, //done
    CheckEffectiveOperations, //done
}

public static class Utils
{

    public static Operacion CreateOperation(char operador, int operando)
    {
        Operacion operation = new Operacion(operador, operando);
        Assert.NotNull(operation);
        return operation;
    }

    public static ICalculadora CreateCalculator()
    {
        ICalculadora calculator = new CalculadoraSimple();
        Assert.NotNull(calculator);
        return calculator;
    }

    public static void CheckEffectiveOperations(int seed)
    {
        // create a calculator
        ICalculadora calculator = CreateCalculator();

        // create an array of operations
        var operations = new Operacion[]
        {
            CreateOperation('+', 1),
            CreateOperation('-', 2)
        };

        // operate the first two
        calculator.Ejecuta(operations[0]);
        Assert.Equal(1, calculator.ResultadoActual());
        calculator.Ejecuta(operations[1]);
        Assert.Equal(-1, calculator.ResultadoActual());

        // get the effective operations
        var effectiveOperations = new List<Operacion>(calculator.OperacionesEfectivas());

        for (int i = 0; i < effectiveOperations.Count; i++)
        {
            Assert.Equal(operations[i], effectiveOperations[i]);
        }

        // undo the last operation
        calculator.Undo();
        Assert.Equal(1, calculator.ResultadoActual());

        // get the effective operations
        effectiveOperations = new List<Operacion>(calculator.OperacionesEfectivas());

        for (int i = 0; i < effectiveOperations.Count; i++)
        {
            Assert.Equal(operations[i], effectiveOperations[i]);
        }

        // redo the last operation
        calculator.Redo();
        Assert.Equal(-1, calculator.ResultadoActual());

        // get the effective operations
        effectiveOperations = new List<Operacion>(calculator.OperacionesEfectivas());

        for (int i = 0; i < effectiveOperations.Count; i++)
        {
            Assert.Equal(operations[i], effectiveOperations[i]);
        }

        // redo again
        calculator.Redo();
        Assert.Equal(-1, calculator.ResultadoActual());

        // get the effective operations
        effectiveOperations = new List<Operacion>(calculator.OperacionesEfectivas());

        for (int i = 0; i < effectiveOperations.Count; i++)
        {
            Assert.Equal(operations[i], effectiveOperations[i]);
        }
    }
}
