using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class CycleChecker
    {
        private Dictionary<Type, int> _types = new();
        private const int MaxNestingLevel = 3;

        public bool AddType(Type type)
        {
            if (_types.ContainsKey(type))
            {
                _types[type]++;
            }
            else
            {
                _types.Add(type, 1);
            }

            return _types[type] <= MaxNestingLevel;
        }

        public void RemoveType(Type type)
        {
            _types[type]--;
        }

    }
}
