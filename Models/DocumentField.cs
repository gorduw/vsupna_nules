namespace vstupna.Models
{
    public class DocumentField
    {
        public string FieldName { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;

        // Якщо потрібно мати випадаючий список, можна додати:
        public bool IsDropdown { get; set; } = false;
        public List<string>? DropdownValues { get; set; }

        // Можна додати інші властивості для розширення логіки
    }
}
