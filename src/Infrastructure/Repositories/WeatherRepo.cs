//using Infrastructure.Data;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Infrastructure.Repositories
//{
//    public class WeatherRepository : Repository<WeatherRepository>
//    {
//        private ApplicationDbContext _db;
//        public WeatherRepository(ApplicationDbContext db) : base(db)
//        {
//            _db = db;
//        }

// public void Update(WeatherRepository obj) { _db.Products.Update(obj); }

//        public void Save()
//        {
//            _db.SaveChanges();
//        }
//    }
//}