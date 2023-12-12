using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatCom.Examen;

/// <summary>
/// Describe una operación especificando el operador y el valor con el que operar
/// </summary>
public class Operacion
{
    /// <summary>
    /// Constructor, crea una instancia a partir del operador y el valor
    /// especificados
    /// </summary>
    /// <param name="operador">Operador que caracteriza la operación, solamente
    /// son aceptados uno de los 4 valores siguientes: ('+','-','*','/')
    /// </param>
    /// <param name="operando">Valor con el que se realizará la operación</param>
    public Operacion(char operador, int operando)
    {
        Operador = operador; Operando = operando;
    }

    /// <summary>
    /// Propiedad de solo lectura para acceder al Operador que caracteriza la
    /// operación
    /// </summary>
    public char Operador { get; private set; }

    /// <summary>
    /// Propiedad de solo lectura para acceder al Operando con que se realizará la
    /// operación
    /// </summary>
    public int Operando { get; private set; }

    /// <summary>
    /// Redefinición del método ToString() para facilitar la visualización de
    /// objetos de este tipo
    /// </summary>
    /// <returns>Retorna una cadena que representa la operacion</returns>
    public override string ToString()
    {
        return string.Format("({0} {1})", Operador, Operando);
    }
}

public interface ICalculadora
{
    /// <summary>
    /// Procesa la instrucción especificada. Si la operación especificada
    /// es '/' y el valor es 0 el método debe lanzar una excepción del
    /// tipo DivideByZeroException.
    /// </summary>
    /// <param name="operacion">Instancia de la clase Operacion que describe
    /// la operacion a realizar.
    /// </param>
    void Ejecuta(Operacion operacion);

    /// <summary>
    /// Deshace la última instrucción, si no hay ninguna instrucción el
    /// método no tiene ningún efecto.
    /// </summary>
    void Undo();

    /// <summary>
    /// Deja sin efecto la última instrucción "Undo". El método solamente
    /// tiene efecto cuando es invocado después de una instrucción de tipo
    /// "Undo" o "Redo".
    /// </summary>
    void Redo();

    /// <summary>
    /// El método calcula el resultado de realizar todas las operaciones
    /// efectivas. Una operación efectiva es toda aquella que no ha sido
    /// "des-hecha" a través de la instrucción "Undo", o que después
    /// de "des-hecha" ha sido "re-hecha" a través de la instrucción "Redo"
    /// </summary>
    /// <returns>Retorna el resultado calculado</returns>
    int ResultadoActual();

    /// <summary>
    /// Devuelve una secuencia de todas las operaciones efectivas realizadas
    /// hasta el momento
    /// </summary>
    /// <returns>La secuencia calculada</returns>
    IEnumerable<Operacion> OperacionesEfectivas();
}
