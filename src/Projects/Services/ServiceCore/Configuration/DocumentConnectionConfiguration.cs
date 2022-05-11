using System.Collections.Generic;

namespace ServiceCore.Configuration
{
    public class DocumentConnectionConfiguration
    {
        public string DocumentDbEndPoint { get; set; }
        public string DocumentDbKey { get; set; }
        public string DatabaseName { get; set; }
        public IEnumerable<CollectionDbInfo> CollectionDbs { get; set; }
    }

    public class CollectionDbInfo
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}