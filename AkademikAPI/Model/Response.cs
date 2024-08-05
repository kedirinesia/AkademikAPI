namespace WebAPiCrudd.Model
{
    public class Response
    {
        public int StatusCode { get; set; }
        public string? StatusMessage { get; set; }
        public Mahasiswa Data { get; set; }
        public HOmme Dataa { get; set; }
        public Jadwal Damtaa { get; set; }
        public Profile profile { get; set; }
        public KRS KRS { get; set; }
    }

    public class Mahasiswa
    {

        public string NIM { get; set; } // varchar(10)
        public string Nama { get; set; } // varchar(30)
        public string Alamat_asal { get; set; } // varchar(60)
        public string Tempat_lahir { get; set; } // varchar(25)
        public string Tanggal_lahir { get; set; } // varchar(25)
        public string Jenis_kel { get; set; } 
        public string Agama { get; set; } // varchar(2)
        public string Telp { get; set; } // varchar(10)
        public string IPK { get; set; } // varchar(50)
        public string Kode_prodgi { get; set; } // varchar(5)
        public string Status_reg { get; set; } // varchar(10)
        public string Status_akd { get; set; } // varchar(1)
        public string Password { get; set; } // varchar(10)
    }
    public class HOmme
    {

        public string NIM { get; set; } // varchar(10)
        public string Nama { get; set; } // varchar(30)
        public string IPK { get; set; } // varchar(50)
        public string Kode_prodgi { get; set; } // varchar(5)
        public string Status_reg { get; set; } // varchar(10)
        public string Status_akd { get; set; } // varchar(1)
    }
    public class Profile
    {

        public string NIM { get; set; } // varchar(10)
        public string Nama { get; set; } // varchar(30)
      
    }


    public class EmployeeUpdateBy
    {
        public string? Nama { get; set; }
        public string Email { get; set; }
    }

    
        public class Jadwal
        {
            public string Kode_mk { get; set; } // varchar(6)
            public string Kelp { get; set; } // varchar(3)
            public string Hari1 { get; set; } // varchar(6)
            public string Jam1 { get; set; } // varchar(12)
            public string Ruang1 { get; set; } // varchar(6)
            public string Hari2 { get; set; } // varchar(6)
            public string Jam2 { get; set; } // varchar(12)
            public string Ruang2 { get; set; } // varchar(6)
            public string Kode_dosen { get; set; } // varchar(6)
        } public class KRS
        {
          public string NIM { get; set; }
          public string Kode_mk { get; set; }
          public string Kelp { get; set; }
          public string Status { get; set; }

        }
    }

 
 
