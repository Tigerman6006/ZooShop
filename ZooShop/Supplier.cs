using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooShop
{
    public class Supplier
    {
        private int supplierCode;
        private string name;
        private string phoneNumber;
        private int deliveryLeadTime;
        private List<ReplenishmentRequest> replenishmentRequests = new List<ReplenishmentRequest>();
        private Supplier(int supplierCode, string name, string phoneNumber, int deliveryLeadTime)
        {
            this.supplierCode = supplierCode;
            this.name = name;
            this.phoneNumber = phoneNumber;
            this.deliveryLeadTime = deliveryLeadTime;
        }
        public static Supplier CreateSupplier(int supplierCode, string name, string phoneNumber, int deliveryLeadTime)
        {
            return new Supplier(supplierCode, name, phoneNumber, deliveryLeadTime);
        }
        public int SupplierCode
        {
            get { return supplierCode; }
            set { supplierCode = value; }
        }
        public string Name
        {
            get { return name; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    name = value;
                }
            }
        }
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    phoneNumber = value;
                }
            }
        }
        public int DeliveryLeadTime
        {
            get { return deliveryLeadTime; }
            set { deliveryLeadTime = value; }
        }
        public List<ProductBatch> GetActiveContracts()
        {
            List<ProductBatch> activeContracts = ProductBatch.GetAllBatches()
                .Where(batch => batch.Supplier == this)
                .ToList();

            return activeContracts;
        }
  
        public void ReceiveRequest(ReplenishmentRequest request)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            if (replenishmentRequests.Contains(request))
                throw new InvalidOperationException(
                    "This request has already been received.");

            replenishmentRequests.Add(request);
        }
        public void AcceptRequest(ReplenishmentRequest request)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            if (!replenishmentRequests.Contains(request))
                throw new InvalidOperationException(
                    "This request does not belong to this supplier.");

            request.AcceptBySupplier(this);
        }

        public IReadOnlyList<ReplenishmentRequest> GetReplenishmentRequests()
        {
            return replenishmentRequests.AsReadOnly();
        }
    }
}
