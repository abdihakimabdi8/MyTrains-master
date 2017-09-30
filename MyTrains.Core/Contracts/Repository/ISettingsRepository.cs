using System;
using System.Collections.Generic;
using MyTrains.Core.Model;
using MyTrains.Core.Models;

namespace MyTrains.Core.Contracts.Repository
{
    public interface ISettingsRepository
    {
        List<Currency> GetAvailableCurrencies();
        Currency GetCurrencyById(int currencyId);

        string GetAboutContent();
    }
}
