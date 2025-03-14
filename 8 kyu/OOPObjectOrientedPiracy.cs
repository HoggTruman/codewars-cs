// https://www.codewars.com/kata/54fe05c4762e2e3047000add

namespace OOPObjectOrientedPiracy;

public class Ship
{
    public int Draft;
    public int Crew;
  
    public Ship(int draft, int crew)
    {
        Draft = draft;
        Crew = crew;
    }
  
    public bool IsWorthIt() => Draft - 1.5 * Crew > 20;
}
