using FormularzPracownicy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FormularzPracownicy.Presenter
{
    class MainPresenter
    {
        private View.Form1 _view;
        private Model.MainModel _model;
        private Model.Employee tmpEmployee;


        public MainPresenter(View.Form1 view, Model.MainModel model)
        {
            _view = view;
            _model = model;

            tmpEmployee = new Model.Employee("","",DateTime.Today,3500,Position.JuniorProgrammer,TypeOfContract.FullContract);

            _view.ChangeName += _view_ChangeName;
            _view.ChangeSurname += _view_ChangeSurname;
            _view.ChangeDate += _view_ChangeDate;
            _view.ChangeSalary += _view_ChangeSalary;
            _view.ChangePosition += _view_ChangePosition;
            _view.ChangeContract += _view_ChangeContract;
            _view.AddPerson += _view_AddPerson;

            _view.SerializeList += _view_SerializeList;
            _view.DeserializeList += _view_DeserializeList;

            _view.OnEmployeeSelect += _view_OnEmployeeSelect;
        }

        private void _view_ChangeName(string name)
        {
            tmpEmployee.Name = name;
        }

        private void _view_ChangeSurname(string surname)
        {
            tmpEmployee.Surame = surname;
        }

        private void _view_ChangeDate(DateTime date)
        {
            tmpEmployee.Birthdate = date;
        }

        private void _view_ChangeSalary(decimal salary)
        {
            tmpEmployee.Salary = salary;
        }

        private void _view_ChangePosition(int position_id)
        {
            if (position_id == 0)
            {
                tmpEmployee.Position = Model.Position.Designer;
            }

            else if (position_id == 1)
            {
                tmpEmployee.Position = Model.Position.Engineer;
            }

            else if (position_id == 2)
            {
                tmpEmployee.Position = Model.Position.JuniorProgrammer;
            }

            else if (position_id == 3)
            {
                tmpEmployee.Position = Model.Position.SeniorProgrammer;
            }

            else if (position_id == 4)
            {
                tmpEmployee.Position = Model.Position.Tester;
            }
        }

        private void _view_ChangeContract(int contract_id)
        {
            if (contract_id == 0)
            {
                tmpEmployee.Contract = Model.TypeOfContract.FullContract;
            }

            else if (contract_id == 1)
            {
                tmpEmployee.Contract = Model.TypeOfContract.TimeContract;
            }

            else if (contract_id == 2)
            {
                tmpEmployee.Contract = Model.TypeOfContract.MandateContract;
            }
        }

        private void _view_AddPerson()
        {
            _model.AddEmployee(tmpEmployee);
            tmpEmployee = new Model.Employee("", "", DateTime.Today, 3500, Position.JuniorProgrammer, TypeOfContract.FullContract);
            updateView();
        }

        private void updateView()
        {
            _view.DisplayEmployees.Clear();
            foreach (Employee e in _model.getList())
            {
                _view.DisplayEmployees.Add(e.ToString());
            }
        }

        private void _view_SerializeList()
        {
            Console.WriteLine("Serializacja");
            _model.SerializeList(_model.getList());
        }

        private void _view_DeserializeList()
        {
            Console.WriteLine("Deserializacja");
            _model.DeserializeList();
            updateView();
        }

        private void _view_OnEmployeeSelect(int index)
        {
            tmpEmployee = _model.getList()[index];

            int position = 0;

            if (tmpEmployee.Position == Position.Designer) { position = 0; }
            else if (tmpEmployee.Position == Position.Engineer) { position = 1; }
            else if (tmpEmployee.Position == Position.JuniorProgrammer) { position = 2; }
            else if (tmpEmployee.Position == Position.SeniorProgrammer) { position = 3; }
            else if (tmpEmployee.Position == Position.Tester) { position = 4; }

            bool r1 = true;
            bool r2 = false;
            bool r3 = false;

            if (tmpEmployee.Contract == TypeOfContract.FullContract) 
            {
                r1 = true;
                r2 = false;
                r3 = false;
            }

            else if (tmpEmployee.Contract == TypeOfContract.TimeContract)
            {
                r1 = false;
                r2 = true;
                r3 = false;
            }

            else if (tmpEmployee.Contract == TypeOfContract.MandateContract) 
            {
                r1 = false;
                r2 = false;
                r3 = true;
            }

            _view.setFormValues(tmpEmployee.Name, tmpEmployee.Surame, tmpEmployee.Birthdate, tmpEmployee.Salary, position, r1, r2, r3);
        }
    }
}
