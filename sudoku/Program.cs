using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudoku
{
    class Program
    {
        class solucion
        {
            public static int[,] Base = {{0,4,0,1,0,0,0,2,0},
                                  {0,0,2,9,4,7,1,0,6},
                                  {0,9,0,6,5,2,0,0,0},
                                  {2,3,0,0,0,1,4,6,0},
                                  {0,0,4,2,8,5,7,0,0},
                                  {0,7,8,4,0,0,0,1,5},
                                  {0,0,3,8,7,9,0,5,0},
                                  {5,0,6,3,1,4,9,0,0},
                                  {0,8,0,0,0,6,0,4,0}};

            /*
            static int[,] Base = {{0,4,0,1,0,0,0,2,0},
                                  {0,0,2,9,4,7,1,0,6},
                                  {0,9,0,6,5,2,8,0,0},
                                  {2,3,0,0,0,1,4,6,0},
                                  {0,0,4,2,8,5,7,0,0},
                                  {0,7,8,4,0,0,0,1,5},
                                  {0,0,3,8,7,9,0,5,0},
                                  {5,0,6,3,1,4,9,0,0},
                                  {0,8,0,0,0,6,0,4,0}};//*/

            public int[,] filas = new int[9,9];

            public int evaluar()
            {
                int resultado = 0;
                for (int i = 0; i < 9; i++)
                {
                    List<int> listaHorizontal = new List<int>();
                    List<int> listaVertical = new List<int>();

                    for (int j = 0; j < 9; j++)
                    {
                        listaHorizontal.Add(j + 1);
                        listaVertical.Add(j + 1);
                    }

                    for (int j = 0; j < 9; j++)
                    {
                        listaHorizontal.Remove(this.filas[i, j]);
                        listaVertical.Remove(this.filas[j, i]);
                    }

                    resultado += listaHorizontal.Count;
                    resultado += listaVertical.Count;
                }



                List<int> lista1 = new List<int>();
                List<int> lista2 = new List<int>();
                List<int> lista3 = new List<int>();
                List<int> lista4 = new List<int>();
                List<int> lista5 = new List<int>();
                List<int> lista6 = new List<int>();
                List<int> lista7 = new List<int>();
                List<int> lista8 = new List<int>();
                List<int> lista9 = new List<int>();

                for (int i = 1; i < 10; i++)
                {
                    lista1.Add(i);
                    lista2.Add(i);
                    lista3.Add(i);
                    lista4.Add(i);
                    lista5.Add(i);
                    lista6.Add(i);
                    lista7.Add(i);
                    lista8.Add(i);
                    lista9.Add(i);
                }
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        lista1.Remove(filas[i, j]);
                        lista2.Remove(filas[3 + i, j]);
                        lista3.Remove(filas[6 + i, j]);
                        lista4.Remove(filas[i, 3 + j]);
                        lista5.Remove(filas[3 + i, 3 + j]);
                        lista6.Remove(filas[6 + i, 3 + j]);
                        lista7.Remove(filas[i, 6 + j]);
                        lista8.Remove(filas[3 + i, 6 + j]);
                        lista9.Remove(filas[6 + i, 6 + j]);
                    }
                }

                resultado += lista1.Count;
                resultado += lista2.Count;
                resultado += lista3.Count;
                resultado += lista4.Count;
                resultado += lista5.Count;
                resultado += lista6.Count;
                resultado += lista7.Count;
                resultado += lista8.Count;
                resultado += lista9.Count;//*/

                return resultado;
            }

            public int evaluarHorizontal()
            {
                int resultado = 0;
                for (int i = 0; i < 9; i++)
                {
                    List<int> listaHorizontal = new List<int>();

                    for (int j = 0; j < 9; j++)
                    {
                        listaHorizontal.Add(j + 1);
                    }

                    for (int j = 0; j < 9; j++)
                    {
                        listaHorizontal.Remove(this.filas[i, j]);
                    }

                    resultado += listaHorizontal.Count;
                }

                return resultado;
            }

            public int evaluarVertical()
            {
                int resultado = 0;
                for (int i = 0; i < 9; i++)
                {
                    List<int> listaVertical = new List<int>();

                    for (int j = 0; j < 9; j++)
                    {
                        listaVertical.Add(j + 1);
                    }

                    for (int j = 0; j < 9; j++)
                    {
                        listaVertical.Remove(this.filas[j, i]);
                    }

                    resultado += listaVertical.Count;
                }

                return resultado;
            }

            public int evaluarCuadros()
            {
                int resultado = 0;

                List<int> lista1 = new List<int>();
                List<int> lista2 = new List<int>();
                List<int> lista3 = new List<int>();
                List<int> lista4 = new List<int>();
                List<int> lista5 = new List<int>();
                List<int> lista6 = new List<int>();
                List<int> lista7 = new List<int>();
                List<int> lista8 = new List<int>();
                List<int> lista9 = new List<int>();

                for (int i = 1; i < 10; i++)
                {
                    lista1.Add(i);
                    lista2.Add(i);
                    lista3.Add(i);
                    lista4.Add(i);
                    lista5.Add(i);
                    lista6.Add(i);
                    lista7.Add(i);
                    lista8.Add(i);
                    lista9.Add(i);
                }
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        lista1.Remove(filas[i, j]);
                        lista2.Remove(filas[3 + i, j]);
                        lista3.Remove(filas[6 + i, j]);
                        lista4.Remove(filas[i, 3 + j]);
                        lista5.Remove(filas[3 + i, 3 + j]);
                        lista6.Remove(filas[6 + i, 3 + j]);
                        lista7.Remove(filas[i, 6 + j]);
                        lista8.Remove(filas[3 + i, 6 + j]);
                        lista9.Remove(filas[6 + i, 6 + j]);
                    }
                }

                resultado += lista1.Count;
                resultado += lista2.Count;
                resultado += lista3.Count;
                resultado += lista4.Count;
                resultado += lista5.Count;
                resultado += lista6.Count;
                resultado += lista7.Count;
                resultado += lista8.Count;
                resultado += lista9.Count;//*/

                return resultado;
            }

            public void generar()             
            {
                Random rand = new Random(DateTime.Now.Millisecond);
                for (int i = 0; i < 9; i++) 
                {
                    for (int j = 0; j < 9; j++) 
                    {
                        if (Base[i, j] != 0)
                        {
                            filas[i,j] = Base[i,j];
                        }
                        else
                        {
                            filas[i, j] = 1 + (rand.Next() % 9);
                        }
                    }
                }
            }

            public static int[,] descendencia(int[,] A, int[,] B)
            {
                Random rand = new Random(DateTime.Now.Millisecond);
                Random rand2 = new Random(DateTime.Now.Millisecond * DateTime.Now.Second);
                Random rand3 = new Random(DateTime.Now.Second);
                Random rand4 = new Random(DateTime.Now.Millisecond - DateTime.Now.Second);

                solucion retorno = new solucion();

                for (int i = 0; i < 9; i++)
                {
                    int probabilidadMutacion = rand.Next() % 8;
                    for (int j = 0; j < 9; j++)
                    {
                        if (Base[i, j] != 0)
                        {
                            retorno.filas[i, j] = Base[i, j];
                        }
                        else
                        {
                            int mutacion = rand3.Next() % 10;

                            if (mutacion < probabilidadMutacion)
                            {
                                retorno.filas[i, j] = 1 + rand4.Next() % 9;
                            }
                            else
                            {
                                if (mutacion < 7)
                                {
                                    retorno.filas[i, j] = A[i, j];
                                }
                                else
                                {
                                    retorno.filas[i, j] = B[i, j];
                                }
                            }
                        }
                    }
                }

                return retorno.filas;
            }

            public static bool intentarSolucionar(int[,] problema) 
            {
                bool hayCambios = false;

                for (int i = 0; i < 9; i++) 
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (problema[i, j] == 0) 
                        {
                            List<int> lista = new List<int>{ 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                            for (int k = 0; k < 9; k++) 
                            {
                                if (k != j && problema[i, k] != 0) 
                                {
                                    lista.Remove(problema[i,k]);
                                }
                                if (k != i && problema[k, j] != 0)
                                {
                                    lista.Remove(problema[k,j]);
                                }
                                int x = (i / 3)*3 + k % 3;
                                int y = (j / 3)*3 + k / 3;
                                if (problema[x,y]!=0) 
                                {
                                    lista.Remove(problema[x, y]);
                                }
                            }
                            if (lista.Count == 1) 
                            {
                                problema[i, j] = lista[0];
                                hayCambios = true;
                            }
                        }
                    }
                }
                return hayCambios;
            }
        }


        static void Main(string[] args)
        {
            imprimir(solucion.Base);
            int[,] temp = solucion.Base;            
            
            while (solucion.intentarSolucionar(temp)) 
            {
                imprimir(temp);
                Console.ReadLine();
            }
            imprimir(temp);

            solucion.Base = temp;
            Console.WriteLine("Máxima solución encontrada en forma normal. Presione para comenzar algoritmo genético");
            Console.ReadLine();


            int cantidadSoluciones = 5000;

            List<solucion> soluciones = new List<solucion>();
            for (int i = 0; i < cantidadSoluciones; i++) 
            {
                solucion nueva = new solucion();
                nueva.generar();
                soluciones.Add(nueva);
            }

            bool continuar=true;
            int vueltas = 0;
            int posicionMejorSolucionA = 0;
            int posicionMejorSolucion = 0;

            while (continuar) 
            {
                int mejorEvaluacion = soluciones[0].evaluar();

                posicionMejorSolucionA = 0;
                int mejorEvaluacionA = mejorEvaluacion;

                int posicionMejorSolucionB = 0;
                int mejorEvaluacionB = mejorEvaluacionA;

                for (int i = 1; i < cantidadSoluciones; i++) 
                {
                    int evaluacionA = 1000;
                    int evaluacion = 1000;

                    evaluacion = soluciones[i].evaluar();

                    if (vueltas % 100 < 70)
                    {
                        evaluacionA = soluciones[i].evaluar();
                    }
                    else
                    {
                        if (vueltas % 100 < 80)
                        {
                            evaluacionA = soluciones[i].evaluarHorizontal();
                        }
                        else if (vueltas % 100 < 90)
                        {
                            evaluacionA = soluciones[i].evaluarVertical();
                        }
                        else
                        {
                            evaluacionA = soluciones[i].evaluarCuadros();
                        }
                        
                    }

                    if ( evaluacionA < mejorEvaluacionA)
                    {
                        if (vueltas % 100 < 70) posicionMejorSolucion = i;
                        mejorEvaluacionA = evaluacionA;
                        posicionMejorSolucionA = i;
                    }
                    else if (evaluacionA < mejorEvaluacionB)
                    {
                        mejorEvaluacionB = evaluacionA;
                        posicionMejorSolucionB = i;
                    }
                }
                if (vueltas % 5 == 0) 
                {
                    Console.Clear();
                    imprimir(soluciones[posicionMejorSolucionA].filas);
                    Console.WriteLine();
                    Console.WriteLine("Evaluación A: " + mejorEvaluacionA);
                    imprimir(soluciones[posicionMejorSolucionB].filas);
                    Console.WriteLine();
                    Console.WriteLine("Evaluación B: " + mejorEvaluacionB);
                    Console.WriteLine();
                    Console.WriteLine("Vueltas: " + vueltas);
                    //Console.ReadLine();
                }
                vueltas++;

                if (mejorEvaluacionA > 0)
                {
                    for (int i = 0; i < cantidadSoluciones; i++)
                    {
                        if (i != posicionMejorSolucionA && i!=posicionMejorSolucion)
                            soluciones[i].filas = solucion.descendencia(soluciones[posicionMejorSolucionA].filas, soluciones[posicionMejorSolucionB].filas);
                    }
                }
                else                 
                {
                    continuar = false;
                }
            }
            imprimir(soluciones[posicionMejorSolucionA].filas);
            Console.ReadLine();
        }

        private static void imprimir(int[,] solucion)
        {
            Console.WriteLine();
            for (int i = 0; i < 9; i++) 
            {
                if (i % 3 == 0) Console.WriteLine();
                for (int j = 0; j < 9; j++)                 
                {
                    if (j % 3 == 0) Console.Write("\t");
                    Console.Write(solucion[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
