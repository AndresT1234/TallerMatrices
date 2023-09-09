using System;
using Taller1_Matrices;

namespace Taller1_Matrices
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //---------------------------------------------------------------------------------

            Matriz matrixA = new Matriz();
            int[,] matrizAArray = { { 2, 2, 2 }, { 2, 2, 2 }, { 2, 2, 2 }};
            matrixA.SetMatrix(matrizAArray);

            Matriz matrixB = new Matriz();
            int[,] matrizBArray = { { 2, 2, 2 }, { 2, 2, 2 }, { 2, 2, 2 }};
            matrixB.SetMatrix(matrizBArray);

            Matriz matrixC = new Matriz();
            int[,] matrizCArray = { { 4, 4, 4 }, { 4, 4, 4 }, { 4, 4, 4 } };
            matrixC.SetMatrix(matrizCArray);

            Matriz matrixD = new Matriz();
            int[,] matrizDArray = { { 72, 72, 72 }, { 72, 72, 72 }, { 72, 72, 72 }};
            matrixD.SetMatrix(matrizDArray);

            Matriz matrixE = new Matriz();
            int[,] matrizEArray = { { 15552, 15552, 15552 }, { 15552, 15552, 15552 }, { 15552, 15552, 15552 } };
            matrixE.SetMatrix(matrizEArray);

            Console.WriteLine("\nPruebas De Metodos implementados usando el Metodo equals");
            Console.WriteLine("------------------------------------------------------------");

            Matriz sumado = matrixA.Sumar(matrixB);
            Matriz multiplicado = matrixA.Multiplicar(matrixB);
            Matriz potenciado = matrixA.Potencia(6);
            

            if (matrixC.equals(sumado))
            {
                Console.WriteLine("La suma es igual a la matriz C.\n");
            }
            else
            {
                Console.WriteLine("La suma no es igual a la matriz C.\n");
            }

            if (matrixD.equals(multiplicado))
            {
                Console.WriteLine("La multiplicacion es igual a la matriz D.\n");
            }
            else
            {
                Console.WriteLine("La multiplicacion no es igual a la matriz D.\n");
            }

            if (matrixE.equals(potenciado))
            {
                Console.WriteLine("La potenciacion es igual a la matriz E.");
            }
            else
            {
                Console.WriteLine("La potenciacion no es igual a la matriz E.");
            }
            Console.WriteLine("------------------------------------------------------------");

            //----------------------------------------------------------------------------------

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
