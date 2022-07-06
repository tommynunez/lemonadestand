using System;
namespace LemonadeStand.Abstractions.Struct
{
	public struct ProductLogMessages
	{
        public const string PRODUCT_INVOKE_DELETE_SERVICE = "Invoking service delete method";
        public const string PRODUCT_INVOKE_GETALL_SERVICE = "Invoking service get all method";
        public const string PRODUCT_INVOKE_GETBYID_SERVICE = "Invoking service get by id method";
        public const string PRODUCT_INVOKE_INSERT_SERVICE = "Invoking service insert method";
        public const string PRODUCT_INVOKE_UPDATE_SERVICE = "Invoking service update method";
        public const string PRODUCT_INVOKE_DELETE_SERVICE_ERROR = "Error invoking service delete method";
        public const string PRODUCT_INVOKE_GETALL_SERVICE_ERROR = "Error invoking service get all method";
        public const string PRODUCT_INVOKE_GETBYID_SERVICE_ERROR = "Error invoking service get by id method";
        public const string PRODUCT_INVOKE_INSERT_SERVICE_ERROR = "Error invoking service insert method";
        public const string PRODUCT_INVOKE_UPDATE_SERVICE_ERROR = "Error invoking service update method";
    }
}

