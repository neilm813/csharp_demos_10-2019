using System;

namespace InterfaceAbstractExample
{
  public abstract class Building : IDamageable
  {
    public int Health { get; set; }
    public abstract double SquareFootage { get; }
    public abstract string Name { get; set; }
    public virtual int TakeDamage(int amnt) // virtual allows it to be overriden if needed but can be inherited as is if doesn't need to be changed
    {
      Health -= amnt;
      Console.WriteLine($"{Name}'s health is now {Health}");
      return Health;
    }

    public Building()
    {
      Health = 300;
    }
  }
}