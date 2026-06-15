using System;

namespace RapidPack
{
    public enum ShipmentType { Standardowa, Ostroznie, Paleta }

    public class ParcelCalculator
    {
        public double CalculatePrice(double weight, double height, double width, double depth, bool isExpress, ShipmentType shipmentType)
        {
            if (weight > 30) throw new ArgumentException("Waga przesyłki nie może przekraczać 30 kg!");
            if (weight < 0 || height < 0 || width < 0 || depth < 0) throw new ArgumentException("Wymiary oraz waga nie mogą być wartościami ujemnymi!");

            double price = shipmentType switch
            {
                ShipmentType.Paleta => 100,
                _ => (10 + weight * 2) * (height + width + depth > 150 ? 1.5 : 1) + (shipmentType == ShipmentType.Ostroznie ? 10 : 0)
            };

            return price + (isExpress ? 15 : 0);
        }
    }
}