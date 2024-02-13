namespace ViewModels
{
    public class InputViewModel
    {
        public InputViewModel() {
            Type = "";
            Description = "";
        }

        public bool Readonly { get; set; }
        public string Type { get; set; }
        public string? Label { get; set; }
        public string Description { get; set; }
        public string? Placeholder { get; set; }
        public string? Value { get; set; }
        public List<string>? Values { get; set; }
    }
}
