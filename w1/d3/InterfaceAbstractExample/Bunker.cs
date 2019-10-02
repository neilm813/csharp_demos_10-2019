using System;

namespace InterfaceAbstractExample
{
  public class Bunker : Building
  {
    public override string Name { get; set; }
    public override double SquareFootage
    {
      get { return 400; }
    }
    private bool _isShielded;
    public bool IsShielded
    {
      get { return _isShielded; }
    }
    public Bunker(string name = "Bunker")
    {
      _isShielded = true;
      Health = 400;
      Name = name;
    }
    public override int TakeDamage(int amnt)
    {
      if (_isShielded == true)
      {
        _isShielded = false;
      }
      else
      {
        Health -= amnt;
      }
      if (Health <= 100)
      {
        _isShielded = true;
      }
      Console.WriteLine($"{Name}'s health is now {Health}");
      return Health;
    }
  }
}