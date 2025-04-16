using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoBD datos = new AccesoBD();

            try
            {
                datos.setearConsulta("SELECT " +
                    "A.Id, " +
                    "A.Codigo, " +
                    "A.Nombre, " +
                    "A.Descripcion, " +
                    "A.Precio, " +
                    "C.Id AS IdCategoria, " +
                    "C.Descripcion AS Categoria, " +
                    "M.Id AS IdMarca, " +
                    "M.Descripcion AS Marca, " +
                    "(" +
                        "SELECT TOP 1 ImagenUrl " +
                        "FROM IMAGENES " +
                        "WHERE IdArticulo = A.Id " +
                        "ORDER BY ImagenUrl" +
                    ") AS ImagenUrl " +
                    "FROM Articulos A " +
                    "JOIN Categorias C ON A.IdCategoria = C.Id " +
                    "JOIN Marcas M ON A.IdMarca = M.Id");

                datos.ejecutarLectura();

                while (datos.Lectorbd.Read())
                {
                    Articulo aux = new Articulo();

                    aux.Id = (int)datos.Lectorbd["Id"];
                    aux.Codigo = (string)datos.Lectorbd["Codigo"];
                    aux.Nombre = (string)datos.Lectorbd["Nombre"];
                    aux.Descripcion = (string)datos.Lectorbd["Descripcion"];


                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lectorbd["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lectorbd["Marca"];

                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lectorbd["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lectorbd["Categoria"];

                    aux.Precio = Decimal.Round((decimal)datos.Lectorbd["Precio"], 2);
                    aux.Imagen = (string)datos.Lectorbd["ImagenUrl"];
                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    
        public void agregar (Articulo newArticulo)
        {
            AccesoBD datos = new AccesoBD();
            try
            {
                datos.setearConsulta("INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, Precio) VALUES ('" + newArticulo.Codigo + "', '" + newArticulo.Nombre + "', '" + newArticulo.Descripcion + "', " + newArticulo.Precio + ")");
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void modificar(Articulo articulo)
        {
            try
            {
                AccesoBD datosTablaArticulos = new AccesoBD();
                datosTablaArticulos.setearConsulta("UPDATE ARTICULOS SET " +
                    "Codigo = @codigo, " +
                    "Nombre = @nombre, " +
                    "Descripcion = @descripcion, " +
                    "IdMarca = @idmarca, " +
                    "IdCategoria = @idcategoria, " +
                    "Precio = @precio " +
                    "WHERE Id = @id");

                datosTablaArticulos.setearParametro("@id", articulo.Id);
                datosTablaArticulos.setearParametro("@codigo", articulo.Codigo);
                datosTablaArticulos.setearParametro("@nombre", articulo.Nombre);
                datosTablaArticulos.setearParametro("@descripcion", articulo.Descripcion);
                datosTablaArticulos.setearParametro("@idmarca", articulo.Marca.Id);
                datosTablaArticulos.setearParametro("@idcategoria", articulo.Categoria.Id);
                datosTablaArticulos.setearParametro("@precio", articulo.Precio);
                datosTablaArticulos.ejecutarAccion();
                datosTablaArticulos.cerrarConexion();

                AccesoBD datosTablaImagenes = new AccesoBD();
                datosTablaImagenes.setearConsulta("UPDATE IMAGENES SET ImagenUrl = @imagenurl WHERE IdArticulo = @idarticulo");
                datosTablaImagenes.setearParametro("@imagenurl", articulo.Imagen);
                datosTablaImagenes.setearParametro("@idarticulo", articulo.Id);
                datosTablaImagenes.ejecutarAccion();
                datosTablaImagenes.cerrarConexion();
            }
            catch (Exception)
            {
                throw;
            }
        }


    }

}
