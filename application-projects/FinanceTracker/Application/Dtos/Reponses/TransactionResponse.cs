using Domain.Entities;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos.Reponses
{
    public record TransactionResponse(
        Money Amount,
        Category Category,
        string? Description,
        TransactionType Type,
        DateTime CreatedAt);
}
