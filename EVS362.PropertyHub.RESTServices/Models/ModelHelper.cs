using EVS360;
using EVS360.PropertyHub;
using System.Collections.Generic;

namespace EVS362.PropertyHub.RESTServices.Models
{
    public static class ModelHelper { 
    
        public static Country ToEntity(this CountryModel model)
        {
            return new Country { Id = model.Id, Code = model.Code, Name = model.Name };
        }
        public static CountryModel ToModel(this Country entity)
        {
            return new CountryModel { Id = entity.Id, Code = entity.Code, Name = entity.Name };
        }

        public static Province ToEntity(this ProvinceModel model)
        {
            return new Province { Id = model.Id, Name = model.Name,  Country= model.Country?.ToEntity() };
        }

        public static ProvinceModel ToModel(this Province entity)
        {
            return new ProvinceModel { Id = entity.Id, Name = entity.Name, Country = entity.Country?.ToModel() };
        }


        public static CityModel ToModel(this City entity)
        {
            return new CityModel { Id = entity.Id, Name = entity.Name, Province = entity.Province?.ToModel() };
        }

        public static City ToEntity(this CityModel model)
        {
            return new City { Id = model.Id, Name = model.Name, Province = model.Province?.ToEntity() };
        }

        public static NeighborhoodModel ToModel(this Neighborhood entity)
        {
            return new NeighborhoodModel { Id = entity.Id, Name = entity.Name, City = entity.City?.ToModel() };
        }

        public static Neighborhood ToEntity(this NeighborhoodModel model)
        {
            return new Neighborhood { Id = model.Id, Name = model.Name, City = model.City?.ToEntity() };
        }

        public static List<NeighborhoodModel> ToModelList(this List<Neighborhood> entitiesList)
        {
            List<NeighborhoodModel> modelsList = new List<NeighborhoodModel>();
            foreach (var entity in entitiesList)
            {
                modelsList.Add(entity.ToModel());
            }
            modelsList.TrimExcess();
            return modelsList;
        }


        public static List<CountryModel> ToModelList(this List<Country> entitiesList)
        {
            List<CountryModel> modelsList = new List<CountryModel>();
            foreach (var entity in entitiesList)
            {
                modelsList.Add(entity.ToModel());
            }
            modelsList.TrimExcess();
            return modelsList;
        }
    }
}
