using GGO2016.Domain.Ships;

namespace GGO2016.Domain.Players
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
