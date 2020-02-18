using System;
using TicTacTou.Game.Core;
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
            while (true)
            {
                Update();
                //Console.Clear();
            }
        }
        
        ///<summary>
        /// Метод, который содержит логику, которая выполняется на
        /// каждой итерации цикла
        ///</summary>
        public void Update()
        {
            PlayersTurn(player); 
            Draw();
            PlayersTurn(playerOne); 
            Draw();
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
        
        internal Player CreatePlayer()
        {
            var builder = new ActorBuilder<Player>();
            Console.WriteLine("Hello, enter your name plz: ");
            builder.SetName(Console.ReadLine());
            builder.SetSymbol('X');
            builder.SetColor(ConsoleColor.DarkRed);
            return builder.Get();
        }
        
        internal void PlayersTurn(Actor actor)
        {
            Int32 left = Console.CursorLeft;
            Int32 top = Console.CursorTop;
            Console.SetCursorPosition(0, mapHeight);
            Console.WriteLine($"Hey, {actor.Name} enter position(example: 1 2): ");
            string position = Console.ReadLine();
            map.SetActorSymbolToBoard(actor, Vector.FromString(position)); 
            Console.SetCursorPosition(left, top);
        }
         
        private void Initialization()
        {
            map = new Map(mapWidth, mapHeight);

            player      = CreatePlayer();
            playerOne   = CreatePlayer();

            playerOne.Symbol = '0';
            playerOne.Color = ConsoleColor.DarkBlue;
        }
        #endregion
    }
}
