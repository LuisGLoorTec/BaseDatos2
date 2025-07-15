using BaseDatos.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDatos.BaseDatos
{
    public static class BaseDeDatos
    {
        public static List<Cliente> BaseDatosCliente = new List<Cliente>();

        public static void ImprimirClientes()
        {
            foreach (Cliente cliente in BaseDatosCliente)
            {
                cliente.imprimir();
            }
        }


        public static Cliente BuscarClientePorCedula(string parametro_cedula)
        {
            return BaseDatosCliente.FirstOrDefault(bdc => bdc.cedula == parametro_cedula);
        }



    }
}
