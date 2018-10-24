using System.Collections.Generic;
using System;
using System.Linq;

namespace Number_Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstPlayerCards = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string[] secondPlayerCards = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Queue<KeyValuePair<int, char>> firstDeck = new Queue<KeyValuePair<int, char>>();
            Queue<KeyValuePair<int, char>> secondDeck = new Queue<KeyValuePair<int, char>>();

            FillDeck(firstDeck, firstPlayerCards);
            FillDeck(secondDeck, secondPlayerCards);

            int turns = 0;
            bool gameOver = false;
            while(turns < 1000000 && firstDeck.Any() && secondDeck.Any() && !gameOver)
            {
                turns++;
                var firstCard = firstDeck.Dequeue();
                var secondCard = secondDeck.Dequeue();

                int valueFirst = firstCard.Key;
                int valueSecond = secondCard.Key;

                if(valueFirst > valueSecond)
                {
                    firstDeck.Enqueue(firstCard);
                    firstDeck.Enqueue(secondCard);
                }
                else if(valueSecond > valueFirst)
                {
                    secondDeck.Enqueue(secondCard);
                    secondDeck.Enqueue(firstCard);
                }
                else if(valueFirst == valueSecond)
                {
                    List<KeyValuePair<int, char>> cardsOnTable = new List<KeyValuePair<int, char>>();

                    cardsOnTable.Add(firstCard);
                    cardsOnTable.Add(secondCard);

                    int valueOfFirstThree = 0;
                    int valueOfSecondThree = 0;

                    while (!gameOver)
                    {
                        if(firstDeck.Count >= 3 && secondDeck.Count >= 3)
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                var current = firstDeck.Dequeue();
                                cardsOnTable.Add(current);
                                valueOfFirstThree += current.Value;

                                current = secondDeck.Dequeue();
                                cardsOnTable.Add(current);
                                valueOfSecondThree += current.Value;
                            }

                            if(valueOfFirstThree > valueOfSecondThree)
                            {
                                FillWinnersDeck(firstDeck, cardsOnTable);
                                break;
                            }
                            
                            else if(valueOfSecondThree > valueOfFirstThree)
                            {
                                FillWinnersDeck(secondDeck, cardsOnTable);
                                break;
                            }
                        }
                        else
                        {
                            gameOver = true;
                        }
                    }
                }
            }

            if (firstDeck.Count > secondDeck.Count)
            {
                Console.WriteLine($"First player wins after {turns} turns");
            }
            else if(firstDeck.Count < secondDeck.Count)
            {
                Console.WriteLine($"Second player wins after {turns} turns");
            }
            else
            {
                Console.WriteLine($"Draw after {turns} turns");
            }
        }

        private static void FillWinnersDeck(Queue<KeyValuePair<int, char>> Deck, List<KeyValuePair<int, char>> cardsOnTable)
        {
            foreach (var card in cardsOnTable.OrderByDescending(x => x.Key).ThenByDescending(x => x.Value))
            {
                Deck.Enqueue(card);
            }
        }

        private static void FillDeck(Queue<KeyValuePair<int, char>> Deck, string[] PlayerCards)
        {
            foreach (var card in PlayerCards)
            {
                int value = int.Parse(card.Substring(0, card.Length - 1));
                char symbol = card[card.Length - 1];

                KeyValuePair<int, char> current = new KeyValuePair<int, char>(value, symbol);
                Deck.Enqueue(current);
            }
        }
    }
}
