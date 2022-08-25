using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    public class ProductoController : Controller
    {
        protected readonly ConexionDBContext _context;

        public ProductoController(ConexionDBContext context)
        {
            _context = context;
        }
        //Read
        public List<Producto> TraerProductos()
        {
            var listaProductos = _context.Producto.ToList();

            return listaProductos;
        }
        //ReadBy
        public Producto? TraerUnProducto(int id)
        {
            var producto = _context.Producto.Where(p => p.Id == id).FirstOrDefault();

            return producto;
        }
        //Create
        public bool CrearProducto(Producto prod)
        {
            var producto = new Producto();
            
            try
            {
                producto.Nombre = prod.Nombre;
                producto.Descripcion = prod.Descripcion;
                producto.Modelo = prod.Modelo;
                producto.Costo = prod.Costo;
                producto.Stock = prod.Stock;

                _context.Producto.Add(producto);

                _context.SaveChanges();

                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);

                return false;
            }
        }
        //Update
        public bool ActualizarProducto(Producto producto)
        {
            try
            {              
                if(producto != null)
                {
                    _context.Producto.Update(producto);

                    _context.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);

                return false;
            }
        }
        //Delete
        public bool BorrarProducto(int id)
        {
            try
            {
                var producto = _context.Producto.Where(p => p.Id == id).FirstOrDefault();

                if(producto != null)
                {
                    _context.Producto.Remove(producto);

                    _context.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);

                return false;
            }
        }

        public IActionResult Home()
        {
            return View(TraerProductos());
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Producto producto)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            var respuesta = CrearProducto(producto);

            if (respuesta)
            {
                return RedirectToAction("Home");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Actualizar(int id)
        {
            var producto = TraerUnProducto(id);
            
            return View(producto);
        }

        [HttpPost]
        public IActionResult Actualizar(Producto producto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var respuesta = ActualizarProducto(producto);

            if (respuesta)
            {
                return RedirectToAction("Home");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Borrar(int id)
        {
            var producto = TraerUnProducto(id);
            
            return View(producto);
        }

        [HttpPost]
        public IActionResult Borrar(Producto producto)
        {
            var respuesta = BorrarProducto(producto.Id);

            if (respuesta)
            {
                return RedirectToAction("Home");
            }
            else
            {
                return View();
            }
        }
    }
}
