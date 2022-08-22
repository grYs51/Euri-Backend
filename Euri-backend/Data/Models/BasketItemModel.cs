using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Euri_backend.Data.Models;


public class BasketItemModel
{
    public  int Id { get; set; }
    public int ProductId { get; set; }
    public ProductModel Product { get; set; }
    public int BasketId { get; set; }
    public BasketModel Basket { get; set; }

    public int Quantity { get; set; }
    
    
}