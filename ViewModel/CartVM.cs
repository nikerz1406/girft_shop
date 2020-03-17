using Girft_shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Girft_shop.ViewModel
{
    public class CartVM
    {
        public List<SubProducts> _cart;

        public CartVM()
        {
            _cart = new List<SubProducts>();
        }


        private double _amount;

        public int count;

        public double amount { get => _amount; set => _amount = 0; }
        public void addTocart(String id, String qty)
        {
            product row = new girftEntities().products.Where(x => x.id.ToString() == id).FirstOrDefault();
            var qtyP = Convert.ToInt32(qty);
            var check = _cart.Where(x => x.id.ToString() == id).FirstOrDefault();

            if (check != null)
            {
                var remove = false;
                var tmp = _cart.Select(x =>
                {
                    x.quantity = (x.id.ToString() == id) ? (x.quantity + qtyP) : x.quantity;
                    x.total = (double)x.price * x.quantity;
                    if(x.quantity==0) remove = true;
                    return x;
                }).ToList();

                if (remove) tmp.RemoveAll(x => x.id.ToString() == id);
                    _cart = tmp;

            }
            else
            {
                var itemTotal = (double)row.price * qtyP;
                var pro = new SubProducts()
                {
                    id = row.id,
                    name = row.name,
                    description = row.description,
                    price = row.price,
                    quantity = qtyP,
                    img = row.img,
                    total = itemTotal
                };

                _cart.Add(pro);
            }

            count = count + qtyP;

            if (qtyP < 0)
            {
                _amount -= (double)row.price;
            }
            else
            {
                _amount += (double)row.price;
            }
            

        }



    }
}