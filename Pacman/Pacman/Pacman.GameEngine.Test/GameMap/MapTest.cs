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
            var projectPath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            var mapFile = @"\Map\Map.txt";
            string mapPath = string.Concat(projectPath, mapFile);
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
            var projectPath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            var pacmanFile = @"\Map\PathArrayToPacman.txt";      
            string mapPathToPacman = string.Concat(projectPath, pacmanFile);            
            int[,] result = LoadPath(mapPathToPacman);
                        
            CollectionAssert.AreEqual(game.Map.FindPaths(game, 13, 26), result);        
        }
     

        [TestMethod]
        public void FindPathsToDownLeftCorner()
        {
            var projectPath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            var pacmanFile = @"\Map\PathArrayToDownLeftCorner.txt";
            string mapPathToPacman = string.Concat(projectPath, pacmanFile);
            int[,] result = LoadPath(mapPathToPacman);

            CollectionAssert.AreEqual(game.Map.FindPaths(game, 1, 30), result);
        }


        [TestMethod]
        public void FindPathsToUpRightCorner()
        {
            var projectPath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            var pacmanFile = @"\Map\PathArrayToUpRightCorner.txt";
            string mapPathToPacman = string.Concat(projectPath, pacmanFile);
            int[,] result = LoadPath(mapPathToPacman);

            CollectionAssert.AreEqual(game.Map.FindPaths(game, 26, 1), result);
        }
       
    }
}



