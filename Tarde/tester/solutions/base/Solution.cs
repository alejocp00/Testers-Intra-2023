using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatCom.Examen;

public class CalculadoraSimple : ICalculadora
{
    /// <summary>
    /// Constructor sin parámetros
    /// </summary>
    public CalculadoraSimple()
    {
        //TODO: Implementar las inicializaciones necesarias
    }

    /// <summary>
    /// Procesa la instrucción especificada. Si la operación especificada 
    /// es '/' y el valor es 0 el método debe lanzar una excepción del 
    /// tipo DivideByZeroException. 
    /// </summary>
    /// <param name="operacion">Instancia de la clase Operacion que describe 
    /// la operacion a realizar.
    /// </param>
    public void Ejecuta(Operacion operacion)
    {

    }

    /// <summary>
    /// Deshace la última instrucción, si no hay ninguna instrucción el 
    /// método no tiene ningún efecto.
    /// </summary>
    public void Undo()
    {

    }

    /// <summary>
    /// Deja sin efecto la última instrucción "Undo". El método solamente 
    /// tiene efecto cuando es invocado después de una instrucción de tipo 
    /// "Undo" o "Redo".
    /// </summary>
    public void Redo()
    {

    }

    /// <summary>
    /// El método calcula el resultado de realizar todas las operaciones 
    /// efectivas. Una operación efectiva es toda aquella que no ha sido 
    /// "des-hecha" a través de la instrucción "Undo", o que después 
    /// de "des-hecha" ha sido "re-hecha" a través de la instrucción "Redo"
    /// </summary>
    /// <returns>Retorna el resultado calculado</returns>
    public int ResultadoActual()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Devuelve una secuencia de todas las operaciones efectivas realizadas hasta el 
    /// momento. 
    /// </summary>
    /// <returns>La secuencia calculada</returns>
    public IEnumerable<Operacion> OperacionesEfectivas()
    {
        throw new NotImplementedException();
    }
}