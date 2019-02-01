namespace _03BarracksFactory.Models.Units
{
    using _03BarracksFactory.Models.Units;

    public class Gunner : Unit
    {
        private const int BaseHealth = 20;
        private const int BaseAttackDamage = 20;

        public Gunner()
            : base(BaseHealth, BaseAttackDamage)
        {
        }
    }
}
