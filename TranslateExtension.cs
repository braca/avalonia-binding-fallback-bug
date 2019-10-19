namespace AvaloniaBindingFallback.Localization
{
    using System;
    using Avalonia.Data;
    using Avalonia.Markup.Xaml;
    using Avalonia.Markup.Xaml.MarkupExtensions;
    using Portable.Xaml.Markup;

    public class TranslateExtension : MarkupExtension
    {
        public TranslateExtension(string key)
        {
            this.Key = key;
        }

        public string Key { get; set; }

        public string FallBack { get; set; }

        public string Context { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var fallback = FallBack;
            if (string.IsNullOrWhiteSpace(FallBack))
            {
                fallback = Key;
            }

            var keyToUse = Key;
            if (!string.IsNullOrWhiteSpace(Context))
            {
                keyToUse = $"{Context}/{Key}";
            }

            var binding = new BindingExtension($"[{keyToUse}]")
            {
                Mode = BindingMode.OneWay,
                Source = Translator.Instance,
                FallbackValue = fallback,
            };

            return binding.ProvideValue(serviceProvider);
        }
    }
}
