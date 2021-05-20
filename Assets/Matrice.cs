using System;

namespace Matrice
{
    class Matrice
    {
        //Ce script n'est pas utilisé car nous avions changé d'idée. Initiallement, Félix avait parlé de faire un système
        //de pointage à l'aide de matrices. Par contre pour X raisons nous n'avons pas utiliser cette façon. En revanche,
        //j'avais déjà fais le code (Pascal) et les matrice compterais selon moi pour un élément mathématique, alors je crois
        //que ça vaut la peine de vous montrer que ce script fonctionne.
        //
        //J'ai modifié ce script avant la remise en ajoutant des matrices prédéterminées, en utilisant seulement "using System"
        //et en créant une interface pour la console. Comme ça vous pourrez l'essayer sans qu'il soit dans le projet Unity.
        //
        //Dans mes exemples, les matrices sont 3x3 parce que nous pensions utiliser des matrices 3x3. Je ne me rappel plus trop pourquoi...
        //Je sais que le script est relativement basic mais il n'a jamais concrètement servi alors je n'ai jamais eu à le rendre plus complexe.
        static void Main(string[] args)
        {
            //Matrice prédéterminée #1
            int[,] m1 = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

            //Matrice prédéterminée #2
            int[,] m2 = new int[3, 3] { { 2, 4, 6 }, { 1, 6, 9 }, { 8, 2, 6 } };

            //Interface dans la console comme ça vous pouvez le tester si vous voulez
            Console.WriteLine("Que voulez vous faire?");
            Console.WriteLine("1. Additionner les deux matrices");
            Console.WriteLine("2. Multiplier les deux matrices ensembles");
            Console.WriteLine("3. Multiplier une des matrices avec un scalaire");
            int choix = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            switch(choix)
            {
                case 1:
                    Additionner(m1, m2);
                    break;
                case 2:
                    Multiplier(m1, m2);
                    break;
                case 3:
                    Console.WriteLine("Quelle matrice? (1 ou 2)");
                    int matrice = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Quel scalaire?");
                    int scalaire = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    if(matrice == 1)
                    {
                        MultiplierScalaire(m1, scalaire);
                    }
                    else
                    {
                        MultiplierScalaire(m2, scalaire);
                    }
                    break;
            }
        }
        static void Additionner(int[,] m1, int[,] m2)
        {
            for(int i = 0; i < 3; ++i)
            {
                for(int j = 0; j < 3; ++ j)
                {
                    int reponse = m1[i, j] + m2[i, j];
                    Console.Write(" " + reponse + " ");
                }
                Console.WriteLine();
            }
        }

        static void Multiplier(int[,] m1, int[,] m2)
        {
            for (int i = 0; i < 3; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    int reponse = 0;
                    for (int k = 0; k < 3; ++k)
                    {
                        reponse += m1[i, k] * m2[k, j];
                    }
                    Console.Write(" " + reponse + " ");
                }
                Console.WriteLine();
            }
        }

        static void MultiplierScalaire(int[,]m , int scalaire)
        {
            for (int i = 0; i < 3; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    int reponse = m[i, j] * scalaire;
                    Console.Write(" " + reponse + " ");
                }
                Console.WriteLine();
            }
        }

    }
}
