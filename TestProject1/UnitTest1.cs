using WebApplication1.Controllers;
using WebApplication1.Data;
using WebApplication1.Models;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        

        [TestMethod]
        public void TestMethod1()
        {
            var lista1 = ListarProductos();
            var lista2 = ListarProductos();

            Assert.AreEqual(lista1.Count, lista2.Count);

            //int num1 = 10;
            //int num2 = 10;

            //Assert.AreEqual(num1, num2);
        }

        public List<Producto> ListarProductos()
        {
            return new List<Producto>();
        }
    }
}