using System;

class Converter
{
    private decimal UsdExchangeRate;
    private decimal EurExchangeRate;

    public Converter(decimal usdToUah, decimal eurToUah)
    {
        this.UsdExchangeRate = usdToUah;
        this.EurExchangeRate = eurToUah;
    }

    public decimal Uah_Usd(decimal money)
    {
        return money / UsdExchangeRate;
    }

    public decimal Uah_Eur(decimal money)
    {
        return money / EurExchangeRate;
    }

    public decimal Usd_Uah(decimal money)
    {
        return money * UsdExchangeRate;
    }

    public decimal Eur_Uah(decimal money)
    {
        return money * EurExchangeRate;
    }
}


class Program
{
    static void Main()
    {
        Converter converter = new Converter(35.88m, 38.58m);

        Console.Write("Введіть суму: ");
        decimal money = decimal.Parse(Console.ReadLine());

        Console.Write("Виберіть валюту (USD або EUR): ");
        string currency = Console.ReadLine().ToUpper();

        decimal convertedMoney = 0;

        switch (currency)
        {
            case "USD":
                convertedMoney = converter.Uah_Usd(money);
                Console.WriteLine($"Сума в доларах США: {convertedMoney}");
                break;
            case "EUR":
                convertedMoney = converter.Uah_Eur(money);
                Console.WriteLine($"Сума в євро: {convertedMoney}");
                break;
            default:
                Console.WriteLine("На жаль сталась помилка, можливо Ви ввели неправильну валюту.");
                break;
        }

        Console.Write("Виберіть валюту для конвертації в гривні (USD або EUR): ");
        string toCurrency = Console.ReadLine().ToUpper();

        switch (toCurrency)
        {
            case "USD":
                convertedMoney = converter.Usd_Uah(money);
                Console.WriteLine($"Сума в гривнях: {convertedMoney}");
                break;
            case "EUR":
                convertedMoney = converter.Eur_Uah(money);
                Console.WriteLine($"Сума в гривнях: {convertedMoney}");
                break;
            default:
                Console.WriteLine("На жаль сталась помилка, можливо Ви ввели неправильну валюту.");
                break;
        }
    }
}
