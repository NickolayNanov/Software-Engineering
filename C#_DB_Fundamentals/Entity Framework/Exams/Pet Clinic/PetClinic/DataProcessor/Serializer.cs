namespace PetClinic.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Xml;
    using System.Xml.Serialization;
    using AutoMapper.QueryableExtensions;
    using Newtonsoft.Json;
    using PetClinic.Data;
    using PetClinic.DataProcessor.Dtos.Exports;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportAnimalsByOwnerPhoneNumber(PetClinicContext context, string phoneNumber)
        {
            //Export all animals by their owner's number sorted by age ascending, then by serial number alphabetically.
            //Export dates in the format "dd-MM-yyyy", using CultureInfo.InvariantCulture!


            var animals = context
                                .Animals
                                .Where(x => x.Passport.OwnerPhoneNumber == phoneNumber)
                                .Select(x => new
                                {
                                    OwnerName = x.Passport.OwnerName,
                                    AnimalName = x.Name,
                                    x.Age,
                                    SerialNumber = x.PassportSerialNumber,
                                    RegisteredOn = x.Passport.RegistrationDate.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture)
                                })
                                .OrderBy(x => x.Age)
                                .ThenBy(x => x.SerialNumber)
                                .ToArray();

            string json = JsonConvert.SerializeObject(animals, Formatting.Indented);
            return json;
        }

        public static string ExportAllProcedures(PetClinicContext context)
        {
            var procedures = context
                                .Procedures
                                .OrderBy(x => x.Animal.Passport.RegistrationDate)
                                .ThenBy(x => x.Animal.Passport.SerialNumber)
                                .ProjectTo<ExportProcedureDto>()
                                .ToArray();

            string xml = SerializeObject(procedures, "Procedures");
            return xml;
        }

        public static string SerializeObject<T>(T values, string rootName, bool omitXmlDeclaration = false,
        bool indentXml = true)
        {
            string xml = string.Empty;

            var serializer = new XmlSerializer(typeof(T), new XmlRootAttribute(rootName));

            var settings = new XmlWriterSettings()
            {
                Indent = indentXml,
                OmitXmlDeclaration = omitXmlDeclaration
            };

            XmlSerializerNamespaces @namespace = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            using (var stream = new StringWriter())
            using (var writer = XmlWriter.Create(stream, settings))
            {
                serializer.Serialize(writer, values, @namespace);
                xml = stream.ToString();
            }

            return xml;
        }
    }
}
