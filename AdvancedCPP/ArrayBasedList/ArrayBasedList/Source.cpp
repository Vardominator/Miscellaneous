#include <iostream>
#include "UnsortedType.h"

using namespace std;

// Array-based Lists


int main()
{

	UnsortedType ust;
	ust.InsertItem(5);
	ust.InsertItem(6);
	ust.InsertItem(10);
	ust.InsertItem(2);

	ust.DeleteItem(5);

	ust.Show();

}