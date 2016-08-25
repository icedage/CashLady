using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CashLady.Mvc.WebApp.Models;

namespace CashLady.Mvc.WebApp.Presenters
{
    public interface IUserPresenter
    {
        IList<TitleModel> Titles();
    }
}