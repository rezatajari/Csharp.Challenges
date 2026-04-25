using Domain.Entities;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos.Reponses
{
    public record AccountResponse(
        int Id,
        string Name,
        Money Balance,
        AccountType Type,
        Money? CreditLimit = null
        );
}
