using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using WebApplication1.Controllers;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1;
using Microsoft.Extensions.Configuration;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestTraerProductos()
        {
            var configuracion = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            ConexionDBContext conexionDBContext = new ConexionDBContext(configuracion);

            var producto = new ProductoController(conexionDBContext);

            Assert.IsNotNull(producto.TraerProductos());
        }
    }
}