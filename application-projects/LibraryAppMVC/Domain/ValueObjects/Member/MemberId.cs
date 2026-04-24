using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ValueObjects.Member
{
    public sealed record MemberId
    {
        public Guid Value { get;}

        private MemberId(Guid value)
        {
            if (value == Guid.Empty)
                throw new ArgumentException("MemberId cannot be empty.");

            Value = value;
        }

        public static MemberId New() =>new MemberId(Guid.NewGuid());
        public static MemberId From(Guid value) => new MemberId(value);
    }
}
