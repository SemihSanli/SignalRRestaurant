using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DTOLayer.FeatureDTO;
using SignalR.DTOLayer.ProductDTO;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var value = _mapper.Map<List<ResultProductDTO>>(_productService.TGetListAll());
            return Ok(value);
        }
        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            var context = new SignalRContext();
            var values = context.Products.Include(x => x.Category).Select(y => new ResultProductWithCategory
            {
                ProductDescription = y.ProductDescription,
                ProductImageURL = y.ProductImageURL,
                ProductName = y.ProductName,
                ProductID = y.ProductID,
                ProductPrice = y.ProductPrice,
                CategoryName = y.Category.CategoryName
            }).ToList();
            return Ok(values.ToList());
        }
        [HttpGet("ProductCountByHamburger")]
        public IActionResult ProductCountByHamburger()
        {
            return Ok(_productService.TProductCountByCategoryNameHamburger());
        }
        [HttpGet("ProductCountByDrink")]
        public IActionResult ProductCountByDrink()
        {
            return Ok(_productService.TProductCountByCategoryNameDrink());
        }
        [HttpGet("ProductPriceAvg")]
        public IActionResult ProductPriceAvg()
        {
            return Ok(_productService.TProductPriceAvg());
        }
        [HttpGet("ProductNameByMaxPrice")]
        public IActionResult ProductNameByMaxPrice()
        {
            return Ok(_productService.TProductNameByMaxPrice());
        }
        [HttpGet("ProductNameByMinPrice")]
        public IActionResult ProductNameByMinPrice()
        {
            return Ok(_productService.TProductNameByMinPrice());
        }
        [HttpGet("ProductAvgPriceByHamburger")]
        public IActionResult ProductAvgPriceByHamburger()
        {
            return Ok(_productService.TProductAvgPriceByHamburger());
        }
        [HttpPost]
        public IActionResult CreateProduct(CreateProductDTO createProductDTO)
        {
            _productService.TAdd(new Product()
            {
              ProductDescription = createProductDTO.ProductDescription,
              ProductName = createProductDTO.ProductName,
              ProductImageURL = createProductDTO.ProductImageURL,
              ProductPrice = createProductDTO.ProductPrice,
              ProductStatus = createProductDTO.ProductStatus,
              CategoryID=createProductDTO.CategoryID

            });
            return Ok("Ürün Bilgileri Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.TGetByID(id);
            _productService.TDelete(value);
            return Ok("Ürün Bilgileri Silindi");
        }

        [HttpGet("ProductCount")]
        public IActionResult ProductCount(int id)
        {
            return Ok(_productService.TProductCount());
        }

        [HttpGet("{id}")]
        public IActionResult ProductList(int id)
        {
            var value = _productService.TGetByID(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDTO updateProductDTO)
        {
            _productService.TUpdate(new Product()
            {

               ProductID = updateProductDTO.ProductID,
               ProductDescription = updateProductDTO.ProductDescription,
               ProductName = updateProductDTO.ProductName,
               ProductStatus= updateProductDTO.ProductStatus,
               ProductPrice= updateProductDTO.ProductPrice,
               ProductImageURL= updateProductDTO.ProductImageURL,
               CategoryID = updateProductDTO.CategoryID
            });
            return Ok("Ürün Bilgileri Güncellendi");
        }
    }
}
