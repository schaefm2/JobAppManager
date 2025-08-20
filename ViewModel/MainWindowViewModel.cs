using System.Collections.ObjectModel;
using JobAppManager.Model;

namespace JobAppManager.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<Job> Jobs { get; set; }

        public RelayCommand AddCommand => new RelayCommand(execute => AddJob(), canExecute => true);
        public RelayCommand SaveCommand => new RelayCommand(execute => SaveJob(), canExecute => true);
        public RelayCommand DelCommand => new RelayCommand(execute => DelJob(), canExecute => selectedJob == currentJob);

        public bool IsAdding => SelectedJob == null;

        public MainWindowViewModel()
        {
            Jobs = new ObservableCollection<Job>();
            selectedJob = new Job();
            newJob = new Job();
            currentJob = newJob;
        }

        private Job currentJob;

        public Job CurrentJob
        {
            get { return currentJob; }
            set { currentJob = value;
                onPropertyChanged();
            }
        }


        private Job selectedJob;

        public Job SelectedJob
        {
            get { return selectedJob; }
            set { selectedJob = value;
                onPropertyChanged();
                AddCommand.RaiseCanExecuteChanged();
                SaveCommand.RaiseCanExecuteChanged();
                DelCommand.RaiseCanExecuteChanged();
                CurrentJob = selectedJob ?? new Job();
            }
        }

        private Job newJob;

        private void SaveJob()
        {
            Jobs.Add(new Job
            {
                Name = currentJob.Name,
                Description = currentJob.Description,
                Company = currentJob.Company,
                Link = currentJob.Link,
                Status = currentJob.Status
            });
            if (selectedJob == currentJob)
            {
                Jobs.Remove(selectedJob);
            }
            selectedJob = null;


        }
        private void AddJob()
        {
            SelectedJob = null;
        }

        private void DelJob()
        {
            Jobs.Remove(selectedJob);
        }

    }
}
