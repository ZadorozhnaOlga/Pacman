using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Timers;
using Pacman.GameEngine;
using System.IO;

namespace Pacman.GameEngine.Test.GameMap
{
  


    [TestClass]
    public class MapTest

        
    {
        public int [,] LoadPath(string path)
        {
            int[,] result = new int[32, 28];
            int X = 0;
            int Y = 0;
            using (StreamReader rdr = new StreamReader(path))
            {
                string[] array = rdr.ReadToEnd().Split(',').ToArray();

                for (int i = 0; i < array.Length; i++)
                {
                    if (Y == 28)
                    {
                        Y = 0;
                        X++;
                    }
                    
                    result[X, Y] = Int32.Parse((array[i]));


                    //if (i == 29) 
                    //{
                    //    Console.WriteLine(array[29]);
                    //    Console.WriteLine("{0}, {1}", X, Y);
                    //}
                   
                    Y++;
                }
                
            }
            
            return result;

            
        }


        [TestMethod]
        public void Map()
        {
            int[,] array = new int[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    array[j, i] = 0;
                }
            }
            Assert.IsNotNull(new Map(array));
        }

        [TestMethod]
        public void FindPaths()
        {
            int[,] result = LoadPath(@"../../Map\PathArrayToPacman.txt");
            Game game = new Game();

            //for (int i = 0; i < 28; i++)
            //{
            //    for (int j = 0; j < 32; j++)
            //    {
            //        Console.Write(game.Map.FindPaths(game, 13, 9)[j, i] + " ");
            //    }
            //    Console.WriteLine();
            //}

            CollectionAssert.AreEqual(game.Map.FindPaths(game, 13, 26), result);
           
        }

       

        [TestMethod]
        public void FindPathsToDownLeftCorner()
        {
            int[,] result = LoadPath(@"../../Map\PathArrayToDownLeftCorner.txt");
            Game game = new Game();

            
            
           CollectionAssert.AreEqual(game.Map.FindPaths(game, 1, 30), result);

        }


        [TestMethod]
        public void FindPathsToUpRightCorner()
        {
            int[,] result = LoadPath(@"../../Map\PathArrayToUpRightCorner.txt");
            Game game = new Game();
            CollectionAssert.AreEqual(game.Map.FindPaths(game, 26, 1), result);

        }




        

        
    }
}



