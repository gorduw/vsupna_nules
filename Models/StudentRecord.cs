namespace vstupna.Models
{
    public class StudentRecord
    {
        public string DisplayInfo => $"{ApplicantName} ({ApplicationId})";

        // 0. Ід заявки
        public string? ApplicationId { get; set; }

        // 1. Ід персони
        public string? PersonId { get; set; }

        // 2. Тип пропозиції
        public string? OfferType { get; set; }

        // 3. Чи іноземець (Так/Ні)
        public bool? IsForeigner { get; set; }

        // 4. Назва КП
        public string? ProgramName { get; set; }

        // 5. ОКР
        public string? OKR { get; set; }

        // 6. Вступ на основі
        public string? AdmissionBasis { get; set; }

        // 7. Спеціальність
        public string? Specialty { get; set; }

        // 8. Спеціалізація
        public string? Specialization { get; set; }

        // 9. Форма навчання
        public string? StudyForm { get; set; }

        // 10. Курс
        public string? Course { get; set; }

        // 11. Структурний підрозділ
        public string? Faculty { get; set; }

        // 12. Чи скорочений термін навчання (Так/Ні)
        public bool? IsShortStudyTerm { get; set; }

        // 13. Чи електронна заява (Так/Ні)
        public bool? IsElectronic { get; set; }

        // 14. Вступник (ПІБ + дата народження)
        public string? ApplicantName { get; set; }

        // 15. Контактний номер
        public string? ContactPhone { get; set; }

        // 16. Електронна адреса
        public string? Email { get; set; }

        // 17. Стать
        public string? Gender { get; set; }

        // 18. Чи громадянин України (Так/Ні)
        public bool? IsCitizenOfUkraine { get; set; }

        // 19. Статус заявки
        public string? ApplicationStatus { get; set; }

        // 20. Номер (шифр) особової справи
        public string? PersonalFileCode { get; set; }

        // 21. Конкурсний бал
        public string? CompetitionScore { get; set; }

        // 22. Пріоритет
        public string? Priority { get; set; }

        // 23. Черговість в рейтингу з однаковою кількістю балів
        public string? RankOrderWithSameScore { get; set; }

        // 24. Бере участь в конкурсі на місця державного та регіонального замовлення (Так/Ні)
        public bool? IsGovCompetition { get; set; }

        // 25. Бере участь в конкурсі на місця за кошти фізичних та юридичних осіб (Так/Ні)
        public bool? IsContractCompetition { get; set; }

        // 26. Тип конкурсу, за яким отримано рекомендацію
        public string? CompetitionType { get; set; }

        // 27. Чи рекомендовано за співбесідою (Так/Ні)
        public bool? IsInterviewRecommended { get; set; }

        // 28. Чи подано оригінал (Так/Ні)
        public bool? IsOriginalSubmitted { get; set; }

        // 29. Чи подано довідку про місцезнаходження оригіналів (Так/Ні)
        public bool? IsOriginalLocationCertSubmitted { get; set; }

        // 30. Категорія заяви іноземця
        public string? ForeignerApplicationCategory { get; set; }

        // 31. Пільгові категорії
        public string? BenefitsCategories { get; set; }

        // 32. Номер акту
        public string? ActNumber { get; set; }

        // 33. Причини скасування
        public string? CancellationReasons { get; set; }

        // 34. Особа претендує на зарахування 200 балів (Так/Ні)
        public bool? IsClaiming200Points { get; set; }

        // 35. Особа претендує на застосування сільського коефіцієнту (Так/Ні)
        public bool? IsRuralCoefficient { get; set; }

        // 36. Претендує на квоту 3 (Так/Ні)
        public bool? IsQuota3 { get; set; }

        // 37. Наказ про зарахування
        public string? EnrollmentOrder { get; set; }

        // 38. Причини відрахування
        public string? DismissalReasons { get; set; }

        // 39. Претендує на контракт (Так/Ні)
        public bool? IsContract { get; set; }

        // 40. Претендує на бюджет (Так/Ні)
        public bool? IsBudget { get; set; }

        // 41. Причина допуску лише на контракт
        public string? ContractOnlyReason { get; set; }

        // 42. Опис причини допуску лише на контракт для причини 'Інша'
        public string? ContractOnlyReasonDescription { get; set; }

        // 43. Чи здобувався ОКР уже за бюджет (Так/Ні)
        public bool? IsDegreeAlreadyBudget { get; set; }

        // 44. Право здобувати іншу освіту за бюджет (Так/Ні)
        public bool? HasRightForAnotherBudgetEducation { get; set; }

        // 45. Чи вступ на ту саму або споріднену галузь (Так/Ні)
        public bool? IsSameOrRelatedField { get; set; }

        // 46. Чи здобуває ступінь(рівень) або вищий (Так/Ні)
        public bool? IsObtainingSameOrHigherDegree { get; set; }

        // 47. Чи потрібно пройти додаткові вступні випробування (Так/Ні)
        public bool? IsAdditionalExamsRequired { get; set; }

        // 48. Тип документа
        public string? DocumentType { get; set; }

        // 49. Серія документа
        public string? DocumentSeries { get; set; }

        // 50. Номер документа
        public string? DocumentNumber { get; set; }

        // 51. Дата видачі документа
        public string? DocumentIssueDate { get; set; }

        // 52. Ким видано
        public string? DocumentIssuedBy { get; set; }

        // 53. Відзнака (Так/Ні?) 
        public bool? IsHonors { get; set; }

        // 54. Сканкопія додана (Так/Ні)
        public bool? IsScanAdded { get; set; }

        // 55. Час додання заяви до ЄДЕБО
        public string? ApplicationAddedTime { get; set; }

        // 56. Потрібно внести зміни в ЗНО (Так/Ні)
        public bool? IsZNOChangesRequired { get; set; }

        // 57. Чи рекомендовано за результатом адресного розміщення державного замовлення (Так/Ні)
        public bool? IsRecommendedByAddressPlacement { get; set; }

        // 58. Тип конкурсу, за яким одержано рекомендацію за результатом адресного розміщення ДЗ
        public string? CompetitionTypeByAddressPlacement { get; set; }

        // 59. Пріоритет заяви, яка отримала рекомендацію за результатом адресного розміщення ДЗ
        public string? PriorityByAddressPlacement { get; set; }

        // 60. Чи отримав рекомендацію на анульовану конкурсну пропозицію (Так/Ні)
        public bool? IsRecommendedForCanceledProposal { get; set; }

        // 61. Час останньої зміни
        public string? LastChangeTime { get; set; }

        // 62. Додав заяву
        public string? WhoAddedApplication { get; set; }

        // 63. Середній бал документа про освіту
        public string? AverageEducationScore { get; set; }

        // 64. ЗНО.Українська мова
        public string? ZNOUkrainianLang { get; set; }

        // 65. ЗНО.Українська мова та література
        public string? ZNOUkrainianLangLit { get; set; }

        // 66. ЗНО.Історія України
        public string? ZNOHistoryUkraine { get; set; }

        // 67. ЗНО.Математика
        public string? ZNOMath { get; set; }

        // 68. ЗНО.Біологія
        public string? ZNOBiology { get; set; }

        // 69. ЗНО.Географія
        public string? ZNOGeography { get; set; }

        // 70. ЗНО.Фізика
        public string? ZNOPhysics { get; set; }

        // 71. ЗНО.Хімія
        public string? ZNOChemistry { get; set; }

        // 72. ЗНО.Англійська мова
        public string? ZNOEnglish { get; set; }

        // 73. ЗНО.Французька мова
        public string? ZNOFrench { get; set; }

        // 74. ЗНО.Німецька мова
        public string? ZNOGerman { get; set; }

        // 75. ЗНО.Іспанська мова
        public string? ZNOSpanish { get; set; }

        // 76. ДПО
        public string? DPO { get; set; }

        // 77. ДПО.Серія
        public string? DPOSeries { get; set; }

        // 78. ДПО.Номер
        public string? DPONumber { get; set; }

        // 79. ДПО.Дата видачі
        public string? DPOIssueDate { get; set; }

        // 80. ДПО.Дійсний до
        public string? DPOValidUntil { get; set; }

        // 81. РНОКПП
        public string? RNOKPP { get; set; }

        // 82. Прізвище (Surname) – витягується з ApplicantName (формат: "Прізвище Ім'я Побатькові дд.мм.гггг")
        public string? Surname =>
            ApplicantName?.Split(' ') is string[] parts && parts.Length >= 2 ? parts[0] : null;

        // 83. Ім'я (FirstName)
        public string? FirstName =>
            ApplicantName?.Split(' ') is string[] parts && parts.Length >= 1 ? parts[1] : null;

        // 84. По батькові (Patronymic)
        public string? Patronymic =>
            ApplicantName?.Split(' ') is string[] parts && parts.Length >= 3 ? parts[2] : null;

        // 85. Дата народження (BirthDate) – очікується формат "дд.мм.гггг"
        public string? BirthDate =>
            ApplicantName?.Split(' ') is string[] parts && parts.Length >= 4 ? parts[3] : null;

        // 86. Повне ім'я (Fullname)
        public string? FullName => Surname + ' ' + FirstName + ' ' + Patronymic;

        // 87. Час навчання ОКР
        public string? OKRTimePeriod { get; set; }

    }
}
