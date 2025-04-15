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
                    "A.Descripcion," +
                    " A.IdMarca, " +
                    "A.IdCategoria, " +
                    "A.Precio, " +
                    "I.ImagenUrl " +
                    "FROM  " +
                    "Articulos A " +
                    "LEFT JOIN " +
                    "IMAGENES I ON A.Id = I.IdArticulo");

                datos.ejecutarLectura();

                while (datos.Lectorbd.Read())
                {
                    Articulo aux = new Articulo();

                    aux.Id = (int)datos.Lectorbd["Id"];
                    aux.Codigo = (string)datos.Lectorbd["Codigo"];
                    aux.Nombre = (string)datos.Lectorbd["Nombre"];
                    aux.Descripcion = (string)datos.Lectorbd["Descripcion"];
                    aux.IdMarca = (int)datos.Lectorbd["IdMarca"];
                    aux.IdCategoria = (int)datos.Lectorbd["IdCategoria"];
                    aux.Precio = (decimal)datos.Lectorbd["Precio"];
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
    }

}
