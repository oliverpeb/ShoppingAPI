using ShoppingAPI;
using System.Xml.Linq;
using ShoppingAPI;

namespace ShoppingAPIAPI.Repositories
{
    public class ShoppingItemsRepository

    {
        private int _nextId;
        private List<shoppingitem> _items;

        public ShoppingItemsRepository()
        {

            _nextId = 1;
            _items = new List<shoppingitem>()
            {


                new shoppingitem { Id = _nextId++, Name = "Milk", Quantity = 4, Price = 14 },
                new shoppingitem { Id = _nextId++, Name = "Bread", Quantity = 1, Price = 20 },
                new shoppingitem { Id = _nextId++, Name = "Eggs", Quantity = 2, Price = 12 },
            };

        }
        public List<shoppingitem> GetAll()
        {
            return new List<shoppingitem>(_items);
        }

        public shoppingitem Add(shoppingitem newshoppingitem)
        {
            newshoppingitem.Id = _nextId++;
            _items.Add(newshoppingitem);
            return newshoppingitem;
        }

        public shoppingitem? GetById(int id)
        {
            return _items.Find(x => x.Id == id);
        }

        public shoppingitem? Delete(int id)
        {
            shoppingitem? foundshoppingitem = GetById(id);
            if (foundshoppingitem == null)
            {
                return null;
            }
            _items.Remove(foundshoppingitem);
            return foundshoppingitem;
        }

        public shoppingitem TotalPrice()
        {

            shoppingitem totalpriceofitems = new shoppingitem();
            totalpriceofitems.Price = _items.Sum(x => x.Price);
            totalpriceofitems.Id = _nextId++;
            return totalpriceofitems;


        }
    }
}