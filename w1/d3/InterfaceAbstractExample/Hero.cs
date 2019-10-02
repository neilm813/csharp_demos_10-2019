using System;

namespace InterfaceAbstractExample
{
  public class Hero : IDamageable
  {
    public int Health { get; set; }
    public string Name;
    public Building HomeBase { get; }
    public Hero(string name, Building homeBase)
    {
      Name = name;
      Health = 100;
      HomeBase = homeBase;
    }

    public int TakeDamage(int amnt)
    {
      Health -= amnt;
      return Health;
    }

    public void Attack(IDamageable target)
    {
      target.TakeDamage(10);
    }
  }
}