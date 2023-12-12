using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatCom.Examen;

public class Matriz : IMatriz
{
    /// <summary>
    /// Inicializa una instancia de la clase Matriz
    /// </summary>
    /// <param name="filas">Cantidad de filas de la matriz</param>
    /// <param name="columnas">Cantidad de columnas de la matriz</param>
    public Matriz(int filas, int columnas)
    {
        throw new NotImplementedException();

    }

    /// <summary>
    /// Devuelve la cantidad de filas de la matriz
    /// </summary>
    public int Filas
    {
        get
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Devuelve la cantidad de columnas de la matriz
    /// </summary>
    public int Columnas
    {
        get
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Devuelve la cantidad de elementos distintos de 0
    /// </summary>
    public int CantidadDeElementosNoNulos
    {
        get
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Inserta una celda en la matriz. Si los valores de fila o columna de la celda
    /// se salen de los límites especificados en el constructor el método debe lanzar  
    /// una excepción del tipo IndexOutOfRangeException si  ya existía una
    /// celda en esa posición lo que se le hace es cambiar el valor. La inserción
    /// de un valor igual a 0 no debe adicionar una nueva celda, si la celda ya    
    /// existía entonces deberá ser eliminada.
    /// </summary>
    /// <param name="celda">Nodo a insertar, provee fila, columna y valor</param>
    public void Inserta(CeldaMatriz celda)
    {
        throw new NotImplementedException();

    }

    /// <summary>
    /// Devuelve el valor en la fila,columna dada. Si los valores de fila o 
    /// columna se salen de los límites especificados en el constructor 
    /// el método debe lanzar una excepción del tipo IndexOutOfRangeException. Si
    /// nunca ha sido insertada una celda en dicha fila,columna (o se canceló y eliminó)
    /// se debe retornar el valor 0.
    /// </summary>
    /// <param name="fila">Fila donde se encuentra el valor</param>
    /// <param name="columna">Columna donde se encuentra el valor</param>
    /// <returns>Retorna el valor</returns>
    public int ValorEn(int fila, int columna)
    {
        throw new NotImplementedException();

    }

    /// <summary>
    /// Realiza la operacion de suma entre la matriz actual y la matriz que se 
    /// recibe como parámetro, si la operación de suma provoca la inserción de 
    /// valores nulos en la matriz, estas celdas deben ser excluidas, exactamente 
    /// como cuando se hace en la inserción de un valor nulo
    /// </summary>
    /// <param name="otra">Matriz para sumar con la matriz actual. Esta matriz debe
    /// tener las mismas dimensiones que la matriz actual.</param>
    public void Adiciona(IMatriz otra)
    {
        throw new NotImplementedException();

    }

    /// <summary>
    /// Itera sobre los elementos de la fila especificada
    /// </summary>
    /// <param name="fila">Fila de la cual se quieren recuperar los elementos</param>
    /// <returns>Retorna la secuencia de elementos distintos de 0 en la fila</returns>
    public IEnumerable<CeldaMatriz> Fila(int fila)
    {
        throw new NotImplementedException();

    }

    /// <summary>
    /// Itera sobre los elementos de la columna especificada
    /// </summary>
    /// <param name="columna">Columna de la cual se quieren recuperar los elementos</param>
    /// <returns>Retorna la secuencia de elementos distintos de 0 en la columna</returns>
    public IEnumerable<CeldaMatriz> Columna(int columna)
    {
        throw new NotImplementedException();

    }

    /// <summary>
    /// Implementación de la Interfaz IEnumerable<CeldaMatriz>
    /// El objetivo es devolver todos los elementos no nulos de la matriz
    /// </summary>
    /// <returns></returns>
    public IEnumerator<CeldaMatriz> GetEnumerator()
    {
        throw new NotImplementedException();

    }

    /// <summary>
    /// Implementación implícita de la interfaz IEnumerable
    /// </summary>
    /// <returns></returns>
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}
