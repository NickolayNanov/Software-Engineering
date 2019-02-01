namespace TheTankGame.Entities.Parts
{
    using Contracts;

    public class EndurancePart : BasePart, IHitPointsModifyingPart
    {
        public EndurancePart(string model, double weight, decimal price, int parameter)
            : base(model, weight, price)
        {
            this.HitPointsModifier = parameter;
        }

        public int HitPointsModifier { get; private set; }

        public override string ToString()
        {
            return base.ToString() + $"+{this.HitPointsModifier} HitPoints";
        }
    }
}