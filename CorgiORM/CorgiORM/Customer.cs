using CorgiORM.Mapping;

namespace CorgiORM {
    public class Customer {
        [DataNames("ID", "ID")]
        public string ID { get; set; }

        [DataNames("Fullname", "Fullname")]
        public string Fullname { get; set; }

        [DataNames("Tel", "Tel")]
        public string tel { get; set; }
    }
}
