using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Pacman.GameEngine
{
    public class Game 
    {
        
        public Map Map;
        
        public Pacman myPacman;
        public Inky myInky;
        public Pinky myPinky;

        public static int Scores { get; set; }
       
        public Game() 
        {
            int[,] array = Game.LoadMap(@"../../Map\Map.txt", 28, 32);
            Map = new Map(array);
            
            myPacman = new Pacman(13, 26);
            myInky = new Inky(13, 12);
            myPinky = new Pinky(14, 12);

            

        }

        
        //public bool GameOver()
        //{
        //    if ((myPinky.X != myPacman.X | myPinky.Y != myPacman.Y) |
        //        (myInky.X != myPacman.X | myInky.Y != myPacman.Y))
        //    {
        //        return true;
        //    }
        //    else 
        //    {
        //        return false;
        //    }
        //}




        public bool GameOver() 
        {
            if ((myInky.X == myPacman.X & myInky.Y == myPacman.Y) 
                |(myPinky.X == myPacman.X & myPinky.Y == myPacman.Y))
            {
                return true;
            }
            
            else 
            {
                return false;
            }
        }
    

        public static int[,] LoadMap(string path, int mapX, int mapY)
        {
            int[,] result = new int[mapY, mapX];
            int X = 0;
            int Y = 0;
            using (StreamReader rdr = new StreamReader(path))
            {
                var array = rdr.ReadToEnd().ToCharArray();
                for (int i = 0; i < array.Length; i++)
                {
                    if (Y == mapX)
                    {
                        Y = 0;
                        X++;
                    }
                    switch (array[i])
                    {
                        case '0':
                            {
                                result[X, Y] = 0;
                                Y++;
                                break;
                            }
                        case '1':
                            {
                                result[X, Y] = 1;
                                Y++;
                                break;
                            }
                        case '2':
                            {
                                result[X, Y] = 2;
                                Y++;
                                break;
                            }

                        

                    }


                }
                return result;
            }
        }

        

       

        //public int GetScores(int x, int y)
        //{
        //    return Game.Scores;
        //}
        
    }
}
