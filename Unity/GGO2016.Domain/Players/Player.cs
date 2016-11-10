using GOO2016.Domain.Ships;

namespace GOO2016.Domain.Players
{
    public class Player
    {
        public Ship Ship { get; }

        public Player(Ship ship)
        {
            this.Ship = ship;
        }
    }
}
