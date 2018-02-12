using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P3_NumberWars
{
    class NumberWars
    {
        static void Main()  // basi usloviata...

        {
            var firstPlayerCards = Console.ReadLine()
                        .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();
            var secondPlayerCards = Console.ReadLine()
                .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            int count = 0;
            var firstAllCards = new Queue<string>(firstPlayerCards);
            var secondAllCards = new Queue<string>(secondPlayerCards);

            bool gameOver = false;

            while (firstAllCards.Count != 0 && secondAllCards.Count != 0 && count < 1000000 && !gameOver)
            {
                count++;
                var firstCard = firstAllCards.Dequeue();
                var secondCard = secondAllCards.Dequeue();
                int curFirstcardNumber = GetNumberOfCard(firstCard);
                int curSecondcardNumber = GetNumberOfCard(secondCard);

                if (curFirstcardNumber > curSecondcardNumber)
                {
                    firstAllCards.Enqueue(firstCard);
                    firstAllCards.Enqueue(secondCard);
                }
                else if (curFirstcardNumber < curSecondcardNumber)
                {
                    secondAllCards.Enqueue(secondCard);
                    secondAllCards.Enqueue(firstCard);
                }
                // wor!
                else
                {
                    List<string> cardsNand = new List<string>();
                    cardsNand.Add(firstCard);
                    cardsNand.Add(secondCard);

                    while (!gameOver)
                    {
                        if (firstAllCards.Count > 3 && secondAllCards.Count > 3)
                        {
                            int firstSum = 0;
                            int secondSum = 0;
                            for (int i = 0; i < 3; i++)
                            {
                                var firstHandCard = firstAllCards.Dequeue();
                                var secondHandCard = secondAllCards.Dequeue();
                                firstSum += GetChar(firstHandCard);
                                secondSum += GetChar(secondHandCard);
                                cardsNand.Add(firstHandCard);
                                cardsNand.Add(secondHandCard);
                            }
                            if (firstSum > secondSum)
                            {
                                AddCardsToWinner(cardsNand, firstAllCards);
                                break;
                            }
                            else if (firstSum < secondSum)
                            {
                                AddCardsToWinner(cardsNand, secondAllCards);
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
            if (firstAllCards.Count > secondAllCards.Count)
            {
                Console.WriteLine($"First player wins after {count} turns");
            }
            else if (firstAllCards.Count < secondAllCards.Count)
            {
                Console.WriteLine($"Secomd player wins after {count} turns");
            }
            else if (firstAllCards.Count == secondAllCards.Count)
            {
                Console.WriteLine($"Draw after {count} turns");
            }
        }

        private static void AddCardsToWinner(List<string> cardsHand, Queue<string> firstAllCards)
        {
            foreach (var card in cardsHand.OrderByDescending(c => GetNumberOfCard(c)).ThenByDescending(c => GetChar(c)))
            {
                firstAllCards.Enqueue(card);
            }
        }

        private static int GetChar(string card)
        {
            char letter = card[card.Length - 1];

            return (int)letter - 96;
        }             

        private static int GetNumberOfCard(string card)
        { 
            //  вариант 1:
            return int.Parse(card.Substring(0, card.Length - 1));
                        
            //// Тъп вариант 2:
            //    var sb = new StringBuilder();
            //    var card = currentFcard.ToList();
            //    for (int i = 0; i < card.Count; i++)
            //    {
            //        if (!Char.IsLetter(card[i]))
            //        {
            //            // card.Remove(card[i]);
            //            sb.Append(card[i]);
            //        }
            //    }

            //    // string cardString = card.ToString();
            //    string sbString = sb.ToString();
            //    return int.Parse(sbString);
        }
    }
}
