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

        #region LoadingPath
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
                    Y++;
                }               
            }
            
            return result;            
        }

        #endregion

        [TestMethod]
        public void Map()
        {
            int[,] array = new int[28, 32];
            for (int i = 0; i < 32; i++)
            {
                for (int j = 0; j < 28; j++)
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



