namespace ProductShop
{
    using AutoMapper;
    using ProductShop.Dtos.Export;
    using ProductShop.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<Product, ProductInRangeDTO>()
                .ForMember(dest => dest.Buyer,
                            opt => opt.MapFrom(src => $"{src.Buyer.FirstName} {src.Buyer.LastName}"));

            this.CreateMap<User, GetSoldProductsDto>()
                .ForMember(dest => dest.SoldProducts,
                            opt => opt.MapFrom(src => src.ProductsSold));

            this.CreateMap<Category, CategoriesByProductsDto>()
               .ForMember(x => x.Count, y => y.MapFrom(obj => obj.CategoryProducts.Count))
               .ForMember(x => x.TotalRevenue, y => y.MapFrom(obj => obj.CategoryProducts.Sum(z => z.Product.Price)))
               .ForMember(x => x.AveragePrice, y => y.MapFrom(obj => obj.CategoryProducts.Average(z => z.Product.Price)));


            //Task 8
            CreateMap<ICollection<UserDto>, UsersAndProductsDto>()
               .ForMember(x => x.Users, y => y.MapFrom(obj => obj.Take(10)))
               .ForMember(x => x.Count, y => y.MapFrom(obj => obj.Count));

            CreateMap<User, UserDto>()
                .ForMember(x => x.SoldProducts, y => y.MapFrom(obj => obj.ProductsSold));

            CreateMap<User, SoldProductsFacade>()
                .ForMember(x => x.Products, y => y.MapFrom(obj => obj.ProductsSold));

            CreateMap<ICollection<Product>, SoldProductsFacade>()
                .ForMember(x => x.Products, y => y.MapFrom(obj => obj.OrderByDescending(z => z.Price)))
                .ForMember(x => x.Count, y => y.MapFrom(obj => obj.Count));
        }
    }
}
