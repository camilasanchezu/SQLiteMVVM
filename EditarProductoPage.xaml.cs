using ProductoMVVMSQLite.Models;
using ProductoMVVMSQLite.ViewModels;

namespace ProductoMVVMSQLite.Views;

public partial class EditarProductoPage : ContentPage
{
	

    public Producto producto2;
    public EditarProductoPage(Producto producto)
    {
        InitializeComponent();
        producto2 = producto;
        BindingContext = new EditarProductoViewModel(producto2);

    }
}
