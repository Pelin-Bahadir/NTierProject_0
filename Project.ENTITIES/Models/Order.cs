using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Order:BaseEntity
    {
        public string ShippedAddress { get; set; }
        public decimal TotalPrice { get; set; }

        //Sipariş işlemlerinin icerisindeki bilgileri daha rahat yakalamak adına actıgımız property'lerden bir tanesi de TotalPrice'dir...Yalnız burada cok dikkatli olmanız gerekir gercekten size hız kazandıracak bir durum varsa bu bilgileri ek olarak buraya almanız gerekir...Aynı zamanda bu durum abartılmamalıdır...Yani ilgili yapının tüm verileri asla bu sınıfa komple koyulmamalıdır...Sadece Spesifik parcalar alınmalıdır...
        public string UserName { get; set; }
        public string Email { get; set; }
        public int? AppUserID { get; set; }
        public int? ShipperID { get; set; }



        //Relational Properties
        public virtual AppUser AppUser { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
        public virtual Shipper Shipper { get; set; }



    }
}
