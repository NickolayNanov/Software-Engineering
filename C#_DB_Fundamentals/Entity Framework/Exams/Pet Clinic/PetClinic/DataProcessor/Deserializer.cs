namespace PetClinic.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using AutoMapper;
    using Newtonsoft.Json;
    using PetClinic.Data;
    using PetClinic.DataProcessor.Dtos.Imports;
    using PetClinic.Models;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string FailureMessage = "Error: Invalid data.";
        private const string SuccessMessage = "Record {0} successfully imported.";
        private const string SuccessAnimalImportMessage = "Record {0} Passport №: {1} successfully imported.";
        private const string SuccessVetAdd = "Record {0} successfully imported.";

        public static string ImportAnimalAids(PetClinicContext context, string jsonString)
        {
            Models.AnimalAid[] animalAids = JsonConvert.DeserializeObject<Models.AnimalAid[]>(jsonString);

            StringBuilder sb = new StringBuilder();

            List<Models.AnimalAid> animalAidss = new List<Models.AnimalAid>();
            foreach (Models.AnimalAid ai in animalAids)
            {
                bool contains = animalAidss.Any(x => x.Name == ai.Name);

                if (!IsValid(ai) || contains)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                animalAidss.Add(ai);
                sb.AppendLine(String.Format(SuccessMessage, ai.Name));
            }

            context.AnimalAids.AddRange(animalAidss);
            context.SaveChanges();

            string result = sb.ToString();
            return result;
        }

        public static string ImportAnimals(PetClinicContext context, string jsonString)
        {
            AnimalDto[] dtos = JsonConvert.DeserializeObject<AnimalDto[]>(jsonString);
            StringBuilder stringBuilder = new StringBuilder();

            IList<Animal> existingAnimals = new List<Animal>();
            foreach (var dto in dtos)
            {
                Animal currentAnimal = Mapper.Map<Animal>(dto);

                bool validAnimal = IsValid(currentAnimal);
                bool validPassport = IsValid(currentAnimal.Passport);

                bool existsSerialNumber = existingAnimals.Any(x => x.Passport.SerialNumber == currentAnimal.Passport.SerialNumber);

                if(!validAnimal || !validPassport || existsSerialNumber)
                {
                    stringBuilder.AppendLine(FailureMessage);
                    continue;
                }

                existingAnimals.Add(currentAnimal);
                stringBuilder.AppendLine(String.Format(SuccessMessage, $"{currentAnimal.Name} Passport №: {currentAnimal.Passport.SerialNumber}"));
            }

            context.Animals.AddRange(existingAnimals);
            context.SaveChanges();

            string result = stringBuilder.ToString();
            return result;
        }

        public static string ImportVets(PetClinicContext context, string xmlString)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(VetDto[]), new XmlRootAttribute("Vets"));
            VetDto[] purchasesDto = (VetDto[])serializer.Deserialize(new StringReader(xmlString));

            StringBuilder sb = new StringBuilder();
            IList<Vet> allVets = new List<Vet>();

            foreach (VetDto dto in purchasesDto)
            {
                Vet currentVet = Mapper.Map<Vet>(dto);

                bool isValidVet = IsValid(currentVet);
                bool phoneNumberExist = allVets.Any(v => v.PhoneNumber == currentVet.PhoneNumber);

                if(!isValidVet || phoneNumberExist)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                allVets.Add(currentVet);
                sb.AppendLine(string.Format(SuccessVetAdd, currentVet.Name));
            }

            context.Vets.AddRange(allVets);
            context.SaveChanges();

            string result = sb.ToString();
            return result;
        }

        public static string ImportProcedures(PetClinicContext context, string xmlString)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ProcedureDto[]), new XmlRootAttribute("Procedures"));
            ProcedureDto[] procedureDtos = (ProcedureDto[])serializer.Deserialize(new StringReader(xmlString));

            StringBuilder sb = new StringBuilder();
            IList<Procedure> procedures = new List<Procedure>();

            foreach (ProcedureDto dto in procedureDtos)
            {
                Animal animal = context.Animals.FirstOrDefault(a => a.PassportSerialNumber == dto.Animal);
                Vet vet = context.Vets.FirstOrDefault(v => v.Name == dto.VetName);
                bool dateTime = DateTime.TryParse(dto.DateTime, out DateTime trueDatetime);

                if (animal == null || vet == null)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                List<int> aidIds = new List<int>();
                bool allExists = true;

                foreach (var item in dto.AnimalAids)
                {
                    Models.AnimalAid aid = context.AnimalAids.FirstOrDefault(x => x.Name == item.Name);
                    int? aidId = context.AnimalAids.SingleOrDefault(a => a.Name == item.Name)?.Id;

                    if(aid == null || aidIds.Any(x => x == aid.Id))
                    {
                        allExists = false;
                        break;
                    }

                    aidIds.Add(aidId.Value);
                }

                if (!allExists)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                Procedure currentProcedure = new Procedure
                {
                    Vet = vet,
                    Animal = animal,
                    DateTime = trueDatetime
                };

                foreach (int id in aidIds)
                {
                    currentProcedure.ProcedureAnimalAids.Add(new ProcedureAnimalAid()
                    {
                        Procedure = currentProcedure,
                        AnimalAidId = id
                    });
                }
                bool isValid = IsValid(currentProcedure);


                if (!isValid)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                procedures.Add(currentProcedure);
                sb.AppendLine("Record successfully imported.");
            }

            context.Procedures.AddRange(procedures);
            context.SaveChanges();
            
            string result = sb.ToString();
            return result;
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);

            return isValid;
        }
    }
}
