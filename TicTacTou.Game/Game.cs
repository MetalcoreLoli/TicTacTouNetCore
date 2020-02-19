using System;
using System.Linq;
using System.Collections.Generic;
using TicTacTou.Game.Core;
using TicTacTou.Game.Enums;
using TicTacTou.Game.Actors;
using TicTacTou.Game.Builders;



namespace TicTacTou.Game
{
    ///<summary>
    /// Класс содержит основную логику игры
    ///</summary>
    internal class Game
    {
        #region Private Members

        ///<summary>
        /// Класс, "строитель", который создаст игрока
        ///</summary>
        private ActorBuilder<Player> playerBuilder;


        ///<summary>
        /// Поле для хранение первого игрока 
        ///</summary>
        private Actor player;

        ///<summary>
        /// Поле для хранение второго игрока 
        ///</summary>
        private Actor playerOne;


        ///<summary>
        /// Поле для хранение высоты карты 
        ///</summary>
        private Int32 mapHeight = 5;

        ///<summary>
        /// Поле для хранение ширины карты 
        ///</summary>
        private Int32 mapWidth = 5;


        ///<summary>
        /// Поле для хранение карты 
        ///</summary>
        private Map map;


        private bool IsNotEnd = true;
        #endregion

        #region Public Propeties 

        #endregion

        #region Constructors
        public Game()
        {
            Initialization();
        }
        #endregion

        #region Public methods

        ///<summary>
        /// Метод, который зарпускает игру
        ///</summary>
        public void Start()
        {

            Console.Clear();
            Draw();
            while (IsNotEnd)
            {
                if (PlayersTurn(player))
                {
                    Draw();
                    ShowWinnerMessage(player);
                    break;
                }
                Draw();
                if (IsDraw())
                {
                    ShowDrawMessage();
                    break;
                }
                if (PlayersTurn(playerOne))
                {
                    Draw();
                    ShowWinnerMessage(playerOne);
                    break;
                }
                Draw();
                if (IsDraw())
                {
                    ShowDrawMessage();
                    break;
                }
                //Console.Clear();
            }
        }

        ///<summary>
        /// Метод, который содержит логику, которая выполняется на
        /// каждой итерации цикла
        ///</summary>
        public void Update()
        {
        }

        ///<summary>
        /// Метод, который занимается отрисовкой
        ///</summary>
        public void Draw()
        {
            map.Draw();
        }
        #endregion

        #region Private Methods

        internal void ShowDrawMessage()
        {
        
            Int32 left = Console.CursorLeft;
            Int32 top = Console.CursorTop;
            Console.SetCursorPosition(0, mapHeight);
            Console.WriteLine(new string ('-', mapWidth));    
            Console.WriteLine("Draw" + new string (' ', 30));
            Console.WriteLine(new string ('-', mapWidth));    
            Console.SetCursorPosition(left, top);
        }
        internal Player CreatePlayer()
        {
            var builder = new ActorBuilder<Player>();
            Console.WriteLine("Hello, enter your name plz: ");
            builder.SetName(Console.ReadLine());
            builder.SetSymbol('X');
            builder.SetColor(ConsoleColor.DarkRed);
            return builder.Get();
        }

        internal bool PlayersTurn(Actor actor)
        {
            Int32 left = Console.CursorLeft;
            Int32 top = Console.CursorTop;
            Console.SetCursorPosition(0, mapHeight);
            bool isCanBePlaced = true;
            while (isCanBePlaced)
            {
                Console.WriteLine($"Hey, {actor.Name} enter position(example: 1): ");
                PositionOnBoard position
                    = (PositionOnBoard)Int32.Parse(Console.ReadLine());
                isCanBePlaced = !map.SetActorSymbolToBoard(actor, position);
            }
            Console.SetCursorPosition(left, top);
            return CheckPlayersWin(actor);
        }


        internal bool CheckPlayersWin(Actor actor)
        {
            bool rowFirst
                = map
                    .GetCellBy(cell => cell.Position.X.Equals(0) && cell.Position.Y % 2 == 0)
                    .ToList()
                    .All(cell => cell.Symbol.Equals(actor.Symbol));

            bool rowSecond
                = map
                    .GetCellBy(cell => cell.Position.X.Equals(2) && cell.Position.Y % 2 == 0)
                    .All(cell => cell.Symbol.Equals(actor.Symbol));

            bool rowThird
                = map
                    .GetCellBy(cell => cell.Position.X.Equals(4) && cell.Position.Y % 2 == 0)
                    .All(cell => cell.Symbol.Equals(actor.Symbol));


            bool columnFirst
                = map
                    .GetCellBy(cell => cell.Position.Y.Equals(0) && cell.Position.X % 2 == 0)
                    .All(cell => cell.Symbol.Equals(actor.Symbol));

            bool columnSecond
                = map
                    .GetCellBy(cell => cell.Position.Y.Equals(2) && cell.Position.X % 2 == 0)
                    .All(cell => cell.Symbol.Equals(actor.Symbol));

            bool columnThird
                = map
                    .GetCellBy(cell => cell.Position.Y.Equals(4) && cell.Position.X % 2 == 0)
                    .All(cell => cell.Symbol.Equals(actor.Symbol));

            bool mainDiagonal = 
                    map
                        .GetCellBy(cell => (cell.Position.X.Equals(cell.Position.Y) && cell.Position.X % 2 == 0))
                        .All(cell => cell.Symbol.Equals(actor.Symbol));

            return rowFirst || rowSecond || rowThird ||
                    columnFirst || columnSecond || columnThird
                    || mainDiagonal;
        }

        internal bool IsDraw()
        {
            List<Cell> cells = new List<Cell>();
            for(int i = 0; i < map.Width * map.Height; i += 2)
                cells.Add(map.Board[i]);
            return cells.All(cell => cell.Symbol != ' ');
        }


        internal void ShowWinnerMessage(Actor winner)
        {
            Int32 left = Console.CursorLeft;
            Int32 top = Console.CursorTop;

            Console.SetCursorPosition(0, mapHeight);
            Console.WriteLine(new string ('-', mapWidth));    
            Console.WriteLine($"{winner.Name} is winner" + new string(' ', 30));
            Console.WriteLine(new string ('-', mapWidth));    
            Console.SetCursorPosition(left, top);
        }

        private void Initialization()
        {
            map = new Map(mapWidth, mapHeight);

            player = CreatePlayer();
            playerOne = CreatePlayer();

            playerOne.Symbol = '0';
            playerOne.Color = ConsoleColor.DarkBlue;
        }


        #endregion
    }
}
