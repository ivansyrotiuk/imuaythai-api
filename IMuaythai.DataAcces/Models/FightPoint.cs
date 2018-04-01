using System.ComponentModel.DataAnnotations;

namespace IMuaythai.DataAccess.Models
{
    public class FightPoint
    {
        protected bool Equals(FightPoint other)
        {
            return Id == other.Id && RoundId == other.RoundId && string.Equals(FighterId, other.FighterId) && string.Equals(JudgeId, other.JudgeId) && Points == other.Points && FightId == other.FightId && Cautions == other.Cautions && Warnings == other.Warnings && KnockDown == other.KnockDown && J == other.J && X == other.X && string.Equals(Injury, other.Injury) && InjuryTime == other.InjuryTime && Accepted == other.Accepted;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((FightPoint) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id;
                hashCode = (hashCode * 397) ^ RoundId;
                hashCode = (hashCode * 397) ^ (FighterId != null ? FighterId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (JudgeId != null ? JudgeId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Points;
                hashCode = (hashCode * 397) ^ FightId;
                hashCode = (hashCode * 397) ^ Cautions;
                hashCode = (hashCode * 397) ^ Warnings;
                hashCode = (hashCode * 397) ^ KnockDown;
                hashCode = (hashCode * 397) ^ J;
                hashCode = (hashCode * 397) ^ X;
                hashCode = (hashCode * 397) ^ (Injury != null ? Injury.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ InjuryTime.GetHashCode();
                hashCode = (hashCode * 397) ^ Accepted.GetHashCode();
                hashCode = (hashCode * 397) ^ (Fight != null ? Fight.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Judge != null ? Judge.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Fighter != null ? Fighter.GetHashCode() : 0);
                return hashCode;
            }
        }

        [Key]
    
        public int Id { get; set; }

        public int RoundId{ get; set; }// Number of a round

        public string FighterId { get; set; }
        public string JudgeId { get; set; }
        public int Points { get; set; }
        public int FightId { get; set; }
        public int Cautions { get; set; }
      
        public int Warnings { get; set; }

        public int KnockDown { get; set; }

        public int J { get; set; }
        public int X { get; set; }
        public string Injury { get; set; }
        public int? InjuryTime { get; set; }
        public bool Accepted { get; set; }

        public virtual Fight Fight { get; set; }
        public virtual ApplicationUser Judge { get; set; }
        public virtual ApplicationUser Fighter { get; set; }
    }
}
