﻿using System;
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
        #region Fields

        private GameStatus _status;
        private Map _map;
        private Pacman _pacman;
        private Inky _inky;
        private Pinky _pinky;

        #endregion

        #region Properties
        // Варто було б створити автопроперті з приватим сеттером
        // public GameStatus Status{get; private set;}
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

        #endregion

        #region Constructor

        public Game() 
        {
            _status = GameStatus.ReadyToStart;
            
            // Завантаження карти доцільніше було б зробити в ConsoleUI
            // Необхідно отримати шлях до поточної папки за допомогою  
            //System.Reflection.Assembly.GetEntryAssembly().Location;
            // Небажано виходити за межі поточної директорії
            int[,] array = Game.LoadMap(@"../../Map\Map.txt", 28, 32);
            _map = new Map(array);           
            _pacman = new Pacman(13, 26);
            _inky = new Inky(13, 12);
            _pinky = new Pinky(14, 12);
        }

        #endregion

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
            if (myPacman.Lives == 0)
            {
                _status = GameStatus.Completed;
                return true;
            }
            else 
            {
                return false;
            }
            
        }

        public  void MinusLive()
        {
            myPacman.Lives--;
        }
        
        public bool IfPacmanNotEated() 
        {
            // для збільшення продуктивності бажано використовувати &&
            if (!(myInky.X == myPacman.X & myInky.Y == myPacman.Y) &
                !(myPinky.X == myPacman.X & myPinky.Y == myPacman.Y))
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
            // Локальні змінні
            int X = 0;
            int Y = 0;
            using (StreamReader rdr = new StreamReader(path))
            {
                var array = rdr.ReadToEnd().ToCharArray();
                for (var i = 0; i < array.Length; i++)
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

        #endregion

    }
}
