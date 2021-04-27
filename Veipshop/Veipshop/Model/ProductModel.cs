using System.Collections.ObjectModel;
using System.Linq;
using System.Data.Entity;

namespace Veipshop.Model
{
    public static class ProductModel
    {
        public static ObservableCollection<Products> getProducts(int id)
        {
            ObservableCollection<Products> Collection;

            using (VapeEntities db = new VapeEntities())
            {
                var Section = db.Products.Where(el => el.section_id == id);

                Collection = new ObservableCollection<Products>() { };

                foreach (Products Product in Section)
                {
                    Collection.Add(Product);
                }
            }
            return Collection;
        }

        public static Pod ProductToPod(Products product)
        {
            using (VapeEntities db = new VapeEntities())
            {
                var Product = db.Pod.Where(el => el.product_id == product.product_id);

                Pod pod = null;

                foreach (Pod Pods in Product)
                {
                    pod = Pods;
                }
                return pod;
            }
        }

        public static Tobacco_heating_systems ProductToTHS(Products product)
        {
            using (VapeEntities db = new VapeEntities())
            {
                var Product = db.Tobacco_heating_systems.Where(el => el.product_id == product.product_id);

                Tobacco_heating_systems ths = null;

                foreach (Tobacco_heating_systems THS in Product)
                {
                    ths = THS;
                }
                return ths;
            }
        }

        public static Vaping_liquid ProductToVapingLiquid(Products product)
        {
            using (VapeEntities db = new VapeEntities())
            {
                var Product = db.Vaping_liquid.Where(el => el.product_id == product.product_id);

                Vaping_liquid vapingLiquid = null;

                foreach (Vaping_liquid VapingLiquid in Product)
                {
                    vapingLiquid = VapingLiquid;
                }
                return vapingLiquid;
            }
        }

        public static Vapes ProductToVapes(Products product)
        {
            using (VapeEntities db = new VapeEntities())
            {
                var Product = db.Vapes.Where(el => el.product_id == product.product_id);

                Vapes vapes = null;

                foreach (Vapes Vapes in Product)
                {
                    vapes = Vapes;
                }
                return vapes;
            }
        }

        public static void delete(int ProductId, int? SectionId)
        {
            using (VapeEntities db = new VapeEntities())
            {
                if(SectionId == 1)
                {
                    Pod pod = db.Pod.Where(el => el.product_id == ProductId).FirstOrDefault();
                    db.Pod.Remove(pod);
                }
                else if(SectionId == 2)
                {
                    Tobacco_heating_systems ths = db.Tobacco_heating_systems.Where(el => el.product_id == ProductId).FirstOrDefault();
                    db.Tobacco_heating_systems.Remove(ths);
                }
                else if (SectionId == 3)
                {
                    Vaping_liquid vl = db.Vaping_liquid.Where(el => el.product_id == ProductId).FirstOrDefault();
                    db.Vaping_liquid.Remove(vl);
                }
                else if (SectionId == 4)
                {
                    Vapes vp = db.Vapes.Where(el => el.product_id == ProductId).FirstOrDefault();
                    db.Vapes.Remove(vp);
                }

                Products product = db.Products.Where(el => el.product_id == ProductId).FirstOrDefault();

                db.Products.Remove(product);
                db.SaveChanges();
            }
        }

        public static void updatePod(int ProductId, string Name, int? Price, string BatteryCapacity)
        {
            using (VapeEntities db = new VapeEntities())
            {
                Products product = db.Products.Where(el => el.product_id == ProductId).FirstOrDefault();

                product.name = Name;
                product.price = Price;

                db.Entry(product).State = EntityState.Modified;

                Pod pod = db.Pod.Where(el => el.product_id == ProductId).FirstOrDefault();

                pod.battery_capacity = BatteryCapacity;

                db.Entry(pod).State = EntityState.Modified;

                db.SaveChanges();
            }
        }

        public static void updateTHS(int ProductId, string Name, int? Price, string BatteryCapacity)
        {
            using (VapeEntities db = new VapeEntities())
            {
                Products product = db.Products.Where(el => el.product_id == ProductId).FirstOrDefault();

                product.name = Name;
                product.price = Price;

                db.Entry(product).State = EntityState.Modified;

                Tobacco_heating_systems ths = db.Tobacco_heating_systems.Where(el => el.product_id == ProductId).FirstOrDefault();

                ths.battery_capacity = BatteryCapacity;

                db.Entry(ths).State = EntityState.Modified;

                db.SaveChanges();
            }
        }

        public static void updateVapingLiquid(int ProductId, string Name, int? Price, string Taste, string Volume, string Strong)
        {
            using (VapeEntities db = new VapeEntities())
            {
                Products product = db.Products.Where(el => el.product_id == ProductId).FirstOrDefault();

                product.name = Name;
                product.price = Price;

                db.Entry(product).State = EntityState.Modified;

                Vaping_liquid vl = db.Vaping_liquid.Where(el => el.product_id == ProductId).FirstOrDefault();

                vl.taste = Taste;
                vl.volume = Volume;
                vl.strong = Strong;

                db.Entry(vl).State = EntityState.Modified;

                db.SaveChanges();
            }
        }

        public static void updateVapes(int ProductId, string Name, int? Price, string PeakPower)
        {
            using (VapeEntities db = new VapeEntities())
            {

                Products product = db.Products.Where(el => el.product_id == ProductId).FirstOrDefault();

                product.name = Name;
                product.price = Price;

                db.Entry(product).State = EntityState.Modified;

                Vapes vp = db.Vapes.Where(el => el.product_id == ProductId).FirstOrDefault();

                vp.peak_power = PeakPower;

                db.Entry(vp).State = EntityState.Modified;

                db.SaveChanges();
            }
        }

        public static int addProduct(string Name, int? Price, int SectionId, int BrandId, int ManufacturerId, int CountryId)
        {
            using (VapeEntities db = new VapeEntities())
            {
                Products newProduct = new Products()
                {
                    name = Name,
                    price = Price,
                    section_id = SectionId,
                    brand_id = BrandId,
                    manufacturer_id = ManufacturerId,
                    country_id = CountryId
                };

                db.Products.Add(newProduct);

                db.SaveChanges();

                //newProduct = db.Products.OrderByDescending(el => el.product_id).FirstOrDefault();

                if (SectionId == 1)
                {
                    Pod pod = new Pod()
                    {
                        product_id = newProduct.product_id,
                        battery_capacity = "0"    
                    };
                    db.Pod.Add(pod);
                }
                else if (SectionId == 2)
                {
                    Tobacco_heating_systems ths = new Tobacco_heating_systems()
                    {
                        product_id = newProduct.product_id,
                        battery_capacity = "0"
                    };
                    db.Tobacco_heating_systems.Add(ths);
                }
                else if (SectionId == 3)
                {
                    Vaping_liquid vl = new Vaping_liquid()
                    {
                        product_id = newProduct.product_id,
                        taste = "",
                        strong = "",
                        volume = ""
                    };
                    db.Vaping_liquid.Add(vl);
                }
                else if (SectionId == 4)
                {
                    Vapes vapes = new Vapes()
                    {
                        product_id = newProduct.product_id,
                        peak_power = "0W"
                    };
                    db.Vapes.Add(vapes);
                }

                db.SaveChanges();

                return newProduct.product_id;
            }

        }    
        
    }
}
