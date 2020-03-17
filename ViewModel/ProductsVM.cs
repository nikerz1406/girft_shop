using Girft_shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Girft_shop.ViewModel
{
    public class ProductsVM
    {
        public List<SubProducts> Teddy(String condition) {

            List<product> teddyPro = new List<product>();
            var model = new girftEntities();
            // get data teddy
            if (condition != null)
            {
                 teddyPro = model.products.Where(x=>x.type.Contains(condition)).ToList();
            }
            else
            {
                 teddyPro = model.products.ToList();
            }
            

                List<SubProducts> subTable = new List<SubProducts>();
            foreach (var item in teddyPro)
            {
                var tmp = (double) item.price * 0.9;
                String link = "/product?id="+item.id.ToString();
                subTable.Add(
                            new SubProducts()
                            {
                                id = item.id,
                                name = item.name,
                                img = item.img,
                                price = item.price,
                                discount = tmp,
                                type = item.type,
                                link = link
                            }
                        );

            }
            return subTable;
        }

        
    }
}