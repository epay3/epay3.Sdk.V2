using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace epay3.Web.Api.Sdk.V2.Models
{
    /// <summary>
    /// Creates a payment token.
    /// </summary>
    [DataContract]
    public class PostTokenRequestModel : IEquatable<PostTokenRequestModel>
    {
        [DataMember(Name = "payer", EmitDefaultValue = false)]
        public string Payer { get; set; }

        [DataMember(Name = "emailAddress", EmitDefaultValue = false)]
        public string EmailAddress { get; set; }

        [DataMember(Name = "creditCardInformation", EmitDefaultValue = false)]
        public CreditCardInformationModel CreditCardInformation { get; set; }

        [DataMember(Name = "bankAccountInformation", EmitDefaultValue = false)]
        public BankAccountInformationModel BankAccountInformation { get; set; }

        [DataMember(Name = "attributeValues", EmitDefaultValue = false)]
        public Dictionary<string, string> AttributeValues { get; set; }

        public override string ToString() => JsonConvert.SerializeObject(this, Formatting.Indented);

        public override bool Equals(object obj) => Equals(obj as PostTokenRequestModel);

        public bool Equals(PostTokenRequestModel other) =>
            other != null &&
            Payer == other.Payer &&
            EmailAddress == other.EmailAddress &&
            Equals(CreditCardInformation, other.CreditCardInformation) &&
            Equals(BankAccountInformation, other.BankAccountInformation) &&
            (AttributeValues?.SequenceEqual(other.AttributeValues) ?? other.AttributeValues == null);

        public override int GetHashCode() => HashCode.Combine(Payer, EmailAddress, CreditCardInformation, BankAccountInformation, AttributeValues);
    }
}
