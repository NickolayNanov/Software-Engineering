namespace PetClinic.App
{
    using AutoMapper;
    using PetClinic.DataProcessor.Dtos.Exports;
    using PetClinic.DataProcessor.Dtos.Imports;
    using PetClinic.Models;
    using System;
    using System.Globalization;
    using System.Linq;

    public class PetClinicProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
        public PetClinicProfile()
        {
            this.CreateMap<AnimalDto, Animal>();

            this.CreateMap<PassportDto, Passport>()
                .ForMember(x => x.RegistrationDate, z => z.MapFrom(y => DateTime.ParseExact(y.RegistrationDate, "dd-MM-yyyy", CultureInfo.InvariantCulture)));

            this.CreateMap<VetDto, Vet>();

            this.CreateMap<ProcedureDto, Procedure>();

            this.CreateMap<Procedure, ExportProcedureDto>()
                .ForMember(x => x.PassportSerialNumber, y => y.MapFrom(z => z.Animal.Passport.SerialNumber))
                .ForMember(x => x.OwnerPhoneNumber, y => y.MapFrom(z => z.Animal.Passport.OwnerPhoneNumber))
                .ForMember(x => x.DateTime, y => y.MapFrom(z => z.Animal.Passport.RegistrationDate.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture)))
                .ForMember(x => x.TotalPrice, y => y.MapFrom(z => z.Vet.Procedures.Sum(p => p.Cost)));
        }
    }
}
