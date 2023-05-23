using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework_number_41
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandAddCard = "1";
            const string CommandShowCard = "2";
            const string CommandExit = "3";

            Deck deck = new Deck();
            Player player = new Player();

            bool isExit = false;
            string userInput;

            while (isExit == false)
            {
                Console.WriteLine($"Что бы взять карту веди {CommandAddCard}\n" +
                             $"Что бы показать все ваши карты нажмите {CommandShowCard}\n" +
                             $"Что бы выйти ведите команду {CommandExit}");

                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandAddCard:
                        player.AddCard(deck.GiveCard());
                        break;

                    case CommandShowCard:
                        player.ShowCards();
                        break;

                    case CommandExit:
                        isExit = true;
                        break;

                    default:
                        Console.WriteLine("Такой команды нет в наличии!");
                        break;
                }
            }
        }
    }

    class Deck
    {
        private List<Card> _cards = new List<Card>();

        public Deck()
        {
            Create();
            Shuffle();
        }

        public Card GiveCard()
        {
            Card card = null;

            if (_cards.Count() > 0)
            {
                card = _cards[0];

                _cards.Remove(card);

                return card;
            }
            else
            {
                return card;
            }
        }

        private void Create()
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

        private void Shuffle()
        {
            Random random = new Random();

            Card tempCard;
            int indexRandomElement = 0;

            for (int i = 0; i < _cards.Count; i++)
            {
                indexRandomElement = random.Next(0, _cards.Count);
                tempCard = _cards[indexRandomElement];
                _cards[indexRandomElement] = _cards[i];
                _cards[i] = tempCard;
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
            if (card != null)
            {
                _cards.Add(card);

                ShowMessage("Вы получили одну карту!");
            }
            else
            {
                ShowMessage("К сожалению в колоде нет больше карт!", ConsoleColor.Red);
            }
        }

        public void ShowCards()
        {
            for (int i = 0; i < _cards.Count(); i++)
            {
                ShowMessage($"{_cards[i].Suit} {_cards[i].Rank}");
            }
        }

        private void ShowMessage(string text, ConsoleColor consoleColor = ConsoleColor.Green)
        {
            Console.ForegroundColor = consoleColor;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
