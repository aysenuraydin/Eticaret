using System.Security.Claims;
using Eticaret.Application.Abstract;
using Eticaret.Domain;
using Eticaret.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eticaret.Api.Controllers
{
    [ApiController]
    [Authorize(Roles = "seller")]
    [Route("api/[controller]")]
    public class SellerProductController : ControllerBase
    {
        private readonly IProductRepository _productRepo;
        private readonly IProductCommentRepository _commentRepo;
        private readonly IProductImageRepository _productImageRepo;
        public SellerProductController(
            IProductRepository productRepo,
            IProductCommentRepository commentRepo,
            IProductImageRepository productImageRepo)
        {
            _productRepo = productRepo;
            _productImageRepo = productImageRepo;
            _commentRepo = commentRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            //bool Id = int.TryParse(User.FindFirstValue(JwtClaimTypes.Subject), out int sellerId);//!
            bool result = int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int sellerId);

            var products = (await _productRepo.GetIdAllIncludeFilterAsync(
                            p => p.UserId == sellerId,
                            p => p.ProductImages,
                            p => p.ProductComments,
                            p => p.UserFk!,
                            p => p.CategoryFk!,
                            p => p.OrderItems,
                            p => p.CartItems
                            ))
                            .OrderByDescending(p => p.CreatedAt)
                            .Select(p => ProductListToDTO(p))
                            .ToList();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int? id)
        {
            bool Id = int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int sellerId);

            if (id == null) return NotFound();

            var product = (await _productRepo.GetIdAllIncludeFilterAsync(
                            p => p.Id == id && p.UserId == sellerId,
                            p => p.ProductImages,
                            p => p.ProductComments,
                            p => p.UserFk!,
                            p => p.CategoryFk!,
                            p => p.OrderItems,
                            p => p.CartItems
                            )).FirstOrDefault();

            if (product == null) return NotFound();

            return Ok(ProductDetailToDTO(product, sellerId));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(SellerProductCreateOrUpdateDTO entity)
        {
            if (entity == null) return NotFound(entity);

            try
            {
                bool Id = int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int sellerId);
                entity.SellerId = sellerId;

                var p = ProductCreateToDTO(entity);
                await _productRepo.AddAsync(p);

                foreach (var item in ProductImagesCreateToDTO(entity, p))
                {
                    await _productImageRepo.AddAsync(item);
                }

                return CreatedAtAction(nameof(GetProduct), new { id = p.Id }, entity);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, SellerProductCreateOrUpdateDTO product)
        {
            if (product == null || product?.Id != id) return NotFound();

            bool Id = int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int sellerId);

            var prd = (await _productRepo.GetIdAllIncludeFilterAsync(
                i => i.Id == product!.Id && i.UserId == sellerId,
                i => i.ProductImages))
                .FirstOrDefault();

            if (prd == null) return NotFound();

            try
            {
                var p = ProductUpdateToDTO(product!, prd);
                await _productRepo.UpdateAsync(p);

                if (product!.ImageList.Count > 0)
                {
                    var imagesToDelete = prd.ProductImages.ToList();
                    foreach (var item in imagesToDelete)
                    {
                        await _productImageRepo.DeleteAsync(item);
                    }

                    var img = ProductImagesUpdateToDTO(product, p);
                    foreach (var item in img)
                    {
                        await _productImageRepo.AddAsync(item);
                    }
                }
            }
            catch (Exception)
            {
                return NotFound();
            }

            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product); //değiştir
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int? id)
        {
            if (id == null) return NotFound();

            var prd = (await _productRepo.GetIdAllIncludeFilterAsync(
                        i => i.Id == id,
                        i => i.ProductImages,
                        i => i.ProductComments
                        )).FirstOrDefault();

            if (prd == null) return NotFound();

            try
            {
                var imagesToDelete = prd.ProductImages.ToList();
                foreach (var image in imagesToDelete)
                {
                    await _productImageRepo.DeleteAsync(image);
                }

                // ProductComments koleksiyonunun bir kopyasını oluşturun
                var commentsToDelete = prd.ProductComments.ToList();
                foreach (var comment in commentsToDelete)
                {
                    await _commentRepo.DeleteAsync(comment);
                }

                await _productRepo.DeleteAsync(prd);
            }
            catch (Exception ex)
            {
                // Hata mesajını loglayın veya geri döndürün
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

            return NoContent();
        }

        private static SellerProductListDTO ProductListToDTO(Product p)
        {
            return new SellerProductListDTO
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                ImageUrlList = p.ProductImages.Select(i => i.Url ?? "").Where(url => url != "").ToList()!,
                Details = p.Details,
                StockAmount = p.StockAmount,
                Enabled = p.Enabled,
                IsConfirmed = p.IsConfirmed,
                CategoryId = p.CategoryId,
                CategoryName = p.CategoryFk!.Name ?? "",
                CategoryColor = p.CategoryFk!.Color ?? "",
                SellerName = $"{p.UserFk!.FirstName} {p.UserFk.LastName}",
                CommentCount = p.ProductComments.Count,
                OrderCount = p.OrderItems.Count,
                CartCount = p.CartItems.Count,
                CreatedAt = p.CreatedAt.ToString("dd.MM.yyyy"),
            };
        }

        private static Product ProductUpdateToDTO(SellerProductCreateOrUpdateDTO p, Product prd)
        {
            prd.Id = p.Id;
            prd.Name = p.Name;
            prd.Price = p.Price;
            prd.Details = p.Details;
            prd.StockAmount = p.StockAmount;
            prd.CategoryId = p.CategoryId;
            prd.Enabled = p.Enabled;

            if (p.ImageList.Count > 0)
            {
                prd.ProductImages.Clear();
                prd.ProductImages = p.ImageList.Select(i =>
                                    new ProductImage()
                                    {
                                        Url = i,
                                        ProductId = prd.Id,
                                        UserId = prd.UserId
                                    }
                                ).ToList();
            }

            return prd;
        }

        private List<ProductImage> ProductImagesUpdateToDTO(SellerProductCreateOrUpdateDTO p, Product prd)
        {
            if (p.ImageList.Count > 0)
            {
                prd.ProductImages.Clear();
                prd.ProductImages = p.ImageList.Select(i =>
                    new ProductImage()
                    {
                        Url = i,
                        ProductId = p.Id,
                        UserId = p.SellerId
                    }
                ).ToList();
            }
            return prd.ProductImages;

        }

        private static SellerProductCreateOrUpdateDTO ProductDetailToDTO(Product product, int sellerId)
        {
            return new SellerProductCreateOrUpdateDTO()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Details = product.Details,
                StockAmount = product.StockAmount,
                SellerId = sellerId,
                CategoryId = product.CategoryId,
                Enabled = product.Enabled,
                ImageList = product.ProductImages.Select(i => i.Url ?? "").Where(url => url != "").ToList()
            };
        }

        private static Product ProductCreateToDTO(SellerProductCreateOrUpdateDTO p)
        {
            var prd = new Product();

            prd.Name = p.Name;
            prd.Price = p.Price;
            prd.Details = p.Details;
            prd.StockAmount = p.StockAmount;
            prd.CategoryId = p.CategoryId;
            prd.UserId = p.SellerId;
            prd.Enabled = p.Enabled;

            return prd;
        }

        private List<ProductImage> ProductImagesCreateToDTO(SellerProductCreateOrUpdateDTO p, Product product)
        {
            var imgList = p.ImageList.Select(i =>
                    new ProductImage()
                    {
                        Url = i,
                        ProductId = product.Id,
                        UserId = product.UserId
                    }).ToList();

            return imgList;
        }
    }
}
