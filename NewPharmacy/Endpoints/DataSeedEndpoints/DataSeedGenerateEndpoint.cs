namespace NewPharmacy.Endpoints.DataSeedEndpoints;

using Microsoft.AspNetCore.Mvc;
using NewPharmacy.Data.Models.Auth;
using NewPharmacy.Data.Models;
using NewPharmacy.Data;
using NewPharmacy.Helper.Api;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using System.Runtime.Intrinsics.X86;

[Route("data-seed")]
public class DataSeedGenerateEndpoint(ApplicationDbContext db)
    : MyEndpointBaseAsync
    .WithoutRequest
    .WithResult<string>
{
    [HttpPost]
    public override async Task<string> HandleAsync(CancellationToken cancellationToken = default)
    {
        if (db.MyAppUsers.Any())
        {
            throw new Exception("The data has already been generated");
        }

        // Kreiranje kategorija
        var categories = new List<Category>
        {
            new Category { Name = "Your health" },
            new Category { Name = "Beauty and care" },
            new Category { Name = "Childcare" },
            new Category { Name = "Skin protection" },
            new Category { Name = "Devices" }
        };

        // Kreiranje proizvoda
        var products = new List<Product>
        {
            new Product { Name = "Flobian capsules A10",Description = "Flobian® is a dietary supplement that helps with irritable bowel syndrome (stomach gas, flatulence, stomach pain, irregular bowel movements), and it is extremely successfully used throughout Europe and America as a natural, completely safe and thoroughly tested product.",Category = categories[0], Price = 18.30, QuantityInStock = 27, Picture = "https://internetapoteka.ba/image/cache/catalog/ARTIKLI/flobian_kapsule_a10-500x500.jpg"},
            new Product { Name = "Herbiko Propomucil syrup for children 120ml",Description = "Propomucil syrup for children is the only one that contains natural propolis purified by innovative technology, into which natural N-acetylcysteine (NAC) is incorporated, which breaks down the secretion and throws it out.",Category = categories[0], Price = 10.70, QuantityInStock = 30, Picture = "https://internetapoteka.ba/image/cache/data/artikli/2020095-500x500.jpg"},
            new Product { Name = "Vitamin C 1000g Powder 150g",Description = "Vitamin C is a powerful antioxidant, supporting the immune and nervous systems. It is recommended for athletes and recreationists, for everyone who wants to strengthen the immune system and for everyone who wants to raise their energy level.",Category = categories[0], Price = 12.90, QuantityInStock = 22, Picture = "https://internetapoteka.ba/image/cache/catalog/ARTIKLI/Vitamin-C-1000mg-u-prahu-150g-500x500.jpg"},
            new Product { Name = "Arnika gel 250ml Cydonia",Description = "The ingredients act as analgesics (reduce the intensity of pain), anti-inflammatory, immunostimulating and as astringents, reducing swelling and pain in case of injuries and consequences of accidents such as, for example. hematomas, dislocations, contusions, edema due to fractures, rheumatic problems in muscles and joints.",Category = categories[0], Price = 6.10, QuantityInStock = 14, Picture = "https://internetapoteka.ba/image/cache/catalog/CYDONIA/arnika-gel-250ml-Cydonia-500x500.jpg"},
            new Product { Name = "Advancis Throat spray 20ml",Description = "To relieve the symptoms of a sore and inflamed throat.",Category = categories[0], Price = 18.80, QuantityInStock = 33, Picture = "https://internetapoteka.ba/image/cache/catalog/FARMODIETICA/Advancis-Throat-Sprej-20-ml-apoteka-monis.png-500x500.jpg"},
            new Product { Name = "Melem original 10ml",Description = "Melem is an original cream that loves healthy skin and, with daily use, allows your skin to be hydrated, nourished and resistant to external influences.",Category = categories[0], Price = 6.20, QuantityInStock = 20, Picture = "https://internetapoteka.ba/image/cache/data/artikli/2040096-500x500.jpg"},

            new Product { Name = "A-DERMA Shower gel 500ml",Description = "It cleans, hydrates and protects the fragile skin of children (older than 2 years) and adults. It contains a gentle cleansing base and balancing ingredients.",Category = categories[1], Price = 34.80, QuantityInStock = 20, Picture = "https://internetapoteka.ba/image/cache/catalog/A-DERMA/A-Derma-gel-za-tusiranje-500-ml-Super-Apoteka-500x500.png"},
            new Product { Name = "Gloria scalp peeling 100ml ",Description = "Scalp peeling is specially designed for oily scalp and dandruff-prone hair.",Category = categories[1], Price = 17.60, QuantityInStock = 22, Picture = "https://internetapoteka.ba/image/cache/catalog/GLORIA/Gloria-Piling-za-vlasiste-Super-Apoteka-500x500.png"},
            new Product { Name = "CeraVe oil control-cream 52ml + floaming gel 236ml ",Description = "For combination to oily skin• Helps balance oily skin",Category = categories[1], Price = 43.00, QuantityInStock = 14, Picture = "https://internetapoteka.ba/image/cache/catalog/CERAVE%20SET-500x500.jpg"},
            new Product { Name = "BIOMD First Aid Face Cream 40ml",Description = "First Aid Face Cream is an organic, natural and hypoallergenic face cream that is great for sensitive skin with a burning and hot sensation.",Category = categories[1], Price = 34.90, QuantityInStock = 30, Picture = "https://internetapoteka.ba/image/cache/catalog/BIOMD/BIOMD-First-aid-krema-za-lice-40ml-500x500.jpg"},
            new Product { Name = "Neven Gel 100ml Cydonia",Description = "Marigold flower tincture (Calendula officinalis), as well as rose geranium oil (Pelargonium roseum), have an analgesic effect (reduce the intensity of pain)",Category = categories[1], Price = 3.00, QuantityInStock = 19, Picture = "https://internetapoteka.ba/image/cache/catalog/CYDONIA/neven-gel-tuba-100ml-Cydonia-500x500.jpg"},
            new Product { Name = "VICHY Capital Soleil Baby Milk SPF50+ 300ml",Description = "High protection for children in a large package\r\nFor fair-skinned children.To combat the harmful effects of UV rays",Category = categories[1], Price = 47.10, QuantityInStock = 20, Picture = "https://internetapoteka.ba/image/cache/catalog/VICHY/VICHY%20Sun/3337871323639_1-500x500.jpg"},

            new Product { Name = "ECODENTA Children's toothbrush Soft A1 ",Description = "Toothbrush designed for daily care of milk and permanent teeth of children from 1 to 7 years of age.",Category = categories[2], Price = 09.10, QuantityInStock = 19, Picture = "https://internetapoteka.ba/image/cache/catalog/ECODENTA/Ecodenta-Djecija-cetkica-soft-A1-500x500.jpg"},
            new Product { Name = "A-DERMA Exomega Control Cleansing Gel 2 in 1 200ml",Description = "Emollient cleansing gel 2in1 for dry skin prone to atopy.\r\n \r\nAnti-scratch. Infants, children.",Category = categories[2], Price = 28.40, QuantityInStock = 20, Picture = "https://internetapoteka.ba/image/cache/catalog/A-DERMA/A-DERMA-Exomega-Control-Gel-za-ciscenje-2-u-1-200ml-500x500.jpg"},
            new Product { Name = "Humana 1800g",Description = "Humana 1 contains high-quality nutrients and energy and is adapted to the special nutritional needs of a newborn during the first 6 months of life.",Category = categories[2], Price = 44.90, QuantityInStock = 32, Picture = "https://internetapoteka.ba/image/cache/catalog/humana-500x500.png"},
            new Product { Name = "PINO 3D Puzzle Urgent",Description = "The Mini 3D puzzle is a didactic tool that helps children learn to recognize shapes, practice coordination of movements, and the ability to combine different elements.",Category = categories[2], Price = 09.40, QuantityInStock = 12, Picture = "https://internetapoteka.ba/image/cache/data/PINO/02170022-500x500.jpg"},
            new Product { Name = "MAM Fruit Pacifier",Description = "Perfect for little beginners: with MAM pacifiers for fresh fruit and soft vegetables you can taste without fear of choking",Category = categories[2], Price = 18.90, QuantityInStock = 35, Picture = "https://internetapoteka.ba/image/cache/catalog/MAM/MAM_duda_za_voce-500x500.jpg"},
            new Product { Name = "Trudi Liquid powder 100ml",Description = "Extremely rich powder in cream, provides instant relief to irritated and wet children's skin.",Category = categories[2], Price = 08.20, QuantityInStock = 21, Picture = "https://internetapoteka.ba/image/cache/catalog/TRUDI/Trudi-Teku%C4%87i-puder-100-ml-Super-Apoteka-500x500.jpg"},

            new Product { Name = "AVENE Sun Tonirana krema SPF50+ 50ml",Description = "Tinted sun protection cream SPF 50+ is intended for dry sensitive facial skin, always prone to sunburn or exposed to intense sunlight.",Category = categories[3], Price = 44.70 , QuantityInStock = 13, Picture = "https://internetapoteka.ba/image/cache/catalog/AVENE/AVENE-SUN-Tonirana-krema-SPF50-50ml-400x400.jpg"},
            new Product { Name = "Mapez spray 100ml",Description = "Natural protection against mosquitoes and other insects\r\n\r\nMapez spray is a mixture of non-toxic, non-irritating, effective, natural extracts suitable for use even in the youngest children from the first days of life.",Category = categories[3], Price = 16.20 , QuantityInStock = 16, Picture = "https://internetapoteka.ba/image/cache/catalog/ARTIKLI/Mapez-sprej-protiv-komaraca-za-djecu-100ml-400x400.jpg"},
            new Product { Name = "Hansaplast Aqua Protect Waterproof patch",Description = "Hansaplast Aqua Protect patches are waterproof and suitable for covering all types of minor wounds.Flexible, waterproof material protects when bathing and showering.",Category = categories[3], Price = 7.00, QuantityInStock =15, Picture = "https://internetapoteka.ba/image/cache/catalog/HANSAPLAST/hansaplast-flaster-aqua-protect-400x400.png"},
            new Product { Name = "Gloria Body myst 200ml",Description = "A soothing body mist, rich in moisturizing active substances, regenerates and refreshes the skin during hot summer days.Gives the skin a healthy look. Red algae with skin proteins create a protective layer that protects against external harmful influences, while ferulic acid has a photoprotective effect. The product is quickly absorbed and does not leave greasy traces. By pressing the pump, spray the product on the target area.",Category = categories[3], Price = 16.50, QuantityInStock = 13, Picture = "https://internetapoteka.ba/image/cache/catalog/GLORIA/Gloria-Body-mist-200-ml-Super-Apoteka-400x400.png"},
            new Product { Name = "Laboratorios BABE Aloe Vera gel 300ml",Description = "Aloe vera gel that moisturizes, soothes, softens, refreshes and restores the skin. It is especially recommended for sensitive and irritated skin.\r\nSometimes our skin becomes irritated due to situations such as prolonged exposure to the sun, shaving or waxing.",Category = categories[3], Price = 33.90, QuantityInStock = 10, Picture = "https://internetapoteka.ba/image/cache/catalog/LABORATORIOS%20BABE/Aloe-Vera-300ml-400x400.png"},
            new Product { Name = "URIAGE Thermal water 150ml",Description = "Uriage thermal water for daily skin care\r\nNaturally isotonic, 100% Uriage thermal water is very rich in minerals and trace elements.\r\n100% natural and bacteriologically clean.",Category = categories[3], Price = 17.40, QuantityInStock = 19, Picture = "https://internetapoteka.ba/image/cache/catalog/URIAGE/URIAGE-Termalna-voda-150ml-400x400.jpg"},

            new Product { Name = "BEURER BY 84 Baby monitor",Description = "The analog baby monitor shows you your baby's mood using baby emotions. The device is suitable for every household thanks to its extremely long range of up to 800 m.",Category = categories[4], Price = 135.90, QuantityInStock = 9, Picture = "https://internetapoteka.ba/image/cache/catalog/BEURER/beurer-baby-monitor-BY84-400x400.png"},
            new Product { Name = "BEURER FC 41 Pore cleaner",Description = "The deep pore cleaner enables deep cleaning of the pores thanks to the most modern vacuum technology.\r\nUsing round attachments, spots, blackheads and dead skin cells are effectively removed.",Category = categories[4], Price = 58.20, QuantityInStock = 6, Picture = "https://internetapoteka.ba/image/cache/catalog/BEURER/FC41-400x400.jpg"},
            new Product { Name = "BEURER FC 65 Facial cleansing brush",Description = "The Beurer Pureo Deep clear facial brush enables gentle and thorough cleaning of the facial skin.\r\nThe brush cleans the facial skin by vibration or pulsation, but also improves circulation.",Category = categories[4], Price = 85.50, QuantityInStock = 9, Picture = "https://internetapoteka.ba/image/cache/catalog/BEURER/BEURER-FC-65-cetka-za-ciscenje-lica-0-400x400.jpg"},
            new Product { Name = "MEDISANA Manicure and pedicure device MP815",Description = "Care and treatment of nails, cuticles and small calluses.",Category = categories[4], Price = 89.50, QuantityInStock = 4, Picture = "https://internetapoteka.ba/image/cache/catalog/m815-400x400.png"},
            new Product { Name = "BEURER LA 20 Aroma diffuser",Description = "The aroma diffuser for essential oils fills the entire room with pleasant scents using ultrasound technology.",Category = categories[4], Price = 78.00, QuantityInStock = 7, Picture = "https://internetapoteka.ba/image/cache/catalog/BEURER/beurer-aroma-difuzer-LA20-400x400.png"},
            new Product { Name = "BEURER MG 17 mini spa massager",Description = "The spa mini massager is waterproof and therefore can be used even under water, in wellness or any other occasion.",Category = categories[4], Price = 25.50, QuantityInStock = 4, Picture = "https://internetapoteka.ba/image/cache/catalog/BEURER/Beurer-MG-17-mini-spa-masazer-500x500.jpg"}

        };

        // Kreiranje korisnika
        var users = new List<MyAppUser>
        {
            new MyAppUser
            {
                Username = "anaanic",
                Password = "ana123",
                FirstName = "Ana",
                LastName = "Anic",
                IsAdmin = true,
                IsCustomer = false,
                IsPharmacist = false
            },
            new MyAppUser
            {
                Username = "mujomujic",
                Password = "mujo123",
                FirstName = "Mujo",
                LastName = "Mujic",
                IsAdmin = false,
                IsCustomer = true,
                IsPharmacist = false
            },
            new MyAppUser
            {
                Username = "husohusic",
                Password = "huso123",
                FirstName = "Huso",
                LastName = "Husic",
                IsAdmin = false,
                IsCustomer = false,
                IsPharmacist = true
            }
        };

        // Kreiranje dobavljača
        var suppliers = new List<Supplier>
        {
            new Supplier { Name = "Hercegovinalijek d.o.o. Mostar", Address = "Muje Pašića 4, Mostar 88000", Phone = "036 501-500",Email ="info@hercegovinalijek.ba" },
            new Supplier { Name = "Bosnalijek d.d. Sarajevo", Address = "Jukićeva 53, Sarajevo 71000", Phone = "033 254-400",Email ="info@bosnalijek.ba" },
            new Supplier { Name = "ZADA Pharmaceuticals d.o.o. Lukavac", Address = "GH7C+R2M, M4, Bistarac Donji", Phone = "035 551-140",Email ="zada@zada.ba" },
        };

        var advertisements = new List<Advertisement>
        {
            new Advertisement {Title ="PF Happy Holidays", imageURL="https://internetapoteka.ba/image/catalog/revslider_media_folder/avene.jpg"},
            new Advertisement {Title = "ORAL-B", imageURL="https://internetapoteka.ba/image/catalog/revslider_media_folder/super%20apoteka_web_decembar_oral%20b.jpg"},
            new Advertisement{Title="Vichy deo-duo", imageURL="https://internetapoteka.ba/image/catalog/revslider_media_folder/super%20apoteka_web_decembar_Vichy%20Deo%20duo_1.jpg"}
        };

        // Dodavanje podataka u bazu
        await db.Categories.AddRangeAsync(categories, cancellationToken);
        await db.Products.AddRangeAsync(products, cancellationToken);
        await db.MyAppUsers.AddRangeAsync(users, cancellationToken);
        await db.Advertisements.AddRangeAsync(advertisements, cancellationToken);
        await db.SaveChangesAsync(cancellationToken);

        return "Data generation completed successfully.";
    }
}