using System;
using System.Linq;

namespace GoodPlaysLib.models
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public override string ToString() {
            return $"{Id}: {Name}";
        }

        public static string FieldNames() {
            return typeof(Game).GetProperties().Select(p => p.Name.ToLower()).Aggregate((res, n) => $"{res},{n}");
        }
    }
}
