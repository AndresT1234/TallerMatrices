using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Taller1_Matrices
{
    public class Matriz
    {
        private int filas;
        private int columnas;
        private int[,] matrix;

        public Matriz()
        {
        }

        public Matriz(int filas, int columnas)
        {
            this.filas = filas;
            this.columnas = columnas;
            this.matrix = new int[filas, columnas];
        }

        public int GetFilas()
        {
            return filas;
        }

        public int GetColumnas()
        {
            return columnas;
        }

        public void SetMatrix(int[,] x)
        {
            matrix = x;
        }

        public int[,] GetMatrix()
        {
            return matrix;
        }

        public override string ToString()
        {
            string resultado = "";
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    resultado += matrix[i, j] + " ";
                }
                resultado += "\n";
            }
            return resultado;
        }

        public bool equals(object otraMatriz)
        {
            if (otraMatriz == null)
                return false;

            Matriz nuevito = (Matriz)otraMatriz;

            // Comprobando dimensiones iguales
            if (this.filas != nuevito.filas || this.columnas != nuevito.columnas)
                return false;

            // Comprobando componente por componente
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    if (this.matrix[i, j] != nuevito.matrix[i, j])
                        return false;
                }
            }
            return true;
        }

        public int HashEquipo(string[] idMiembros)
        {
            int resultado = 0;
            int valor;
            foreach (string amiguitos in idMiembros)
            {
                valor = amiguitos.GetHashCode();
                resultado += valor;
                // Console.WriteLine($"Para {amiguitos} el valor es {valor} y el resultado va en ... {resultado}"); prueba
            }
            return Math.Abs(resultado % 5); //como da -4, se saca el valor absoluta ya que el hascode me da un valor con signo
        }

        public Matriz Sumar(Matriz nuevamatriz)
        {
            if (this.filas != nuevamatriz.filas || this.columnas != nuevamatriz.columnas)
            {
                throw new Exception("Las matrices deben tener las mismas dimensiones para poder realizar la suma");
            }

            Matriz resultado = new Matriz(GetFilas(), GetColumnas());

            for (int i = 0; i < GetFilas(); i++)
            {
                for (int j = 0; j < GetColumnas(); j++)
                {
                    resultado.matrix[i, j] = this.matrix[i, j] + nuevamatriz.matrix[i, j];
                }
            }
            return resultado;
        }

        public Matriz Multiplicar(Matriz nuevamatriz)
        {
            if (GetColumnas() != nuevamatriz.filas)
            {
                throw new Exception("La matriz no es cuadrada, no se pueden calcular potencias.");
            }

            Matriz resultado = new Matriz(GetFilas(), nuevamatriz.columnas);

            for (int i = 0; i < GetFilas(); i++)
            {
                for (int j = 0; j < nuevamatriz.columnas; j++)
                {
                    int suma = 0;
                    for (int k = 0; k < GetColumnas(); k++)
                    {
                        suma += this.matrix[i, k] * nuevamatriz.matrix[k, j];
                    }
                    resultado.matrix[i, j] = suma;
                }
            }
            return resultado;
        }

        public Matriz Potencia(int potencia)
        {
            if (GetFilas() != GetColumnas())
            {
                throw new Exception("La matriz no es cuadrada, no se pueden calcular potencias.");
            }

            Matriz resultado = new Matriz(GetFilas(), GetColumnas());

            // Copiar la matriz original en baseMatriz
            Matriz baseMatriz = new Matriz(GetFilas(), GetColumnas());

            for (int i = 0; i < GetFilas(); i++)
            {
                for (int j = 0; j < GetColumnas(); j++)
                {
                    baseMatriz.matrix[i, j] = this.matrix[i, j];
                }
            }

            // Inicializar la matriz resultado como la matriz identidad
            for (int i = 0; i < filas; i++)
            {
                resultado.matrix[i, i] = 1;
            }

            for (; potencia > 0; potencia /= 2, baseMatriz = baseMatriz.Multiplicar(baseMatriz))
            {
                if (potencia % 2 == 1)
                {
                    resultado = resultado.Multiplicar(baseMatriz);
                }
            }

            return resultado;
        }

        public void InicializarMatriz()
        {
            Random random = new Random(DateTime.Now.Millisecond);//un milisegundo del tiempo actual, una semilla al metodo
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    this.matrix[i, j] = random.Next(6);
                }
            }
        }



        public static void Main(string[] args)
        {
            //---------------------------------------------------------------------------------

            Matriz matrixA = new Matriz();
            int[,] matrizAArray = { { 2, 2, 2 }, { 2, 2, 2 }, { 2, 2, 2 } };
            matrixA.SetMatrix(matrizAArray);

            Matriz matrixB = new Matriz();
            int[,] matrizBArray = { { 2, 2, 2 }, { 2, 2, 2 }, { 2, 2, 2 } };
            matrixB.SetMatrix(matrizBArray);

            Matriz matrixC = new Matriz();
            int[,] matrizCArray = { { 4, 4, 4 }, { 4, 4, 4 }, { 4, 4, 4 } };
            matrixC.SetMatrix(matrizCArray);

            Matriz matrixD = new Matriz();
            int[,] matrizDArray = { { 72, 72, 72 }, { 72, 72, 72 }, { 72, 72, 72 } };
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

            //--------------------->Prueba #1

            // Arrange
            Matriz matriz = new Matriz(2, 2);
            matriz.GetMatrix()[0, 0] = 2;
            matriz.GetMatrix()[0, 1] = 2;
            matriz.GetMatrix()[1, 0] = 2;
            matriz.GetMatrix()[1, 1] = 2;

            // Act
            Matriz resultado = matriz.Potencia(3);

            // Assert
            Assert.AreEqual(32, resultado.GetMatrix()[0, 0]);
            Assert.AreEqual(32, resultado.GetMatrix()[0, 1]);
            Assert.AreEqual(32, resultado.GetMatrix()[1, 0]);
            Assert.AreEqual(32, resultado.GetMatrix()[1, 1]);

            //--------------------->prueba#2

            // Arrange
            Matriz matriz2 = new Matriz(2, 2);
            matriz2.GetMatrix()[0, 0] = 1;
            matriz2.GetMatrix()[0, 1] = 2;
            matriz2.GetMatrix()[1, 0] = 3;
            matriz2.GetMatrix()[1, 1] = 4;

            // Act
            Matriz resultado2 = matriz2.Potencia(5);

            // Assert
            Assert.AreEqual(1069, resultado2.GetMatrix()[0, 0]);
            Assert.AreEqual(1558, resultado2.GetMatrix()[0, 1]);
            Assert.AreEqual(2337, resultado2.GetMatrix()[1, 0]);
            Assert.AreEqual(3406, resultado2.GetMatrix()[1, 1]);

            //---------------------->prueba #3

            // Arrange
            Matriz matriz3 = new Matriz(3, 3);
            matriz3.GetMatrix()[0, 0] = 1;
            matriz3.GetMatrix()[0, 1] = 2;
            matriz3.GetMatrix()[0, 2] = 3;
            matriz3.GetMatrix()[1, 0] = 4;
            matriz3.GetMatrix()[1, 1] = 5;
            matriz3.GetMatrix()[1, 2] = 6;
            matriz3.GetMatrix()[2, 0] = 7;
            matriz3.GetMatrix()[2, 1] = 8;
            matriz3.GetMatrix()[2, 2] = 9;

            // Act
            Matriz resultado3 = matriz3.Potencia(3);

            // Assert
            Assert.AreEqual(468, resultado3.GetMatrix()[0, 0]);
            Assert.AreEqual(576, resultado3.GetMatrix()[0, 1]);
            Assert.AreEqual(684, resultado3.GetMatrix()[0, 2]);
            Assert.AreEqual(1062, resultado3.GetMatrix()[1, 0]);
            Assert.AreEqual(1305, resultado3.GetMatrix()[1, 1]);
            Assert.AreEqual(1548, resultado3.GetMatrix()[1, 2]);
            Assert.AreEqual(1656, resultado3.GetMatrix()[2, 0]);
            Assert.AreEqual(2034, resultado3.GetMatrix()[2, 1]);
            Assert.AreEqual(2412, resultado3.GetMatrix()[2, 2]);

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
                int potencia = 5; // Potencia 
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

