namespace _03BarracksFactory.Models.Units
{
    using _03BarracksFactory.Models.Units;

    public class Horseman : Unit
    {
        private const int BaseHealth = 50;
        private const int BaseAttackDamage = 10;

        public Horseman()
            : base(BaseHealth, BaseAttackDamage)
        {
        }
    }
}
