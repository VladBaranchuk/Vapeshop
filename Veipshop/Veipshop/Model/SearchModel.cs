using System.Collections.ObjectModel;
using System.Windows;
using System.Linq;
using System;

namespace Veipshop.Model
{
    public static class SearchModel
    {
        public static ObservableCollection<Section> getSection()
        {
            ObservableCollection<Section> Collection;

            using (VapeEntities db = new VapeEntities())
            {
                var Section = db.Section;

                Collection = new ObservableCollection<Section>() { };

                Collection.Add(new Section() {name = "Все" });

                foreach (Section section in Section)
                {
                    Collection.Add(section);
                }
            }
            return Collection;
        }

        public static ObservableCollection<Brand> getBrand()
        {
            ObservableCollection<Brand> Collection;

            using (VapeEntities db = new VapeEntities())
            {
                var Brand = db.Brand;

                Collection = new ObservableCollection<Brand>() { };

                Collection.Add(new Brand() { brand1 = "Все" });

                foreach (Brand brand in Brand)
                {
                    Collection.Add(brand);
                }
            }
            return Collection;
        }

        public static ObservableCollection<Section> getSections()
        {
            ObservableCollection<Section> Collection;

            using (VapeEntities db = new VapeEntities())
            {
                var Section = db.Section;

                Collection = new ObservableCollection<Section>() { };

                Collection.Add(new Section() { name = "" });

                foreach (Section section in Section)
                {
                    Collection.Add(section);
                }
            }
            return Collection;
        }

        public static ObservableCollection<Brand> getBrands()
        {
            ObservableCollection<Brand> Collection;

            using (VapeEntities db = new VapeEntities())
            {
                var Brand = db.Brand;

                Collection = new ObservableCollection<Brand>() { };

                Collection.Add(new Brand() { brand1 = "" });

                foreach (Brand brand in Brand)
                {
                    Collection.Add(brand);
                }
            }
            return Collection;
        }

        public static ObservableCollection<Manufacturer> getManufacturers()
        {
            ObservableCollection<Manufacturer> Collection;

            using (VapeEntities db = new VapeEntities())
            {
                var Manufacturer = db.Manufacturer;

                Collection = new ObservableCollection<Manufacturer>() { };

                Collection.Add(new Manufacturer() { manufacturer1 = "" });

                foreach (Manufacturer manufacturer in Manufacturer)
                {
                    Collection.Add(manufacturer);
                }
            }
            return Collection;
        }

        public static ObservableCollection<Country> getCountries()
        {
            ObservableCollection<Country> Collection;

            using (VapeEntities db = new VapeEntities())
            {
                var Country = db.Country;

                Collection = new ObservableCollection<Country>() { };

                Collection.Add(new Country() { country1 = "" });

                foreach (Country country in Country)
                {
                    Collection.Add(country);
                }
            }
            return Collection;
        }

        public static ObservableCollection<Products> getSearch(int from, int to, int section, int brand, string str)
        {
            ObservableCollection<Products> Collection;

            using (VapeEntities db = new VapeEntities())
            {
                var Products = db.Products.Where(el => el.price > from && el.price < to);

                if (section != 0)
                {
                    Products = Products.Where(el => el.section_id == section);
                }

                if(brand != 0)
                {
                    Products = Products.Where(el => el.brand_id == brand);
                }

                if (str != "")
                {
                    Products = Products.Where(el => el.name.Contains(str));
                }

                Collection = new ObservableCollection<Products>() { };

                foreach (Products product in Products)
                {
                    Collection.Add(product);
                }
            }
            return Collection;
        }
    }
}
