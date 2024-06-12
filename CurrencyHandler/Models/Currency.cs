using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyHandler.Models
{
    /// <summary>
    /// Сущность для хранения суммы денег в определённой валюте
    /// </summary>
    public class Currency
    {
        /// <summary>
        /// Наименование валюты
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Количество валюты
        /// </summary>
        public decimal Amount { get; }

        public Currency(decimal amount, string name)
        {
            Amount = amount;
            Name = name;
        }
    }
};
