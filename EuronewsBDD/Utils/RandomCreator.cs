using Aquality.Selenium.Core.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuroNewsTest.Utils
{
    public class RandomCreator
    {
        private RandomCreator() { }

        public static List<int> CreateRandomIndexes(int n, int numItems) 
        {
            Random Random = new Random();

            Logger.Instance.Info("Selecting " + n + " random indexes from " + numItems + " items");

            List<int> selectedIndexes = new List<int>();
            HashSet<int> selectedSet = new HashSet<int>();

            while (selectedSet.Count < n) 
            {
                int randomIndex = Random.Next(numItems);
                if (selectedSet.Add(randomIndex))
                {
                    selectedIndexes.Add(randomIndex);
                }
            }

            Logger.Instance.Info("Selected indexes: " + selectedIndexes);

            return selectedIndexes;
        }
    }
}
