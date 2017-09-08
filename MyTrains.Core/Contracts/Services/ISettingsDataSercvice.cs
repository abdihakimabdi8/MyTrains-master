using MyTrains.Core.Model;
using System;
using System.Collections.Generic;

namespace MyTrains.Core.Contracts.Services
{
    public interface ISettingsDataService
    {
        List<Currency> GetCurrencies();
        Currency GetActiveCurrency();
        void SetActiveCurrency(Currency currency);
        string GetAboutContent();
    }
}
