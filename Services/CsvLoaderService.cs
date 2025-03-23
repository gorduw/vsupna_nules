using System.Collections.ObjectModel;
using System.Data;
using vstupna.Models;

namespace vstupna.Services
    {
        public static class CsvLoaderService
        {
            // Helper method to convert "Так"/"Ні" to bool?
            private static bool? ToBool(object? value)
            {
                if (value == null) return null;
                var text = value.ToString()?.Trim().ToLower();
                if (text == "так") return true;
                if (text == "ні") return false;
                return null;
            }

            public static ObservableCollection<StudentRecord> LoadFromDataTable(DataTable table)
            {
                var records = new ObservableCollection<StudentRecord>();

                // Assuming row 0 has column headers
                for (int i = 1; i < table.Rows.Count; i++)
                {
                    var row = table.Rows[i];

                    var record = new StudentRecord
                    {
                        // 0
                        ApplicationId = row[0]?.ToString(),
                        // 1
                        PersonId = row[1]?.ToString(),
                        // 2
                        OfferType = row[2]?.ToString(),
                        // 3
                        IsForeigner = ToBool(row[3]),
                        // 4
                        ProgramName = row[4]?.ToString(),
                        // 5
                        OKR = row[5]?.ToString(),
                        // 6
                        AdmissionBasis = row[6]?.ToString(),
                        // 7
                        Specialty = row[7]?.ToString(),
                        // 8
                        Specialization = row[8]?.ToString(),
                        // 9
                        StudyForm = row[9]?.ToString(),
                        // 10
                        Course = row[10]?.ToString(),
                        // 11
                        Faculty = row[11]?.ToString(),
                        // 12
                        IsShortStudyTerm = ToBool(row[12]),
                        // 13
                        IsElectronic = ToBool(row[13]),
                        // 14
                        ApplicantName = row[14]?.ToString(),
                        // 15
                        ContactPhone = row[15]?.ToString(),
                        // 16
                        Email = row[16]?.ToString(),
                        // 17
                        Gender = row[17]?.ToString(),
                        // 18
                        IsCitizenOfUkraine = ToBool(row[18]),
                        // 19
                        ApplicationStatus = row[19]?.ToString(),
                        // 20
                        PersonalFileCode = row[20]?.ToString(),
                        // 21
                        CompetitionScore = row[21]?.ToString(),
                        // 22
                        Priority = row[22]?.ToString(),
                        // 23
                        RankOrderWithSameScore = row[23]?.ToString(),
                        // 24
                        IsGovCompetition = ToBool(row[24]),
                        // 25
                        IsContractCompetition = ToBool(row[25]),
                        // 26
                        CompetitionType = row[26]?.ToString(),
                        // 27
                        IsInterviewRecommended = ToBool(row[27]),
                        // 28
                        IsOriginalSubmitted = ToBool(row[28]),
                        // 29
                        IsOriginalLocationCertSubmitted = ToBool(row[29]),
                        // 30
                        ForeignerApplicationCategory = row[30]?.ToString(),
                        // 31
                        BenefitsCategories = row[31]?.ToString(),
                        // 32
                        ActNumber = row[32]?.ToString(),
                        // 33
                        CancellationReasons = row[33]?.ToString(),
                        // 34
                        IsClaiming200Points = ToBool(row[34]),
                        // 35
                        IsRuralCoefficient = ToBool(row[35]),
                        // 36
                        IsQuota3 = ToBool(row[36]),
                        // 37
                        EnrollmentOrder = row[37]?.ToString(),
                        // 38
                        DismissalReasons = row[38]?.ToString(),
                        // 39
                        IsContract = ToBool(row[39]),
                        // 40
                        IsBudget = ToBool(row[40]),
                        // 41
                        ContractOnlyReason = row[41]?.ToString(),
                        // 42
                        ContractOnlyReasonDescription = row[42]?.ToString(),
                        // 43
                        IsDegreeAlreadyBudget = ToBool(row[43]),
                        // 44
                        HasRightForAnotherBudgetEducation = ToBool(row[44]),
                        // 45
                        IsSameOrRelatedField = ToBool(row[45]),
                        // 46
                        IsObtainingSameOrHigherDegree = ToBool(row[46]),
                        // 47
                        IsAdditionalExamsRequired = ToBool(row[47]),
                        // 48
                        DocumentType = row[48]?.ToString(),
                        // 49
                        DocumentSeries = row[49]?.ToString(),
                        // 50
                        DocumentNumber = row[50]?.ToString(),
                        // 51
                        DocumentIssueDate = row[51]?.ToString(),
                        // 52
                        DocumentIssuedBy = row[52]?.ToString(),
                        // 53
                        IsHonors = ToBool(row[53]),
                        // 54
                        IsScanAdded = ToBool(row[54]),
                        // 55
                        ApplicationAddedTime = row[55]?.ToString(),
                        // 56
                        IsZNOChangesRequired = ToBool(row[56]),
                        // 57
                        IsRecommendedByAddressPlacement = ToBool(row[57]),
                        // 58
                        CompetitionTypeByAddressPlacement = row[58]?.ToString(),
                        // 59
                        PriorityByAddressPlacement = row[59]?.ToString(),
                        // 60
                        IsRecommendedForCanceledProposal = ToBool(row[60]),
                        // 61
                        LastChangeTime = row[61]?.ToString(),
                        // 62
                        WhoAddedApplication = row[62]?.ToString(),
                        // 63
                        AverageEducationScore = row[63]?.ToString(),
                        // 64
                        ZNOUkrainianLang = row[64]?.ToString(),
                        // 65
                        ZNOUkrainianLangLit = row[65]?.ToString(),
                        // 66
                        ZNOHistoryUkraine = row[66]?.ToString(),
                        // 67
                        ZNOMath = row[67]?.ToString(),
                        // 68
                        ZNOBiology = row[68]?.ToString(),
                        // 69
                        ZNOGeography = row[69]?.ToString(),
                        // 70
                        ZNOPhysics = row[70]?.ToString(),
                        // 71
                        ZNOChemistry = row[71]?.ToString(),
                        // 72
                        ZNOEnglish = row[72]?.ToString(),
                        // 73
                        ZNOFrench = row[73]?.ToString(),
                        // 74
                        ZNOGerman = row[74]?.ToString(),
                        // 75
                        ZNOSpanish = row[75]?.ToString(),
                        // 76
                        DPO = row[76]?.ToString(),
                        // 77
                        DPOSeries = row[77]?.ToString(),
                        // 78
                        DPONumber = row[78]?.ToString(),
                        // 79
                        DPOIssueDate = row[79]?.ToString(),
                        // 80
                        DPOValidUntil = row[80]?.ToString(),
                        // 81
                        RNOKPP = row[81]?.ToString()
                    };

                    records.Add(record);
                }

                return records;
            }
        }
    }


    // Новий метод для завантаження даних з DataTable
    /*
    public static ObservableCollection<StudentRecord> LoadFromDataTable(DataTable table)
        {
            var records = new ObservableCollection<StudentRecord>();

            // Припускаємо, що перший рядок таблиці містить заголовки
            for (int i = 1; i < table.Rows.Count; i++)
            {
                var row = table.Rows[i];
                var record = new StudentRecord
                {
                    // Призначте поля відповідно до індексів колонок
                    Id = row[0]?.ToString(),
                    FirstName = row[1]?.ToString(),
                    LastName = row[2]?.ToString(),
                    PassportDetails = row[3]?.ToString() // Приклад, змініть індекси за необхідністю
                };

                records.Add(record);
            }
            return records;
        } */

        // Залиште старий метод для завантаження CSV, якщо знадобиться в майбутньому

