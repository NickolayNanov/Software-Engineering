namespace TheTankGame.Core
{
    using Contracts;
    using Entities.Vehicles.Contracts;
    using System;

    public class TankBattleOperator : IBattleOperator
    {
        public string Battle(IVehicle attacker, IVehicle target)
        {
            double attackerWeight = attacker.TotalWeight;
            long attackerAttack = attacker.TotalAttack;
            long attackerDefense = attacker.TotalDefense;
            long attackerHitPoints = attacker.TotalHitPoints;

            double targetWeight = target.TotalWeight;
            long targetAttack = target.TotalAttack;
            long targetDefense = target.TotalDefense;
            long targetHitPoints = target.TotalHitPoints;

            bool isSomeoneDead = this.IsDead(attackerHitPoints) || this.IsDead(targetHitPoints);

            while (!isSomeoneDead)
            {
                targetHitPoints -= (long)Math.Max(0, Math.Ceiling(attackerAttack - (targetDefense + (targetWeight / 2))));

                attackerHitPoints -= (long)Math.Max(0, Math.Ceiling(targetAttack - (attackerDefense + (attackerWeight / 2))));


                isSomeoneDead = this.IsDead(attackerHitPoints) || this.IsDead(targetHitPoints);
            }

            string result = this.IsDead(attackerHitPoints) ?
                target.Model :
                attacker.Model;

            return result;
        }

        private bool IsDead(long hitPoints)
        {
            return hitPoints <= 0;
        }
    }
}