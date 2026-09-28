var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Enable serving static files from wwwroot (index.html, css, js, images)
app.UseDefaultFiles();
app.UseStaticFiles();

// API endpoint returning rich menu data
app.MapGet("/api/menu", () => Results.Ok(new[]
{
    new {
        Id = 1,
        Name = "Truffle Glazed Wagyu Ribeye",
        Category = "mains",
        Price = 48.00,
        Rating = 4.9,
        Reviews = 142,
        Tag = "Chef's Signature",
        Description = "A5 Miyazaki Wagyu, black winter truffle jus, parsnip silk, charred asparagus.",
        Calories = "780 kcal",
        Image = "https://images.unsplash.com/photo-1544025162-d76694265947?auto=format&fit=crop&w=800&q=80"
    },
    new {
        Id = 2,
        Name = "Smoked Rosemary Old Fashioned",
        Category = "beverages",
        Price = 18.00,
        Rating = 5.0,
        Reviews = 210,
        Tag = "Craft Cocktail",
        Description = "Small-batch Kentucky bourbon, charred rosemary smoke, Angostura bitters, flamed orange peel.",
        Calories = "190 kcal",
        Image = "https://images.unsplash.com/photo-1514362545857-3bc16c4c7d1b?auto=format&fit=crop&w=800&q=80"
    },
    new {
        Id = 3,
        Name = "Pan-Seared Chilean Sea Bass",
        Category = "mains",
        Price = 42.00,
        Rating = 4.8,
        Reviews = 98,
        Tag = "Fresh Catch",
        Description = "Sustainably caught sea bass, saffron dashi broth, baby bok choy, lotus root crisp.",
        Calories = "520 kcal",
        Image = "https://images.unsplash.com/photo-1519708227418-c8fd9a32b7a2?auto=format&fit=crop&w=800&q=80"
    },
    new {
        Id = 4,
        Name = "Velvet Espresso Martini",
        Category = "beverages",
        Price = 16.50,
        Rating = 4.9,
        Reviews = 175,
        Tag = "Signature Sip",
        Description = "Single-origin Ethiopian cold brew espresso, Ketel One vodka, coffee liqueur, Madagascar vanilla froth.",
        Calories = "210 kcal",
        Image = "https://images.unsplash.com/photo-1551024709-8f23befc6f87?auto=format&fit=crop&w=800&q=80"
    },
    new {
        Id = 5,
        Name = "Burrata di Puglia & Heirloom Peaches",
        Category = "starters",
        Price = 22.00,
        Rating = 4.7,
        Reviews = 84,
        Tag = "Vegetarian",
        Description = "Creamy artisanal burrata, grilled Georgia peaches, 18-year balsamic drizzle, toasted pistachio dust.",
        Calories = "410 kcal",
        Image = "https://images.unsplash.com/photo-1592417817098-8f3d69102657?auto=format&fit=crop&w=800&q=80"
    },
    new {
        Id = 6,
        Name = "Kyoto Matcha Affogato",
        Category = "beverages",
        Price = 14.00,
        Rating = 4.9,
        Reviews = 120,
        Tag = "Artisan Drink",
        Description = "Ceremonial grade Uji matcha whisked tableside, poured over artisanal Tahitian vanilla bean gelato.",
        Calories = "280 kcal",
        Image = "https://images.unsplash.com/photo-1579954115545-a95591f28bfc?auto=format&fit=crop&w=800&q=80"
    },
    new {
        Id = 7,
        Name = "Valrhona Dark Chocolate Sphere",
        Category = "desserts",
        Price = 19.00,
        Rating = 5.0,
        Reviews = 312,
        Tag = "Must Try",
        Description = "70% Guanaja chocolate sphere melted tableside with hot salted caramel, hazelnut praline core.",
        Calories = "590 kcal",
        Image = "https://images.unsplash.com/photo-1606313564200-e75d5e30476c?auto=format&fit=crop&w=800&q=80"
    },
    new {
        Id = 8,
        Name = "Yuzu Citrus Sparkling Spritz",
        Category = "beverages",
        Price = 12.00,
        Rating = 4.8,
        Reviews = 95,
        Tag = "Zero Proof / Mocktail",
        Description = "Fresh Japanese yuzu juice, sparkling mineral water, wild lavender syrup, crystallized thyme.",
        Calories = "85 kcal",
        Image = "https://images.unsplash.com/photo-1536935338788-846bb9981813?auto=format&fit=crop&w=800&q=80"
    }
}));

// Simple health check endpoint for Azure pinging
app.MapGet("/health", () => Results.Ok(new
{
    Status = "Healthy",
    Service = "Aura & Ember Culinary Service",
    Environment = "Azure Cloud",
    Timestamp = DateTime.UtcNow
}));

app.Run();

// Required for tests
public partial class Program { }
