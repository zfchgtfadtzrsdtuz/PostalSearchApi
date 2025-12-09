using PostalSearchApi.Models;

namespace PostalSearchApi.Data
{
    public class SettlementRepository
    {
        private readonly List<Settlement> _settlements = new()
        {
            new Settlement { Id = 1, Name = "Budapest", PostalCode = "1011", County = "Budapest" },
            new Settlement { Id = 2, Name = "Győr", PostalCode = "9000", County = "Győr-Moson-Sopron" },
            new Settlement { Id = 3, Name = "Miskolc", PostalCode = "3525", County = "Borsod-Abaúj-Zemplén" },
            new Settlement { Id = 4, Name = "Szeged", PostalCode = "6720", County = "Csongrád-Csanád" },
            new Settlement { Id = 5, Name = "Eger", PostalCode = "3300", County = "Heves" },
        };

        public IEnumerable<Settlement> GetAll() => _settlements;

        public IEnumerable<Settlement> GetByPostalCode(string postalCode)
        {
            if (string.IsNullOrWhiteSpace(postalCode)) return Enumerable.Empty<Settlement>();
            var normalized = new string(postalCode.Where(char.IsDigit).ToArray());
            return _settlements.Where(s => s.PostalCode.StartsWith(normalized));
        }
    }
}
