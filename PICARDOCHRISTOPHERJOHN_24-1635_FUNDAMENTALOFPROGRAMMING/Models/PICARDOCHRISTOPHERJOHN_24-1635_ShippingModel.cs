using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace PICARDOCHRISTOPHERJOHN_24_1635_FUNDAMENTALOFPROGRAMMING.Models;

public class PICARDOCHRISTOPHERJOHN_24_1635_ShippingModel
{
    [Required]
    [Range(typeof(decimal), "0", "1000000")]
    public decimal? OrderTotal { get; set; }

    public bool IsMember { get; set; }

    [BindNever]
    public string? Result { get; private set; }

    public void Calculate()
    {
        decimal fee;
        if (OrderTotal >= 1000)
        {
            if (IsMember)
                fee = 0;
            else
                fee = 50;
        }
        else
        {
            if (IsMember)
                fee = 50;
            else
                fee = 100;
        }
        Result = $"Shipping fee: ₱{fee:F2}";
    }
}
