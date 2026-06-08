using System;

namespace MathLibrary
{
    public class BillingService
    {
        public double CalculateBill(string patientType, string paymentMethod, double amount, bool insuranceApproved)
        {
            if (amount <= 0)
                throw new ArgumentException("Amount must be positive");

            // 1. حساب التسعير بناءً على نوع المريض (تطبيق الشروط)
            double multiplier;
            if (patientType == "VIP") multiplier = 0.8;
            else if (patientType == "Regular") multiplier = 1.0;
            else if (patientType == "Emergency") multiplier = 1.2;
            else throw new ArgumentException("Invalid patient type");

            double afterDiscount = amount * multiplier;

            // 2. التحقق من حالة الدفع والتغطية التأمينية
            if (paymentMethod == "Insurance")
            {
                if (!insuranceApproved)
                    throw new InvalidOperationException("Insurance not approved");
                return afterDiscount * 0.5; // تغطية جزئية
            }
            else if (paymentMethod == "Cash")
            {
                return afterDiscount;
            }

            throw new ArgumentException("Invalid payment method");
        }
    }
}