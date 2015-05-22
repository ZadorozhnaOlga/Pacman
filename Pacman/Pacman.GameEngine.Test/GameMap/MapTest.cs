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
        private static Game game;

        static MapTest() 
        {
            string mapPath = GetPath(@"\Map\Map.txt"); 
            game = new Game(28, 32, Game.LoadMap(mapPath, 28, 32), 13, 26, 13, 12, 14, 12);
        }


        #region LoadingPath
        public int [,] LoadPath(string path)
        {
            int[,] result = new int[32, 28];
            int x = 0;
            int y = 0;
            using (StreamReader rdr = new StreamReader(path))
            {
                string[] array = rdr.ReadToEnd().Split(',').ToArray();

                for (int i = 0; i < array.Length; i++)
                {
                    if (y == 28)
                    {
                        y = 0;
                        x++;
                    }
                    
                    result[x, y] = Int32.Parse((array[i]));           
                    y++;
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
            Assert.IsNotNull(new Map(array, 1, 10));
        }

        [TestMethod]
        public void FindPaths()
        {
            string mapPathToPacman = GetPath(@"\Map\PathArrayToPacman.txt");      
            int[,] result = LoadPath(mapPathToPacman);
                        
            CollectionAssert.AreEqual(game.Map.FindPaths(game, 13, 26), result);        
        }
     

        [TestMethod]
        public void FindPathsToDownLeftCorner()
        {
            string mapPathToPacman = GetPath(@"\Map\PathArrayToDownLeftCorner.txt"); 
            int[,] result = LoadPath(mapPathToPacman);

            CollectionAssert.AreEqual(game.Map.FindPaths(game, 1, 30), result);
        }


        [TestMethod]
        public void FindPathsToUpRightCorner()
        {
            string mapPathToPacman = GetPath(@"\Map\PathArrayToUpRightCorner.txt"); 
            int[,] result = LoadPath(mapPathToPacman);

            CollectionAssert.AreEqual(game.Map.FindPaths(game, 26, 1), result);
        }

        public static string GetPath(string str) 
        {
            var projectPath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            return string.Concat(projectPath, str);
        }
       
    }
}



