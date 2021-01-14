using CorgiORM.Model;

namespace CorgiORM {
    public class Customer {
        [DataNames("ID")]
        public string ID { get; set; }

        [DataNames("Fullname")]
        public string Fullname { get; set; }

        [DataNames("tele_tel")]
        public string tel { get; set; }

        public string test { get; set; }
    }
}
