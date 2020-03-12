﻿using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace DataAccess
{
    public class DMAMeterReadingEntity : TableEntity
    {
        // By default, when creating a new entity, the PartitionKey is set to the current year, and the RowKey is a GUID. Insert the ticks in the beginning of RowKey because the result returned by a query is ordered by PartitionKey and then RowKey. 
        public DMAMeterReadingEntity()
            : base(DateTime.UtcNow.ToString("yyyy"),
                $"{DateTime.MaxValue.Ticks - DateTime.Now.Ticks:10}_{Guid.NewGuid()}")
        { }

        // partitionKey = DMA, rowKey = reading datetime ticks
        public DMAMeterReadingEntity(string partitionKey, string rowKey)
            : base(partitionKey, rowKey)
        { }

        public DateTime CreatedOn { get; set; }
        public string MeterID { get; set; }
        public string Reading { get; set; }
        public bool Encrypted { get; set; }
    }

}
