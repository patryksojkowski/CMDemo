using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFUI.Models;

namespace WPFUI.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private string _firstName = "Jim";
        private string _lastName;
        private BindableCollection<PersonModel> _people = new BindableCollection<PersonModel>();
        private PersonModel _selectedPerson;

        private IFirstChildViewModel _firstChild;
        private ISecondChildViewModel _secondChild;

        public ShellViewModel(IFirstChildViewModel firstChild, ISecondChildViewModel secondChild)
        {
            People.Add(new PersonModel { FirstName = "Tim", LastName = "Corey" });
            People.Add(new PersonModel { FirstName = "John", LastName = "Doe" });
            People.Add(new PersonModel { FirstName = "Anne", LastName = "Plain" });

            _firstChild = firstChild;
            _secondChild = secondChild;
        }

        public string FirstName
        {
            get {
                return _firstName;
            }
            set {
                _firstName = value;
                NotifyOfPropertyChange(() => FirstName);
                NotifyOfPropertyChange(() => FullName);
            }
        }

        public string LastName
        {
            get { 
                return _lastName;
            }
            set { 
                _lastName = value;
                NotifyOfPropertyChange(() => LastName);
                NotifyOfPropertyChange(() => FullName);
            }
        }

        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }

        public BindableCollection<PersonModel> People
        {
            get { return _people; }
            set { _people = value; }
        }

        public PersonModel SelectedPerson
        {
            get { return _selectedPerson; }
            set {
                _selectedPerson = value;
                NotifyOfPropertyChange(() => SelectedPerson);
            }
        }

        public bool CanClearText(string firstName, string lastName) => !(string.IsNullOrWhiteSpace(firstName) && string.IsNullOrWhiteSpace(lastName));

        public void ClearText(string firstName, string lastName)
        {
            FirstName = LastName = string.Empty;
        }

        public void LoadPageOne()
        {
            ActivateItem(_firstChild);
        } 
        
        public void LoadPageTwo()
        {
            ActivateItem(_secondChild);
        }
    }
}
