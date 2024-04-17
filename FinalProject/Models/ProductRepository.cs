namespace FinalProject.Models
{
    public class ProductRepository
    {
        private static List<Product> _products = new List<Product>();

        public List<Product> GetAll() => _products;

        public void Add(Product newProduct) => _products.Add(newProduct);

        public void Remove(int id)
        {
            var hasProduct = _products.FirstOrDefault(i => i.Id == id);
            if (hasProduct == null)
            {
                throw new Exception($"There are no products with this id{id}");
            }

            _products.Remove(hasProduct);
        }

        public void Update(Product updateProduct)
        {
            var hasProduct = _products.FirstOrDefault(i => i.Id == updateProduct.Id);
            if (hasProduct == null)
            {
                throw new Exception($"There are no products with this id{updateProduct.Id}");
            }

            hasProduct.Name = updateProduct.Name;
            hasProduct.Price = updateProduct.Price;
            hasProduct.Stock = updateProduct.Stock;

            var inx = _products.FindIndex(i => i.Id == updateProduct.Id);
            _products[inx] = hasProduct;
        }
    }
}
