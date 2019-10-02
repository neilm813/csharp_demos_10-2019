namespace InterfaceAbstractExample
{
  public class Tower : Building
  {
    public override string Name { get; set; }
    public override double SquareFootage
    {
      get { return 200; }
    }
    public Tower(string name = "Tower")
    {
      Health = 200;
      Name = name;
    }
    // public override int TakeDamage(int amnt)
    // {
    //   Console.WriteLine("Tower health is now " + Health);
      
    //   return Health -= amnt;
    // }
  }
}