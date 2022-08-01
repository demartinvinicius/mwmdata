using System;
using System.Collections.Generic;

namespace mwmdata
{
    public partial class ManufacturingResult
    {
        public Guid Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public Guid ManufacturingOperationId { get; set; }
        public string? PlainData { get; set; }
        public string? EffectiveDataBkp { get; set; }
        public string? EffectiveData { get; set; }
    }
}
