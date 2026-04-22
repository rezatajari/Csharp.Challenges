using Domain.Entities;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos
{
    public record TransactionDto(Money Amount,Category Category,string? Desctiprion,TransactionType Type,DateTime CreatedAt)
}
