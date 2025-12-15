using Marten.Schema;

namespace Catalog.API.Data
{
    public class CatalogInitialData : IInitialData
    {
        public async Task Populate(IDocumentStore store, CancellationToken cancellationToken)
        {
            using var session = store.LightweightSession();

            if (!session.Query<Product>().Any())
            {
                session.StoreObjects(InitialProducts());
                await session.SaveChangesAsync(cancellationToken);
            }

        }

        public List<Product> InitialProducts()
        {
            return
            [
                new Product
        {
            Id = Guid.Parse("ca210221-dae0-4823-af8d-0177d3ae413a"),
            Name = "Mechanical Gaming Keyboard",
            Description = "RGB backlit mechanical keyboard with blue switches.",
            ImageFile = "keyboard-mechanical.jpg",
            Price = 1899.90M,
            Category = ["Electronics", "Computer", "Keyboard"]
        },

        new Product
        {
            Id = Guid.Parse("2e57ff88-7d21-452f-862c-43faf9b37206"),
            Name = "27 Inch Gaming Monitor",
            Description = "27-inch IPS gaming monitor with 165Hz refresh rate.",
            ImageFile = "monitor-27inch.jpg",
            Price = 8499.90M,
            Category = ["Electronics", "Computer", "Monitor"]
        },

        new Product
        {
            Id = Guid.Parse("6c75a295-035a-4476-9bef-f1d54152031c"),
            Name = "ATX Gaming Computer Case",
            Description = "Mid-tower ATX case with tempered glass side panel.",
            ImageFile = "gaming-case.jpg",
            Price = 2799.90M,
            Category = ["Electronics", "Computer", "Case"]
        },

        new Product
        {
            Id = Guid.Parse("1051182a-725c-457b-9ac6-fea5db93decf"),
            Name = "RTX 4070 Graphics Card",
            Description = "High-performance graphics card with 12GB GDDR6X memory.",
            ImageFile = "rtx-4070.jpg",
            Price = 32999.90M,
            Category = ["Electronics", "Computer", "Graphics Card"]
        },

        new Product
        {
            Id = Guid.Parse("122cd910-b2d1-4ce8-b5f2-2f5ff6aa997a"),
            Name = "2TB Internal Hard Drive",
            Description = "7200 RPM 2TB internal hard drive for desktop computers.",
            ImageFile = "hdd-2tb.jpg",
            Price = 1899.90M,
            Category = ["Electronics", "Computer", "Storage"]
        },

        new Product
        {
            Id = Guid.Parse("86ca4843-014f-4bb6-ad4e-2c62d04ee78b"),
            Name = "1TB NVMe SSD",
            Description = "High-speed 1TB NVMe SSD with PCIe Gen4 support.",
            ImageFile = "ssd-nvme-1tb.jpg",
            Price = 2499.90M,
            Category = ["Electronics", "Computer", "Storage"]
        },

        new Product
        {
            Id = Guid.Parse("c54de42f-9302-4f9a-aa8b-a820b784e56f"),
            Name = "Gaming Mouse",
            Description = "Ergonomic gaming mouse with adjustable DPI and RGB lighting.",
            ImageFile = "gaming-mouse.jpg",
            Price = 1299.90M,
            Category = ["Electronics", "Computer", "Mouse"]
        },

        new Product
        {
            Id = Guid.Parse("486080ce-270b-4463-9e9f-f6e8039cb211"),
            Name = "750W Power Supply",
            Description = "80+ Gold certified 750W power supply unit.",
            ImageFile = "psu-750w.jpg",
            Price = 3199.90M,
            Category = ["Electronics", "Computer", "Power Supply"]
        },

        new Product
        {
            Id = Guid.Parse("b4a2fa64-278a-4b3c-a5b0-26bbe42c3aba"),
            Name = "Gaming Headset",
            Description = "Surround sound gaming headset with noise-canceling microphone.",
            ImageFile = "gaming-headset.jpg",
            Price = 2199.90M,
            Category = ["Electronics", "Computer", "Headset"]
        },

        new Product
        {
            Id = Guid.Parse("2ef76c44-9e25-435e-8189-425c7def3f3a"),
            Name = "1080p Webcam",
            Description = "Full HD 1080p webcam for streaming and video conferencing.",
            ImageFile = "webcam-1080p.jpg",
            Price = 1599.90M,
            Category = ["Electronics", "Computer", "Webcam"]
        }
            ];
        }

    }
}
