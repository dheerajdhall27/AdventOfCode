namespace Day6_LanternFish
{
    public class LanternFish: IEquatable<LanternFish>
    {
        public int Day { get; set; }

        public int InternalTimer { get; set; }

        public bool Equals(LanternFish? other)
        {
            if ((other == null) || !this.GetType().Equals(other.GetType()))
            {
                return false;
            }

            return (Day == other.Day) && (InternalTimer == other.InternalTimer);
        }

        public override int GetHashCode()
        {
            //int hash = 17;
            //hash = hash * 23 + Day.GetHashCode();
            //hash = hash * 23 + InternalTimer.GetHashCode();
            //return hash;

            return (Day << 2) ^ InternalTimer;
        }
    }
}
