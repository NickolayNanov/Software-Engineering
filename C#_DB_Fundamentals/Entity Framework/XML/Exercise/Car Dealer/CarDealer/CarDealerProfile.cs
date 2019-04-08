using AutoMapper;
using CarDealer.Dtos.Export;
using CarDealer.Models;
using System.Linq;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<Car, CarsWithDistanceDto>();

            this.CreateMap<Car, BmwDto>();

            this.CreateMap<Supplier, LocalSuppliersDto>()
                .ForMember(dest => dest.Parts,
                            opt => opt.MapFrom(src => src.Parts.Count));

            this.CreateMap<Car, ListOfPartsDto>()
                .ForMember(dest => dest.Parts,
                            opt => opt.MapFrom(src => src.PartCars.Select(pc => pc.Part).OrderByDescending(p => p.Price)));


            CreateMap<Customer, CustomerTotalSale>()
                .ForMember(x => x.FullName, y => y.MapFrom(obj => obj.Name))
                .ForMember(x => x.BoughtCars, y => y.MapFrom(obj => obj.Sales.Count))
                .ForMember(x => x.SpentMoney,
                    y => y.MapFrom(obj => obj.Sales.Sum(z => z.Car.PartCars.Sum(w => w.Part.Price))));

            CreateMap<Sale, SalesWithDiscountDto>()
                 .ForMember(x => x.CustomerName, y => y.MapFrom(obj => obj.Customer.Name))
                 .ForMember(x => x.Car, y => y.MapFrom(obj => obj.Car))
                 .ForMember(x => x.Price, y => y.MapFrom(obj => obj.Car.PartCars.Sum(z => z.Part.Price)))
                 .ForMember(x => x.PriceWithDiscount,
                     y => y.MapFrom(
                         obj => $"{obj.Car.PartCars.Sum(z => z.Part.Price) - (obj.Car.PartCars.Sum(w => w.Part.Price) * (obj.Discount / 100))}".TrimEnd('0')));

            CreateMap<Car, CarDto>()
                .ForMember(x => x.Make, y => y.MapFrom(obj => obj.Make))
                .ForMember(x => x.Model, y => y.MapFrom(obj => obj.Model))
                .ForMember(x => x.TravelledDistance, y => y.MapFrom(obj => obj.TravelledDistance));
        }
    }
}
