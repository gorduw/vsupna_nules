using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using vstupna.Commands;
using vstupna.Models;
using vstupna.Services;

namespace vstupna.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private object _currentView;
        public object CurrentView
        {
            get => _currentView;
            set { _currentView = value; OnPropertyChanged(); }
        }

        public ICommand ShowFileLoadCommand { get; }
        public ICommand ShowSearchCommand { get; }
        public ICommand ShowDocumentsCommand { get; }
        public ICommand ShowDocumentEditorCommand { get; }
        public ICommand ShowCsvPreviewCommand { get; }

        public MainViewModel()
        {
            // Початковий екран – завантаження файлу
            CurrentView = new FileLoadViewModel();

            ShowFileLoadCommand = new RelayCommand(_ => CurrentView = new FileLoadViewModel());

            ShowSearchCommand = new RelayCommand(
                _ => CurrentView = new SearchViewModel(),
                _ => DataStore.IsDataLoaded // Активна лише якщо дані завантажено
            );

            ShowDocumentsCommand = new RelayCommand(
                studentObj =>
                {
                    if (studentObj is StudentRecord student)
                    {
                        CurrentView = new DocumentsViewModel(student);
                    }
                },
                _ => DataStore.IsDataLoaded // Активна лише якщо дані завантажено
            );

            // Редактор документів завжди доступний
            ShowDocumentEditorCommand = new RelayCommand(
                _ => CurrentView = new DocumentEditorViewModel(),
                _ => DataStore.IsDataLoaded);

            ShowCsvPreviewCommand = new RelayCommand(
                _ => CurrentView = new CsvPreviewViewModel(),
                _ => DataStore.IsDataLoaded // Активна лише якщо дані завантажено
            );
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
