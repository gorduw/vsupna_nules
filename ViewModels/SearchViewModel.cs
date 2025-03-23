using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using vstupna.Commands;
using vstupna.Models;
using vstupna.Services;

namespace vstupna.ViewModels
{
    public class SearchViewModel : INotifyPropertyChanged
    {
        private string _searchText;
        private StudentRecord? _selectedStudent;

        public string SearchText
        {
            get => _searchText;
            set { _searchText = value; OnPropertyChanged(); }
        }

        public ObservableCollection<StudentRecord> SearchResults { get; set; }

        // Використовуємо одну властивість для зберігання вибраного студента
        public StudentRecord? SelectedStudent
        {
            get => _selectedStudent;
            set
            {
                if (_selectedStudent != value)
                {
                    _selectedStudent = value;
                    // Зберігаємо обраного студента у спільному сховищі
                    DataStore.SelectedStudent = _selectedStudent;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand SearchCommand { get; }

        // Використовуємо спільний список студентів із DataStore
        private ObservableCollection<StudentRecord> _students;

        private string _searchStatus = "";
        public string SearchStatus
        {
            get => _searchStatus;
            set { _searchStatus = value; OnPropertyChanged(); }
        }

        public SearchViewModel()
        {
            SearchText = "";
            SearchResults = new ObservableCollection<StudentRecord>();

            // Отримуємо список із спільного сховища. Якщо дані ще не завантажено, це буде порожня колекція.
            _students = DataStore.Students;

            SearchCommand = new RelayCommand(_ => ExecuteSearch());
        }

        private void ExecuteSearch()
        {
            SearchResults.Clear();

            if (string.IsNullOrWhiteSpace(SearchText))
            {
                SearchStatus = "Введіть текст для пошуку.";
                return;
            }

            if (_students == null || _students.Count == 0)
            {
                SearchStatus = "Список студентів не завантажено.";
                return;
            }

            foreach (var student in _students)
            {
                // Припустимо, що для пошуку використовуємо поле ApplicantName
                if (student.ApplicantName != null &&
                    student.ApplicantName.ToLower().Contains(SearchText.ToLower()))
                {
                    SearchResults.Add(student);
                }
            }

            SearchStatus = SearchResults.Count == 0 ? "Нічого не знайдено." : "";
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
