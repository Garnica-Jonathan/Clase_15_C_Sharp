using Clase_14.Controllers.PTOS;
using Clase_14.Modelo;
using Clase_14.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Clase_14.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ProductoController : ControllerBase
    {
        [HttpPost]
        public bool CrearProducto([FromBody] PostProducto producto)
        {
            return ProductoHandler.CrearProducto(new Producto
            {
                Descripciones = producto.Descripciones,
                Costo = producto.Consto,
                PrecioVenta = producto.PrecioVenta,
                Stock = producto.Stock,
                IdUsuario = producto.IdUsuario,
            });
        }

        [HttpPut]

        public bool ModificarProducto([FromBody] PutProducto produto)
        {
            return ProductoHandler.ModificarProducto(new Producto
            {
                Descripciones=produto.Descripciones,
                Id = produto.Id,
            });
        }

        [HttpDelete]

        public bool EliminarProducto([FromBody] DeleteProducto producto)
        {
            return ProductoHandler.EliminarProducto(new Producto { 

            Id = producto.Id,
            
            });
        }

    }
}
