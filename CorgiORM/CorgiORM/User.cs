using CorgiORM.Model;

namespace CorgiORM {
    [TableName("User")]
    class User {
        [DataNames("id")]
        public int id { get; set; }

        [DataNames("name")]
        public string name { get; set; }

        [DataNames("email")]
        public string email { get; set; }

        [DataNames("password")]
        public string password { get; set; }

        [DataNames("avatar")]
        public string avatar { get; set; }
    }
}
