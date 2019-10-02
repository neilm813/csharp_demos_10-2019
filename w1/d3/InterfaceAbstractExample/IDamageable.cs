namespace InterfaceAbstractExample
{
  public interface IDamageable
  {
    // Must have health
    int Health { get; set; } // get set needed b/c interface can't have fields
    // Must be able to take damage
    int TakeDamage(int amnt);
  }
}