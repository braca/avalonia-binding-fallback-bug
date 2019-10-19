namespace AvaloniaBindingFallback
{
    using System;
    using System.ComponentModel;

    public class Translator : INotifyPropertyChanged
    {
        private const string IndexerName = "Item";
        private const string IndexerArrayName = "Item[]";

        public string this[string key]
        {
            get
            {
                if (key.Equals("test", StringComparison.InvariantCultureIgnoreCase))
                {
                    return "Test translated";
                }

                return null;
            }
        }

        public static Translator Instance { get; set; } = new Translator();

        public event PropertyChangedEventHandler PropertyChanged;

        public void Invalidate()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(IndexerName));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(IndexerArrayName));
        }
    }
}