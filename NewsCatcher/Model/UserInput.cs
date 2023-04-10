using System.Collections.Generic;

namespace NewsCatcherAPI.Model
{
    public class UserInput
    {
        public object lang { get; set; }

        public object not_lang { get; set; }

        public List<string> countries { get; set; }

        public object not_countries { get; set; }

        public int page { get; set; }

        public int size { get; set; }

        public object sources { get; set; }

        public List<object> not_sources { get; set; }

        public string topic { get; set; }

        public string from { get; set; }
    }
}
