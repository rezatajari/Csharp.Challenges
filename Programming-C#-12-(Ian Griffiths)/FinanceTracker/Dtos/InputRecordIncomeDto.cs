using FinanceTracker.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceTracker.Dtos
{
    record class InputRecordTxDto(int accountId,Money amount,Category category,string? description);
}
