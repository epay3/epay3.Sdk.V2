using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace epay3.Web.Api.Sdk.V2.Models
{
    /// <summary>
    /// Provides details of a token.
    /// </summary>
    [DataContract]
    public class GetTokenResponseModel : IEquatable<GetTokenResponseModel>
    {
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        [DataMember(Name = "payer", EmitDefaultValue = false)]
        public string Payer { get; set; }

        [DataMember(Name = "emailAddress", EmitDefaultValue = false)]
        public string EmailAddress { get; set; }

        [DataMember(Name = "attributeValues", EmitDefaultValue = false)]
        public List<AttributeValueModel> AttributeValues { get; set; }

        [DataMember(Name = "transactionType", EmitDefaultValue = false)]
        public TransactionType? TransactionType { get; set; }

        [DataMember(Name = "maskedAccountNumber", EmitDefaultValue = false)]
        public string MaskedAccountNumber { get; set; }

        public override string ToString() => JsonConvert.SerializeObject(this, Formatting.Indented);

        public override bool Equals(object obj) => Equals(obj as GetTokenResponseModel);

        public bool Equals(GetTokenResponseModel other) =>
            other != null &&
            Id == other.Id &&
            Payer == other.Payer &&
            EmailAddress == other.EmailAddress &&
            (AttributeValues?.SequenceEqual(other.AttributeValues) ?? other.AttributeValues == null) &&
            TransactionType == other.TransactionType &&
            MaskedAccountNumber == other.MaskedAccountNumber;

        public override int GetHashCode() => HashCode.Combine(Id, Payer, EmailAddress, AttributeValues, TransactionType, MaskedAccountNumber);
    }
}
