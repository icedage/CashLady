using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CashLady.Mvc.WebApp.Models;

namespace CashLady.Mvc.WebApp.Presenters
{
    public class UserPresenter : IUserPresenter
    {
        public IList<TitleModel> Titles()
        {
            var titles = new List<TitleModel>()
            {
                new TitleModel() { Text = "Mr", Value = 0 },
                new TitleModel() { Text = "Miss", Value = 1 },
                new TitleModel() { Text = "Mrs", Value = 2 },
                new TitleModel() { Text = "Dr", Value = 3 },
            };

            return titles;
        }
    }
}