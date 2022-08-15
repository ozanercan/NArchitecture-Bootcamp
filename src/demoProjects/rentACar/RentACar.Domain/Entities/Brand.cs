using Core.Persistence.Repositories;

namespace RentACar.Domain.Entities;
public class Brand : Entity
{
    public Brand(int id, string name) : base(id)
    {
        Name = name;
    }
    public Brand()
    {
    }

    public string Name { get; set; }
}
