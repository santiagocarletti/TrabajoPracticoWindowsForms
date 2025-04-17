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
                    "I.ImagenUrl " +
                    "FROM Articulos A " +
                    "LEFT JOIN Categorias C ON A.IdCategoria = C.Id " +
                    "LEFT JOIN Marcas M ON A.IdMarca = M.Id " +
                    "LEFT JOIN Imagenes I ON I.IdArticulo = A.Id " +
                    "ORDER BY A.Id, I.ImagenUrl");

                datos.ejecutarLectura();

                int IdUltimoarticulo = 0;

                while (datos.Lectorbd.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = Convert.ToInt32(datos.Lectorbd["Id"]);

                    if (aux.Id == IdUltimoarticulo)
                    {
                        lista[IdUltimoarticulo - 1].Imagen.Add(Convert.ToString(datos.Lectorbd["ImagenUrl"]));
                        continue;
                    }

                    aux.Codigo = Convert.ToString(datos.Lectorbd["Codigo"]);
                    aux.Nombre = Convert.ToString(datos.Lectorbd["Nombre"]);
                    aux.Descripcion = Convert.ToString(datos.Lectorbd["Descripcion"]);

                    aux.Marca = new Marca();

                    if (datos.Lectorbd["IdMarca"] != DBNull.Value)
                    {
                        aux.Marca.Id = Convert.ToInt32(datos.Lectorbd["IdMarca"]);
                        aux.Marca.Descripcion = Convert.ToString(datos.Lectorbd["Marca"]);
                    }
                    else
                    {
                        aux.Marca.Id = 0;
                        //aux.Marca.Descripcion = "Sin Descripcion";
                    }

                    aux.Categoria = new Categoria();


                    if (datos.Lectorbd["IdCategoria"] != DBNull.Value)
                    {
                        aux.Categoria.Id = Convert.ToInt32(datos.Lectorbd["IdCategoria"]);
                        aux.Categoria.Descripcion = Convert.ToString(datos.Lectorbd["Categoria"]);
                    }
                    else
                    {
                        aux.Categoria.Id = 0;
                        //aux.Categoria.Descripcion = "Sin Categoria";
                    }

                    aux.Precio = Decimal.Round(Convert.ToDecimal(datos.Lectorbd["Precio"]), 2);

                    aux.Imagen = new List<string>();
                    aux.Imagen.Add(Convert.ToString(datos.Lectorbd["ImagenUrl"]));
                    IdUltimoarticulo = aux.Id;


                    aux.Precio = Decimal.Round((decimal)datos.Lectorbd["Precio"], 2);
                    //aux.Imagen = (string)datos.Lectorbd["ImagenUrl"];

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

        public void agregar(Articulo newArticulo)
        {
            AccesoBD datos = new AccesoBD();
            try
            {
                datos.setearConsulta("INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, Precio, IdMarca, IdCategoria) " +
                                     "VALUES (@codigo, @nombre, @descripcion, @precio, @idMarca, @idCategoria)");

                datos.setearParametro("@codigo", newArticulo.Codigo);
                datos.setearParametro("@nombre", newArticulo.Nombre);
                datos.setearParametro("@descripcion", newArticulo.Descripcion);
                datos.setearParametro("@precio", newArticulo.Precio);
                datos.setearParametro("@idMarca", newArticulo.Marca.Id);
                datos.setearParametro("@idCategoria", newArticulo.Categoria.Id);

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
            AccesoBD datosTablaArticulos = new AccesoBD();

            try
            {
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
                datosTablaArticulos.limpiarParametros();

                datosTablaArticulos.setearConsulta("DELETE FROM IMAGENES WHERE IdArticulo = @idarticulo");
                datosTablaArticulos.setearParametro("@idarticulo", articulo.Id);
                datosTablaArticulos.ejecutarMasAcciones();
                datosTablaArticulos.limpiarParametros();

                foreach (string imagen in articulo.Imagen)
                {
                    if (imagen == "")
                    { continue; }

                    datosTablaArticulos.setearConsulta("INSERT INTO IMAGENES (IdArticulo, ImagenUrl) VALUES (@idarticulo, @imagenurl)");
                    datosTablaArticulos.setearParametro("@imagenurl", imagen);
                    datosTablaArticulos.setearParametro("@idarticulo", articulo.Id);
                    datosTablaArticulos.ejecutarMasAcciones();
                    datosTablaArticulos.limpiarParametros();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datosTablaArticulos.cerrarConexion();
            }
        }
    
    
        public void eliminar(int Id)
        {
            try
            {
                AccesoBD datos = new AccesoBD();
                datos.setearConsulta("delete from articulos where Id = @Id");
                datos.setearParametro("@Id", Id);
                datos.ejecutarAccion();
            }
            catch(Exception ex)
            {
                throw ex;

            }
        }
    
    
    
    }



}
