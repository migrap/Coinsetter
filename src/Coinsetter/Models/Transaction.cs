using Newtonsoft.Json;
using System;

namespace Coinsetter.Models {
    public class Transaction {
        [JsonProperty("uuid")]
        public string TransactionUuid { get; set; }

        [JsonProperty("customerUuid")]
        public string CustomerUuid { get; set; }

        [JsonProperty("accountUuid")]
        public string AccountUuid { get; set; }
        
        [JsonProperty("amount")]
        public double Amount { get; set; }
        
        [JsonProperty("originalAmount")]
        public double OriginalAmount { get; set; }
        
        [JsonProperty("currenceCode")]
        public string CurrencyCode { get; set; }
        
        [JsonProperty("orderUuid")]
        public string OrderUuid { get; set; }
        
        [JsonProperty("orderNumber")]
        public string OrderNumber { get; set; }
        
        [JsonProperty("referenceNumber")]
        public string ReferecneNumber { get; set; }
        
        [JsonProperty("transactionCategoryDescription")]
        public string TransactionCategoryDescription { get; set; }

        [JsonProperty("transactionCategoryName")]
        public string TransactionCategoryName { get; set; }
        
        [JsonProperty("transferTypeDescription")]
        public string TransferTypeDescription { get; set; }

        [JsonProperty("transferTypeName")]
        public string TransferTypeName { get; set; }

        [JsonProperty("createDate")]
        public DateTimeOffset Created { get; set; }
    }
}


