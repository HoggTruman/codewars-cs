// https://www.codewars.com/kata/58691792a44cfcf14700027c

namespace RPSKnockoutTournamentWinner;

using System;
using System.Collections.Generic;

public interface IRockPaperScissorsPlayer
{
    // Your name as displayed in match results.
    string Name { get; }    
    
    // Used by playground to notify you that a new match will start.
    void SetNewMatch(string opponentName);
    
    // Used by playground to get your game shape (values: "R", "P" or "S").
    string GetShape();
    
    // Used by playground to inform you about the shape your opponent played in the game. 
    void SetOpponentShape(string shape);
}

public class Player : IRockPaperScissorsPlayer
{
    private List<string> _opponentMoves = [];
    private string _opponent = "";

    public string Name { get; } = "MyPlayer";

    public void SetNewMatch(string nameOpponent)
    {
        _opponentMoves = [];
        _opponent = nameOpponent;
    }

    public string GetShape()
    {
        if (_opponent == "Vitraj Bachchan" || _opponent == "Sven Johanson")
            return _opponentMoves.Count > 0 ? BeatingShape(_opponentMoves[0]) : "R";

        if (_opponent == "Max Janssen")
            return "P";

        if (_opponent == "Bin Hinhao")
            return "R";

        return "RPS"[_opponentMoves.Count % 3].ToString();
    }

    public void SetOpponentShape(string shape)
    {
        _opponentMoves.Add(shape);
    }

    public static string BeatingShape(string shape)
    {
        return shape switch
        {
            "R" => "P",
            "P" => "S",
            "S" => "R",
            _ => throw new Exception("Invalid shape")
        };
    }
}
