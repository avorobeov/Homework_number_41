using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_number_41
{
    internal class Program
    {
        const string CommandAddCard = "1";
        const string CommandShowCard = "2";
        const string CommandExit= "3";

        static void Main(string[] args)
        {
            Deck deck = new Deck();
            Player player = new Player();

            bool isExit = false;
            string userInput;

            while (isExit == false)
            {
                ShowMenu();

                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandAddCard:
                        AddCard(deck, player);
                        break;

                    case CommandShowCard:
                        player.ShowCards();
                        break;

                    case CommandExit:
                        isExit = true;
                        break;
                }
            }
        }

        private static void AddCard(Deck deck, Player player)
        {
            Card card;

            if (deck.TryGetCards(out card) == true)
            {
                player.AddCard(card);

                ShowMessage("Вы получили одну карту!");
            }
            else
            {
                ShowMessage("К сожалению в колоде нет больше карт!", ConsoleColor.Red);
            }
        }

        private static void ShowMessage(string text, ConsoleColor consoleColor = ConsoleColor.Green)
        {
            Console.ForegroundColor = consoleColor;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        private static void ShowMenu()
        {
            Console.WriteLine($"Что бы взять карту веди {CommandAddCard}\n" +
                              $"Что бы показать все ваши карты нажмите {CommandShowCard}\n" +
                              $"Что бы выйти ведите команду {CommandExit}");
        }
    }

    class Deck
    {
        public Deck()
        {
            string[] ranks = new string[] { "6", "7", "8", "9", "10", "Валет", "Дама", "Кароль", "Туз" };
            string[] suit = new string[] { "Пики", "Черви", "Бубны", "Трефы" };

            for (int i = 0; i < suit.Length; i++)
            {
                for (int j = 0; j < ranks.Length; j++)
                {
                    _cards.Add(new Card(ranks[j], suit[i]));
                }
            }
        }

        private List<Card> _cards = new List<Card>();

        public bool TryGetCards(out Card card)
        {
            if (_cards.Count() > 0)
            {
                Random random = new Random();

                card = _cards[random.Next(0, _cards.Count())];

                _cards.Remove(card);

                return true;
            }
            else
            {
                card = null;

                return false;
            }
        }
    }

    class Card
    {
        public Card(string rank, string suit)
        {
            Rank = rank;
            Suit = suit;
        }

        public string Rank { get; private set; }
        public string Suit { get; private set; }
    }

    class Player
    {
        private List<Card> _cards = new List<Card>();

        public void AddCard(Card card)
        {
            _cards.Add(card);
        }

        public void ShowCards()
        {
            for (int i = 0; i < _cards.Count(); i++)
            {
                Console.WriteLine($"{_cards[i].Suit} {_cards[i].Rank}");
            }
        }
    }
}
