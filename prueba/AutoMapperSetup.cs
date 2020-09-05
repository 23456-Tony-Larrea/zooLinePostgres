using AutoMapper;
using prueba.Models;
using System;
using System.Reflection;
using ZooLine.Models;

namespace ZooLine
{

    public class ValueConverter<Tsource, Tdestination, Tout> : IValueResolver<Tsource, Tdestination, Tout>
	{
		private Func<Tsource, Tdestination, Tout, ResolutionContext, Tout> _converAction;
		// fuente destinacion contexto y salida
		public ValueConverter(Func<Tsource, Tdestination, Tout, ResolutionContext, Tout> action)
		{
			_converAction = action;

		}
		public ValueConverter()
		{

		}
		public Tout Resolve(Tsource source, Tdestination destination, Tout destMember, ResolutionContext context)
		{
			return _converAction(source, destination, destMember, context);
		}
	}
	public static class AutmapperExtensions
	{
		public static IMappingExpression<TSource, TDestination> IgnoreAllNonExisting<TSource, TDestination>
	(this IMappingExpression<TSource, TDestination> expression)
		{
			var flags = BindingFlags.Public | BindingFlags.Instance;
			var sourceType = typeof(TSource);
			var destinationProperties = typeof(TDestination).GetProperties(flags);

			foreach (var property in destinationProperties)
			{
				if (sourceType.GetProperty(property.Name, flags) == null)
				{
					expression.ForMember(property.Name, opt => opt.Ignore());
				}
			}
			return expression;
		}
	}
	public class AutoMapperSetup:Profile
    {
		public AutoMapperSetup()
        {
																											             
			CreateMap<Animales, AnimalIndexDataModel>().ForMember(dest => dest.Especie, opt => opt.MapFrom(new ValueConverter<Animales, AnimalIndexDataModel, string>((fuente, destinacion, salida, contexto) => {

				return fuente.Especie.NombreEspecie;

			})))
				
				.ForMember(dest=> dest.ImagenArchivo, act => act.Ignore()).ReverseMap();

			CreateMap<Animales, AnimalModifyModel>().IgnoreAllNonExisting().ReverseMap() ;			
		}
    }
}
