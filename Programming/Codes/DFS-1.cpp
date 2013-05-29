#include <iostream>
#include <cstdio>
#include <vector>
#include <algorithm>
using namespace std;

vector <int> v[20001];
vector <int> q;
bool used[20001];

int people, couples;
int x, y, result, counter;

int dfs(int top);
int main(void)
{
    scanf("%d %d", &people, &couples);
    for(int times = 1; times <= couples; times++)
    {
        scanf("%d %d", &x, &y);
        v[x].push_back(y);
        v[y].push_back(x);
    }

    for(int i = 1; i <= people; i++)
    {
        if(!used[i])
        {
            result ++;
            counter = 1; dfs(i);
            q.push_back(counter);
        }
    }
    sort(q.begin(), q.end());

    printf("%i\n", result);
    for(int i = 0; i < q.size(); i++)
     printf("%i ", q[i]);

    printf("\n");
    return 0;
}
int dfs(int top)
{
    used[top] = true;
    for(int i = 0; i < v[top].size(); i++)
          if(!used[v[top][i]]){counter ++; dfs(v[top][i]);}
}