using System;

namespace UnitTestingDemo
{
    public class Class1
    {
        // التابع الرئيسي بعد التعديل (أصبح تعقيده الدوري منخفض جداً ويساوي 2)
        public string EvaluateStudentGrade(double score, bool isLate, bool hasDiscountCode)
        {
            if (IsInvalidScore(score)) return "Invalid Score";

            score = ApplyLatePenalty(score, isLate);

            return GetFinalGrade(score, hasDiscountCode);
        }

        // تابع مساعد فرعي 1: للتحقق من صحة الدرجة المدخلة
        private bool IsInvalidScore(double score)
        {
            return score < 0 || score > 100;
        }

        // تابع مساعد فرعي 2: لتطبيق حسم التأخير
        private double ApplyLatePenalty(double score, bool isLate)
        {
            if (!isLate) return score;
            double newScore = score - 10;
            return newScore < 0 ? 0 : newScore;
        }

        // تابع مساعد فرعي 3: لتحديد النتيجة النهائية والخصم
        private string GetFinalGrade(double score, bool hasDiscountCode)
        {
            if (score >= 90)
            {
                return hasDiscountCode ? "A+ with Discount" : "A+";
            }
            return score >= 60 ? "Pass" : "Fail";
        }
    }
}