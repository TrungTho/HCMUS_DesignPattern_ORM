using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorgiORM
{
    [TableName("employee")]
    class Employee
    {

        [Column("id", isKey: true, autoincrement: true)]
        public int idnhanvien { get; set; }

        [Column("name")]
        public string tennhanvien { get; set; }

        [Column("gender")]
        public string gioitinh { get; set; }

        [Column("address")]
        public string diachi { get; set; }

        [Column("email")]
        public string email { get; set; }

        [Column("phone")]
        public string sdt { get; set; }

        [Column("birthday")]
        public DateTime ngaysinh { get; set; }

        [Column("room")]
        public int idphong { get; set; }

        public Employee(int idnhanvien, string tennhanvien, string gioitinh, string email, string sdt, string diachi, DateTime ngaysinh, int idphong)
        {
            this.idnhanvien = idnhanvien;
            this.tennhanvien = tennhanvien;
            this.gioitinh = gioitinh;
            this.email = email;
            this.sdt = sdt;
            this.diachi = diachi;
            this.ngaysinh = ngaysinh;
            this.idphong = idphong;
        }
        public Employee() { }
    }
}
