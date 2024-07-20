using BusinessObjects;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

namespace ProductOData
{
    public class ModelBuilder
    {
        public static IEdmModel GetEDMModel()
        {
            var modelBuilder = new ODataConventionModelBuilder();
            modelBuilder.EntitySet<Product>("Products");
            modelBuilder.EntitySet<Category>("Categories");
            modelBuilder.EntitySet<Customer>("Customers");
            modelBuilder.EntitySet<Order>("Orders");
            modelBuilder.EntitySet<OrderDetail>("OrderDetails");
            // Thiết lập các quan hệ
            var product = modelBuilder.EntityType<Product>();
            product.HasRequired(p => p.Category, (product, category) => product.CategoryId == category.CategoryId);

            var order = modelBuilder.EntityType<Order>();
            order.HasKey(o => o.OrderId);
            order.HasRequired(o => o.Customer, (order, customer) => order.CustomerId == customer.CustomerId);
            order.HasMany(o => o.OrderDetails);

            var orderDetail = modelBuilder.EntityType<OrderDetail>();
            orderDetail.HasKey(od => new { od.OrderId, od.ProductId });
            orderDetail.HasRequired(od => od.Order, (orderDetail, order) => orderDetail.OrderId == order.OrderId);
            orderDetail.HasRequired(od => od.Product, (orderDetail, product) => orderDetail.ProductId == product.ProductId);


            return modelBuilder.GetEdmModel();
        }

    }
}
