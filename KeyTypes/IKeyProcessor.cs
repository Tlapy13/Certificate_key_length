using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certificate_key_length.KeyTypes
{
    public interface IKeyProcessor
    {
        string FormatName { get; }
        int GetKeyLength(string keyContent);
    }
}
