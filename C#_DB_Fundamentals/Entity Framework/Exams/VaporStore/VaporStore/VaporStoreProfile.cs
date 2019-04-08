namespace VaporStore
{
	using AutoMapper;
    using System.Linq;
    using VaporStore.Data.Models;
    using VaporStore.DataProcessor.ExportDtos;
    using VaporStore.DataProcessor.ImputDtos;

    public class VaporStoreProfile : Profile
	{
		// Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
		public VaporStoreProfile()
		{
            this.CreateMap<User, ExportUserDto>()
                .ForMember(x => x.Username, y => y.MapFrom(z => z.Username))
                .ForMember(x => x.Purchases, y => y.MapFrom(z => z.Cards.Select(c => c.Purchases).ToArray()))
                .ForMember(x => x.TotalSpent, y => y.MapFrom(z => z.Cards.Select(c => c.Purchases.Select(p => p.Game.Price).Sum())));
        }
	}
}