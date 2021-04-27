using System.Collections.ObjectModel;
using System.Windows;
using System.Linq;
using System.Data.Entity;
using Veipshop.Model.Ords;

namespace Veipshop.Model
{
    public static class BasketModel
    {
        public static int BasketId;

        public static int addBasket()
        {            
            using (VapeEntities db = new VapeEntities())
            {
                Basket baskets = db.Basket.Where(el => el.user_id == UserModel.UserId).Where(el => el.complete == "false").FirstOrDefault();

                if (baskets != null)
                {
                    return baskets.basket_id;
                }
                else
                {
                    Basket basket = new Basket() { user_id = UserModel.UserId, complete = "false", confirm = "false" };

                    db.Basket.Add(basket);
                    db.SaveChanges();
                }
            }
            return getBasketId();
        }

        private static int getBasketId()
        {
            using (VapeEntities db = new VapeEntities())
            {
                var baskets = db.Basket.Where(el => el.user_id == UserModel.UserId).OrderByDescending(el=>el.basket_id).First();

                Basket Basket = baskets as Basket;

                return Basket.basket_id;
            }
        }

        public static void setOrder(int ProductId)
        {
            using (VapeEntities db = new VapeEntities())
            {
                Orders Order = new Orders() { basket_id = BasketId, product_id = ProductId };

                db.Orders.Add(Order);
                db.SaveChanges();
            }
        }

        public static ObservableCollection<B> getOrders()
        {
            ObservableCollection<B> bs;
            ObservableCollection<P> ps;

            using (VapeEntities db = new VapeEntities())
            {
                bs = new ObservableCollection<B>() { };

                var baskets = db.Basket.Where(el => el.user_id == UserModel.UserId).OrderByDescending(el => el.basket_id);

                foreach (Basket Basket in baskets)
                {
                    if (Basket.complete == "true")
                    {
                        ps = new ObservableCollection<P>() { };

                        var orders = db.Orders.Where(el => el.basket_id == Basket.basket_id);

                        foreach (Orders Order in orders)
                        {
                            Products procuct = db.Products.Where(el => el.product_id == Order.product_id).FirstOrDefault();

                            P p = new P() {
                                name = procuct.name,
                                price = procuct.price,
                                product_id = procuct.product_id
                            };

                            ps.Add(p);
                        }

                        B b = new B()
                        {
                            basket_id = Basket.basket_id,
                            complete = Basket.complete,
                            confirm = Basket.confirm,
                            Product = ps
                        };

                        bs.Add(b);
                    }
                }
            }     
            return bs; 
        }

        public static ObservableCollection<B> getAllOrders()
        {
            ObservableCollection<B> bs;
            ObservableCollection<P> ps;

            using (VapeEntities db = new VapeEntities())
            {
                bs = new ObservableCollection<B>() { };

                var baskets = db.Basket.OrderByDescending(el => el.basket_id);

                foreach (Basket Basket in baskets)
                {
                    if (Basket.complete == "true" && Basket.confirm == "false")
                    {
                        ps = new ObservableCollection<P>() { };

                        var orders = db.Orders.Where(el => el.basket_id == Basket.basket_id);

                        foreach (Orders Order in orders)
                        {
                            Products procuct = db.Products.Where(el => el.product_id == Order.product_id).FirstOrDefault();

                            P p = new P()
                            {
                                name = procuct.name,
                                price = procuct.price,
                                product_id = procuct.product_id
                            };

                            ps.Add(p);
                        }

                        B b = new B()
                        {
                            basket_id = Basket.basket_id,
                            complete = Basket.complete,
                            confirm = Basket.confirm,
                            Product = ps
                        };

                        bs.Add(b);
                    }
                }
            }
            return bs;
        }

        public static ObservableCollection<Products> getBasket()
        {
            ObservableCollection<Products> Collection;

            using (VapeEntities db = new VapeEntities())
            {
                Collection = new ObservableCollection<Products>() { };

                string complete = db.Basket.Where(el => el.user_id == UserModel.UserId).Where(el => el.basket_id == BasketId).FirstOrDefault().complete;

                if (complete == "false")
                {
                    var Basket = db.Orders.Where(el => el.basket_id == BasketId);

                    foreach (Orders Product in Basket)
                    {
                        Collection.Add(db.Products.Where(el => el.product_id == Product.product_id).FirstOrDefault());
                    }
                    return Collection;
                }
            }
            return Collection;
        }

        public static void removeProductFromBasket(int ProductId)
        {
            using (VapeEntities db = new VapeEntities())
            {
                Orders Order = db.Orders.Where(el => el.basket_id == BasketId).Where(el => el.product_id == ProductId).FirstOrDefault();

                db.Orders.Remove(Order);
                db.SaveChanges();
            }
        }

        public static void toOrder()
        {
            using (VapeEntities db = new VapeEntities())
            {
                Basket Order = db.Basket.Where(el => el.user_id == UserModel.UserId).Where(el => el.basket_id == BasketId).FirstOrDefault();

                if(db.Orders.Where(el => el.basket_id == Order.basket_id).Count() > 0)
                {
                    Order.complete = "true";
                    db.Entry(Order).State = EntityState.Modified;

                    db.SaveChanges();

                    BasketId = addBasket();
                }         
            }
        }

        public static void toConfirm(int BasketId)
        {
            using (VapeEntities db = new VapeEntities())
            {
                Basket Order = db.Basket.Where(el => el.basket_id == BasketId).FirstOrDefault();

                Order.confirm = "true";
                db.Entry(Order).State = EntityState.Modified;

                db.SaveChanges();

                BasketId = addBasket();
            }
        }
    }
}
