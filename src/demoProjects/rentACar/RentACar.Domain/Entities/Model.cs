﻿using Core.Persistence.Repositories;

namespace RentACar.Domain.Entities;
public class Model : Entity
{
    public int BrandId { get; set; }
    public string Name { get; set; }
    public decimal DailyPrice { get; set; }
    public string ImageUrl { get; set; }

    public virtual Brand? Brand { get; set; }

    public Model(int id, int brandId, string name, decimal dailyPrice, string imageUrl) : base(id)
    {
        Name = name;
        DailyPrice = dailyPrice;
        ImageUrl = imageUrl;
        BrandId = brandId;
    }
    public Model()
    {
    }
}
