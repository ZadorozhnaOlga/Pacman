using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Timers;

namespace Pacman.GameEngine
{
    public enum GameStatus
    {
        ReadyToStart,
        InProgress,
        Completed
    }
    public class Game 
    {
        //public Timer myTimer = new Timer(500);
        private GameStatus _status;
        private Map _map;
        private Pacman _pacman;
        private Inky _inky;
        private Pinky _pinky;
        public GameStatus Status
        {
            get { return this._status; }
        }
        public Map Map
        {
            get { return this._map; }
        }
        public Pacman myPacman
        {
            get { return this._pacman; }
        }
        public Inky myInky
        {
            get { return this._inky; }
        }
        public Pinky myPinky
        {
            get { return this._pinky; }
        }

        public static int Scores { get; set; }

        //private void OnTimeInkyEvent(object source, ElapsedEventArgs e)
        //{
        //    myInky.Move(this);
        //}
       
        public Game() 
        {
            _status = GameStatus.ReadyToStart;
            int[,] array = Game.LoadMap(@"../../Map\Map.txt", 28, 32);
            _map = new Map(array);
            
            _pacman = new Pacman(13, 26);
            _inky = new Inky(13, 12);
            _pinky = new Pinky(14, 12);
            //myTimer.Elapsed += new ElapsedEventHandler(OnTimeInkyEvent);
            

        }

        public void Start()
        {
            #region Validation

            if (this._status != GameStatus.ReadyToStart)
            {
                throw new InvalidOperationException("Only game with status 'ReadyToStart' can be started");
            }

            #endregion

            this._status = GameStatus.InProgress;
        }

        public void Stop()
        {
            #region Validation

            if (this._status != GameStatus.InProgress)
            {
                throw new InvalidOperationException("Only game with status 'InProgress' can be stopped");
            }

            #endregion

            this._status = GameStatus.Completed;
        }


        public bool CheckLives() 
        {
            if ((myInky.X == myPacman.X & myInky.Y == myPacman.Y))
            {
                myPacman.lives--;
                return true;
            }
            else if (myPinky.X == myPacman.X & myPinky.Y == myPacman.Y)
            {
                myPacman.lives--;
                return true;
            }
            else return false;
        }

        public bool GameOver() 
        {
            if (myPacman.lives == 0)
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
                        case ',': continue;
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
