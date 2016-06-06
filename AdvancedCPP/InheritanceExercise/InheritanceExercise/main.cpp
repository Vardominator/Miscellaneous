#include <iostream>

using namespace std;


class Account
{
protected:
	double balance;

public:
	Account(double bal)
	{
		if (bal > 0)
		{
			balance = bal;
		}
		
		else
		{

		}
	}

	void credit(double amount)
	{
		balance += amount;
	}

	void debit(double amount)
	{
		if (balance < amount)
		{
			balance = balance - amount;
		}
		else
		{
			cout << "Insufficient funds" << endl;
		}
		
	}

	double getBalance()
	{
		return balance;
	}

};


class CheckingAccount : public Account
{
private:
	double fee;

public:
	CheckingAccount(double balance, double f)
		: Account(balance)
	{
		fee = f;
	}
	
	// Override debit
	void debit(double amount)
	{
		if (balance > amount)
		{
			balance = balance - amount - fee;
		}
		else
		{
			cout << "Inusfficient funds." << endl;
		}
	}

};


int main()
{
	
	CheckingAccount myacct(500, 0.5);
	myacct.credit(100);
	cout << myacct.getBalance() << endl;
	myacct.debit(50);
	cout << myacct.getBalance();

	return 0;

}