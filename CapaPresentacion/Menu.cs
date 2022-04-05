using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaNegocios;

namespace CapaPresentacion
{
    public class Menu : Crud
    {
        public void iniciar()
        {
            crearAdmin();
            cabecera();
        }
        string opcion_menu = "";
        string opcion_menu_admin = "";
        string opcion_menu_user = "";
        public void cabecera()
        {
            Console.Clear();
            Console.WriteLine("       ******  BIENVENIDO  ******");
            Console.WriteLine("\nESCOJA UNA OPCIÓN\n");
            Console.WriteLine("1. Administrador");
            Console.WriteLine("2. Usuarios");
            Console.WriteLine("3. Salir\n");
            opcion_menu = Console.ReadLine();
            seleccion_menu(opcion_menu);
        }

        private void seleccion_menu(string opc)
        {
            if (opc == "")
                cabecera();
            switch (opc)
            {
                case "1":
                    Console.Clear();
                    menu_admin();
                    Console.ReadLine();
                    break;
                case "2":
                    Console.Clear();
                    menu_user();
                    Console.ReadKey();
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("Saliendo del programa...");
                    Console.ReadKey();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Selección no válida\n");
                    Console.WriteLine("Presione Enter para regresar al menú principal");
                    Console.ReadKey();
                    cabecera();
                    break;
            }
        }

        //public void iniciar()
        //{
        //    crearAdmin();
        //    login();
        //}
        //public void login()
        //{
        //    Console.Clear();

        //    if (verificarLogin() == 1)
        //    {
        //        menu_admin();
        //    }
        //    else
        //    {
        //        menu_user();

        //    }
        //}

        /////////////////////////// MENU ADMIN ///////////////////////////////
        
        string opc_menu_admin;
        public void menu_admin()
        {
            Console.Clear();
            Console.WriteLine("       ******  BIENVENIDO ADMINISTRADOR ******");
            Console.WriteLine("\n¿QUÉ DESEA HACER?");
            Console.WriteLine("\n1. Crear Usuarios");
            Console.WriteLine("2. Listar Usuarios");
            Console.WriteLine("3. Listar Blogs");
            Console.WriteLine("4. Listar Posts");
            Console.WriteLine("5. Listar Tags");
            Console.WriteLine("6. Volver");
            Console.WriteLine("7. Cerrar sesión\n");
            opc_menu_admin = Console.ReadLine();
            selecc_menu_admin(opc_menu_admin);
        }

        public void selecc_menu_admin(string opc)
        {
            if (opc == "")
                menu_admin();
            switch (opc)
            {
                case "1":
                    Console.Clear();
                    crearUsers();
                    menu_admin();
                    break;
                case "2":
                    Console.Clear();
                    //listaUsers(); 
                    listaSinAdmin(1);
                    Console.ReadKey();
                    menu_admin();
                    break;
                case "3":
                    Console.Clear();
                    listaBlogs();
                    menu_admin();
                    break;
                case "4":
                    Console.Clear();
                    listarPosts();
                    menu_admin();
                    break;
                case "5":
                    Console.Clear();
                    listarTags();
                    menu_admin();
                    break;
                case "6":
                    Console.Clear();
                    cabecera();
                    break;
                case "7":
                    Console.Clear();
                    Environment.Exit(0);
                    menu_admin();
                    break;     
            }
        }

        /////////////////////////// MENU USER ///////////////////////////////
        
        string opc_menu_user;
        public void menu_user()
        {
            Console.Clear();
            Console.WriteLine("       ******  BIENVENIDO USUARIO  ******");
            Console.WriteLine("\n¿QUÉ DESEA HACER?");
            Console.WriteLine("\n1. Crear Blogs");
            Console.WriteLine("2. Modificar Blogs");
            Console.WriteLine("3. Crear Posts");
            Console.WriteLine("4. Modificar Posts");
            Console.WriteLine("5. Eliminar Posts");
            Console.WriteLine("6. Volver");
            opc_menu_user = Console.ReadLine();
            selecc_menu_user(opc_menu_user);
        }

        public void selecc_menu_user(string opc)
        {
            if (opc == "")
                menu_admin();
            switch (opc)
            {
                case "1":
                    Console.Clear();
                    crearBlog();
                    menu_user();
                    break;
                case "2":
                    Console.Clear();
                    modificarBlogs();
                    menu_user();
                    break;
                case "3":
                    Console.Clear();
                    crearPosts();
                    menu_user();
                    break;
                case "4":
                    Console.Clear();
                    modificarPosts();
                    menu_user();
                    break;
                case "5":
                    Console.Clear();
                    eliminarPosts();
                    menu_user();
                    break;
                case "6":
                    Console.Clear();
                    cabecera();
                    break;

            }
        }

    }
}
