using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using vstupna.Commands;
using vstupna.Models;
using vstupna.Services;

namespace vstupna.ViewModels
{
    public class DocumentEditorViewModel : INotifyPropertyChanged
    {
        private StudentRecord? _templateData;
        private string? _templateFolder;
        private string? _outputFolder;
        private string? _selectedTemplatePath;
        private ObservableCollection<string> _templateFiles = new ObservableCollection<string>();

        public StudentRecord? TemplateData
        {
            get => _templateData;
            set { _templateData = value; OnPropertyChanged(); }
        }

        public string? TemplateFolder
        {
            get => DataStore.TemplateFolder;
            set
            {
                if (DataStore.TemplateFolder != value)
                {
                    DataStore.TemplateFolder = value ?? "";
                    OnPropertyChanged();
                    LoadTemplateFiles();
                }
            }
        }

        public string? OutputFolder
        {
            get => _outputFolder;
            set
            {
                _outputFolder = value;
                DataStore.OutputFolder = value ?? "";
                OnPropertyChanged();
            }
        }

        public string? SelectedTemplatePath
        {
            get => _selectedTemplatePath;
            set
            {
                _selectedTemplatePath = value;
                DataStore.SelectedTemplatePath = value ?? "";
                OnPropertyChanged();
            }
        }

        public ObservableCollection<string> TemplateFiles
        {
            get => _templateFiles;
            set { _templateFiles = value; OnPropertyChanged(); }
        }

        public ICommand PreviewCommand { get; }
        public ICommand GenerateDocumentCommand { get; }
        public ICommand SelectTemplateFolderCommand { get; }
        public ICommand SelectOutputFolderCommand { get; }

        public DocumentEditorViewModel()
        {
            // Завантаження даних обраного студента із спільного сховища
            TemplateData = DataStore.SelectedStudent;

            PreviewCommand = new RelayCommand(_ => PreviewDocument());
            GenerateDocumentCommand = new RelayCommand(_ => GenerateDocument());
            SelectTemplateFolderCommand = new RelayCommand(_ => SelectTemplateFolder());
            SelectOutputFolderCommand = new RelayCommand(_ => SelectOutputFolder());

            // Якщо вже встановлено шлях до папки шаблонів, завантажуємо список файлів
            if (!string.IsNullOrWhiteSpace(TemplateFolder) && Directory.Exists(TemplateFolder))
            {
                LoadTemplateFiles();
            }
        }


        private void PreviewDocument()
        {
            System.Windows.MessageBox.Show("Попередній перегляд документа");
        }

        private void GenerateDocument()
        {
            if (TemplateData != null)
            {
                DocumentGeneratorService.GenerateDocumentFromStudent(TemplateData);
            }
            else
            {
                System.Windows.MessageBox.Show("Обраний студент не встановлено.");
            }
        }

        private void SelectTemplateFolder()
        {
            var dialog = new OpenFolderDialog();
            {
                dialog.Title = "Оберіть папку з шаблонами";
                if (dialog.ShowDialog() == true)
                {
                    TemplateFolder = dialog.FolderName;
                }
            }
        }

        private void SelectOutputFolder()
        {
            var dialog = new OpenFolderDialog();
            {
                dialog.Title = "Оберіть папку для збереження згенерованих документів";
                if (dialog.ShowDialog() == true)
                {
                    OutputFolder = dialog.FolderName;
                }
            }
        }

        private void LoadTemplateFiles()
        {
            TemplateFiles.Clear();
            if (!string.IsNullOrWhiteSpace(TemplateFolder) && Directory.Exists(TemplateFolder))
            {
                var files = Directory.GetFiles(TemplateFolder, "*.docx");
                foreach (var file in files)
                {
                    TemplateFiles.Add(file);
                }
            }
            if (TemplateFiles.Count > 0)
            {
                SelectedTemplatePath = TemplateFiles[0];
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
