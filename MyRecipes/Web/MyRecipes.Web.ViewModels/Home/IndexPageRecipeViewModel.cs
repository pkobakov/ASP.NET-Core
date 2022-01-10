﻿namespace MyRecipes.Web.ViewModels.Home
{
    using System;
    using System.Linq;
    using AutoMapper;

    using MyRecipes.Data.Models;
    using MyRecipes.Services.Mapping;

    public class IndexPageRecipeViewModel : IMapFrom<Recipe>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string Category { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Recipe, IndexPageRecipeViewModel>()
                .ForMember(x => x.ImageUrl, opt =>
                opt.MapFrom(x =>
                x.Images.FirstOrDefault().RemoteImageUrl != null
                ? x.Images.FirstOrDefault().RemoteImageUrl
                : "/images/recipes" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extension));
        }
    }
}
