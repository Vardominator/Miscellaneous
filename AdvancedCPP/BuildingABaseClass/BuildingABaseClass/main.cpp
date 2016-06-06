#include <iostream>
#include <sstream>		// This library is used to convert doubles to strings, etc

using namespace std;


class Employee 
{
	private:
		string name;
		double pay;

	public:
		Employee() 
		{
			name = "";
			pay = 0;
		}
		Employee(string empName, double payRate) 
		{
			name = empName;
			pay = payRate;
		}

		string getName() {
			return name;
		}

		void setName(string newName) {
			name = newName;
		}

		double getPay() {
			return pay;
		}
		void setPay(double payRate) {
			pay = payRate;
		}
		string toString()
		{
			// sstream library used here
			stringstream stm;
			// we are going to flow double and string data to it, turn it into a string
			// and return it
			stm << name << ": " << pay;
			return stm.str();
		}

};

class Manager : public Employee 
{
	
	private:
		bool salaried;

	public:
		Manager(string name, double payRate, bool isSalaried)
			:Employee(name, payRate)
		{
			salaried = isSalaried;
		}

		bool getSalaried() 
		{
			return salaried;
		}

};

int main()
{

	//Employee testEmp("Vardo Barsegyan", 35000);
	//Employee testEmp2("Not Vardo Barsegyan", 444444);

	//cout << testEmp.toString() << endl;
	//cout << testEmp2.toString() << endl;


	Employee emp1("Mary Smith", 15.00);
	cout << "Employee name: " << emp1.getName() << endl;
	cout << "Employee pay rate: " << emp1.getPay() << endl;

	Manager emp2("Bob Brown", 1500, true);
	cout << "Employee name: " << emp2.getName() << endl;
	cout << "Pay rate: " << emp2.getPay() << endl;
	cout << "Salaried? " << emp2.getSalaried() << endl; 




	return 0;
}