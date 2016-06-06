#include <iostream>
#include <sstream>

using namespace std;

class Employee
{

// The protected keyword allows a derived class to access a parent class field
protected:
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

	// destructor is called automatically 
	~Employee()
	{
		
	}

	string getName()
	{
		return name;
	}

	void setName(string newName)
	{
		name = newName;
	}

	double getPay()
	{
		return pay;
	}

	void setPay(double payRate)
	{
		pay = payRate;
	}

	// virtual makes the grossPay funciton polymorphic
	//		the compiler will not look at the grossPay function and see that it is virtual.
	//		Based on this it will run the grossPay of the object's class rather than it's 
	//		variable. 
	virtual double grossPay(int hours)
	{
		return pay * hours;
	}


	string toString() 
	{
		stringstream stm;
		stm << name << ": " << pay;
		return stm.str();
	}

};


class Manager : public Employee
{

private:
	bool salaried;

public:
	// default constructor
	Manager() : salaried(true) { }


	Manager(string name, double payRate, bool isSalaried)
		: Employee(name, payRate)
	{
		salaried = isSalaried;
	}

	// called automatically
	~Manager()
	{
		// free allocated resources
	}


	bool getSalaried()
	{
		return salaried;
	}

	virtual double grossPay(int hours)
	{
		if (salaried)
		{
			return pay;
		}
		else
		{
			return pay * hours;
		}
	}

	string toString()
	{
		stringstream stm;
		string salary;
		if (salaried)
		{
			salary = "Salaried";
		}
		else
		{
			salary = "Hourly";
		}

		stm << name << ": " << pay << ": " << salary << endl;

		return stm.str();

	}

};


int main() {

	// Base Class Pointers
	Employee testEmp("Jones", 25.00);
	Manager testMgr("Smith", 1200, true);

	// Create pointers and let the compiler figure out which function to call
	Employee *empPtr;  // Create a ptr to an employee address
	empPtr = &testEmp; // Assign it the address of testEmp
	cout << "Name: " << empPtr->getName() << endl;
	cout << "Pay: " << empPtr->grossPay(40) << endl;

	// Try with manager object
	empPtr = &testMgr;
	cout << "Name: " << empPtr->getName() << endl;
	cout << "Pay : " << empPtr->grossPay(40) << endl;

	// The compiler is not looking at the type of object -- in this case Manager --
	//		but rather the data type of the pointer variable itself to decide what to do.

	return 0;
}