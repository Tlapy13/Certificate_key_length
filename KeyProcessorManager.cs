using Certificate_key_length.KeyTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certificate_key_length
{
    public static class KeyProcessorManager
    {
        private static readonly List<IKeyProcessor> KeyProcessors = new List<IKeyProcessor>
    {
        new PemKeyProcessor(),
        new OpenSshKeyProcessor(),
        new DerKeyProcessor()
    };

        public static IKeyProcessor GetProcessor(string formatName)
        {
            foreach (var processor in KeyProcessors)
            {
                if (processor.FormatName == formatName)
                {
                    return processor;
                }
            }

            throw new KeyNotFoundException($"No processor found for format: {formatName}");
        }
    }
}
