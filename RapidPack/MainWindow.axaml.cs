using Avalonia.Controls;
using Avalonia.Interactivity;
using System;

namespace RapidPack
{
    public partial class MainWindow : Window
    {
        private readonly ParcelCalculator _calculator = new();

        public MainWindow() => InitializeComponent();

        private void OnCalculateClick(object? sender, RoutedEventArgs e)
        {
            if (!double.TryParse(WeightTextBox.Text, out double weight))
            {
                ResultTextBlock.Text = "BŁĄD: Wprowadź poprawną wagę (liczba).";
                return;
            }

            if (!double.TryParse(HeightTextBox.Text, out double h) ||
                !double.TryParse(WidthTextBox.Text, out double w) ||
                !double.TryParse(DepthTextBox.Text, out double d))
            {
                ResultTextBlock.Text = "BŁĄD: Wszystkie wymiary muszą być poprawnymi liczbami.";
                return;
            }

            var type = (ShipmentType)TypeComboBox.SelectedIndex;
            bool isExpress = ExpressCheckBox.IsChecked ?? false;

            try
            {
                double finalPrice = _calculator.CalculatePrice(weight, h, w, d, isExpress, type);

                ResultTextBlock.Text = $"CENA KOŃCOWA: {finalPrice:F2} PLN\n\n" +
                                       $"Specyfikacja:\n" +
                                       $"• Waga: {weight} kg\n" +
                                       $"• Gabaryty: {h} x {w} x {d} cm (Suma: {h + w + d} cm)\n" +
                                       $"• Typ usługi: {GetTypeDescription(type)}\n" +
                                       $"• Tryb ekspresowy: {(isExpress ? "TAK" : "NIE")}";
            }
            catch (ArgumentException ex)
            {
                ResultTextBlock.Text = $"BŁĄD: {ex.Message}";
            }
        }

        private string GetTypeDescription(ShipmentType type) => type switch
        {
            ShipmentType.Ostroznie => "Ostrożnie (Szkło)",
            ShipmentType.Paleta => "Przesyłka Paletowa",
            _ => "Standardowa"
        };
    }
}