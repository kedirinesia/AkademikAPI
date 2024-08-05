using Microsoft.AspNetCore.Connections.Features;
using System;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;

namespace WebAPiCrudd.Model
{
    public class DAL
    {
        public Response Login(SqlConnection connection, string NIM, string password)
        {
            Response response = new Response();

            string query = "SELECT * FROM Mahasiswa WHERE NIM = '" + NIM + "'AND Password = '" + password + "';";

          
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            var mahasiswaData = new Mahasiswa
                            {
                                NIM = reader["NIM"].ToString(),
                                Nama = reader["Nama"].ToString(),
                                Alamat_asal = reader["Alamat_asal"].ToString(),
                                Tempat_lahir = reader["Tempat_lahir"].ToString(),
                                Tanggal_lahir = reader["Tanggal_lahir"].ToString(),
                                Jenis_kel = reader["Jenis_kel"].ToString(),
                                Agama = reader["Agama"].ToString(),
                                Telp = reader["Telp"].ToString(),
                                IPK = reader["IPK"].ToString(),
                                Kode_prodgi = reader["Kode_prodgi"].ToString(),
                                Status_reg = reader["Status_reg"].ToString(),
                                Status_akd = reader["Status_akd"].ToString(),
                                Password = reader["Password"].ToString()
                            };

                            response.StatusCode = 200;
                            response.StatusMessage = "Login Berhasil";
                            response.Data = mahasiswaData;
                        }
                        else
                        {
                            response.StatusCode = 401;
                            response.StatusMessage = "Username atau Password salah";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                response.StatusMessage = $"Terjadi kesalahan: {ex.Message}";
            }

            return response;
        }

        public Response Home(SqlConnection conn, string NIM )

        {
            conn.Open();
            Response response = new Response();
            string query = "SELECT * FROM Mahasiswa where nim = @nim ";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query,conn)) 
                {
                    cmd.Parameters.AddWithValue("@nim", NIM);
                  

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            var mahasiswaData = new Mahasiswa
                            {

                                NIM = reader["NIM"].ToString(),
                                Nama = reader["Nama"].ToString(),
                                Kode_prodgi = reader["Kode_prodgi"].ToString(),
                                Status_reg = reader["Status_reg"].ToString(),
                                Status_akd = reader["Status_akd"].ToString(),
                               
                            };

                            response.StatusCode = 200;
                            response.StatusMessage = "Berhasil Mengambil data";
                            response.Data = mahasiswaData;
                        }
                        else
                        {
                            response.StatusCode = 401;
                            response.StatusMessage = "Gagal Mengambil Data";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                response.StatusMessage = $"Terjadi kesalahan: {ex.Message}";
            }

            return response;




        }

        public Response Profile(SqlConnection conn, string NIM)

        {
            conn.Open();
            Response response = new Response();
            string query = "SELECT * FROM Mahasiswa where nim = @nim ";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nim", NIM);


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            var mahasiswaData = new Profile
                            {

                                NIM = reader["NIM"].ToString(),
                                Nama = reader["Nama"].ToString(),
                            
                            };

                            response.StatusCode = 200;
                            response.StatusMessage = "Berhasil Mengambil data";
                            response.profile = mahasiswaData;
                        }
                        else
                        {
                            response.StatusCode = 401;
                            response.StatusMessage = "Gagal Mengambil Data";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                response.StatusMessage = $"Terjadi kesalahan: {ex.Message}";
            }

            return response;




        }
        public Response KRS(SqlConnection conn, string NIM)

        {
            conn.Open();
            Response response = new Response();
            string query = "SELECT * FROM krs where nim = @nim ";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nim", NIM);


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            var mahasiswaData = new KRS
                            {

                                NIM = reader["NIM"].ToString(),
                                Kode_mk = reader["Kode_mk"].ToString(),
                                Kelp = reader["Kelp"].ToString(),
                                Status = reader["Status"].ToString()

                            };

                            response.StatusCode = 200;
                            response.StatusMessage = "Berhasil Mengambil data";
                            response.KRS = mahasiswaData;
                        }
                        else
                        {
                            response.StatusCode = 401;
                            response.StatusMessage = "Gagal Mengambil Data";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                response.StatusMessage = $"Terjadi kesalahan: {ex.Message}";
            }

            return response;




        }

        public Response GetJadwal(SqlConnection conn)

        {
            conn.Open();
            Response response = new Response();
            string query = "SELECT * FROM Jadwal ";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                   


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            var mahasiswaData = new Jadwal
                            {

                                Kode_mk = reader["Kode_mk"].ToString(),
                            Kelp = reader["Kelp"].ToString(),
                            Hari1 = reader["Hari1"].ToString(),
                            Jam1 = reader["Jam1"].ToString(),
                            Ruang1 = reader["Ruang1"].ToString(),
                            Hari2 = reader["Hari2"].ToString(),
                            Jam2 = reader["Jam2"].ToString(),
                            Ruang2 = reader["Ruang2"].ToString(),
                            Kode_dosen = reader["Kode_dosen"].ToString()

                        };

                            response.StatusCode = 200;
                            response.StatusMessage = "Berhasil Mengambil data";
                            response.Damtaa = mahasiswaData;
                        }
                        else
                        {
                            response.StatusCode = 401;
                            response.StatusMessage = "Gagal Mengambil Data";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                response.StatusMessage = $"Terjadi kesalahan: {ex.Message}";
            }

            return response;




        }


        public Response AddJadwal(SqlConnection connection , Jadwal jadwal )
        {
            Response response = new Response();
            string query = "insert into jadwal values ('"+jadwal.Kode_mk+"', '"+jadwal.Kelp+"', '"+jadwal.Hari1+"', '"+jadwal.Jam1+"', '"+jadwal.Ruang1+"', '"+jadwal.Hari2+"', '"+jadwal.Jam2+"', '"+jadwal.Ruang2+"', '"+jadwal.Kode_dosen+"' )";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {



                connection.Open();
                int i = cmd.ExecuteNonQuery();
                connection.Close();

                if (i > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "OK";
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "Error";
                }
                return response;
            }
        }
        public Response DeleteKRS(SqlConnection connection, string NIM)
        {
            Response response = new Response();
            string query = "DELETE FROM KRS WHERE NIM = @NIM";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@NIM", NIM);

                try
                {
                    connection.Open();
                    int i = cmd.ExecuteNonQuery();

                    if (i > 0)
                    {
                        response.StatusCode = 200;
                        response.StatusMessage = "OK";
                    }
                    else
                    {
                        response.StatusCode = 100;
                        response.StatusMessage = "Error";
                    }
                }
                catch (Exception ex)
                {
                    response.StatusCode = 500;
                    response.StatusMessage = "Internal Server Error: " + ex.Message;
                }
                finally
                {
                    connection.Close();
                }
            }

            return response;
        }

    }
}
