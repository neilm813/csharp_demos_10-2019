using System;

namespace InterfaceAbstractExample
{
  class Program
  {
    static void Main(string[] args)
    {
      Bunker bunker = new Bunker();
      Hero protagonist = new Hero("Protag", new Bunker("The good place"));
      Hero antagonist = new Hero("Antag", new Tower("The bad place"));
      
      Console.WriteLine(antagonist.HomeBase.SquareFootage);
      Console.WriteLine(protagonist.HomeBase.SquareFootage);

      protagonist.Attack(antagonist.HomeBase);
      protagonist.Attack(antagonist.HomeBase);
      antagonist.Attack(protagonist.HomeBase);
      
    }
  }
}
