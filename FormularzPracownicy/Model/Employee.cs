using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormularzPracownicy.Model
{
    public enum Position {Designer, Engineer, JuniorProgrammer, SeniorProgrammer, Tester};
    public enum TypeOfContract {FullContract, TimeContract, MandateContract};

    public class Employee
    {
        private String _name;
        private String _surname;
        private DateTime _birthdate;
        private decimal _salary;
        private Position _position;
        private TypeOfContract _contract;

        public Employee() { }

        public Employee(string name, string surname, DateTime birthdate, decimal salary, Position position, TypeOfContract contract)
        {
            _name = name;
            _surname = surname;
            _birthdate = birthdate;
            _salary = salary;
            _position = position;
            _contract = contract;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Surame
        {
            get { return _surname; }
            set { _surname = value; }
        }

        public DateTime Birthdate
        {
            get { return _birthdate; }
            set { _birthdate = value; }
        }

        public decimal Salary
        {
            get { return _salary; }
            set  { _salary = value; }
        }

        public Position Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public TypeOfContract Contract
        {
            get { return _contract; }
            set { _contract = value; }
        }

        public override string ToString()
        {
            string position = "";
            string type_of_contract = "";

            if (_position == Position.Designer)
            {
                position = "Projektant";
            }
            if (_position == Position.Engineer)
            {
                position = "Inżynier";
            }
            if (_position == Position.JuniorProgrammer)
            {
                position = "Junior Programista";
            }
            if (_position == Position.SeniorProgrammer)
            {
                position = "Seinor Programista";
            }
            if (_position == Position.Tester)
            {
                position = "Tester";
            }

            if (_contract == TypeOfContract.FullContract)
            {
                type_of_contract = "Umowa n. c. nieokreślony";
            }
            if (_contract == TypeOfContract.TimeContract)
            {
                type_of_contract = "Umowa n. c. określony";
            }
            if (_contract == TypeOfContract.MandateContract)
            {
                type_of_contract = "Umowa zlecenie";
            }

            return $"[ {_name} {_surname} ][ Data urodzenia: {_birthdate.ToShortDateString().ToString()} ][ "  +
                $"Stanowisko: {position} ][ Rodzaj umowy: {type_of_contract} ][ Pensja: {_salary} PLN ]";
        }
    }
}
