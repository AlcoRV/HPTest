using System;
using System.Collections.Generic;
namespace HPTest.Tools
{
    public class DataDevider
    {
        public IEnumerable<IEnumerable<string>> Devide(IEnumerable<string> data)
        {
            if (data == null) { return null; }

            var common = new HashSet<HashSet<string>>();
            var processed = new HashSet<string>();

            foreach (var first in data)
            {
                if (processed.Contains(first))
                    continue;

                var similars = new HashSet<string>(data.Where(it => it.IsSimilar(first)));
                common.Add(similars);
                processed.UnionWith(similars);
            }

            return common;
        }
    }
}
