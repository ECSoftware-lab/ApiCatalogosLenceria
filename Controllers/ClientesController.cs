using System.Linq;
using Api_Catalogos.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api_Catalogos.Controllers
{
    [Route("api/[controller]")]
    public class ClientesController : Controller
    {
        private Conexion dbConexion;

        public ClientesController()
        {
            dbConexion = Conectar.Create();
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(dbConexion.Clientes.ToArray());
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var cliente =
                dbConexion.Clientes.SingleOrDefault(a => a.IdClientes == id);
            if (cliente != null)
            {
                return Ok(cliente);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Clientes cliente)
        {
            if (ModelState.IsValid)
            {
                dbConexion.Clientes.Add(cliente);
                dbConexion.SaveChanges();
                return Ok(cliente);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        public ActionResult Put([FromBody] Clientes cliente)
        {
            var V_Cliete =
                dbConexion
                    .Clientes
                    .SingleOrDefault(a => a.IdClientes == cliente.IdClientes);
            if (V_Cliete != null && ModelState.IsValid)
            {
                dbConexion.Entry(V_Cliete).CurrentValues.SetValues(cliente);
                dbConexion.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
