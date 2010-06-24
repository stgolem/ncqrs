using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace Ncqrs.Eventing.Storage.Serialization
{
    public class StringEventTranslator : IEventTranslator<string>
    {
        public StoredEvent<JObject> TranslateToCommon(StoredEvent<string> obj)
        {
            return obj.Clone(JObject.Parse(obj.Data));
        }

        public StoredEvent<string> TranslateToRaw(StoredEvent<JObject> obj)
        {
            return obj.Clone(obj.Data.ToString(Formatting.None, new IsoDateTimeConverter()));
        }
    }
}
