using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using vstupna.Commands;
using vstupna.Services;
using System.Data;
using ExcelDataReader;

namespace vstupna.ViewModels
{
    public class FileLoadViewModel : INotifyPropertyChanged
    {
        private string _statusMessage;
        public string StatusMessage
        {
            get => _statusMessage;
            set { _statusMessage = value; OnPropertyChanged(); }
        }

        public ICommand LoadFileCommand { get; }

        public FileLoadViewModel()
        {
            LoadFileCommand = new RelayCommand(_ => ExecuteLoadFile());
            StatusMessage = "Оберіть Excel-файл для завантаження...";
        }

        private void ExecuteLoadFile()
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                var path = openFileDialog.FileName;
                try
                {
                    System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

                    using (var stream = File.Open(path, FileMode.Open, FileAccess.Read))
                    {
                        using (var reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            var result = reader.AsDataSet();
                            DataTable table = result.Tables[0];

                            if (table.Rows.Count > 1)
                            {
                                var studentRecords = CsvLoaderService.LoadFromDataTable(table);
                                // Зберігаємо завантажені дані у спільному сховищі
                                DataStore.Students = studentRecords;

                                StatusMessage = $"Файл успішно завантажено. Знайдено {studentRecords.Count} записів.";
                            }
                            else
                            {
                                StatusMessage = "Файл прочитано, але даних не знайдено або структура неправильна.";
                            }
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    StatusMessage = $"Помилка завантаження файлу: {ex.Message}";
                }
            }
            else
            {
                StatusMessage = "Завантаження скасовано.";
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
