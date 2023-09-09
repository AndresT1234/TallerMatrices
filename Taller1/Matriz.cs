using System;

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
            this.matrix = new int[filas,columnas];
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

        public  int[,] GetMatrix()
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

            while (potencia > 0)
            {
                if (potencia % 2 == 1)
                {
                    resultado = resultado.Multiplicar(baseMatriz);
                }
                baseMatriz = baseMatriz.Multiplicar(baseMatriz);
                potencia /= 2;
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
             
    }
}