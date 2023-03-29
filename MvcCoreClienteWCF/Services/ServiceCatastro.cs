﻿using MvcCoreClienteWCF.Models;
using ReferenceCatastro;
using System.Xml;
using System.Xml.Linq;

namespace MvcCoreClienteWCF.Services
{
    public class ServiceCatastro
    {
        CallejerodelasedeelectrónicadelcatastroSoapClient client;

        public ServiceCatastro(CallejerodelasedeelectrónicadelcatastroSoapClient client)
        {
            this.client = client;
        }

        public async Task<List<Provincia>> GetProvinciasAsync()
        {
            ConsultaProvincia1 response = await
                this.client.ObtenerProvinciasAsync();
            XmlNode nodo = response.Provincias;
            //NECESITO EXTRAER "ALGO" DE ESTE NODO XML
            string dataXml = nodo.OuterXml;
            //UTILIZAMOS LINQ TO XML PARA EXTRAER LOS DATOS
            XDocument document = XDocument.Parse(dataXml);
            List<Provincia> provinciasList = new List<Provincia>();
            var consulta = from datos in document.Descendants("prov")
                           select datos;
            foreach (XElement tag in consulta)
            {
                string cp = tag.Element("cpine").Value;
                string nombre = tag.Element("np").Value;
                Provincia p = new Provincia
                {
                    IdProvincia = int.Parse(cp),
                    Nombre = nombre
                };
                provinciasList.Add(p);
            }
            return provinciasList;
        }
    }
}
