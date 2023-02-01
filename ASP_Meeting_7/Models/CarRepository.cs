namespace ASP_Meeting_7.Models
{
    public class CarRepository : IRepository<Car>
    {
        List<Car> _cars;

        public CarRepository()
        {
            _cars = new List<Car>();
            _cars.Add(new Car { Id = 1, ModelName = "Jetta",
                Manufacturer = "Volkswagen", Price = 20000 });
            _cars.Add(new Car
            {
                Id = 2,
                ModelName = "X5",
                Manufacturer = "BMW",
                Price = 30000
            });

        }
        public Car Add(Car entity)
        {
            _cars.Add(entity);
            return entity;
        }

        public bool Delete(int id)
        {
            Car? car = Get(id);
            return _cars.Remove(car!);
        }

        public Car Edit(Car entity)
        {
            Car? car = Get(entity.Id);
            car!.ModelName = entity.ModelName;
            car!.Manufacturer = entity.Manufacturer;
            car!.Price = entity.Price;
            return car;
        }

        public Car? Get(int id)
        {
            return _cars.FirstOrDefault(t=>t.Id == id);
        }

        public IEnumerable<Car> GetAll()
        {
            return _cars;
        }
    }
}
