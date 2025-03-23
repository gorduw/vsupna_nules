using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using vstupna.Models;
using vstupna.Services;

namespace vstupna.ViewModels
{
    public class CsvPreviewViewModel : INotifyPropertyChanged
    {
        // Колекція для відображення всіх записів Excel
        public ObservableCollection<StudentRecord> CsvRecords { get; set; }

        // Колекція для відображення у ComboBox або списку варіантів (наприклад, "Спеціальність")
        public ObservableCollection<string> SpecialtyOptions { get; set; }

        // Обрана спеціальність для фільтрації (якщо потрібно)
        private string _selectedSpecialty;
        public string SelectedSpecialty
        {
            get => _selectedSpecialty;
            set
            {
                if (_selectedSpecialty != value)
                {
                    _selectedSpecialty = value;
                    OnPropertyChanged();
                    ApplySpecialtyFilter();
                }
            }
        }

        // Повна копія даних із DataStore для фільтрації
        private ObservableCollection<StudentRecord> _allRecords;

        public CsvPreviewViewModel()
        {
            // Отримуємо дані із спільного сховища
            _allRecords = DataStore.Students;
            CsvRecords = new ObservableCollection<StudentRecord>(_allRecords);

            // Формуємо список унікальних значень спеціальностей із завантажених даних
            var specialties = _allRecords
                                .Select(r => r.Specialty)
                                .Where(s => !string.IsNullOrEmpty(s))
                                .Distinct()
                                .OrderBy(s => s)
                                .ToList();

            // Можна додати опцію "Всі"
            specialties.Insert(0, "Всі");

            SpecialtyOptions = new ObservableCollection<string>(specialties);

            // За замовчуванням вибираємо "Всі"
            SelectedSpecialty = "Всі";
        }

        // Метод для фільтрації записів за обраною спеціальністю
        private void ApplySpecialtyFilter()
        {
            CsvRecords.Clear();

            if (SelectedSpecialty == "Всі")
            {
                foreach (var rec in _allRecords)
                    CsvRecords.Add(rec);
            }
            else
            {
                foreach (var rec in _allRecords.Where(r => r.Specialty == SelectedSpecialty))
                    CsvRecords.Add(rec);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
