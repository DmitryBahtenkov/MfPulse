using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MfPulse.CrossCutting.Extensions
{
    public static class EnumerableExtensions
    {
        public static async Task<List<T>> ToListAsync<T>(this IEnumerable<Task<T>> enumerable)
        {
            var result = new List<T>();
            foreach (var task in enumerable)
            {
                result.Add(await task);
            }

            return result;
        }
    }
}