// ConsoleApplication2.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>

int main()
{
	int x;
	int c1;
	int c2 = c1;
	int c3 = c2;
	int c4 = c3;
	while (c1 != 0 || c2 != 0 || c3 != 0 || c4 != 0) {
		printf("Enter a number");
		scanf_s("%d", &x);
		while (x > 0) {
			switch (x % 10) {
			case 1:
				c1++;
				break;
			case 2:
				c2++;
				break;
			case 3:
				c3++;
				break;
			case 4:
				c4++;
				break;
			}
			x = (int)x / 10;
		}
		printf(" %d\n %d\n %d\n %d\n", c1, c2, c3, c4);
	}
	return 0;
}


// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
