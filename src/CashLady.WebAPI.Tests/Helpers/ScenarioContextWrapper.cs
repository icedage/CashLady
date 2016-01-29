using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace CashLady.WebAPI.Tests.Helpers
{
    public class ScenarioContextWrapper<T>
    {
        public void SetValue(string key, T value)
        {
            if (ScenarioContext.Current.ContainsKey(key))
            {
                ScenarioContext.Current[key] = value;
            }
            else
            {
                ScenarioContext.Current.Add(key, value);
            }
        }

        public T GetValue(string key)
        {
            return ScenarioContext.Current.Get<T>(key);
        }
    }
}
