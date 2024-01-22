using ProductoMVVMSQLite.Models;
using ProductoMVVMSQLite.Utils;
using ProductoMVVMSQLite.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProductoMVVMSQLite.ViewModels
{
    public class EditarProductoViewModel
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Cantidad { get; set; }
        public string Descripcion { get; set; }
        public EditarProductoViewModel(Producto producto)
        {
            IdProducto = producto.IdProducto;
            Nombre = producto.Nombre;
            Cantidad = producto.Cantidad.ToString();
            Descripcion = producto.Descripcion;

        }
        public ICommand ActualizarProducto =>
            new Command(async () =>
            {
                Producto producto2 = new Producto()
                {
                    IdProducto = IdProducto,
                    Nombre = Nombre,
                    Cantidad = Int32.Parse(Cantidad),
                    Descripcion = Descripcion
                };
                App.productoRepository.Update(producto2);
                Util.ListaProductos.Clear();
                App.productoRepository.GetAll().ForEach(Util.ListaProductos.Add);
                await App.Current.MainPage.Navigation.PopAsync();
            });
    }
}
