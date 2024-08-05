using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Threading.Tasks;
using WebAPiCrudd.Model;

namespace WebAPiCrudd.Controllers
{
    [Route("")]
    [ApiController]
    public class Controllerr : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public Controllerr(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("login")]
        public async Task<IActionResult> Login([FromQuery] string NIM, [FromQuery] string password)
        {
            string connectionString = _configuration.GetConnectionString("Conn");

            if (string.IsNullOrEmpty(connectionString))
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Connection string is not configured.");
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    DAL dal = new DAL();
                    var response = dal.Login(conn, NIM, password);

                    if (response.StatusCode == 200)
                    {
                        return Ok(response);
                    }
                    else
                    {
                        return Unauthorized(response);
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("home")]
        public Response Home(string NIM)
        {
            Response response = new Response();

            using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("Conn").ToString()))
            {
                //string query = "Select "
                DAL dal = new DAL();
                response = dal.Home(conn, NIM);
                //response = dal.GetEmployee(conn, query);
            }



            return response;
        }

        [HttpGet]
        [Route("jadwal")]
        public Response GetJadwal(string NIM)
        {
            Response response = new Response();

            using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("Conn").ToString()))
            {
                //string query = "Select "
                DAL dal = new DAL();
                response = dal.GetJadwal(conn);
                //response = dal.GetEmployee(conn, query);
            }



            return response;
        }
        [HttpPost]
        [Route("jadwal")]
        public ActionResult<Response> AddJadwal(Jadwal jadwal)
        {


            Response response = new Response();


            using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("Conn")))
            {
                DAL dal = new DAL();
                response = dal.AddJadwal(conn, jadwal);

            }


            return Ok(response);
        }
        [HttpGet]
        [Route("profile")]
        public Response Profile(string NIM)
        {
            Response response = new Response();

            using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("Conn").ToString()))
            {

                DAL dal = new DAL();
                response = dal.Profile(conn, NIM);

            }



            return response;
        }


        [HttpGet]
        [Route("krs")]
        public Response GETKRS(string NIM)
        {
            Response response = new Response();

            using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("Conn").ToString()))
            {

                DAL dal = new DAL();
                response = dal.KRS(conn, NIM);

            }



            return response;
        }

        [HttpDelete]
        [Route("krs")]
        public ActionResult<Response> DeleteKRS(string NIm) {
            {


                Response response = new Response();


                using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("Conn")))
                {
                    DAL dal = new DAL();
                    response = dal.DeleteKRS(conn, NIm);

                }


                return Ok(response);
            }
        }
    }}
