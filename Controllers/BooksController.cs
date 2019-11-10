using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using BookStore.Enums;
using BookStore.Helpers;
using BookStore.Interfaces;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
  [Route("api/[controller]")]
  public class BooksController : Controller
  {
    private readonly IBookRepository _bookRepository;
    public BooksController(IBookRepository bookRepository)
    {
      _bookRepository = bookRepository;
    }

    [HttpGet("Get")]
    public async Task<IEnumerable<BookInfo>> GetBooks(string searchPhrase)
    {
      return await _bookRepository.GetBooks(searchPhrase);
    }

    [HttpGet("DeliveryCosts")]
    public IEnumerable<BookDeliveryOption> GetDeliveryCosts(DateTime date)
    {
      return DeliveryCostCalculator.GetCosts(date);
    }

    [HttpPost("SubmitOrder")]
    public string BuyBook([FromBody] BuyBookModel model)
    {
      if (model.DeliveryService == "Motorbike")
      {
        DateTime deliveryDate = DateTime.Now.AddDays(random.Next(0, 7));
        return DeliveryInfoGenerator.Generate(new MotorbikeDeliveryInfo
        {
          Driver = RandomString(random.Next(5, 15)),
          Mobile = random.Next(640000000, 649999999).ToString(),
          DeliveryCost = DeliveryCostCalculator.GetCost(DeliveryType.Motorbike, deliveryDate),
          DeliveryDate = deliveryDate
        });
      }
      else if (model.DeliveryService == "Train")
      {
        DateTime arrivalDate = DateTime.Now.AddDays(random.Next(1, 7));
        return DeliveryInfoGenerator.Generate(new TrainDeliveryInfo
        {
          TrainNo = random.Next(100, 999).ToString(),
          ArrivalDate = arrivalDate,
          DeliveryCost = DeliveryCostCalculator.GetCost(DeliveryType.Train, arrivalDate),
          StationName = RandomString(random.Next(5, 15))
        });
      }
      else if (model.DeliveryService == "Aircraft")
      {
        DateTime arrivalDate = DateTime.Now.AddDays(random.Next(0, 3));
        return DeliveryInfoGenerator.Generate(new AircraftDeliveryInfo
        {
          FlightNo = random.Next(100, 999).ToString(),
          ArrivalDate = arrivalDate,
          DeliveryCost = DeliveryCostCalculator.GetCost(DeliveryType.Aircraft, arrivalDate),
          GateNumber = random.Next(1, 500).ToString()
        });
      }
      else
      {
        throw new Exception("Wrong delivery service");
      }
    }

    private static Random random = new Random();
    private static string RandomString(int length)
    {
      const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
      return new string(Enumerable.Repeat(chars, length)
          .Select(s => s[random.Next(s.Length)]).ToArray());
    }
  }
}
