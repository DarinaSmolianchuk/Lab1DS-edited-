using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1DS
{
    class GameAccount
    {
        //Ім'я
        public string UserName { get; }

        //Рейтинг
        //Поле
        private int currentRating = 0;
        //Проперті
        public int CurrentRating 
        {
            get { return currentRating; }
            set
            {
                //Рейтинг не може бути менше 0
                //Якщо отримане значення менше 0, то встановлюємо 0
                if (value < 0)
                    currentRating = 0;
                else
                    currentRating = value;
            }
        }

        //Кількість зіграних ігр
        private int gamesCount = 0;
        public int GamesCount
        {
            get { return gamesCount; }
            set
            {
                //Кількість зіграних ігр не може бути менше 0
                //Якщо отримане значення менше 0, то встановлюємо 0
                if (value < 0)
                    gamesCount = 0;
                else
                    gamesCount = value;
            }
        }

        //Список з іграми
        private List<Game> history = new List<Game>();
        public List<Game> History
        {
            get { return history; }
        }

        //Конструктор користувача. У стандартному випадку при реєстрації користувача у нього 0 ігр і такий же рейтинг
        public GameAccount(string userName)
        {
            UserName = userName;
        }

        //Виграш
        public void winGame(GameAccount opponent, int rating)
        {
            try
            {
                //Якщо рейтинг, на який грають -- від'ємний, то гра не відбувається
                if (rating < 0)
                    throw new Exception("Error! Playing on incorrect rating!");

                //Зміна рейтингу і кількості ігор
                opponent.CurrentRating = opponent.CurrentRating - rating;
                opponent.gamesCount++;
                CurrentRating = CurrentRating + rating;
                gamesCount++;

                //Запис в історію
                //Грають оба гравці -- оба отримують запис в історію
                Game currentGame = new Game(this, opponent, rating, true);
                history.Add(currentGame);
                opponent.history.Add(currentGame);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        //Програш
        public void loseGame(GameAccount opponent, int rating)
        {
            try
            {
                //Якщо рейтинг, на який грають -- від'ємний, то гра не відбувається
                if (rating < 0)
                    throw new Exception("Error! Playing on incorrect rating!\n");

                //Зміна рейтингу і кількості ігор
                opponent.CurrentRating = opponent.CurrentRating + rating;
                opponent.gamesCount++;
                CurrentRating = CurrentRating - rating;
                gamesCount++;

                //Запис в історію
                //Грають оба гравці -- оба отримують запис в історію
                Game currentGame = new Game(this, opponent, rating, false);
                history.Add(currentGame);
                opponent.history.Add(currentGame);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void getStats()
        {
            //Якщо не грав -- відповідне повідомлення
            if (history == null)
            {
                Console.WriteLine("Player " + UserName + " not played yet!");
                return;
            }

            //Отримуємо дані щодо ігр
            Console.WriteLine("Player " + UserName + ".\nRating: " + currentRating + ".\nPlayed " + gamesCount + " games:");
            Console.WriteLine("\tID   \tOpponent   \tRating   \tResult");
            foreach (Game game in history)
            {
                Console.Write("\t" + game.ID);
                //В записі вказано 2 гравця, визначаємо який з них поточний
                if (game.FirstPlayer.UserName == UserName)
                {
                    Console.Write("\t" + game.SecondPlayer.UserName + "\t\t" + game.Rating);
                    if (game.IsWinFisrt)
                        Console.WriteLine("\t\tWin");
                    else
                        Console.WriteLine("\t\tLose");
                }
                else
                {
                    Console.Write("\t" + game.FirstPlayer.UserName + "\t\t" + game.Rating);
                    if (game.IsWinFisrt)
                        Console.WriteLine("\t\tLose");
                    else
                        Console.WriteLine("\t\tWin");
                }
            }
            Console.WriteLine();
        }
    }
}