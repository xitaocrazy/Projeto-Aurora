using System;

namespace ProjetoAuroraApi.Models {
    public class Bet : IEquatable<Bet> {
        public int CategoryID {get; set;}
        public string Dices {get; set;}

        public override string ToString() {
            return $"CategoryID: {CategoryID} - Dices: {Dices}";
        }

        public bool Equals(Bet other) {
            return other != null && 
            CategoryID == other.CategoryID &&
            String.Equals(Dices, other.Dices);
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) {
                return false;
            }
            if (ReferenceEquals(this, obj)) {
                return true;
            }
            if (obj.GetType() != GetType()) {
                return false;
            }
            return Equals((Bet) obj);
        }

        public override int GetHashCode() {
            unchecked {
                var hashCode = CategoryID.GetHashCode();
                hashCode = (hashCode * 397) ^ Dices?.GetHashCode() ?? 0;
                return hashCode;
            }
        }

        public static bool operator ==(Bet a, Bet b) {
            return Equals(a, b);
        }

        public static bool operator !=(Bet a, Bet b) {
            return !Equals(a, b);
        }
    }
}
