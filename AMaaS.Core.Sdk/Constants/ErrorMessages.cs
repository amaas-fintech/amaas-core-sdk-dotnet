using System;
using System.Collections.Generic;
using System.Text;

namespace AMaaS.Core.Sdk.Constants
{
    public static class ErrorMessages
    {
        public const string AddressInvalid = "Invalid addresses attribute: {0}. Party ID {1} for Asset Manager {2}";
        public const string AddressPrimary = "Must set exactly one address as primary. Party ID {0} for Asset Manager {1}";
        public const string AMTypeInvalid = "Asset Manager Type: {0} is invalid.  Asset Manager: {1}";
        public const string AMAccountTypeInvalid = "Account Type: {0} is invalid.  Asset Manager: {1}";
        public const string BookTypeInvalid = "Invalid book type {0}. Book ID: {1} for Asset Manager: {2}";
        public const string CountryIdInvalid = "Country ID should be a ISO 3166-1 Alpha-3 code. Value: {0}";
        public const string CurrencyInvalid = "Invalid currency {0}. Transaction ID: {1} for asset manager: {1}";
        public const string EmailInvalid = "Invalid emails attribute: {0}. Party ID {1} for Asset Manager {2}";
        public const string EmailPrimary = "Must set exactly one email as primary. Party ID {0} for Asset Manager {1}";
        public const string EmailAddressInvalid = "Invalid email: {0}.";
        public const string AmendMissingPrevious = "Cannot find party to amend: ID {0} for Asset Manager {1}";
        public const string AmendMissingAttribute = "Partial amend failed for Asset Manager: {0} on party: {1} - Attribute: {2} does not exist";
        public const string DeactivateMissingPrevious = "Cannot Deactivate Party - Cannot Find ID: {0} for Asset Manager: {1}";
        public const string PartyStatusInvalid = "Invalid party status {0}. Party ID: {1} for Asset Manager: {2}";
        public const string TransactionActionInvalid = "Invalid transaction action {0}. Transaction ID: {1} for Asset Manager: {2}";
        public const string TransactionStatusInvalid = "Invalid transaction status {0}. Transaction ID: {1} for Asset Manager: {2}";
        public const string TransactionTypeInvalid = "Invalid transaction type {0}. Transaction ID: {1} for Asset Manager: {2}";
        public const string TransactionLinkNotFound = "Cannot remove link - not found";
    }
}
