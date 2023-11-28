using DAL.DataSetPSTableAdapters;
using System.ComponentModel;
using System.Data;
using System.Runtime.ConstrainedExecution;

namespace BLL
{
    public class ClassLogicaJP
    {
        private ClienteTableAdapter _clientes;
        private ProveedorTableAdapter _proveedores;
        private NivelesAccesoTableAdapter _nivelesacceso;
        private EmpleadoTableAdapter _empleados;
        private FacturaTableAdapter _factura;
        private DetalleFacturaTableAdapter _detalleFactura;
        private MetodoPagoTableAdapter _metodoPago;
        private PagoFacturaTableAdapter _pagoFactura;
        

        private PresentacionProductoTableAdapter _presentacionProducto;
        private MarcaProductoTableAdapter _marca;
        private AplicacionProductoTableAdapter _aplicacionProducto;
        private ProductosTableAdapter _productos;
        private PedidoProductoTableAdapter _pedidoProducto;
        private EntradaProductoTableAdapter _entradaProducto;

        public ClassLogicaJP()
        {
            _clientes = new ClienteTableAdapter();
            _proveedores = new ProveedorTableAdapter();
            _nivelesacceso = new NivelesAccesoTableAdapter();
            _empleados = new EmpleadoTableAdapter();

            _factura = new FacturaTableAdapter();
            _detalleFactura = new DetalleFacturaTableAdapter();
            _metodoPago = new MetodoPagoTableAdapter();
            _pagoFactura = new PagoFacturaTableAdapter();
            
            // cadenas de conexion dinamicas
            _clientes.Connection.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + Environment.CurrentDirectory.Split("WinUI")[0] + "Database\\PaintingStoreDatabase.mdf; Integrated Security = True";
            _proveedores.Connection.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + Environment.CurrentDirectory.Split("WinUI")[0] + "Database\\PaintingStoreDatabase.mdf; Integrated Security = True";
            _nivelesacceso.Connection.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + Environment.CurrentDirectory.Split("WinUI")[0] + "Database\\PaintingStoreDatabase.mdf; Integrated Security = True";
            _empleados.Connection.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + Environment.CurrentDirectory.Split("WinUI")[0] + "Database\\PaintingStoreDatabase.mdf; Integrated Security = True";            

            _factura.Connection.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + Environment.CurrentDirectory.Split("WinUI")[0] + "Database\\PaintingStoreDatabase.mdf; Integrated Security = True";
            _detalleFactura.Connection.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + Environment.CurrentDirectory.Split("WinUI")[0] + "Database\\PaintingStoreDatabase.mdf; Integrated Security = True";
            _metodoPago.Connection.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + Environment.CurrentDirectory.Split("WinUI")[0] + "Database\\PaintingStoreDatabase.mdf; Integrated Security = True";
            _pagoFactura.Connection.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + Environment.CurrentDirectory.Split("WinUI")[0] + "Database\\PaintingStoreDatabase.mdf; Integrated Security = True";
            

            _presentacionProducto = new PresentacionProductoTableAdapter();
            _marca = new MarcaProductoTableAdapter();
            _aplicacionProducto = new AplicacionProductoTableAdapter();
            _productos = new ProductosTableAdapter();
            _pedidoProducto = new PedidoProductoTableAdapter();
            _entradaProducto = new EntradaProductoTableAdapter();

            _presentacionProducto.Connection.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + Environment.CurrentDirectory.Split("WinUI")[0] + "Database\\PaintingStoreDatabase.mdf; Integrated Security = True";
            _marca.Connection.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + Environment.CurrentDirectory.Split("WinUI")[0] + "Database\\PaintingStoreDatabase.mdf; Integrated Security = True";
            _aplicacionProducto.Connection.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + Environment.CurrentDirectory.Split("WinUI")[0] + "Database\\PaintingStoreDatabase.mdf; Integrated Security = True";
            _productos.Connection.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + Environment.CurrentDirectory.Split("WinUI")[0] + "Database\\PaintingStoreDatabase.mdf; Integrated Security = True";
            _pedidoProducto.Connection.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + Environment.CurrentDirectory.Split("WinUI")[0] + "Database\\PaintingStoreDatabase.mdf; Integrated Security = True";
            _entradaProducto.Connection.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + Environment.CurrentDirectory.Split("WinUI")[0] + "Database\\PaintingStoreDatabase.mdf; Integrated Security = True";
        }

        public string sp_facturacion(string factura, double monto, int empleado, int cliente, DataTable productos, DataTable metodospago)
        {
            string msg = "";
            try
            {
                _factura.sp_Facturacion(factura, Convert.ToDecimal(monto), empleado, cliente, productos, metodospago, ref msg);
            }
            catch (Exception ex)
            {
                msg = "ERROR: " + ex.Message;
            }

            return msg;
        }

        public DataTable ListarProductosConNombres()
        {
            return _productos.GetData();
        }

        public DataTable ListarClientes()
        {
            return _clientes.GetData();
        }

        public DataTable ListarMetodosPago()
        {
            return _metodoPago.GetData();
        }

        public string get_conn()
        {
            return _empleados.Connection.ConnectionString;
        }

        // Tabla Empleados

        public int getNivelLogin(string username, string password)
        {
            try
            {
                return (int)_empleados.ScalarQueryLogin(username, password);
            }
            catch
            {
                return -1;
            }
        }
        public DataTable ListarEmpleados()
        {
            return _empleados.GetData();
        }

