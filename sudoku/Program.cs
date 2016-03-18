using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudoku
{
    class Program
    {
        static Random rand = new Random(DateTime.Now.Millisecond);
        static Random rand2 = new Random(DateTime.Now.Millisecond * DateTime.Now.Second);
        static Random rand3 = new Random(DateTime.Now.Millisecond + DateTime.Now.Second);

        static int divisorCantidadMejores = 25;
        
        static int maxCantidadCambios = 3;


        class metodoDescartes 
        {
            List<int[,]> posiblesSoluciones;
            int [,] Base;


           public metodoDescartes(int[,] BASE) 
            {
                Base = BASE;
            }

           public List<int[,]> obtenerSoluciones()
           {
               posiblesSoluciones = nuevaSolucion(Base);

               int i = posiblesSoluciones.Count - 1;
               int n = 0;
               bool continuar = true;

               while (posiblesSoluciones.Count > 0 && continuar) 
               {
                   n++;
                   
                   //Console.WriteLine("Posibles soluciones: " + posiblesSoluciones.Count);

                   foreach (int[,] Sol in nuevaSolucion(posiblesSoluciones[i])) 
                   {
                       posiblesSoluciones.Add(Sol);
                   }

                   if (n % 10000 == 0) 
                   {
                       Console.Clear();
                       imprimir(posiblesSoluciones[posiblesSoluciones.Count - 1]);
                   }

                   posiblesSoluciones.RemoveAt(i);
                   i = posiblesSoluciones.Count - 1;
                   while (continuar && posiblesSoluciones.Count > 0 && evaluar(posiblesSoluciones[i]) == 0) 
                   {
                       i--;
                       if (i < 0) continuar = false;
                   }
               }

               return posiblesSoluciones;
            }

           public int evaluar(int[,] filas)
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
                       listaHorizontal.Remove(filas[i, j]);
                       listaVertical.Remove(filas[j, i]);
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

           public List<int[,]> nuevaSolucion(int[,] posibleSolucion)
           {
               List<int[,]> retorno = new List<int[,]>();

               for (int i = 1; i <= 9; i++)
               {
                   int[,] nuevaSolucion = agregar(posibleSolucion, i);
                   if (!tieneError(nuevaSolucion))
                   {
                       retorno.Add(nuevaSolucion);
                   }
               }

               return retorno;
           }

           public bool tieneError(int[,] Filas)
           {
               if(Filas[0,0]==0)return false;

               int i = 0, j = 0;

               for (int x = 0; x < 9; x++)
               {
                   for (int y = 0; y < 9; y++) 
                   {
                       if (Filas[x, y] != 0 && Base[x, y] == 0)
                       {
                           i = x;
                           j = y;
                       }
                   }
               }

               for (int k = 0; k < 9; k++)
               {
                   if (Filas[i, j] == Filas[i, k] && j != k)
                   {
                       return true;
                   }
                   if (Filas[i, j] == Filas[k, j] && i != k)
                   {
                       return true;
                   }
               }

               for (int k = 0; k < 3; k++)
               {
                   for (int l = 0; l < 3; l++)
                   {
                       if (Filas[i, j] == Filas[(i / 3) * 3 + k, (j / 3) * 3 + l] 
                           && ((i / 3) * 3 + k != i || (j / 3) * 3 + l != j))
                       {
                           return true;
                       }
                   }
               }

               return false;
           }

           private int[,] agregar(int[,] posibleSolucion, int N)
           {
               int[,] temp = new int[9, 9];

               for (int i = 0; i < 9; i++)
               {
                   for (int j = 0; j < 9; j++)                   
                   {
                       temp[i, j] = posibleSolucion[i, j];
                   }
               }

               bool continuar=true;
               for (int i = 0; i < 9 && continuar; i++) 
               {
                   for (int j = 0; j < 9 && continuar; j++) 
                   {
                       if (temp[i, j] == 0) 
                       {
                           temp[i, j] = N;
                           continuar = false;
                       }
                   }
               }
               return temp;
           }
        }


        class solucion
        {
            public int maximaCantidadCambios;

            public List<int> cantidadNumeros = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            public solucion(int[,] Base) 
            {
                this.maximaCantidadCambios = 2 + rand3.Next() % maxCantidadCambios;
                this.Base = Base;
                for (int i = 0; i < 9; i++) 
                {
                    for (int j = 0; j < 9; j++) 
                    {
                        filas[i, j] = Base[i, j];
                        if (Base[i, j] != 0)
                        {
                            cantidadNumeros[Base[i, j] - 1] += 1;
                        }
                    }
                }
            }

            public int[,] Base;

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
                            int nuevoValor=1 + (rand.Next() % 9);
                            while(cantidadNumeros[nuevoValor-1]>8)
                            {
                                nuevoValor = 1 + (rand.Next() % 9);
                            }

                            cantidadNumeros[nuevoValor - 1] += 1;

                            filas[i, j] = nuevoValor;
                        }
                    }
                }
            }

            public static int[,] descendenciaNormal(int[,] A, int[,] B, int[,] C, int[,] D, int [,] Base)
            {
                solucion retorno = new solucion(Base);
                Random rand = new Random(DateTime.Now.Millisecond*DateTime.Now.Millisecond);

                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (Base[i, j] != 0)
                        {
                            retorno.filas[i, j] = Base[i, j];
                        }
                        else
                        {
                            int num = rand.Next();
                            if (num % 4 == 0)
                            {
                                retorno.filas[i, j] = A[i, j];
                            }
                            else if (num % 4 == 1)
                            {
                                retorno.filas[i, j] = A[i, j];
                            }
                            else if (num % 4 == 2)
                            {
                                retorno.filas[i, j] = A[i, j];
                            }
                            else
                            {
                                retorno.filas[i, j] = A[i, j];
                            }
                        }
                    }
                }

                return retorno.filas;
            }

            public int[,] descendencia()
            {
                if (evaluar() == 0) return filas;

                int[,] retorno = new int[9, 9];

                //Se copia la descendencia con la solución actual:
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        retorno[i, j] = this.filas[i, j];
                    }
                }

                int cantidadCambios = 1 + rand3.Next() % 3;
                //int cantidadCambios = 3;

                //Se hacen diez intercambios de valores
                for (int i = 0; i < cantidadCambios; i++)
                {
                    int X = rand.Next() % 9;
                    int Y = rand2.Next() % 9;

                    while (Base[X, Y] != 0 || !tieneError(retorno, X, Y))
                    //while (Base[X, Y] != 0)
                    {
                        X = rand.Next() % 9;
                        Y = rand2.Next() % 9;
                    }

                    int X2 = rand.Next() % 9;
                    int Y2 = rand2.Next() % 9;

                    //while (Base[X2, Y2] != 0 || !tieneError(retorno, X2, Y2))
                    while (Base[X2, Y2] != 0)
                    {
                        X2 = rand.Next() % 9;
                        Y2 = rand2.Next() % 9;
                    }

                    int temp = retorno[X2, Y2];
                    retorno[X2, Y2] = retorno[X, Y];
                    retorno[X, Y] = temp;
                    //Console.WriteLine(X + "," + Y + " - " + X2 + "," + Y2);
                }

                return retorno;
            }

            public bool intentarSolucionar() 
            {
                bool hayCambios = false;

                for (int i = 0; i < 9; i++) 
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (filas[i, j] == 0) 
                        {
                            List<int> lista = new List<int>{ 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                            for (int k = 0; k < 9; k++) 
                            {
                                if (k != j && filas[i, k] != 0) 
                                {
                                    lista.Remove(filas[i,k]);
                                }
                                if (k != i && filas[k, j] != 0)
                                {
                                    lista.Remove(filas[k,j]);
                                }
                                int x = (i / 3)*3 + k % 3;
                                int y = (j / 3)*3 + k / 3;
                                if (filas[x,y]!=0) 
                                {
                                    lista.Remove(filas[x, y]);
                                }
                            }
                            if (lista.Count == 1) 
                            {
                                filas[i, j] = lista[0];
                                hayCambios = true;
                            }
                        }
                    }
                }
                return hayCambios;
            }

            public static bool tieneError(int[,] Filas, int i, int j)
            {
                for(int k=0;k<9;k++)
                {
                    if (Filas[i, j] == Filas[i, k] && j != k)                     
                    {
                        return true;
                    }
                    if (Filas[i, j] == Filas[k, j] && i != k)
                    {
                        return true;
                    }
                }

                for (int k = 0; k < 3; k++) 
                {
                    for (int l = 0; l < 3; l++) 
                    {
                        if (Filas[i, j] == Filas[(i / 3) * 3 + k, (j / 3) * 3 + l]
                            && ((i / 3) * 3 + k != i || (j / 3) * 3 + l != j))
                        {
                            return true;
                        }
                    }
                }

                    return false;
            }
        }

        class poblacion 
        {

            public List<solucion> soluciones;
            private int cantidadSoluciones;
            public int vueltas = 0;
            public List<int> posicionMejorSolucion = new List<int>();
            public List<solucion> mejorEvaluada = new List<solucion>();
            public List<int> mejorEvaluacion = new List<int>();            
            
            public int tipoEvaluacion = 0;
            int[,] Base;

            public poblacion(int cantidadSoluciones, int[,] Base) 
            {
                this.Base = Base;
                this.cantidadSoluciones = cantidadSoluciones;
                soluciones = new List<solucion>();
                for (int i = 0; i < cantidadSoluciones; i++)
                {
                    solucion nueva = new solucion(Base);
                    nueva.generar();
                    soluciones.Add(nueva);
                }
            }

            public poblacion(int cantidadSoluciones, int tipoEvaluacion, int [,] Base) : this(cantidadSoluciones, Base)
            {
                this.tipoEvaluacion = tipoEvaluacion;                
            }

            internal bool aplicarCiclo()
            {
                posicionMejorSolucion = new List<int>();
                mejorEvaluacion = new List<int>();
                mejorEvaluada = new List<solucion>();
                for (int i = 0; i < cantidadSoluciones / divisorCantidadMejores; i++)
                {
                    mejorEvaluacion.Add(1000);
                    posicionMejorSolucion.Add(rand3.Next() % cantidadSoluciones);
                    mejorEvaluada.Add(new solucion(Base));
                }

                //se evaluan las soluciones:
                for (int i = 1; i < cantidadSoluciones; i++)
                {
                    int evaluacionActual = soluciones[i].evaluar();

                    for (int j = 0; j < cantidadSoluciones / divisorCantidadMejores; j++)
                    {
                        if (evaluacionActual == 0) 
                        {
                            Console.WriteLine("hola");
                        }
                        if (evaluacionActual < mejorEvaluacion[j] && ((j == 0 || mejorEvaluacion[j - 1] < evaluacionActual)))
                        {
                            mejorEvaluacion[j] = evaluacionActual;
                            posicionMejorSolucion[j] = i;
                            mejorEvaluada[j] = soluciones[i];
                            break;
                        }
                    }
                }
                vueltas++;

                if (mejorEvaluacion[0] == 0) 
                {
                    Console.WriteLine("aquí");
                }

                if (mejorEvaluacion[0] > 0)
                {
                    for (int i = 0; i < cantidadSoluciones / divisorCantidadMejores; i++)
                    {
                        mejorEvaluada[i] = copiar(mejorEvaluada[i]);
                        soluciones[posicionMejorSolucion[i]] = new solucion(Base);
                    }

                    for (int i = 0; i < cantidadSoluciones; i++)
                    {
                        soluciones[i].filas = mejorEvaluada[rand3.Next() % (cantidadSoluciones / divisorCantidadMejores)].descendencia();
                    }

                    return false;
                    //Indica que no se ha encontrado la solución
                }
                else
                {
                    if (tipoEvaluacion == 0)
                    {
                        return true;
                    }
                    else return false;
                    //Indica que se ha encontrado la solución
                }
            }

            private solucion copiar(solucion solucion)
            {
                solucion retorno = new solucion(Base);

                for (int i = 0; i < 9; i++) 
                {
                    for (int j = 0; j < 9; j++) 
                    {
                        retorno.filas[i,j] = solucion.filas[i, j];
                    }
                }
                return retorno;
            }


            internal void cruzar(poblacion poblacion, poblacion poblacion2, poblacion poblacion3)
            {
                for(int i=0;i<cantidadSoluciones;i++)
                {
                    if (i != posicionMejorSolucion[0])
                    {
                        soluciones[i].filas = solucion.descendenciaNormal(
                            soluciones[posicionMejorSolucion[0]].filas, poblacion.soluciones[poblacion.posicionMejorSolucion[0]].filas, poblacion2.soluciones[poblacion.posicionMejorSolucion[0]].filas, poblacion3.soluciones[poblacion.posicionMejorSolucion[0]].filas, soluciones[0].Base);
                    }
                }
            }
        }

        class planeta
        {
            public List<poblacion> poblaciones;
            public int cantidadPoblaciones = 0;
            public int cantidadSoluciones = 0;
            public int[,] Base;

            public int posicionMejorResultado = 0;

            public planeta(int cantidadPoblaciones, int cantidadSoluciones, int[,] Base)
            {
                this.cantidadPoblaciones = cantidadPoblaciones;
                this.cantidadSoluciones = cantidadPoblaciones;
                this.Base = Base;
                poblaciones = new List<poblacion>();

                for (int i = 0; i < cantidadPoblaciones; i++) 
                {
                    poblaciones.Add(new poblacion(cantidadSoluciones, 0, Base));
                }
            }

            internal bool iteracion()
            {

                bool retorno = false;//indica si se encontró una solución
                int posicion = 0;                

                while (!retorno && posicion<poblaciones.Count) 
                {
                    retorno = poblaciones[posicion].aplicarCiclo();
                    if (poblaciones[posicion].mejorEvaluacion[0] < poblaciones[posicionMejorResultado].mejorEvaluacion[0]
                        && poblaciones[posicion].tipoEvaluacion==0) 
                    {
                        posicionMejorResultado = posicion;
                    }
                    posicion++;
                }

                return retorno;
            }

            internal void ingresarTuristas()
            {
                if (poblaciones.Count < 2) return;
                Random rand = new Random(DateTime.Now.Millisecond);
                int elegido = rand.Next() % cantidadPoblaciones;
                int pareja1 = rand.Next() % cantidadPoblaciones;
                int pareja2 = rand.Next() % cantidadPoblaciones;
                int pareja3 = rand.Next() % cantidadPoblaciones;

                while (elegido == pareja1) 
                {
                    elegido = rand.Next() % cantidadPoblaciones;
                }

                poblaciones[elegido].cruzar(poblaciones[pareja1], poblaciones[pareja2], poblaciones[pareja3]);
            }

            internal int[,] mejorSolucion()
            {
                return poblaciones[posicionMejorResultado].mejorEvaluada[0].filas;
            }

            internal int[,] mejorSolucionLimpia()
            {
                return limpiar(poblaciones[posicionMejorResultado].soluciones[poblaciones[posicionMejorResultado].posicionMejorSolucion[0]].filas);

            }

            public int[,] limpiar(int[,] p)
            {
                int [,] retorno = new int[9,9];

                //Se copian los valores
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++) 
                    {
                        retorno[i, j] = p[i, j];
                    }
                }

                //Se limpian en forma horizontal:
                for (int i = 0; i < 9; i++) 
                {
                    List<int> numeros = new List<int>();
                    List<int> repetidos = new List<int>();
                    for (int j = 0; j < 9; j++) 
                    {
                        if (numeros.Contains(p[i, j]))
                        {
                            if (!repetidos.Contains(p[i, j]))
                            {
                                repetidos.Add(p[i, j]);
                            }
                        }
                        else 
                        {
                            numeros.Add(p[i,j]);
                        }
                    }
                    for (int j = 0; j < 9; j++)
                    {
                        foreach (int repetido in repetidos) 
                        {
                            if (p[i, j] == repetido && Base[i,j]==0) 
                            {
                                retorno[i, j] = 0;
                            }
                        }
                    }
                }

                //Se limpian en forma vertical
                for (int j = 0; j < 9; j++)
                {
                    List<int> numeros = new List<int>();
                    List<int> repetidos = new List<int>();
                    for (int i = 0; i < 9; i++)
                    {
                        if (numeros.Contains(p[i, j]))
                        {
                            if (!repetidos.Contains(p[i, j]))
                            {
                                repetidos.Add(p[i, j]);
                            }
                        }
                        else
                        {
                            numeros.Add(p[i, j]);
                        }
                    }
                    for (int i = 0; i < 9; i++)
                    {
                        foreach (int repetido in repetidos)
                        {
                            if (p[i, j] == repetido && Base[i, j] == 0)
                            {
                                retorno[i, j] = 0;
                            }
                        }
                    }
                }

                //Se limpian en cuadrados de a 9:
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        List<int> numeros = new List<int>();
                        List<int> repetidos = new List<int>();
                        for (int k = 0; k < 9; k++) 
                        {
                            int x = i  * 3 + k%3;
                            int y = j  * 3 + k/3;

                            if (numeros.Contains(p[x, y]))
                            {
                                if (!repetidos.Contains(p[x, y]))
                                {
                                    repetidos.Add(p[x, y]);
                                }
                            }
                            else
                            {
                                numeros.Add(p[x, y]);
                            }
                        }

                        for (int k = 0; k < 9; k++)
                        {
                            int x = i * 3 + k % 3;
                            int y = j * 3 + k / 3;
                            foreach (int repetido in repetidos)
                            {
                                if (p[x, y] == repetido && Base[x,y] == 0)
                                {
                                    retorno[x, y] = 0;
                                }
                            }
                        }
                    }
                }


                return retorno;
            }

            internal int[,] solucionar(int[,] p)
            {
                solucion temp = new solucion(p);
                while (temp.intentarSolucionar()) 
                {
                }
                return temp.filas;
            }

            internal int solucionarYEvaluar(int[,] p)
            {
                solucion temp = new solucion(p);
                while (temp.intentarSolucionar())
                {
                }
                int retorno = temp.evaluar();
                if (retorno == 0)
                {
                    poblaciones[0].soluciones[0].filas = temp.filas;
                    poblaciones[0].mejorEvaluada[0].filas = temp.filas;
                    poblaciones[0].mejorEvaluacion[0] = 0;
                    poblaciones[0].posicionMejorSolucion[0] = 0;
                }

                return retorno;
            }
        }

        static void Main(string[] args)
        {
            /*
            //Nivel medio
            int[,] Base = {{0,4,0,1,0,0,0,2,0},
                            {0,0,2,9,4,7,1,0,6},
                            {0,9,0,6,5,2,0,0,0},
                            {2,3,0,0,0,1,4,6,0},
                            {0,0,4,2,8,5,7,0,0},
                            {0,7,8,4,0,0,0,1,5},
                            {0,0,3,8,7,9,0,5,0},
                            {5,0,6,3,1,4,9,0,0},
                            {0,8,0,0,0,6,0,4,0}};

             //*/

            /*
            //Nivel Alto
            int[,] Base = {{0,0,0,0,0,3,0,6,0},
                            {2,0,5,0,0,0,0,0,0},
                            {0,0,3,0,9,0,7,2,0},
                            {6,0,0,1,0,9,0,0,0},
                            {0,0,7,0,0,0,1,0,0},
                            {0,0,0,6,0,5,0,0,7},
                            {0,5,2,0,6,0,9,0,0},
                            {0,4,0,9,0,0,5,0,3},
                            {0,0,0,0,0,0,0,0,0}};
            //*/

            
            //Nivel Muy Alto
            int[,] Base =  {{0,0,5, 3,0,0, 0,0,0},
                            {8,0,0, 0,0,0, 0,2,0},
                            {0,7,0, 0,1,0, 5,0,0},

                            {4,0,0, 0,0,5, 3,0,0},
                            {0,1,0, 0,7,0, 0,0,6},
                            {0,0,3, 2,0,0, 0,8,0},

                            {0,6,0, 5,0,0, 0,0,9},
                            {0,0,4, 0,0,0, 0,3,0},
                            {0,0,0, 0,0,9, 7,0,0}};
            //*/

            /*
            //Nivel Muy Alto http://www.telegraph.co.uk/news/science/science-news/9359579/Worlds-hardest-sudoku-can-you-crack-it.html
            int[,] Base =  {{8,0,0, 0,0,0, 0,0,0},
                            {0,0,3, 6,0,0, 0,0,0},
                            {0,7,0, 0,9,0, 2,0,0},

                            {0,5,0, 0,0,7, 0,0,0},
                            {0,0,0, 0,4,5, 7,0,0},
                            {0,0,0, 1,0,0, 0,3,0},

                            {0,0,1, 0,0,0, 0,6,8},
                            {0,0,8, 5,0,0, 0,1,0},
                            {0,9,0, 0,0,0, 4,0,0}};
            //*/

            imprimir(Base);
            solucion temp = new solucion(Base);

            int intentos = 0;

            
            //Método descartes
            Console.ReadLine();
            Console.Clear();

            
            metodoDescartes metodo = new metodoDescartes(Base);
            foreach (int[,] Sol in metodo.obtenerSoluciones()) 
            {
                Console.Clear();
                Console.WriteLine("Solución encontrada:\n");
                imprimir(Sol);
                Console.ReadLine();
            }
            //*/

            /*
            while (temp.intentarSolucionar() && intentos<0) 
            {
                imprimir(temp.filas);
                intentos++;
                Console.ReadLine();
                Console.Clear();
            }
            imprimir(temp.filas);
            //*/
            //Console.WriteLine("\n\nEsta es la mejor solución encontrada en forma normal. Presione para comenzar algoritmo genético");
            //Console.ReadLine();
                       
            /*
            //algoritmo genético

            int cantidadSoluciones = 1500;
            int cantidadPoblaciones = 1;

            planeta Planeta = new planeta(cantidadPoblaciones, cantidadSoluciones, temp.filas);

            bool continuar=true;

            while (continuar) 
            {
                continuar = !Planeta.iteracion();

                if (Planeta.poblaciones[0].vueltas % 100 == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Mejor solución: ");
                    imprimir(Planeta.mejorSolucion());
                    Console.WriteLine("\nMejor solución limpia: ");
                    imprimir(Planeta.mejorSolucionLimpia());
                    Console.WriteLine("\nMejor solución limpia solucionada: ");
                    imprimir(Planeta.solucionar(Planeta.mejorSolucionLimpia()));

                    int puntuacionSolucionada = Planeta.solucionarYEvaluar(Planeta.mejorSolucionLimpia());

                    Console.WriteLine("\nPuntuación mejor solución limpia solucionada: " + puntuacionSolucionada);
                    
                    Console.WriteLine();
                    Console.WriteLine("Mejor evaluación: " + Planeta.poblaciones[Planeta.posicionMejorResultado].mejorEvaluacion[0]);

                    if (Planeta.poblaciones[Planeta.posicionMejorResultado].mejorEvaluacion[0] == 0) 
                    {
                        break;
                    }

                    Console.WriteLine("Planeta con mejor evaluación: " + Planeta.posicionMejorResultado);
                    Console.WriteLine();
                    Console.WriteLine("Vueltas: " + Planeta.poblaciones[0].vueltas);
                    Console.WriteLine();
                    //for (int i = 0; i < cantidadPoblaciones; i++) 
                    //{
                        //Console.WriteLine("Mejor evaluación N° " + i + ": " + Planeta.poblaciones[i].mejorEvaluacionA);
                    //}
                }

                //Planeta.ingresarTuristas();
                
            }
            Console.Clear();
            Console.WriteLine("Mejor solución encontrada: ");
            Console.WriteLine();
            imprimir(Planeta.mejorSolucion());
            Console.WriteLine();
            Console.WriteLine("Cantidad de vueltas: " + Planeta.poblaciones[0].vueltas);
            Console.ReadLine();
            //*/
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
