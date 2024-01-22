using ProductoMVVMSQLite.Models;
using ProductoMVVMSQLite.Utils;
using ProductoMVVMSQLite.Views;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProductoMVVMSQLite.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class DetallesProductoViewModel
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Cantidad { get; set; }
        public string Descripcion { get; set; }

        public DetallesProductoViewModel(Producto producto)
        {
            IdProducto = producto.IdProducto;
            Nombre = producto.Nombre;
            Cantidad = producto.Cantidad.ToString();
            Descripcion = producto.Descripcion;
        }
        public DetallesProductoViewModel()
        {
            
        }

        public void ActualizarProducto()
        {
            var productoActualizado = App.productoRepository.Get(IdProducto);
            IdProducto = productoActualizado.IdProducto;
            Nombre = productoActualizado.Nombre;
            Cantidad = productoActualizado.Cantidad.ToString();
            Descripcion = productoActualizado.Descripcion;
        }

        public ICommand EditarProducto =>
            new Command(async () =>
            {

                Producto producto2 = new Producto()
                {
                    IdProducto = IdProducto,
                    Nombre = Nombre,
                    Cantidad = Int32.Parse(Cantidad),
                    Descripcion = Descripcion
                };
                await App.Current.MainPage.Navigation.PushAsync(new EditarProductoPage(producto2));
                
            });
        public ICommand EliminarProducto =>
            new Command(async () =>
            {

                Producto producto2 = new Producto()
                {
                    IdProducto = IdProducto,
                    Nombre = Nombre,
                    Cantidad = Int32.Parse(Cantidad),
                    Descripcion = Descripcion
                };
                App.productoRepository.Delete(producto2);
                Util.ListaProductos.Clear();
                App.productoRepository.GetAll().ForEach(Util.ListaProductos.Add);
                await App.Current.MainPage.Navigation.PopAsync();
                //await App.Current.MainPage.Navigation.PushAsync(new ProductoPage());
            });

    }

}
