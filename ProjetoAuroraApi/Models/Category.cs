using System;

namespace ProjetoAuroraApi.Models {
    public class Category : IEquatable<Category> {
        public int Id {get; set; }
        public string Name {get; set; }
        public string Rule {get; set; }
        public string Calculation {get; set; }
        public int Points {get; set; }

        public override string ToString() {
            return $"Id: {Id} - Name: {Name} - Rule: {Rule} - Calculation: {Calculation} - Points: {Points}";
        }

        public bool Equals(Category other) {
            return other != null && 
            Id == other.Id &&
            String.Equals(Name, other.Name) &&
            String.Equals(Rule, other.Rule) &&
            String.Equals(Calculation, other.Calculation) &&
            Points == other.Points;
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
            return Equals((Category) obj);
        }

        public override int GetHashCode() {
            unchecked {
                var hashCode = Id.GetHashCode();
                hashCode = (hashCode * 397) ^ Name?.GetHashCode() ?? 0;
                hashCode = (hashCode * 397) ^ Rule?.GetHashCode() ?? 0;
                hashCode = (hashCode * 397) ^ Calculation?.GetHashCode() ?? 0;
                hashCode = (hashCode * 397) ^ Points.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(Category a, Category b) {
            return Equals(a, b);
        }

        public static bool operator !=(Category a, Category b) {
            return !Equals(a, b);
        }
    }    
}