// https://www.codewars.com/kata/5739174624fc28e188000465

namespace RankingPokerHands;

using System;
using System.Collections.Generic;
using System.Linq;

public enum Result 
{ 
    Win, 
    Loss, 
    Tie 
}

public enum CardValue
{
    Two = 2,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
    Jack,
    Queen,
    King,
    Ace
}

public enum CardSuit
{
    Spades = 1,
    Hearts,
    Diamonds,
    Clubs
}

public enum HandValue
{
    HighCard = 1,
    Pair,
    TwoPairs,
    ThreeOfAKind,
    Straight,
    Flush,
    FullHouse,
    FourOfAKind,
    StraightFlush
}

public struct Card
{
    public CardValue Value;
    public CardSuit Suit;
}


public class PokerHand
{
    public List<Card> Cards { get; }    
    public HandValue Evaluation { get; }
    public List<CardValue> TieBreakers { get; }

    public PokerHand(string hand)
    {
        Cards = ParseHandString(hand);
        Evaluation = EvaluateHand();
        TieBreakers = GetTieBreakers(Evaluation);
    }

    public Result CompareWith(PokerHand hand)
    {
        if (Evaluation == hand.Evaluation) {
            return BreakTie(hand);
        }
            
        return Evaluation > hand.Evaluation? Result.Win: Result.Loss;            
    }

    private HandValue EvaluateHand()
    {
        bool isStraight = IsStraight();
        bool isFlush = IsFlush();
        Dictionary<CardValue, int> valueCounts = GetValueCounts();

        if (isStraight && isFlush) {
            return HandValue.StraightFlush;
        }
        if (valueCounts.Any(x => x.Value == 4)) {
            return HandValue.FourOfAKind;
        }
        if (valueCounts.Count == 2) {
            return HandValue.FullHouse;
        }
        if (isFlush) {
            return HandValue.Flush;
        }
        if (isStraight) {
            return HandValue.Straight;
        }
        if (valueCounts.Any(x => x.Value == 3)) {
            return HandValue.ThreeOfAKind;
        }
        if (valueCounts.Count == 3) {
            return HandValue.TwoPairs;
        }
        if (valueCounts.Count == 4) {
            return HandValue.Pair;
        }

        return HandValue.HighCard;
    }

    private List<CardValue> GetTieBreakers(HandValue eval)
    {
        Dictionary<CardValue, int> valueCounts = GetValueCounts();

        if (eval == HandValue.StraightFlush ||            
            eval == HandValue.Straight)
        {
            return Cards.First().Value == CardValue.Two?
                [CardValue.Five]:
                [Cards.Last().Value];
        }
        if (eval == HandValue.FourOfAKind)
        {
            return [
                valueCounts.First(x => x.Value == 4).Key,
                valueCounts.First(x => x.Value == 1).Key
            ];
        }
        if (eval == HandValue.FullHouse)
        {
            return [
                valueCounts.First(x => x.Value == 3).Key,
                valueCounts.First(x => x.Value == 2).Key
            ];
        }
        if (eval == HandValue.ThreeOfAKind)
        {
            return [
                valueCounts.First(x => x.Value == 3).Key,
                ..valueCounts.Where(x => x.Value == 1).Select(x => x.Key).OrderDescending(),
            ];
        }
        if (eval == HandValue.TwoPairs)
        {
            return [
                ..valueCounts.Where(x => x.Value == 2).Select(x => x.Key).OrderDescending(),
                valueCounts.First(x => x.Value == 1).Key,
            ];
        }
        if (eval == HandValue.Pair)
        {
            return [
                valueCounts.First(x => x.Value == 2).Key,
                ..valueCounts.Where(x => x.Value == 1).Select(x => x.Key).OrderDescending()
            ];                
        }
        if (eval == HandValue.Flush ||
            eval == HandValue.HighCard)
        {
            return Cards.Select(x => x.Value).OrderDescending().ToList();
        }

        throw new Exception("Invalid hand evaluation provided");
    }

    private Result BreakTie(PokerHand opp)
    {
        for (int i = 0; i < TieBreakers.Count; ++i)
        {
            if (TieBreakers[i] > opp.TieBreakers[i]) {
                return Result.Win;
            }
            if (TieBreakers[i] < opp.TieBreakers[i]) {
                return Result.Loss;
            }
        }

        return Result.Tie;        
    }

    private bool IsFlush()
    {
        return Cards.All(x => x.Suit == Cards[0].Suit);
    }

    private bool IsStraight()
    {
        if (Cards[0].Value == CardValue.Two &&
            Cards[1].Value == CardValue.Three &&
            Cards[2].Value == CardValue.Four &&
            Cards[3].Value == CardValue.Five &&
            Cards[4].Value == CardValue.Ace)
        {
            return true;
        }

        for (int i = 0; i < Cards.Count - 1; ++i)
        {
            if (Cards[i].Value + 1 != Cards[i + 1].Value)
            {
                return false;
            }
        }

        return true;
    }

    private Dictionary<CardValue, int> GetValueCounts()
    {
        Dictionary<CardValue, int> counts = [];
        foreach (Card card in Cards)
        {
            counts[card.Value] = counts.TryGetValue(card.Value, out int val) ? val + 1: 1;
        }

        return counts;
    }

    private static List<Card> ParseHandString(string hand)
    {
        return hand
            .Split()
            .Select(x => new Card() { Value = GetCardValue(x[0]), Suit = GetCardSuit(x[1]) })
            .OrderBy(x => x.Value)
            .ToList();
    }

    private static CardValue GetCardValue(char value)
    {
        return value switch
        {
            '2' => CardValue.Two,
            '3' => CardValue.Three,
            '4' => CardValue.Four,
            '5' => CardValue.Five,
            '6' => CardValue.Six,
            '7' => CardValue.Seven,
            '8' => CardValue.Eight,
            '9' => CardValue.Nine,
            'T' => CardValue.Ten,
            'J' => CardValue.Jack,
            'Q' => CardValue.Queen,
            'K' => CardValue.King,
            'A' => CardValue.Ace,
            _ => throw new Exception("Symbol does not match card value")
        };
    }

    private static CardSuit GetCardSuit(char suit)
    {
        return suit switch
        {
            'S' => CardSuit.Spades,
            'H' => CardSuit.Hearts,
            'D' => CardSuit.Diamonds,
            'C' => CardSuit.Clubs,
            _ => throw new Exception("Symbol does not match card suit")
        };
    }
}
