#include <iostream>

using namespace std;

long numberOfPaths(int row, int col);

int main()
{

	cout << numberOfPaths(20, 20) << endl;

	return 0;

}

long numberOfPaths(int row, int col)
{
	if (row == 0 || col == 0)
	{
		return 1;
		cout << "finished path..." << endl;
	}
	cout << numberOfPaths(row - 1, col) + numberOfPaths(row, col - 1) << endl;
	return numberOfPaths(row - 1, col) + numberOfPaths(row, col - 1);
}