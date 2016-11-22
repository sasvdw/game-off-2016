using System.Collections.Generic;

namespace GGO2016.Domain.Turrets
{
    public class Turret
    {
        private readonly float maxRotation;
        private readonly HashSet<Gun> guns;

        public Turret(IEnumerable<Gun> guns, float maxRotation)
        {
            this.maxRotation = maxRotation;
            this.guns = new HashSet<Gun>(this.guns);
        }
    }
}
