using System;
using Newtonsoft.Json;

namespace CommonFx
{
    public interface IJsonHelper
    {
        string Serialize(object value, bool indented = true);
        object Deserialize(string content);
        T Deserialize<T>(string content);
    }

    public class JsonHelper : IJsonHelper
    {
        #region for di extensions

        private static Lazy<IJsonHelper> _lazy = new Lazy<IJsonHelper>(() => new JsonHelper());
        private static Func<IJsonHelper> _resolve = () => _lazy.Value;
        public static Func<IJsonHelper> Resolve
        {
            get { return _resolve; }
            set { _resolve = value; }
        }

        #endregion

        public string Serialize(object value, bool indented)
        {
            var formatting = indented ? Formatting.Indented : Formatting.None;
            var serializeObject = JsonConvert.SerializeObject(value, formatting);
            return serializeObject;
        }

        public object Deserialize(string content)
        {
            return JsonConvert.DeserializeObject(content);
        }

        public T Deserialize<T>(string content)
        {
            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}