        public string NuevoEmpleado(string username, string password, string nombre, string direccion, string telefono, DateTime fecha_nacimiento, string dpi, int id_acceso)
        {
            try
            {
                int countUserName = (int)_empleados.ScalarQueryCheckUsernameAvailable(username);

                if (countUserName == 0)
                {
                    _empleados.InsertQueryEmpleado(username, password, nombre, direccion, telefono, fecha_nacimiento, dpi, id_acceso);
                    return "INFO: Usuario creado con exito!";
                }
                else
                {
                    return "ERROR: El nombre de usuario \"" + username + "\" ya existe! Por favor utilice otro";
                }
            }
            catch (Exception error)
            {
                return "ERROR: " + error.Message;
            }
        }

        public string ActualizarEmpleado(int id_empleado, string username, string password, string nombre, string direccion, string telefono, DateTime fecha_nacimiento, string dpi, int id_acceso)
        {
            try
            {
                _empleados.UpdateQueryEmpleado(username, password, nombre, direccion, telefono, fecha_nacimiento, dpi, id_acceso, id_empleado);
                return "INFO: Empleado actualizado con exito!";
            }
            catch (Exception error)
            {
                return "ERROR: " + error.Message;
            }
        }

        public string EliminarEmpleado(int id)
        {
            try
            {
                _empleados.DeleteQueryEmpleado(id);
                return "INFO: Empleado eliminado con exito!";
            }
            catch (Exception error)
            {
                return "ERROR: " + error.Message;
            }
        }

        // Niveles de acceso
        public DataTable ListarNivelesAcceso()
        {
            return _nivelesacceso.GetData();
        }

        public DataTable ListarFacturas()
        {
            return _factura.GetData();
        }

        public void restoreNivelesAcceso()
        {
            _nivelesacceso.DeleteQueryReset();
            _nivelesacceso.InsertQueryNivelesAcceso("Administrador", 1);
            _nivelesacceso.InsertQueryNivelesAcceso("Bodeguero", 2);
            _nivelesacceso.InsertQueryNivelesAcceso("Cajero", 3);
            _nivelesacceso.InsertQueryNivelesAcceso("Gerente", 4);
        }

        public DataTable[] ListarDetallesFactura(string factura)
        {
            DataTable[] ret = new DataTable[2];

            ret[0] = _detalleFactura.GetDataByFacturaId(factura);
            ret[1] = _pagoFactura.GetDataByFacturaId(factura);

            return ret;
        }

        // Tabla Proveedores
        public DataTable ListarProveedores()
        {
            return _proveedores.GetData();
        }

        public string NuevoProveedor(string nombre, string telefono, string direccion, string contacto)
        {
            try
            {
                _proveedores.InsertQueryProveedor(nombre, telefono, direccion, contacto);
                return "INFO: Se ha guardado el nuevo proveedor de forma exitosa!";
            }
            catch (Exception error)
            {
                return "ERROR: " + error.Message;
            }
        }

        public string AnularFactura(string factura)
        {
            string msg = "";

            try
            {
                _factura.sp_AnularFacturacion(factura, ref msg);
            }
            catch (Exception error)
            {
                msg = "ERROR: " + error.Message;
            }

            return msg;
        }

        public string ActualizarProveedor(int id, string nombre, string telefono, string direccion, string contacto)
        {
            try
            {
                _proveedores.UpdateQueryProveedor(nombre, telefono, direccion, contacto, id);
                return "INFO: Proveedor actualizado con exito!";
            }
            catch (Exception error)
            {
                return "ERROR: " + error.Message;
            }
        }

        public string EliminarProveedor(int id)
        {
            try
            {
                _proveedores.DeleteQueryProveedor(id);
                return "INFO: Proveedor eliminado con exito!";
            }
            catch (Exception error)
            {
                return "ERROR: " + error.Message;
            }
        }

        public int numeroProveedores()
        {
            return (int)_proveedores.ScalarQueryNumeroProveedores();
        }

        // Tabla Clientes
        public DataTable Listar()
        {
            return _clientes.GetData();
        }

        public string NuevoCliente(string nombre, string direccion, string telefono, string nit)
        {
            try
            {
                int countNit = (int)_clientes.ScalarQueryExistsNIT(nit);

                if (countNit == 0)
                {
                    _clientes.InsertQueryCliente(nombre, direccion, telefono, nit);
                    return "INFO: Se ha guardado el cliente de forma exitosa!";
                }
                else
                {
                    return "ERROR: Un cliente con el mismo NIT ya existe!";
                }
            }
            catch (Exception error)
            {
                return "ERROR: " + error.Message;
            }
        }

        public string ActualizarCliente(int id, string nombre, string direccion, string telefono, string nit)
        {
            try
            {
                _clientes.UpdateQueryCliente(nombre, direccion, telefono, nit, id);
                return "INFO: Cliente actualizado con exito!";
            }
            catch (Exception error)
            {
                return "ERROR: " + error.Message;
            }
        }

        public string EliminarCliente(int id)
        {
            try
            {
                _clientes.DeleteQueryCliente(id);
                return "INFO: Cliente eliminado con exito!";
            }
            catch (Exception error)
            {
                return "ERROR: " + error.Message;
            }
        }
    }
}