using ProductoMVVMSQLite.Models;
using ProductoMVVMSQLite.ViewModels;

namespace ProductoMVVMSQLite.Views;

public partial class DetallesProductoPage : ContentPage
{
    public Producto producto2;
    public DetallesProductoPage(Producto producto)
    {
        InitializeComponent();
        producto2 = producto;
        BindingContext = new DetallesProductoViewModel(producto2);
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        (BindingContext as DetallesProductoViewModel).ActualizarProducto();
    }
}