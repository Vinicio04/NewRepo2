using DAL.DataSetPSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ClassLogicaJC
    {
        private PresentacionProductoTableAdapter _presentacionProducto;
        private MetodoPagoTableAdapter _metodoPago;
        private MarcaProductoTableAdapter _marca;
        private AplicacionProductoTableAdapter _aplicacionProducto;
        private ProductosTableAdapter _productos;
        private PedidoProductoTableAdapter _pedidoProducto;
        private EntradaProductoTableAdapter _entradaProducto;
        public ClassLogicaJC()
        {
            _presentacionProducto = new PresentacionProductoTableAdapter();
            _metodoPago = new MetodoPagoTableAdapter();
            _marca = new MarcaProductoTableAdapter();
            _aplicacionProducto = new AplicacionProductoTableAdapter();
            _productos = new ProductosTableAdapter();
            _pedidoProducto = new PedidoProductoTableAdapter();
            _entradaProducto = new EntradaProductoTableAdapter();

            _presentacionProducto.Connection.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + Environment.CurrentDirectory.Split("WinUI")[0] + "Database\\PaintingStoreDatabase.mdf; Integrated Security = True";
            _metodoPago.Connection.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + Environment.CurrentDirectory.Split("WinUI")[0] + "Database\\PaintingStoreDatabase.mdf; Integrated Security = True";
            _marca.Connection.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + Environment.CurrentDirectory.Split("WinUI")[0] + "Database\\PaintingStoreDatabase.mdf; Integrated Security = True";
            _aplicacionProducto.Connection.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + Environment.CurrentDirectory.Split("WinUI")[0] + "Database\\PaintingStoreDatabase.mdf; Integrated Security = True";
            _productos.Connection.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + Environment.CurrentDirectory.Split("WinUI")[0] + "Database\\PaintingStoreDatabase.mdf; Integrated Security = True";
            _pedidoProducto.Connection.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + Environment.CurrentDirectory.Split("WinUI")[0] + "Database\\PaintingStoreDatabase.mdf; Integrated Security = True";
            _entradaProducto.Connection.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + Environment.CurrentDirectory.Split("WinUI")[0] + "Database\\PaintingStoreDatabase.mdf; Integrated Security = True";
        }

        //-------------------------------------- CRUD PRESENTACIÓN PRODUCTO --------------------------------------
        public DataTable ListarPresentacionProducto()
        {
            return _presentacionProducto.GetData();
        }
        public string NuevoPresentacionProducto(float MedidaPresentacion, string NombrePresentacion)
        {
            try
            {
                _presentacionProducto.InsertQueryPresentacionProducto(MedidaPresentacion, NombrePresentacion);
                return "INFO: Se ha guardado la nueva Presentación del Producto de forma exitosa!";
            }
            catch (Exception error)
            {
                return "ERROR: " + error.Message;
            }
        }

        public string ActualizarPresentacioProducto(int id, float MedidaPresentacion, string NombrePresentacion)
        {
            try
            {
                _presentacionProducto.UpdateQueryPresentacionProducto(MedidaPresentacion, NombrePresentacion, id);
                return "INFO: Presentación del Producto actualizado de forma exitosa!";
            }
            catch (Exception error)
            {
                return "ERROR: " + error.Message;
            }
        }

        public string EliminarPresentacionProducto(int id)
        {
            try
            {
                _presentacionProducto.DeleteQueryPresentacionProducto(id);
                return "INFO: Presentación del Producto eliminada de forma exitosa!";
            }
            catch (Exception error)
            {
                return "ERROR: " + error.Message;
            }
        }

        //-------------------------------------- CRUD METODO PAGO --------------------------------------
        public DataTable ListarMetodoPago()
        {
            return _metodoPago.GetData();
        }
        public string NuevoMetodoPago(string nombreMetodoPago)
        {
            try
            {
                _metodoPago.InsertQueryMetodoPago(nombreMetodoPago);
                return "INFO: Se ha guardado el nuevo Método de Pago de forma exitosa!";
            }
            catch (Exception error)
            {
                return "ERROR: " + error.Message;
            }
        }

        public string ActualizarMetodoPago(int id, string nombreMetodoPago)
        {
            try
            {
                _metodoPago.UpdateQueryMetodoPago(nombreMetodoPago, id);
                return "INFO: Método de Pago actualizado de forma exitosa!";
            }
            catch (Exception error)
            {
                return "ERROR: " + error.Message;
            }
        }

        public string EliminarMetodoPago(int id)
        {
            try
            {
                _metodoPago.DeleteQueryMetodoPago(id);
                return "INFO: Método de Pago eliminada de forma exitosa!";
            }
            catch (Exception error)
            {
                return "ERROR: " + error.Message;
            }
        }
        //-------------------------------------- CRUD MARCA DEL PRODUCTO --------------------------------------
        public DataTable ListarMarca()
        {
            return _marca.GetDataBy3prueba();
        }
        public string NuevoMarca(string nombreMarca)
        {
            try
            {
                _marca.InsertQueryMarca(nombreMarca);
                return "INFO: Se ha guardado la Marca de forma exitosa!";
            }
            catch (Exception error)
            {
                return "ERROR: " + error.Message;
            }
        }

        public string ActualizarMarca(int id, string nombreMarca)
        {
            try
            {
                _marca.UpdateQueryMarca(nombreMarca, id);
                return "INFO: Marca actualizada de forma exitosa!";
            }
            catch (Exception error)
            {
                return "ERROR: " + error.Message;
            }
        }

        public string EliminarMarca(int id)
        {
            try
            {
                _marca.DeleteQueryMarca(id);
                return "INFO: Marca eliminada de forma exitosa!";
            }
            catch (Exception error)
            {
                return "ERROR: " + error.Message;
            }
        }
        //-------------------------------------- CRUD APLICACIÓN DEL PRODUCTO --------------------------------------
        public DataTable ListarAplicacion()
        {
            return _aplicacionProducto.GetData();
        }
        public string NuevoAplicacion(string nombreAplicacion)
        {
            try
            {
                _aplicacionProducto.InsertQueryAplicacionProducto(nombreAplicacion);
                return "INFO: Se ha guardado la Aplicación del Producto de forma exitosa!";
            }
            catch (Exception error)
            {
                return "ERROR: " + error.Message;
            }
        }

        public string ActualizarAplicacion(int id, string nombreAplicacion)
        {
            try
            {
                _aplicacionProducto.UpdateQueryAplicacionProducto(nombreAplicacion, id);    
                return "INFO: Aplicación del Producto actualizada de forma exitosa!";
            }
            catch (Exception error)
            {
                return "ERROR: " + error.Message;
            }
        }

        public string EliminarAplicacion(int id)
        {
            try
            {
                _aplicacionProducto.DeleteQueryAplicacionProducto(id);
                return "INFO: Aplicación del Producto eliminada de forma exitosa!";
            }
            catch (Exception error)
            {
                return "ERROR: " + error.Message;
            }
        }

        //-------------------------------------- CRUD PRODUCTOS --------------------------------------
        
        public DataTable ListarProductos()
        {
            return _productos.GetData();
        }

        public string NuevoProducto(string nombreProducto, string descripcionProducto, decimal precioVenta, int anoDuracion, int cantidadBodega, int existenciaMinima, int marca, int aplicacion, int presentacionProducto)
        {
            try
            {
                _productos.InsertQueryProductos(nombreProducto, descripcionProducto, precioVenta, anoDuracion, cantidadBodega, existenciaMinima, marca, aplicacion, presentacionProducto);
                return "INFO: Se ha guardado el Producto de forma exitosa!";
            }
            catch (Exception error)
            {
                return "ERROR: " + error.Message;
            }
        }

        public string ActualizarProducto(int id, string nombreProducto, string descripcionProducto, float precioVenta, int anoDuracion, int cantidadBodega, int existenciaMinima, int marca, int aplicacion, int presentacionProducto)
        {
            try
            {
                _productos.UpdateQueryProductos(nombreProducto, descripcionProducto, precioVenta, anoDuracion, cantidadBodega, existenciaMinima, marca, aplicacion, presentacionProducto, id);
                return "INFO: Producto actualizado de forma exitosa!";
            }
            catch (Exception error)
            {
                return "ERROR: " + error.Message;
            }
        }

        public string EliminarProducto(int id)
        {
            try
            {
                _productos.DeleteQueryProductos(id);
                return "INFO: Producto eliminado de forma exitosa!";
            }
            catch (Exception error)
            {
                return "ERROR: " + error.Message;
            }
        }

        //-------------------------------------- CRUD PEDIDO DE PRODUCTO --------------------------------------

        public DataTable ListarPedidoProductos()
        {
            return _pedidoProducto.GetData();
        }

        public string NuevoPedidoProducto(int cantidadPedido, DateTime fechaRealizacion, int proveedor, int producto)
        {
            try
            {
                _pedidoProducto.InsertQueryPedidoProducto(cantidadPedido, fechaRealizacion, proveedor, producto);
                return "INFO: Se ha guardado el Pedido del Producto de forma exitosa!";
            }
            catch (Exception error)
            {
                return "ERROR: " + error.Message;
            }
        }

        public string ActualizarPedidoProducto(int id, int cantidadPedido, DateTime fechaRealizacion, int proveedor, int producto)
        {
            try
            {
                _pedidoProducto.UpdateQueryPedidoProducto(cantidadPedido, fechaRealizacion, proveedor, producto, id);
                return "INFO: Pedido del Producto actualizado de forma exitosa!";
            }
            catch (Exception error)
            {
                return "ERROR: " + error.Message;
            }
        }

        public string EliminarPedidoProducto(int id)
        {
            try
            {
                _pedidoProducto.DeleteQueryPedidoProducto(id);
                return "INFO: Pedido del Producto eliminado de forma exitosa!";
            }
            catch (Exception error)
            {
                return "ERROR: " + error.Message;
            }
        }

        //-------------------------------------- CRUD ENTRADA DE PRODUCTOS --------------------------------------

        public DataTable ListarEntradaProductos()
        {
            return _entradaProducto.GetData();
        }

        public string NuevoEntradaProducto(DateTime fechaEntrada, int cantidadEntrada, int pedidoProducto)
        {
            try
            {
                _entradaProducto.InsertQueryEntradaProductos(fechaEntrada, cantidadEntrada, pedidoProducto);
                return "INFO: Se ha guardado la Entrada del Producto de forma exitosa!";
            }
            catch (Exception error)
            {
                return "ERROR: " + error.Message;
            }
        }

        public string ActualizarEntradaProducto(int id, DateTime fechaEntrada, int cantidadEntrada, int pedidoProducto)
        {
            try
            {
                _entradaProducto.UpdateQueryEntradaProductos(fechaEntrada, cantidadEntrada, pedidoProducto, id);
                return "INFO: Entrada Producto actualizada de forma exitosa!";
            }
            catch (Exception error)
            {
                return "ERROR: " + error.Message;
            }
        }

        public string EliminarEntradaProducto(int id)
        {
            try
            {
                _entradaProducto.DeleteQueryEntradaProductos(id);
                return "INFO: Entrada de Producto eliminada de forma exitosa!";
            }
            catch (Exception error)
            {
                return "ERROR: " + error.Message;
            }
        }
    }
}
