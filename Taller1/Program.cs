using System;
using Taller2_Matrices;

namespace Taller2_Metrices
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Matriz matrixA = new Matriz();
            int[,] matrizAArray = { { 2, 2, 2 }, { 2, 2, 2 }, { 2, 2, 2 }, { 2, 2, 2 } };
            matrixA.SetMatrix(matrizAArray);

            Matriz matrixB = new Matriz();
            int[,] matrizBArray = { { 2, 2, 2 }, { 2, 2, 2 }, { 2, 2, 2 }, { 2, 2, 2 } };
            matrixB.SetMatrix(matrizBArray);

            Matriz matrixC = new Matriz();
            int[,] matrizCArray = { { 4, 4, 4 }, { 4, 4, 4 }, { 4, 4, 4 }, { 4, 4, 4 } };
            matrixC.SetMatrix(matrizCArray);

            Matriz sumado = matrixA.Sumar(matrixB);

            if (matrixC.Equals(sumado))
            {
                Console.WriteLine("La suma es igual a la matriz C.\n");
            }
            else
            {
                Console.WriteLine("La suma no es igual a la matriz C.\n");
            }

            Matriz matrix1 = new Matriz(3, 3);
            Matriz matrix2 = new Matriz(3, 3);

            matrix1.InicializarMatriz();
            matrix2.InicializarMatriz();

            Console.WriteLine("\nMatrix 1:");
            Console.WriteLine(matrix1.ToString());

            Console.WriteLine("Matrix 2:");
            Console.WriteLine(matrix2.ToString());

            Matriz suma = matrix1.Sumar(matrix2);
            Console.WriteLine("Resultado de la suma:");
            Console.WriteLine(suma.ToString() + "\n");

            try
            {
                Matriz multiplicacion = matrix1.Multiplicar(matrix2);
                Console.WriteLine("Resultado de la multiplicación:");
                Console.WriteLine(multiplicacion.ToString());

                Matriz equipo = new Matriz();
                string[] integrantes = { "491739", "493912" };
                Console.WriteLine("--------------INTEGRANTES----------------");
                Console.WriteLine("\n    EL GRUPO QUE NOS TOCÓ FUE EL: " + equipo.HashEquipo(integrantes) + "\n");
                Console.WriteLine("-----------------------------------------\n");

                Console.WriteLine("\nCalcular potencias de una matriz cuadrada\n");
                int potencia = 2; // Potencia 
                Matriz matrizOriginal = matrix1.Potencia(potencia);

                // Imprime la matriz resultado 
                Console.WriteLine("matriz1^" + potencia + ":\n");
                Console.WriteLine(matrizOriginal.ToString());
            }
            catch (Exception upss)
            {
                Console.WriteLine("Tuvimos un error :( --> " + upss.Message);
            }
        }
    }
}
