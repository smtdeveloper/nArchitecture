using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Model : Entity 
    {
        public int BrandId { get; set; }
        public string Name { get; set; }
        public decimal DailyPrice { get; set; }
        public string ImgUrl { get; set; }

        public virtual Brand? Brand { get; set; }

        public Model()
        {

        }

        public Model(int id,string name, decimal dailyPrice, string ımgUrl, int brandId) : this()
        {
            Id = id;
            BrandId = brandId;
            Name = name;
            DailyPrice = dailyPrice;
            ImgUrl = ımgUrl;
        }
        
    }
}
