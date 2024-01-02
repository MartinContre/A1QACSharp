using Aquality.Selenium.Core.Logging;
using System.Collections.Generic;

namespace Userinyerface.Utilis
{
    public class RandomSelector
    {
        public static List<int> SelectRandomIndexes(int n, int numItems)
        {
            Random random = new Random();

            Logger.Instance.Info($"Selecting {n} random indexes from {numItems} items");

            List<int> selectedIndexes = new List<int>();
            HashSet<int> selectedSet = new HashSet<int>();

            while (selectedSet.Count < n) 
            {
                int randomIndex = random.Next(numItems);

                if (selectedSet.Add(randomIndex))
                {
                    selectedIndexes.Add(randomIndex);
                }
            }

            return selectedIndexes;
        }
    }
}
