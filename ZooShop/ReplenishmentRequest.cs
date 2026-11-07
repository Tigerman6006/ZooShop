using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooShop
{
    public class ReplenishmentRequest
    {
        private int requestNumber;
        private DateTime creationDate;
        private int requiredQuantity;
        private Status status;
        private Product product;
        private static int nextRequestNumber = 1;
        private Supplier? supplier;
        private ReplenishmentRequest(int requestNumber, DateTime creationDate, int requiredQuantity, Status status, Product product)
        {
            this.requestNumber = requestNumber;
            this.creationDate = creationDate;
            this.requiredQuantity = requiredQuantity;
            this.status = status;
            this.product = product;
        }
        public static ReplenishmentRequest CreateRequest(int requiredQuantity, Product product)
        {
            return new ReplenishmentRequest(
                nextRequestNumber++,
                DateTime.Now,
                requiredQuantity,
                Status.None,
                product
            );
        }
        public int RequestNumber
        {
            get { return requestNumber; }
            set { requestNumber = value; }
        }
        public DateTime CreationDate
        {
            get { return creationDate; }
        }
        public int RequiredQuantity
        {
            get { return requiredQuantity; }
            set { requiredQuantity = value; }
        }
        public Status Status
        {
            get { return status; }
            set { status = value; }
        }
        public Product Product
        {
            get { return product; }
            set { if (value is not null) { product = value; } }
        }
        public Supplier? Supplier
        {
            get { return supplier; }
        }
        public void SendToSupplier(Supplier supplier)
        {
            if (supplier is null)
            {
                throw new ArgumentNullException(nameof(supplier));
            }

            if (status != Status.None)
            {
                throw new InvalidOperationException(
                    "This request has already been processed."
                );
            }

            this.supplier = supplier;
            supplier.ReceiveRequest(this);

            status = Status.Sent;
        }
        internal void AcceptBySupplier(Supplier supplier)
        {
            if (this.supplier != supplier)
                throw new InvalidOperationException(
                    "This supplier does not own this request.");

            if (status != Status.Sent)
                throw new InvalidOperationException(
                    "Only sent requests can be accepted.");

            Status = Status.InOrder;
        }

        public void CompleteRequest()
        {
            if (status != Status.InOrder)
                throw new InvalidOperationException(
                    "Only ordered requests can be completed.");

            Status = Status.Success;
        }

        public void FailRequest()
        {
            if (status != Status.InOrder)
                throw new InvalidOperationException(
                    "Only ordered requests can fail.");

            Status = Status.Failed;
        }
    }
}
