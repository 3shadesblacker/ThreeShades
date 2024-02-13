namespace ViewModels
{
    public class FormViewModel
    {
        public FormViewModel()
        {
            Inputs = new List<InputViewModel>();
        }

        public bool Readonly { get; set; }
        public IEnumerable<InputViewModel> Inputs { get; set; }
    }
}
