#include <iostream>
#include <vector>
#include <algorithm>
using namespace std;

int main()
{
    int N, start, end;
    cin >> N >> start >> end;

    vector<int> array;
    int variable;

    for (int i = 0; i < N; i++)
    {
        cin >> variable;
        array.push_back(variable);
    }

    sort(array.begin() + start, array.begin() + end + 1);

    for (int i = 0; i < N; i++)
        cout << array.at(i) << " ";
}