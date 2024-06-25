using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YSLDotNetCore.PizzaAPI.Db;

namespace YSLDotNetCore.PizzaAPI.Features.Pizza
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public PizzaController()
        {
            _appDbContext = new AppDbContext();
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var list = await _appDbContext.Pizzas.ToListAsync();
            return Ok(list);
        }

        [HttpGet("Extra")]
        public async Task<IActionResult> GetExtraAsync()
        {
            var list = await _appDbContext.PizzaExtras.ToListAsync();
            return Ok(list);
        }

        [HttpGet("Order/{invoiceNo}")]
        public async Task<IActionResult> GetOrderAsync(string invoiceNo)
        {
            var item = await _appDbContext.PizzaOrders.FirstOrDefaultAsync(x => x.PizzaOrderInvoiceNo == invoiceNo);
            var list = await _appDbContext.PizzaOrderDetails.Where(x => x.PizzaOrderInvoiceNo == invoiceNo).ToListAsync();
            SearchOrderResponse searchOrderResponse = new SearchOrderResponse()
            {
                OrderModel = item,
                Details = list
            };
            return Ok(searchOrderResponse);
        }

        [HttpPost("Order")]
        public async Task<IActionResult> OrderAsync(OrderRequest orderRequest)
        {
            var itemPizza = await _appDbContext.Pizzas.FirstOrDefaultAsync(x => x.Id == orderRequest.PizzaId);
            var total = itemPizza.Price;

            if (orderRequest.Extras.Length > 0)
            {
                //select * from Tbl_PizzaExtra where PizzaExtraId in (1,2,3,4)
                //foreach(var item in orderRequest.Extras)
                //{
                    //
                //}
                var listExtra = await _appDbContext.PizzaExtras.Where(x => orderRequest.Extras.Contains(x.PizzaExtraId)).ToListAsync();
                total += listExtra.Sum(x => x.Price);
            }
            var invoiceNo = DateTime.Now.ToString("yyyyMMddHHmmss");
            PizzaOrderModel pizzaOrderModel = new PizzaOrderModel()
            {
                PizzaId = orderRequest.PizzaId,
                PizzaOrderInvoiceNo = invoiceNo,
                TotalAmount = total
            };

            List<PizzaOrderDetailModel> pizzaOrderDetailModel = orderRequest.Extras.Select(x => new PizzaOrderDetailModel
            {
                PizzaExtraId = x,
                PizzaOrderInvoiceNo = invoiceNo
            }).ToList();
            await _appDbContext.AddAsync(pizzaOrderModel);
            await _appDbContext.AddRangeAsync(pizzaOrderDetailModel);
            await _appDbContext.SaveChangesAsync();

            OrderResponse orderResponse = new OrderResponse()
            {
                InvoiceNo = invoiceNo,
                TotalAmout = total,
                message = "Thank you for your orders! Enjoy your pizza!"
            };
            return Ok(orderResponse);
        }
    }
}
