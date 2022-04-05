using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocios
{
    public class Crud 
    {
        List<Users> datasetUsers = new List<Users>();
        List<Blogs> datasetBlogs = new List<Blogs>();
        List<Posts> datasetPosts = new List<Posts>();
        List<Tags> datasetTags = new List<Tags>();
        List<PostTag> datasetPostTags = new List<PostTag>();
        string usuario, nombreBlog, postContent, title, name;
        int codigo, blogID, codigoUsuario, postID, blogblogID, tagID, post_postID, tags_tagID;
        DateTime createdDate;
        DateTime? modifiedDate;

        //////////////////////// LOGIN ////////////////////////
        //string userIngresado;
        //int codigoIngresado;

        //public int verificarLogin()
        //{
        //    Console.WriteLine("       ******  BIENVENIDO  ******");
        //    Console.WriteLine("----------------------------------------\n");
        //    Console.WriteLine("POR FAVOR INICIE SESIÓN\n");
        //    Console.WriteLine("Usuario: ");
        //    userIngresado = Console.ReadLine();
        //    Console.WriteLine("Codigo: ");
        //    codigoIngresado = Convert.ToInt32(Console.ReadLine());

        //    var existe = false;
        //    foreach (var item in datasetUsers)
        //    {
        //        if (userIngresado == item.usuario && codigoIngresado == item.codigo)
        //        {
        //            Console.WriteLine("Bienvenido " + item.usuario);
        //            existe = true;
        //            Console.ReadKey();
        //            break;
        //        }

        //    }
        //    if (existe == false)
        //    {
        //        Console.WriteLine("Quien monda eres?");
        //        Console.ReadKey();
        //        Console.Clear();
        //        verificarLogin();
        //    }

        //    return codigoIngresado;
        //}
        //public int usuarioActual(int userActual)
        //{
        //    return userActual;
        //}

        //////////////////////// ADMIN ////////////////////////
        public void crearAdmin()
        {
            string userAdmin = "admin";
            int codigoAdmin = 1;
            datasetUsers.Add(new Users(userAdmin, codigoAdmin));
        }

        //////////////////////// USERS ////////////////////////
        int contadorUserID = 2;
        public void crearUsers()
        {
            Console.WriteLine("Usuario: ");
            usuario = Console.ReadLine();
            codigo = contadorUserID;
            
            if (usuario.ToLower() != "admin")
            {
                contadorUserID++;
                datasetUsers.Add(new Users(usuario, codigo));
                Console.WriteLine("\nUsuario guardado con codigo " + codigo);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\nNo se permite crear un usuario con ese nombre, ingrese otro usuario");
                Console.ReadKey();
                Console.Clear();
                crearUsers();
            }
        }

        //////////////////////// LISTAS ////////////////////////
        private bool listaVaciaUsers()
        {
            if (datasetUsers.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public void listaSinAdmin(int IDAdmin)
        {
            Console.WriteLine("Total de registros de usuarios en la lista: " + datasetUsers.Count);
            Console.WriteLine("\n------------------------LISTA DE USUARIOS------------------------");

            foreach (var item in datasetUsers)
            {
                if (item.codigo != IDAdmin)
                {
                    Console.WriteLine("Usuario: {0} | Codigo: {1}", item.usuario, item.codigo);
                }
            }
        }

        //////////////////////// BLOGS ////////////////////////

        int contadorBlogID = 1;

        public void crearBlog()
        {
            listaSinAdmin(1);
            Console.WriteLine("\nNombre del blog: ");
            nombreBlog = Console.ReadLine();
            Console.WriteLine("\nCodigo del usuario: ");
            codigoUsuario = Convert.ToInt32(Console.ReadLine());

            bool existe = false;
            foreach (var item in datasetUsers)
            {
                if (codigoUsuario == item.codigo && codigoUsuario != 1)
                {
                    blogID = contadorBlogID;
                    contadorBlogID++;
                    datasetBlogs.Add(new Blogs(blogID, nombreBlog, codigoUsuario));
                    Console.WriteLine("\nBlog guardado con ID " + blogID);
                    existe = true;
                    Console.ReadKey();
                    break;
                }
            }
            if (existe == false)
            {
                Console.Clear();
                Console.WriteLine("Código de usuario para el Blog no existe o no es válido, " +
                    "vuelva a intentarlo\n");
                crearBlog();
            }
        }
        //public void crearBlog(int codUser)
        //{
        //    Console.WriteLine("\nNombre del blog: ");
        //    nombreBlog = Console.ReadLine();

        //    bool existe = false;
        //    foreach (var item in datasetUsers)
        //    {
        //        if (codUser == item.codigo && codUser != 1)
        //        {
        //            blogID = contadorBlogID;
        //            contadorBlogID++;
        //            datasetBlogs.Add(new Blogs(blogID, nombreBlog, codUser));
        //            Console.WriteLine("\nBlog guardado con ID " + blogID);
        //            existe = true;
        //            Console.ReadKey();
        //            break;
        //        }
        //    }
        //    if (existe == false)
        //    {
        //        Console.Clear();
        //        Console.WriteLine("Código de usuario para el Blog no existe o no es válido, " +
        //            "vuelva a intentarlo\n");
        //        Console.ReadKey();
        //        //crearBlog();
        //    }
        //}

        private bool listaVaciaBlog()
        {
            if (datasetBlogs.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void listaBlogs()
        {
            if (listaVaciaBlog() == true)
            {
                Console.WriteLine("No se encuentra ningun blog en la lista");
            }
            else
            {
                Console.WriteLine("------------------------LISTA DE BLOGS------------------------");
                foreach (Blogs item in datasetBlogs)
                {
                    Console.WriteLine("BlogID: {0} | Nombre del blog: {1} | Codigo Usuario: {2}",
                        item.blogID, item.nombreBlog, item.codigoUsuario);
                }
                Console.WriteLine("\n¿Desea listar Blogs respecto a un usuario? S/N");
                string respuesta = Console.ReadLine();
                if (respuesta.ToLower() == "s")
                {
                    listaBlogsxUsers();
                }
            }
            Console.ReadKey();
        }

        int codUser;
        public void listaBlogsxUsers()
        {
            listaSinAdmin(1);
            Console.WriteLine("\nEscriba el codigo del usuario: ");
            string cod = Console.ReadLine();
            int n;
            bool result = Int32.TryParse(cod, out n);
            if (result)
            {
                codUser = Convert.ToInt32(cod);
            }
            else
            {
                Console.WriteLine("Escriba un codigo correcto");
                Console.ReadKey();
                Console.Clear();
                listaBlogsxUsers();
            }

            if (listaVaciaBlog() == true)
            {
                Console.WriteLine("No se encuentra ningun blog en la lista");
                Console.ReadKey();
            }
            else
            {
                //var aux = false;
                Console.WriteLine("\n------------------------LISTA DE BLOGS DEL USUARIO ------------------------");
                foreach (Blogs item in datasetBlogs)
                {
                    
                    if (item.codigoUsuario == codUser)
                    {
                        Console.WriteLine("BlogID: {0} | Nombre del blog: {1} | Codigo Usuario: {2}",
                        item.blogID, item.nombreBlog, item.codigoUsuario);
                        //Console.ReadKey();
                        //break;
                        // REALIZAR  LA VALIDACION SI NO HAY NINGUN  USUARIO CON EL ID INGRESADO
                    }
                    /*else
                    {
                        
                        Console.WriteLine("\nNo se encuentra un usuario con ese ID en la lista");
                        Console.ReadKey();
                        Console.Clear();
                        listaBlogsxUsers();
                        break;
                    }*/
                }
                Console.ReadKey();
            }
        }

        public void modificarBlogs()
        {
            if (listaVaciaBlog() == true)
            {
                Console.WriteLine("No se encuentra ningún Blog");
                Console.ReadKey();
            }
            else
            {
                Blogs b = new Blogs();
                int idBlogBuscar;
                listaBlogsxUsers();
                Console.WriteLine("\nIngrese el ID del Blog que quiere modificar");
                idBlogBuscar = Convert.ToInt32(Console.ReadLine());

                foreach (Blogs item in datasetBlogs)
                {
                    if (idBlogBuscar == item.blogID)
                    {
                        Console.WriteLine("\nNuevo nombre del Blog: ");
                        b.nombreBlog = Console.ReadLine();
                        item.nombreBlog = b.nombreBlog;
                        Console.WriteLine("\nEl nombre del Blog ha sido modificado");
                        Console.ReadKey();
                    }
                }
            }
        }

        //////////////////////// POSTS ////////////////////////
        
        int contadorPostID = 1;
        public void crearPosts()
        {
            if (listaVaciaBlog() == true)
            {
                Console.WriteLine("Debe crear un Blog primero");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("------------------------LISTA DE BLOGS DISPONIBLES------------------------");
                foreach (Blogs item in datasetBlogs)
                {
                    Console.WriteLine("BlogID: {0} | Nombre del blog: {1} | Codigo Usuario: {2}\n",
                        item.blogID, item.nombreBlog, item.codigoUsuario);
                }
                createdDate = DateTime.Now;
                modifiedDate = null;
                Console.WriteLine("Contenido del Post: ");
                postContent = Console.ReadLine();
                Console.WriteLine("Título: ");
                title = Console.ReadLine();
                Console.WriteLine("ID del BLog: ");
                blogblogID = Convert.ToInt32(Console.ReadLine());

                bool existe = false;
                foreach (Blogs item in datasetBlogs)
                {
                    if (blogblogID == item.blogID)
                    {
                        postID = contadorPostID;
                        contadorPostID++;
                        datasetPosts.Add(new Posts(postID, createdDate, modifiedDate, postContent, title, blogblogID));
                        Console.WriteLine("\nPost creado con ID " + postID);
                        existe = true;

                        Console.WriteLine("\n¿Desea crear un Tag para este Post? S/N");
                        string respuesta = Console.ReadLine();
                        if (respuesta.ToLower() == "s")
                        {
                            crearTags(postID);
                        }
                        break;
                    }
                }
                if (existe == false)
                {
                    Console.Clear();
                    Console.WriteLine("Código del Blog para el Post no existe o no es válido, " +
                        "vuelva a intentarlo\n");
                    crearPosts();
                }
            }
        }

        public bool listaVaciaPosts()
        {
            if (datasetPosts.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public void listarPosts()
        {
            if (listaVaciaPosts() == true)
            {
                Console.WriteLine("No se encuentra ningun Post en la lista");
            }
            else
            {
                Console.WriteLine("------------------------LISTA DE POSTS------------------------");
                foreach (Posts item in datasetPosts)
                {
                    Console.WriteLine("PostID: {0}\nFecha de creación: {1}\nFecha de  modificación: {2}\nContenido del Post: {3}\n"+
                        "Título: {4}\nID del Blog: {5}\n", item.PostID, item.CreatedDate, item.ModifiedDate,
                        item.PostContent, item.Title, item.BlogBlogID);
                }
                Console.WriteLine("\n¿Desea listar Posts respecto a un usuario? S/N");
                string respuesta = Console.ReadLine();
                if (respuesta.ToLower() == "s")
                {
                    listaPostsxUsers();
                }
            }
            Console.ReadKey();
        }

        public void listaPostsxUsers()
        {
            listaSinAdmin(1);
            Console.WriteLine("\nEscriba el codigo del usuario: ");
            string cod = Console.ReadLine();
            int n;
            bool result = Int32.TryParse(cod, out n);
            if (result)
            {
                codUser = Convert.ToInt32(cod);
            }
            else
            {
                Console.WriteLine("Escriba un codigo correcto");
                Console.ReadKey();
                Console.Clear();
                listaPostsxUsers();
            }

            if (listaVaciaPosts() == true)
            {
                Console.WriteLine("No se encuentra ningun Post en la lista");
                Console.ReadKey();
            }
            else
            {

                foreach (Blogs item in datasetBlogs)
                {
                    if (codUser == item.codigoUsuario)
                    {
                        Console.WriteLine("\n------------------------LISTA DE POSTS DEL USUARIO------------------------");
                        foreach (Posts item2 in datasetPosts)
                        {
                            if (item2.BlogBlogID == item.blogID)
                            {
                                Console.WriteLine("PostID: {0}\nFecha de creación: {1}\nFecha de  modificación: {2}\nContenido del Post: {3}\n" +
                                "Título: {4}\nID del Blog: {5}\n", item2.PostID, item2.CreatedDate, item2.ModifiedDate,
                                item2.PostContent, item2.Title, item2.BlogBlogID);
                            }
                        }
                        // REALIZAR  LA VALIDACION SI NO HAY NINGUN  USUARIO CON EL ID INGRESADO
                    }
                    /*else
                    {
                        Console.WriteLine("\nNo se encuentra un usuario con ese ID en la lista");
                        Console.ReadKey();
                        Console.Clear();
                        listaBlogsxUsers();
                        break;
                    }*/
                }
            }
            Console.ReadKey();
        }

        public void modificarPosts()
        {
            if (listaVaciaPosts() == true)
            {
                Console.WriteLine("No se encuentra ningún Post");
                Console.ReadKey();
            }
            else
            {
                Posts p = new Posts();
                int idPostBuscar;
                listaPostsxUsers();
                Console.WriteLine("\nIngrese el ID del Post que quiere modificar");
                idPostBuscar = Convert.ToInt32(Console.ReadLine());

                foreach (Posts item in datasetPosts)
                {

                    if (idPostBuscar == item.PostID)
                    {
                        Console.WriteLine("\nNuevo contenido del Post: ");
                        p.PostContent = Console.ReadLine();
                        item.PostContent = p.PostContent;
                        Console.WriteLine("Nuevo titulo del Post: ");
                        p.Title = Console.ReadLine();
                        item.Title = p.Title;
                        item.ModifiedDate = DateTime.Now;
                        Console.WriteLine("\nEl Post ha sido modificado");
                        Console.ReadKey();
                    }
                }
            }
        }

        public void eliminarPosts()
        {
            if (listaVaciaPosts() == true)
            {
                Console.WriteLine("No hay Posts en la lista");
                Console.ReadKey();
            }
            else
            {
                listarPosts();
                Console.WriteLine("Ingrese el ID del Post a eliminar: ");
                int idPostEliminar = Convert.ToInt32(Console.ReadLine());
                var existe = false;

                foreach (Posts item in datasetPosts)
                {
                    if (item.PostID == idPostEliminar)
                    {
                        datasetPosts.Remove(item);
                        Console.WriteLine("\nEl Post ha sido eliminado");
                        existe = true;
                        Console.ReadKey();
                        break;
                    }
                }
                if (existe == false)
                {
                    Console.WriteLine("No hay un Post con ese ID");
                }
            }
        }

        //////////////////////// TAGS ////////////////////////

        int contadorTagID = 1;
        public void crearTags(int postID)
        {
            Console.WriteLine("\nNombre del Tag: ");
            name = Console.ReadLine();
            tagID = contadorTagID;
            contadorTagID++;

            datasetTags.Add(new Tags(tagID, name));
            datasetPostTags.Add(new PostTag(postID, tagID));
            //datasetPostTags.Add(new PostTag())

            Console.WriteLine("\nTag '" + name+"' creado con ID "+tagID);
            Console.ReadKey();
        }
        /*public void crearPostTags(int postID)
        {
            datasetPostTags.Add(new PostTag(postID, tagID));
        }*/
        public bool listaVaciaTags()
        {
            if (datasetTags.Count  == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void listarTags()
        {
            if (listaVaciaTags() == true)
            {
                Console.WriteLine("No se encuentra ningun Tag en la lista");
            }
            else
            {
                Console.WriteLine("------------------------LISTA DE TAGS------------------------");
                foreach (Tags item in datasetTags)
                {
                    Console.WriteLine("TagID: {0}\nNombre del Tag: {1}", item.TagID, item.Name);
                }
                Console.WriteLine("\n¿Desea listar Tags respecto a un usuario? S/N");
                string respuesta = Console.ReadLine();
                if (respuesta.ToLower() == "s")
                {
                    listarTagsxUsers();
                }
            }
            Console.ReadKey();
        }
        /*public void listarPostTags()
        {
            Console.WriteLine("------------------------LISTA DE POSTS_TAGS------------------------");
            foreach (PostTag item in datasetPostTags)
            {
                Console.WriteLine("Posts_PostID: {0}\nTags_TagID: {1}", item.Post_PostID, item.Tags_TagID);
            }
            Console.ReadKey();
        }*/

        public void listarTagsxUsers()
        {
            listaSinAdmin(1);
            Console.WriteLine("\nEscriba el codigo del usuario: ");
            string cod = Console.ReadLine();
            int n;
            bool result = Int32.TryParse(cod, out n);
            if (result)
            {
                codUser = Convert.ToInt32(cod);
            }
            else
            {
                Console.WriteLine("Escriba un codigo correcto");
                Console.ReadKey();
                Console.Clear();
                listarTagsxUsers();
            }

            if (listaVaciaTags() == true)
            {
                Console.WriteLine("No se encuentra ningun Tag en la lista");
                Console.ReadKey();
            }
            else
            {

                foreach (Blogs item in datasetBlogs)
                {
                    if (item.codigoUsuario == codUser)
                    {
                        //Console.WriteLine("\n------------------------LISTA DE POSTS DEL USUARIO------------------------");
                        foreach (Posts item2 in datasetPosts)
                        {
                            if (item2.BlogBlogID == item.blogID)
                            {
                                foreach (PostTag item3 in datasetPostTags)
                                {
                                    if (item3.Post_PostID == item2.PostID)
                                    {
                                        foreach (Tags item4 in datasetTags)
                                        {
                                            if (item4.TagID == item3.Tags_TagID)
                                            {
                                                Console.WriteLine("TagID: {0} | Nombre del Tag: {1}",
                                                    item4.TagID, item4.Name);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        // REALIZAR  LA VALIDACION SI NO HAY NINGUN  USUARIO CON EL ID INGRESADO
                    }
                    /*else
                    {
                        Console.WriteLine("\nNo se encuentra un usuario con ese ID en la lista");
                        Console.ReadKey();
                        Console.Clear();
                        listaBlogsxUsers();
                        break;
                    }*/
                }
            }
            Console.ReadKey();
        }

    }
}
