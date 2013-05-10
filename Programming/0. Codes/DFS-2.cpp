#include <iostream>
#include <vector>
#include <algorithm>
using namespace std;
 
vector<int>v[20000],res;
int num=0,k=0;
int used[20000]={0};
 
void dfs(int cur)
{
    used[cur]=1;
    k++;
    if(v[cur].empty()) return;
    for(int i=0;i<v[cur].size();i++)
    {
        if(!used[v[cur][i]])
            dfs(v[cur][i]);
    }
    return;
 
}
 
int main()
{
    int n,m,x,y;
    cin>>n>>m;
    for(int i=0;i<m;i++)
    {
        cin>>x>>y;
        v[x-1].push_back(y-1);
        v[y-1].push_back(x-1);
    }
    for(int i=0;i<n;i++)
    {
        //cout<<used[3]<<endl;
        if(!used[i])
        {
        dfs(i);
        res.push_back(k);
        num++;
        k=0;
        }
    }
    cout<<num<<endl;
    sort(res.begin(),res.end());
    for(int i=0;i<num;i++)
    {
        cout<<res[i]<<' ';
    }
    cout<<endl;
}