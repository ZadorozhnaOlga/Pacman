using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Timers;

namespace Pacman.GameEngine
{
    public class Game
    {

        #region Fields

        private GameStatus _status;
        private Map _map;
        private Pacman _pacman;
        private Inky _inky;
        private Pinky _pinky;

        #endregion


        #region Properties
        public GameStatus Status
        {
            get { return this._status; }
        }
        public Map Map
        {
            get { return this._map; }
        }
        public Pacman MyPacman
        {
            get { return this._pacman; }
        }
        public Inky MyInky
        {
            get { return this._inky; }
        }
        public Pinky MyPinky
        {
            get { return this._pinky; }
        }

        public static int Scores { get; set; }

        #endregion


        #region Constructor

        public Game(int width, int heigth, int[,] array, int pacmanX, int pacmanY, int inkyX, int inkyY, int pinkyX, int pinkyY) 
        {
            _status = GameStatus.ReadyToStart;          
            _map = new Map(array, pacmanX, pacmanY);
            _pacman = new Pacman(pacmanX, pacmanY);
            _inky = new Inky(inkyX, inkyY);
            _pinky = new Pinky(pinkyX, pinkyY);
        }

        #endregion



        public event EventHandler PacmanEated;
        
        public event EventHandler Pause;
       // public event EventHandler PacmanDied;

        public event EventHandler PacmanEatApple;

        public event EventHandler<EventArgs> PacmanWin;


        #region Methods

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

        public bool GameOver() 
        {
            bool hasNoMoreLives = MyPacman.Lives == 0;
            if (hasNoMoreLives)
            {
                _status = GameStatus.Completed;
               // PacmanDied(this, EventArgs.Empty);
            }
            
            return hasNoMoreLives;    
        }

        public  void MinusLive()
        {
            --MyPacman.Lives;
        }
        
        public bool IfPacmanNotEated() 
        {           
                var result = (!(MyInky.X == MyPacman.X & MyInky.Y == MyPacman.Y) &&
                    !(MyPinky.X == MyPacman.X & MyPinky.Y == MyPacman.Y));

                if (!result && (PacmanEated != null))
                {
                    --MyPacman.Lives;
                    PacmanEated(this, EventArgs.Empty);
                }

            

                return result;
        }

        public static int[,] LoadMap(string path, int mapX, int mapY)
        {
            int[,] result = new int[mapY, mapX];
            int x = 0;
            int y = 0;
            using (StreamReader rdr = new StreamReader(path))
            {
                var array = rdr.ReadToEnd().ToCharArray();
                for (int i = 0; i < array.Length; i++)
                {
                    if (y == mapX)
                    {
                        y = 0;
                        x++;
                    }
                    switch (array[i])
                    {
                        case ',': continue;
                        case '0':
                            {
                                result[x, y] = 0;
                                y++;
                                break;
                            }
                        case '1':
                            {
                                result[x, y] = 1;
                                y++;
                                break;
                            }
                        case '2':
                            {
                                result[x, y] = 2;
                                y++;
                                break;
                            }
                    }
                }

                return result;
            }
        }

        #endregion

    }
}
