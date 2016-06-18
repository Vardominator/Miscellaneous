#include <iostream>
#include <string>

using namespace std;

// Determine data type at runtime


template <typename T>	// Create generic type variable

void display(T arr[], int size)
{
	for (int i = 0; i < size; i++)
	{
		cout << arr[i] << " ";
	}
}

// Returning a generic type
template <typename T>

T max(T arg1, T arg2)
{
	if(arg1 > arg2)
	{
		return arg1;
	}
	else
	{
		return arg2;
	}
}


int main()
{
	//const int size = 10;
	//int numbers[size];
	//for (int i = 0; i < size; i++)
	//{
	//	numbers[i] = i + 1;
	//}

	//display(numbers, size);

	//cout << endl;

	//string names[] = { "a", "b", "c", "d", "e", "f","g","h","i", "j"};

	//display(names, 10);

	//cout << endl;
	int a = 5;
	int b = 24;

	cout << max(a, b) << endl;

	return 0;
}
